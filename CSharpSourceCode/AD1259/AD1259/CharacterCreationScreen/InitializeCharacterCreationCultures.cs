using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Core;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationCampaignBehavior), "InitializeCharacterCreationCultures")]
	public class AddNewCulturePatch
	{
		private static bool Prefix(CharacterCreationManager characterCreationManager)
		{
			foreach (CultureObject cultureObject in Game.Current.ObjectManager.GetObjectTypeList<CultureObject>())
			{
				bool flag = CustomCultureDefinitions.AllCultureIds.Contains(cultureObject.StringId);
				if (flag)
				{
					characterCreationManager.CharacterCreationContent.AddCharacterCreationCulture(cultureObject, 1, 10);
				}
			}
			return false;
		}
	}
}
