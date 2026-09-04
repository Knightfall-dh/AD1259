<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="action_set[@id='as_human_warrior']">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
			<action type="act_lancer_ride_4_shake" animation="lancer_ride_4" />
			<action type="act_lancer_ride_4_no_shield_shake" animation="lancer_ride_4" />
        </xsl:copy>
    </xsl:template>

</xsl:stylesheet>



