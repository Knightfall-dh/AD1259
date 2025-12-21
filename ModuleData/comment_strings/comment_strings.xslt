<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

    

    <xsl:template match="string[@id='str_comment_noble_introduces_self.vlandia']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.vlandia']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.vlandia_2']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.vlandia_boasting']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.vlandia_boasting_ironic']"/>
	<xsl:template match="string[@id='str_liege_title.vlandia']"/>
    <xsl:template match="string[@id='str_liege_title_female.vlandia']"/>
	
	
	<xsl:template match="string[@id='str_comment_vassal_introduces_self.battania']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.battania']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.battania_honor']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.battania_mercy']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.battania_boasting']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.battania_boasting_cruel']"/>
    <xsl:template match="string[@id='str_liege_title.battania']"/>
	<xsl:template match="string[@id='str_liege_title_female.battania']"/>

    <xsl:template match="string[@id='str_comment_noble_introduces_self.khuzait']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.khuzait_boasting']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.khuzait']"/>
    <xsl:template match="string[@id='str_liege_title.khuzait']"/>
	<xsl:template match="string[@id='str_liege_title_female.khuzait']"/>
	
	<xsl:template match="string[@id='str_comment_vassal_introduces_self.imperial']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self.empire']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.empire']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.empire_honor']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.empire_mercy']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.empire_boasting']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.empire_boasting_cruel']"/>
	<xsl:template match="string[@id='str_liege_title.empire']"/>
	<xsl:template match="string[@id='str_liege_title_female.empire']"/>
	
	<xsl:template match="string[@id='str_comment_vassal_introduces_self.sturgia']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self.sturgia']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.sturgia']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.sturgia_honor']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.sturgia_mercy']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.sturgia_boasting']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.sturgia_boasting_cruel']"/>
	<xsl:template match="string[@id='str_liege_title.sturgia']"/>
	<xsl:template match="string[@id='str_liege_title_female.sturgia']"/>
	
	<xsl:template match="string[@id='str_comment_vassal_introduces_self.aserai']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self.aserai']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.aserai']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.aserai_honor']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.aserai_mercy']"/>
    <xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.aserai_boasting']"/>
	<xsl:template match="string[@id='str_comment_noble_introduces_self_and_clan.aserai_boasting_cruel']"/>
	<xsl:template match="string[@id='str_liege_title.aserai']"/>
	<xsl:template match="string[@id='str_liege_title_female.aserai']"/>
	

</xsl:stylesheet>

