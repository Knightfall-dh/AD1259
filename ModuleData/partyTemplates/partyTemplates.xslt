<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>
	
	<xsl:template match="MBPartyTemplate[@id='main_hero_party_template']"/>


    
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_empire_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_empire_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_empire_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_empire_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_empire_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_empire_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_empire']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_empire']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_empire_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_empire']"/>
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_sturgia_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_sturgia_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_sturgia_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_sturgia']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_sturgia']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_sturgia']"/>
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_vlandia_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_vlandia_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_vlandia_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_vlandia']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_vlandia']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_vlandia']"/>
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_aserai_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_aserai_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_aserai_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_aserai']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_aserai']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_aserai']"/>
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_battania_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_battania_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_battania_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_battania_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_battania_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_battania_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_battania']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_battania']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_battania_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_battania']"/>
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_khuzait_template']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_khuzait_template_level_1']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_khuzait_template_level_2']"/>
	<xsl:template match="MBPartyTemplate[@id='patrol_party_khuzait_template_level_3']"/>
	<xsl:template match="MBPartyTemplate[@id='militia_khuzait_template']"/>
	<xsl:template match="MBPartyTemplate[@id='villager_khuzait_template']"/>
	<xsl:template match="MBPartyTemplate[@id='caravan_template_khuzait']"/>
	<xsl:template match="MBPartyTemplate[@id='elite_caravan_template_khuzait']"/>
	<xsl:template match="MBPartyTemplate[@id='rebels_khuzait_template']"/>
	<xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_khuzait']"/>
	
	
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_mercenary_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_mercenary_empire_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_mercenary_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_mercenary_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_aserai_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_battania_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_empire_e_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_empire_s_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_empire_w_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_sturgia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_outlaw_vlandia_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_jawwal_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_karakhuzaits_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_forest_people_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_eleftheroi_template']"/>
	
	<xsl:template match="MBPartyTemplate[@id='looters_template']"/>
	<xsl:template match="MBPartyTemplate[@id='sea_raiders_template']"/>
	<xsl:template match="MBPartyTemplate[@id='sea_raiders_boss_party_template']"/>
	<xsl:template match="MBPartyTemplate[@id='mountain_bandits_template']"/>
	<xsl:template match="MBPartyTemplate[@id='mountain_bandits_boss_party_template']"/>
	<xsl:template match="MBPartyTemplate[@id='forest_bandits_template']"/>
	<xsl:template match="MBPartyTemplate[@id='forest_bandits_boss_party_template']"/>
	<xsl:template match="MBPartyTemplate[@id='desert_bandits_template']"/>
	<xsl:template match="MBPartyTemplate[@id='desert_bandits_boss_party_template']"/>
	<xsl:template match="MBPartyTemplate[@id='steppe_bandits_template']"/>
	<xsl:template match="MBPartyTemplate[@id='steppe_bandits_boss_party_template']"/>
	
	
	<xsl:template match="MBPartyTemplate[@id='crazyman_party_template']"/>
	<xsl:template match="MBPartyTemplate[@id='mixture_template']"/>
	<xsl:template match="MBPartyTemplate[@id='looters_quest_template']"/>
	<xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_caravan_ambushers']"/>
	
	
</xsl:stylesheet>
