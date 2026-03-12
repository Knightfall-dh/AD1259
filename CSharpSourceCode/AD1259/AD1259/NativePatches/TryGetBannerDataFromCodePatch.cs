using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.Core;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(Banner), "TryGetBannerDataFromCode")]
	public class TryGetBannerDataFromCodePatch
	{
		[HarmonyTranspiler]
		public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
		{
			List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
			int i = 0;
			while (i < codes.Count)
			{
				if (!(codes[i].opcode == OpCodes.Ldc_I4_S))
				{
					goto IL_4B;
				}
				object operand = codes[i].operand;
				if (!(operand is sbyte))
				{
					goto IL_4B;
				}
				sbyte operandValue = (sbyte)operand;
				bool flag = operandValue == 32;
				IL_4C:
				bool flag2 = flag;
				if (flag2)
				{
					codes[i] = new CodeInstruction(OpCodes.Ldc_I4, int.MaxValue);
					break;
				}
				i++;
				continue;
				IL_4B:
				flag = false;
				goto IL_4C;
			}
			return codes;
		}
	}
}
