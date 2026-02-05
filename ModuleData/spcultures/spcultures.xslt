<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>


	<xsl:template match="Culture[@id='looters']"/>
	<xsl:template match="Culture[@id='sea_raiders']"/>
	<xsl:template match="Culture[@id='mountain_bandits']"/>
	<xsl:template match="Culture[@id='forest_bandits']"/>
	<xsl:template match="Culture[@id='desert_bandits']"/>
	<xsl:template match="Culture[@id='steppe_bandits']"/>
	
	<xsl:template match="Culture[@id='khuzait']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>
	
	<xsl:template match="Culture[@id='aserai']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>
	
	<xsl:template match="Culture[@id='battania']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>
    
	<xsl:template match="Culture[@id='sturgia']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>
	
	<xsl:template match="Culture[@id='vlandia']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>
	
	<xsl:template match="Culture[@id='empire']/@is_main_culture">
            <xsl:attribute name="is_main_culture">false</xsl:attribute>
    </xsl:template>

</xsl:stylesheet>