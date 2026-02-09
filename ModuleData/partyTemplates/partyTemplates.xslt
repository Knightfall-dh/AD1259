<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

    <!-- emptying native party's templates  -->

    <xsl:template match="MBPartyTemplate[@id='villager_empire_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='villager_aserai_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='villager_sturgia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='villager_vlandia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='villager_battania_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='villager_khuzait_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>                



    <xsl:template match="MBPartyTemplate[@id='rebels_empire_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='rebels_aserai_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='rebels_sturgia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='rebels_vlandia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='rebels_battania_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='rebels_khuzait_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



    <xsl:template match="MBPartyTemplate[@id='caravan_template_aserai']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='caravan_template_battania']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='caravan_template_empire']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='caravan_template_khuzait']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='caravan_template_sturgia']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='caravan_template_vlandia']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_aserai']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_battania']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_empire']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_khuzait']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_sturgia']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='elite_caravan_template_vlandia']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



    <xsl:template match="MBPartyTemplate[@id='militia_empire_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='militia_sturgia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='militia_aserai_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='militia_vlandia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='militia_battania_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='militia_khuzait_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_empire_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_sturgia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_aserai_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_vlandia_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_battania_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='kingdom_hero_party_khuzait_template']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_empire']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_aserai']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_sturgia']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_battania']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_vlandia']/stacks">
        <stacks>
        </stacks>
    </xsl:template>

    <xsl:template match="MBPartyTemplate[@id='vassal_reward_troops_khuzait']/stacks">
        <stacks>
        </stacks>
    </xsl:template> 



</xsl:stylesheet>