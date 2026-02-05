<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
    <xsl:output omit-xml-declaration="yes"/>

    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>
    
    <xsl:template match="CraftingTemplate[@id='TwoHandedPolearm']/UsablePieces/UsablePiece[1]">
        <UsablePiece piece_id="english_glaive_blade1259"/>
        <UsablePiece piece_id="german_halberd_blade1259"/>
        <UsablePiece piece_id="italian_bill_blade1259"/>
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>
    
</xsl:stylesheet>