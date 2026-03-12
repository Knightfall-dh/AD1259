using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.CharacterCreationContent;
using TaleWorlds.Localization;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CharacterCreationManager), "AddNewMenu")]
	public class FixYouthMenuTextsPatch
	{
		[HarmonyPrefix]
		public static void Prefix(NarrativeMenu menu)
		{
			bool flag = ((menu != null) ? menu.StringId : null) == "narrative_youth_menu";
			if (flag)
			{
				bool flag2 = menu.Description != null;
				if (flag2)
				{
					string text = menu.Description.ToString();
					bool flag3 = text.Contains("Calradia");
					if (flag3)
					{
						text = text.Replace("growing up in Calradia,", "growing up,");
						text = text.Replace("In wartorn Calradia,", "In wartorn lands,");
						TextObject newDescription = new TextObject(text, null);
						FieldInfo descriptionField = typeof(NarrativeMenu).GetField("Description", BindingFlags.Instance | BindingFlags.Public);
						descriptionField.SetValue(menu, newDescription);
					}
				}
			}
		}
	}
}
