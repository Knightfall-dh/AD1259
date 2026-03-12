using System;
using System.Runtime.CompilerServices;

namespace AD1259.Patches
{
	public static class OccupationUtil
	{
		public static bool IsUrbanOccupation(string occupation)
		{
			return occupation == "retainer_urban" || occupation == "mercenary_urban" || occupation == "merchant_urban" || occupation == "vagabond_urban" || occupation == "artisan_urban" || occupation == "physician_urban" || occupation == "healer_urban" || occupation == "bard_urban" || occupation == "shipmaster_urban";
		}
	}
}
