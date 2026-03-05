using HarmonyLib;
using SandBox;
using SandBox.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TaleWorlds.CampaignSystem;
using AD1259.Models;
using TaleWorlds.Engine;
using TaleWorlds.Core;
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
    internal static readonly Harmony _harmony = new Harmony("AnnoDomini");

    protected override void OnSubModuleLoad()
    {
      base.OnSubModuleLoad();
      SubModule._harmony.PatchAll(Assembly.GetExecutingAssembly());
      SubModule.InitGameMenu();
    }

    protected override void InitializeGameStarter(Game game, IGameStarter starterObject)
    {
      base.InitializeGameStarter(game, starterObject);
      if (starterObject is CampaignGameStarter campaignStarter)
      {
        campaignStarter.AddModel(new AD1259CampaignTimeModel());
      }
    }

    protected override void OnSubModuleUnloaded() => base.OnSubModuleUnloaded();

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      base.OnBeforeInitialModuleScreenSetAsRoot();
      AccessTools.Field(typeof (TaleWorlds.MountAndBlade.Module), "_splashScreenPlayed").SetValue((object) TaleWorlds.MountAndBlade.Module.CurrentModule, (object) true);
      InformationManager.DisplayMessage(new InformationMessage("Anno Domini 1259 loaded successfully", new Color(115f, 15f, 151f, 1f)));
    }

    public static void InitGameMenu()
    {
      TaleWorlds.MountAndBlade.Module.CurrentModule.ClearStateOptions();
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("CampaignResumeGame", new TextObject("{=6mN03uTP}Saved Games", (Dictionary<string, object>) null), 0, (Action) (() => ScreenManager.PushScreen(SandBoxViewCreator.CreateSaveLoadScreen(false))), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.", (Dictionary<string, object>) null))), (TextObject) null, (Func<bool>) null));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("NewGame", new TextObject("{=EE000017}New Game", (Dictionary<string, object>) null), 3, (Action) (() => MBGameManager.StartNewGame((MBGameManager) new SandBoxGameManager((SandBoxGameManager.CampaignCreatorDelegate) (() => new Campaign((CampaignGameMode) 1))))), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.", (Dictionary<string, object>) null))), (TextObject) null, (Func<bool>) null));
      foreach (string modulesName in Utilities.GetModulesNames())
      {
        if (modulesName == "RBM")
          SubModule.RBMEnabled = true;
        else
          InformationManager.DisplayMessage(new InformationMessage("Blasphemy! You shall be excommunicated by the Holy See for not having RBM enabled!", new Color(115f, 15f, 151f, 1f)));
      }
      if (SubModule.RBMEnabled)
      {
        Assembly assembly = ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).FirstOrDefault<Assembly>((Func<Assembly, bool>) (a => a.GetName().Name == "RBMConfig"));
        Type type = assembly != (Assembly) null ? assembly.GetType("RBMConfig.RBMConfig") : (Type) null;
        MethodInfo method = type != (Type) null ? type.GetMethod("LoadConfig", BindingFlags.Static | BindingFlags.Public) : (MethodInfo) null;
        if (method != (MethodInfo) null)
          method.Invoke((object) null, (object[]) null);
        ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).FirstOrDefault<Assembly>((Func<Assembly, bool>) (a => a.GetName().Name == "RBMConfig"));
        Type screenType = assembly != (Assembly) null ? assembly.GetType("RBMConfig.RBMConfigScreen") : (Type) null;
        if (screenType != (Type) null)
          TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("RBMConfiguration", new TextObject("{=EE000377}RBM Configuration", (Dictionary<string, object>) null), 9990, (Action) (() => ScreenManager.PushScreen(Activator.CreateInstance(screenType) as ScreenBase)), (Func<(bool, TextObject)>) (() => (false, TextObject.GetEmpty())), (TextObject) null, (Func<bool>) null));
      }
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Options", new TextObject("{=NqarFr4P}Options", (Dictionary<string, object>) null), 9998, (Action) (() => ScreenManager.PushScreen(ViewCreator.CreateOptionsScreen(true))), (Func<(bool, TextObject)>) (() => (false, TextObject.GetEmpty())), (TextObject) null, (Func<bool>) null));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Credits", new TextObject("{=ODQmOrIw}Credits", (Dictionary<string, object>) null), 9999, (Action) (() => ScreenManager.PushScreen(ViewCreator.CreateCreditsScreen())), (Func<(bool, TextObject)>) (() => (false, TextObject.GetEmpty())), (TextObject) null, (Func<bool>) null));
      TaleWorlds.MountAndBlade.Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Exit", new TextObject("{=YbpzLHzk}Exit Game", (Dictionary<string, object>) null), 10000, (Action) (() => MBInitialScreenBase.DoExitButtonAction()), (Func<(bool, TextObject)>) (() => (TaleWorlds.MountAndBlade.Module.CurrentModule.IsOnlyCoreContentEnabled, new TextObject("{=V8BXjyYq}Disabled during installation.", (Dictionary<string, object>) null))), (TextObject) null, (Func<bool>) null));
    }
  }
}
