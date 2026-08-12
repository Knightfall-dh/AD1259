using HarmonyLib;
using SandBox.ViewModelCollection.SaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem.Extensions;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.SaveSystem;

namespace AD1259.Patches
{
    // ────────────────────────────────────────────────
    // 1. Force synchronous InitializeAsync
    // ────────────────────────────────────────────────
    [HarmonyPatch(typeof(SaveLoadVM), nameof(SaveLoadVM.InitializeAsync))]
    public static class SaveLoadVM_InitializeAsync_Patch
    {
        private static readonly FieldInfo IsFinalizedField =
            AccessTools.Field(typeof(SaveLoadVM), "_isFinalized");
        private static readonly FieldInfo CategorizedSaveGroupNameField =
            AccessTools.Field(typeof(SaveLoadVM), "_categorizedSaveGroupName");
        private static readonly FieldInfo UncategorizedSaveGroupNameField =
            AccessTools.Field(typeof(SaveLoadVM), "_uncategorizedSaveGroupName");

        private static readonly MethodInfo GetMostRecentSaveInGroupMethod =
            AccessTools.Method(typeof(SaveLoadVM), "GetMostRecentSaveInGroup");
        private static readonly MethodInfo OnDeleteSavedGameMethod =
            AccessTools.Method(typeof(SaveLoadVM), "OnDeleteSavedGame");
        private static readonly MethodInfo OnSaveSelectionMethod =
            AccessTools.Method(typeof(SaveLoadVM), "OnSaveSelection");
        private static readonly MethodInfo OnCancelLoadSaveMethod =
            AccessTools.Method(typeof(SaveLoadVM), "OnCancelLoadSave");
        private static readonly MethodInfo ExecuteDoneMethod =
            AccessTools.Method(typeof(SaveLoadVM), "ExecuteDone");
        private static readonly MethodInfo GetFirstAvailableSavedGameMethod =
            AccessTools.Method(typeof(SaveLoadVM), "GetFirstAvailableSavedGame");
        private static readonly MethodInfo RefreshCanCreateNewSaveMethod =
            AccessTools.Method(typeof(SaveLoadVM), "RefreshCanCreateNewSave");
        private static readonly MethodInfo RefreshCanSearchMethod =
            AccessTools.Method(typeof(SaveLoadVM), "RefreshCanSearch");

        public static bool Prefix(SaveLoadVM __instance, ref Task __result)
        {
            try
            {
                RunSynchronousInitialize(__instance);
            }
            catch (Exception ex)
            {
                Debug.Print($"[SaveLoadVM_InitializeAsync_Patch] {ex}", 0, Debug.DebugColor.Red);
            }

            __result = Task.CompletedTask;
            return false; // skip original async method
        }

        private static void RunSynchronousInitialize(SaveLoadVM vm)
        {
            if (vm.IsLoadingSaves) return;

            vm.IsBusyWithAnAction = true;
            vm.IsLoadingSaves = true;

            try
            {
                if (IsFinalizedField != null && (bool)IsFinalizedField.GetValue(vm))
                    return;

                vm.SaveGroups.Clear();

                SaveGameFileInfo[] saveFiles = MBSaveLoad.GetSaveFiles();
                var corrupted = saveFiles.Where(s => s.IsCorrupted).ToList();
                var validGroups = saveFiles
                    .Where(s => !s.IsCorrupted)
                    .GroupBy(s => s.MetaData.GetUniqueGameId())
                    .OrderByDescending(g => (DateTime)GetMostRecentSaveInGroupMethod.Invoke(vm, new object[] { g }));

                var categorizedName = (TextObject)CategorizedSaveGroupNameField.GetValue(vm);
                var uncategorizedName = (TextObject)UncategorizedSaveGroupNameField.GetValue(vm);

                int campaignIndex = 0;
                foreach (var group in validGroups)
                {
                    var groupVm = new SavedGameGroupVM();
                    if (string.IsNullOrWhiteSpace(group.Key))
                    {
                        groupVm.IdentifierID = uncategorizedName.ToString();
                    }
                    else
                    {
                        campaignIndex++;
                        categorizedName.SetTextVariable("ID", campaignIndex);
                        groupVm.IdentifierID = categorizedName.ToString();
                    }

                    foreach (var save in group.OrderByDescending(s => s.MetaData.GetCreationTime()))
                    {
                        bool ironman = save.MetaData.GetIronmanMode();
                        groupVm.SavedGamesList.Add(CreateSavedGameVM(vm, save, false, ironman));
                    }
                    vm.SaveGroups.Add(groupVm);
                }

                if (corrupted.Any())
                {
                    var corruptedGroup = new SavedGameGroupVM
                    {
                        IdentifierID = new TextObject("{=o9PIe7am}Corrupted").ToString()
                    };
                    foreach (var save in corrupted)
                        corruptedGroup.SavedGamesList.Add(CreateSavedGameVM(vm, save, true, false));
                    vm.SaveGroups.Add(corruptedGroup);
                }

                RefreshCanCreateNewSaveMethod?.Invoke(vm, null);
                RefreshCanSearchMethod?.Invoke(vm, null);

                var first = (SavedGameVM)GetFirstAvailableSavedGameMethod?.Invoke(vm, null);
                if (first != null)
                    OnSaveSelectionMethod?.Invoke(vm, new object[] { first });

                vm.RefreshValues();
            }
            finally
            {
                vm.IsBusyWithAnAction = false;
                vm.IsLoadingSaves = false;
            }
        }

        private static SavedGameVM CreateSavedGameVM(SaveLoadVM vm, SaveGameFileInfo save, bool isCorrupted, bool isIronman)
        {
            Action<SavedGameVM> onDelete = s => OnDeleteSavedGameMethod.Invoke(vm, new object[] { s });
            Action<SavedGameVM> onSelection = s => OnSaveSelectionMethod.Invoke(vm, new object[] { s });
            Action onCancel = () => OnCancelLoadSaveMethod.Invoke(vm, null);
            Action onDone = () => ExecuteDoneMethod.Invoke(vm, null);

            return new SavedGameVM(save, vm.IsSaving, onDelete, onSelection, onCancel, onDone, isCorrupted, isIronman);
        }
    }

    // ────────────────────────────────────────────────
    // 2. Restore visual codes after construction
    // ────────────────────────────────────────────────
    [HarmonyPatch(typeof(SavedGameVM))]
    [HarmonyPatch(MethodType.Constructor,
        typeof(SaveGameFileInfo), typeof(bool),
        typeof(Action<SavedGameVM>), typeof(Action<SavedGameVM>),
        typeof(Action), typeof(Action), typeof(bool), typeof(bool))]
    public static class SavedGameVM_Constructor_Patch
    {
        public static void Postfix(SavedGameVM __instance, SaveGameFileInfo save)
        {
            try
            {
                if (string.IsNullOrEmpty(__instance.MainHeroVisualCode))
                {
                    string code = save.MetaData.GetCharacterVisualCode();
                    if (!string.IsNullOrEmpty(code))
                        __instance.MainHeroVisualCode = code;
                }

                if (string.IsNullOrEmpty(__instance.BannerTextCode))
                {
                    string banner = save.MetaData.GetClanBannerCode();
                    if (!string.IsNullOrEmpty(banner))
                        __instance.BannerTextCode = banner;
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"[SavedGameVM_Constructor_Patch] {ex.Message}", 0, Debug.DebugColor.Red);
            }
        }
    }
}