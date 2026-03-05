using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem.Encyclopedia;
using TaleWorlds.CampaignSystem.Encyclopedia.Pages;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(DefaultEncyclopediaUnitPage), "InitializeFilterItems")]
	public class DefaultEncyclopediaUnitPage_InitializeFilterItems_Patch
	{
		public static void Postfix(ref IEnumerable<EncyclopediaFilterGroup> __result)
		{
			List<EncyclopediaFilterGroup> list = new List<EncyclopediaFilterGroup>(__result);
			foreach (EncyclopediaFilterGroup group in list)
			{
				bool flag = group.Name.Value == "{=PUjDWe5j}Culture";
				if (flag)
				{
					group.Filters.RemoveAll((EncyclopediaFilterItem item) => item.Name.Value == "{=aseraifaction}Aserai" || item.Name.Value == "{=0B27RrYJ}Battania" || item.Name.Value == "{=IHhWB1aa}Darshi" || item.Name.Value == "{=empirefaction}Empire" || item.Name.Value == "{=sZLd6VHi}Khuzait" || item.Name.Value == "{=sYFaoW7G}Nord" || item.Name.Value == "{=PjO7oY16}Sturgia" || item.Name.Value == "{=bHh03ob0}Vakken" || item.Name.Value == "{=FjwRsf1C}Vlandia" || item.Name.Value == "{=H9MSGaRu}Corsairs");
				}
				bool flag2 = group.Name.Value == "{=GopVkA1q}Outlaw";
				if (flag2)
				{
					group.Filters.RemoveAll((EncyclopediaFilterItem item) => item.Name.Value == "{=*}Corsairs");
				}
			}
			__result = list;
		}
	}
}
