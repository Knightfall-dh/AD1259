using AD1259.Models;
using HarmonyLib;
using SandBox;
using SandBox.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.AdvancedStartOptions;
using TaleWorlds.CampaignSystem.ViewModelCollection.Encyclopedia.Pages;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.MountAndBlade.View;
using TaleWorlds.ScreenSystem;

namespace AD1259
{
    public class SubModule : MBSubModuleBase
    {
        public static bool RBMEnabled = false;

        // Harmony instance used by both main mod and religion mod
        internal static readonly Harmony _harmony = new Harmony("AnnoDomini");

        private bool _heroPagePatched = false;

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

            // Patch everything that has [HarmonyPatch] attributes (both main mod + religion safe patches)
            _harmony.PatchAll(Assembly.GetExecutingAssembly());

            SubModule.InitGameMenu();
        }

        protected override void InitializeGameStarter(Game game, IGameStarter starterObject)
        {
            base.InitializeGameStarter(game, starterObject);

            if (starterObject is CampaignGameStarter campaignStarter)
            {
                campaignStarter.AddModel(new AD1259CampaignTimeModel());

                // Religion behavior will be added in OnGameStart instead (safer)
            }
        }

        public override void OnAfterGameInitializationFinished(Game game, object starterObject)
        {
            base.OnAfterGameInitializationFinished(game, starterObject);

            // Previously this block attempted to apply a postfix from the removed religion
            // component. It referenced `postfixMethod`, which no longer exists and caused
            // compile errors. No manual patching is required now, so the code was removed.
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
            _harmony?.UnpatchAll("AnnoDomini");
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();

            AccessTools.Field(typeof(TaleWorlds.MountAndBlade.Module), "_splashScreenPlayed")
                .SetValue(TaleWorlds.MountAndBlade.Module.CurrentModule, true);

            InformationManager.DisplayMessage(new InformationMessage(
                "Anno Domini 1259 loaded successfully", 
                new Color(115f, 15f, 151f, 1f)));
        }

        public static void InitGameMenu()
        {
            TaleWorlds.MountAndBlade.Module.CurrentModule.ClearStateOptions();

            // Saved Games
            TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
                new InitialStateOption("CampaignResumeGame",
                    new TextObject("{=6mN03uTP}Saved Games"),
                    0,
                    () => ScreenManager.PushScreen(SandBoxViewCreator.CreateSaveLoadScreen(false)),
                    () => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.")),
                    null, null));

           // New Game
TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
    new InitialStateOption("NewGame",
        new TextObject("{=EE000017}New Game"),
        3,
        () => MBGameManager.StartNewGame(
            new SandBoxGameManager(() => new Campaign(CampaignGameMode.Campaign, new AdvancedStartOptionsData()))
        ),
        () => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, 
               new TextObject("{=V8BXjyYq}Disabled during installation.")),
        null, null));

            // RBM Detection & Configuration
            foreach (string modulesName in Utilities.GetModulesNames())
            {
                if (modulesName == "RBM")
                    SubModule.RBMEnabled = true;
                else
                    InformationManager.DisplayMessage(new InformationMessage(
                        "Blasphemy! You shall be excommunicated by the Holy See for not having RBM enabled!",
                        new Color(115f, 15f, 151f, 1f)));
            }

            if (SubModule.RBMEnabled)
            {
                Assembly assembly = AppDomain.CurrentDomain.GetAssemblies()
                    .FirstOrDefault(a => a.GetName().Name == "RBMConfig");

                Type type = assembly?.GetType("RBMConfig.RBMConfig");
                MethodInfo loadMethod = type?.GetMethod("LoadConfig", BindingFlags.Static | BindingFlags.Public);

                loadMethod?.Invoke(null, null);

                Type screenType = assembly?.GetType("RBMConfig.RBMConfigScreen");
                if (screenType != null)
                {
                    TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
                        new InitialStateOption("RBMConfiguration",
                            new TextObject("{=EE000377}RBM Configuration"),
                            9990,
                            () => ScreenManager.PushScreen(Activator.CreateInstance(screenType) as ScreenBase),
                            () => (false, TextObject.GetEmpty()),
                            null, null));
                }
            }

            // Options, Credits, Exit
            TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
                new InitialStateOption("Options",
                    new TextObject("{=NqarFr4P}Options"),
                    9998,
                    () => ScreenManager.PushScreen(ViewCreator.CreateOptionsScreen(true)),
                    () => (false, TextObject.GetEmpty()),
                    null, null));

            TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
                new InitialStateOption("Credits",
                    new TextObject("{=ODQmOrIw}Credits"),
                    9999,
                    () => ScreenManager.PushScreen(ViewCreator.CreateCreditsScreen()),
                    () => (false, TextObject.GetEmpty()),
                    null, null));

            TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(
                new InitialStateOption("Exit",
                    new TextObject("{=YbpzLHzk}Exit Game"),
                    10000,
                    () => MBInitialScreenBase.DoExitButtonAction(),
                    () => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.")),
                    null, null));
        }
    }
}