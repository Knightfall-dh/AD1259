using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AD1259.Patches
{
	internal static class CustomCultureDefinitions
	{
		public static readonly string[] VanillaBases = new string[]
		{
			"aserai",
			"battania",
			"empire",
			"khuzait",
			"sturgia",
			"vlandia"
		};
		public static readonly HashSet<string> AllCultureIds = new HashSet<string>
		{
			"england",
            "scottish",
            "gaelic",
            "wales",
            "french",
            "aragonese",
            "castile",
            "andalus",
            "portuguese",
            "italian",
            "swedish",
            "danish",
            "norwegian",
            "crusader",
            "teutonic",
            "germanic",
            "hungarian",
            "poland",
            "bohemia",
            "baltic",
            "rus",
            "halych",
            "bulgaria",
            "serbia",
            "bosnia",
            "greek",
            "latin",
            "armenia",
            "georgia",
            "ilkhanid",
            "mongolian",
            "turkish",
            "berber"
		};
		public static readonly HashSet<string> CulturesWithOwnEquipmentsIds = new HashSet<string>
		{
			"england",
            "scottish",
            "gaelic",
            "wales",
            "french",
            "aragonese",
            "castile",
            "andalus",
            "portuguese",
            "italian",
            "swedish",
            "danish",
            "norwegian",
            "crusader",
            "teutonic",
            "germanic",
            "hungarian",
            "poland",
            "bohemia",
            "baltic",
            "rus",
            "halych",
            "bulgaria",
            "serbia",
            "bosnia",
            "greek",
            "latin",
            "armenia",
            "georgia",
            "ilkhanid",
            "mongolian",
            "turkish",
            "berber"
		};
		public static readonly HashSet<string> AseraiCultureIds = new HashSet<string>
		{
			"andalus",
			"turkish",
            "berber"
		};
		public static readonly HashSet<string> BattaniaCultureIds = new HashSet<string>
		{
			"baltic",
			"wales",
			"gaelic",
			"scottish"
		};
		public static readonly HashSet<string> EmpireCultureIds = new HashSet<string>
		{
			"italian",
			"portuguese",
			"aragonese",
            "castile",
			"greek",
            "latin",
			"bulgaria",
            "serbia",
            "bosnia",
			"armenia",
            "georgia"
		};
		public static readonly HashSet<string> KhuzaitCultureIds = new HashSet<string>
		{
			"ilkhanid",
			"mongolian"
		};
		public static readonly HashSet<string> SturgiaCultureIds = new HashSet<string>
		{
			"swedish",
            "danish",
            "norwegian",
			"rus",
            "halych"
		};
		public static readonly HashSet<string> VlandiaCultureIds = new HashSet<string>
		{
			"england",
			"french",
			"crusader",
            "teutonic",
            "germanic",
            "hungarian",
            "poland",
            "bohemia"
		};
	}
}
