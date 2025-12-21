<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" indent="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>


    
	
	<xsl:template match="BodyProperty[@id='fighter_khuzait']"/>
	<xsl:template match="BodyProperty[@id='fighter_khuzait_veteran']"/>
	<xsl:template match="BodyProperty[@id='fighter_khuzait_noble']"/>
	<xsl:template match="BodyProperty[@id='townsman_khuzait']"/>
	<xsl:template match="BodyProperty[@id='townswoman_khuzait']"/>
	<xsl:template match="BodyProperty[@id='villager_khuzait']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_empire']"/>
	<xsl:template match="BodyProperty[@id='fighter_empire_veteran']"/>
	<xsl:template match="BodyProperty[@id='townsman_empire']"/>
	<xsl:template match="BodyProperty[@id='townswoman_empire']"/>
	<xsl:template match="BodyProperty[@id='villager_empire']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_aserai']"/>
	<xsl:template match="BodyProperty[@id='fighter_aserai_veteran']"/>
	<xsl:template match="BodyProperty[@id='townsman_aserai']"/>
	<xsl:template match="BodyProperty[@id='townswoman_aserai']"/>
	<xsl:template match="BodyProperty[@id='villager_aserai']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_sturgia']"/>
	<xsl:template match="BodyProperty[@id='fighter_sturgia_veteran']"/>
	<xsl:template match="BodyProperty[@id='townsman_sturgia']"/>
	<xsl:template match="BodyProperty[@id='townswoman_sturgia']"/>
	<xsl:template match="BodyProperty[@id='villager_sturgia']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_vlandia']"/>
	<xsl:template match="BodyProperty[@id='fighter_vlandia_veteran']"/>
	<xsl:template match="BodyProperty[@id='fighter_vlandia_noble']"/>
	<xsl:template match="BodyProperty[@id='townsman_vlandia']"/>
	<xsl:template match="BodyProperty[@id='townswoman_vlandia']"/>
	<xsl:template match="BodyProperty[@id='villager_vlandia']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_battania']"/>
	<xsl:template match="BodyProperty[@id='fighter_battania_veteran']"/>
	<xsl:template match="BodyProperty[@id='fighter_battania_noble']"/>
	<xsl:template match="BodyProperty[@id='townsman_battania']"/>
	<xsl:template match="BodyProperty[@id='townswoman_battania']"/>
	<xsl:template match="BodyProperty[@id='villager_battania']"/>
	
	<xsl:template match="BodyProperty[@id='looter']"/>
	<xsl:template match="BodyProperty[@id='fighter_steppe_bandit']"/>
	<xsl:template match="BodyProperty[@id='fighter_mounted_pillager']"/>
	<xsl:template match="BodyProperty[@id='fighter_mountain_bandits']"/>
	<xsl:template match="BodyProperty[@id='fighter_desert_bandits']"/>
	
	<xsl:template match="BodyProperty[@id='guard']"/>
	<xsl:template match="BodyProperty[@id='beggar']"/>
	<xsl:template match="BodyProperty[@id='female_beggar']"/>
	
	<xsl:template match="BodyProperty[@id='fighter_ghilman']"/>
	<xsl:template match="BodyProperty[@id='fighter_company_of_boar']"/>
	<xsl:template match="BodyProperty[@id='fighter_beni_zilal']"/>
	<xsl:template match="BodyProperty[@id='fighter_jawwal']"/>
	<xsl:template match="BodyProperty[@id='fighter_wolfskin']"/>
	<xsl:template match="BodyProperty[@id='fighter_eleftheroi']"/>
	<xsl:template match="BodyProperty[@id='fighter_lakepike']"/>
	<xsl:template match="BodyProperty[@id='fighter_hidden_hand']"/>
	<xsl:template match="BodyProperty[@id='fighter_brotherhood_of_woods']"/>
	<xsl:template match="BodyProperty[@id='fighter_embers_of_flame']"/>
	
</xsl:stylesheet>
