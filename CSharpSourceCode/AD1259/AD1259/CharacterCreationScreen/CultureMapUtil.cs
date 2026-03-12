using System;
using System.Runtime.CompilerServices;

namespace AD1259.Patches
{
	public static class CultureMapUtil
	{
		public static bool TryGetBaseCulture(string cultureId, out string baseCulture)
		{
			bool flag = CustomCultureDefinitions.AseraiCultureIds.Contains(cultureId);
			bool result;
			if (flag)
			{
				baseCulture = "aserai";
				result = true;
			}
			else
			{
				bool flag2 = CustomCultureDefinitions.BattaniaCultureIds.Contains(cultureId);
				if (flag2)
				{
					baseCulture = "battania";
					result = true;
				}
				else
				{
					bool flag3 = CustomCultureDefinitions.EmpireCultureIds.Contains(cultureId);
					if (flag3)
					{
						baseCulture = "empire";
						result = true;
					}
					else
					{
						bool flag4 = CustomCultureDefinitions.KhuzaitCultureIds.Contains(cultureId);
						if (flag4)
						{
							baseCulture = "khuzait";
							result = true;
						}
						else
						{
							bool flag5 = CustomCultureDefinitions.SturgiaCultureIds.Contains(cultureId);
							if (flag5)
							{
								baseCulture = "sturgia";
								result = true;
							}
							else
							{
								bool flag6 = CustomCultureDefinitions.VlandiaCultureIds.Contains(cultureId);
								if (flag6)
								{
									baseCulture = "vlandia";
									result = true;
								}
								else
								{
									baseCulture = null;
									result = false;
								}	
							}
						}
					}
				}
			}
			return result;
		}
	}
}
