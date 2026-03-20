using System;
using System.Runtime.CompilerServices;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SceneInformationPopupTypes;
using TaleWorlds.Core;
using TaleWorlds.ObjectSystem;

namespace AD1259.Patches
{
	[HarmonyPatch(typeof(CampaignSceneNotificationHelper), "GetBodyguardOfCulture")]
	public class CampaignSceneNotificationHelper_GetBodyguardOfCulture_Patch
	{
		private static bool Prefix(ref SceneNotificationData.SceneNotificationCharacter __result, CultureObject culture)
		{
			string stringId = culture.StringId;
			string troopId = "hre_infantry_root000";
			bool flag = stringId == "aragonese";
			if (flag)
			{
				troopId = "aragon_infantry_root0000";
			}
			else
			{
				bool flag2 = stringId == "armenia";
				if (flag2)
				{
					troopId = "armenia_basic_root0000";
				}
				else
				{
					bool flag3 = stringId == "baltic";
					if (flag3)
					{
						troopId = "baltic_infantry_root0000";
					}
					else
					{
						bool flag4 = stringId == "berber";
						if (flag4)
						{
							troopId = "marinid_infantry_root100";
						}
						else
						{
							bool flag5 = stringId == "bohemia";
							if (flag5)
							{
								troopId = "bohemia_infantry_root10";
							}
							else
							{
								bool flag6 = stringId == "bosnia";
								if (flag6)
								{
									troopId = "bosnia_basic_root0000";
								}
								else
								{
									bool flag7 = stringId == "bulgaria";
									if (flag7)
									{
										troopId = "bulgaria_basic_root0000";
									}
									else
									{
										bool flag8 = stringId == "castile";
										if (flag8)
										{
											troopId = "castile_infantry_root0000";
										}
										else
										{
											bool flag9 = stringId == "crusader";
											if (flag9)
											{
												troopId = "crusader_basic_root0000";
											}
											else
											{
												bool flag10 = stringId == "danish";
												if (flag10)
												{
													troopId = "denmark_basic_root0";
												}
												else
												{
													bool flag11 = stringId == "england";
													if (flag11)
													{
														troopId = "england_infantry_root0000";
													}
													else
													{
														bool flag12 = stringId == "french";
														if (flag12)
														{
															troopId = "france_infantry_root0000";
														}
														else
														{
															bool flag13 = stringId == "gaelic";
															if (flag13)
															{
																troopId = "gaelic_basic_root000";
															}
															else
															{
																bool flag14 = stringId == "georgia";
																if (flag14)
																{
																	troopId = "georgia_basic_root0000";
																}
																else
																{
																	bool flag15 = stringId == "germanic";
																	if (flag15)
																	{
																		troopId = "hre_infantry_root0000";
																	}
																	else
																	{
																		bool flag16 = stringId == "andalus";
																		if (flag16)
																		{
																			troopId = "granada_infantry_root00";
																		}
																		else
																		{
																			bool flag17 = stringId == "greek";
																			if (flag17)
																			{
																				troopId = "greek_basic_root0100";
																			}
																			else
																			{
																				bool flag18 = stringId == "halych";
																				if (flag18)
																				{
																					troopId = "halych_basic_root0000";
																				}
																				else
																				{
																					bool flag19 = stringId == "hungarian";
																					if (flag19)
																					{
																						troopId = "hungary_basic_root0000";
																					}
																					else
																					{
																						bool flag20 = stringId == "ilkhanid";
																						if (flag20)
																						{
																							troopId = "ilkhanid_basic_root0100";
																						}
																						else
																						{
																							bool flag21 = stringId == "italian";
																							if (flag21)
																							{
																								troopId = "italy_infantry_root100";
																							}
																							else
																							{
																								bool flag22 = stringId == "latin";
																								if (flag22)
																								{
																									troopId = "latin_basic_root00";
																								}
																								else
																								{
																									bool flag23 = stringId == "mongolian";
																									if (flag23)
																									{
																										troopId = "mongol_basic_root0010";
																									}
																									else
																									{
																										bool flag24 = stringId == "norwegian";
																										if (flag24)
																										{
																											troopId = "norway_basic_root000";
																										}
																										else
																										{
																											bool flag25 = stringId == "poland";
																											if (flag25)
																											{
																												troopId = "poland_infantry_root0000";
																											}
																											else
																											{
																												bool flag26 = stringId == "portuguese";
																												if (flag26)
																												{
																													troopId = "portugal_infantry_root0000";
																												}
																												else
																												{
																													bool flag27 = stringId == "rus";
																													if (flag27)
																													{
																														troopId = "rus_basic_root0000";
																													}
																													else
																													{
																														bool flag28 = stringId == "scottish";
																														if (flag28)
																														{
																															troopId = "scotland_infantry_root2002";
																														}
																														else
																														{
																															bool flag29 = stringId == "serbia";
																															if (flag29)
																															{
																																troopId = "serbia_basic_root0000";
																															}
																															else
																															{
																																bool flag30 = stringId == "swedish";
																																if (flag30)
																																{
																																	troopId = "sweden_infantry_root000";
																																}
																																else
																																{
																																	bool flag31 = stringId == "teutonic";
																																	if (flag31)
																																	{
																																		troopId = "teutonic_infantry_root0000";
																																	}
																																	else
																																	{
																																		bool flag32 = stringId == "turkish";
																																		if (flag32)
																																		{
																																			troopId = "turkish_basic_root010";
																																		}
																																		else
																																		{
																																			bool flag33 = stringId == "wales";
																																			if (flag33)
																																			{
																																				troopId = "wales_basic_root0000";
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			__result = new SceneNotificationData.SceneNotificationCharacter(MBObjectManager.Instance.GetObject<CharacterObject>(troopId), null, default(BodyProperties), false, uint.MaxValue, uint.MaxValue, false);
			return false;
		}
	}
}