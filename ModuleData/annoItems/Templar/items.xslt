<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>
	<!-- region Templar Armor -->
    <xsl:template match="Item[@id='ktmail_with_tabbard1']"/>
    <xsl:template match="Item[@id='ktmail_with_tabbard2']"/>
    <xsl:template match="Item[@id='ktmail_with_tabbard3']"/>
    <xsl:template match="Item[@id='ktmail_with_tabbard4']"/>
    <xsl:template match="Item[@id='ktmail_with_tabbard5']"/>
    <xsl:template match="Item[@id='ktmail_with_tabbard6']"/>
    <xsl:template match="Item[@id='ktemplar_a_white']"/>
    <xsl:template match="Item[@id='ktemplar_b_white']"/>
    <xsl:template match="Item[@id='ktemplar_c_white']"/>
    <xsl:template match="Item[@id='ktemplar_d_white']"/>
    <xsl:template match="Item[@id='ktemplar_e_white']"/>
    <xsl:template match="Item[@id='ktemplar_f_white']"/>
    <xsl:template match="Item[@id='ktemplar_p_white']"/>
    <xsl:template match="Item[@id='ktemplar_z_white']"/>
    <xsl:template match="Item[@id='ktemplar_g_white']"/>
    <xsl:template match="Item[@id='ktemplar_h_white']"/>
    <xsl:template match="Item[@id='sergeant_tunic']"/>
    <xsl:template match="Item[@id='templar_robe']"/>
    <xsl:template match="Item[@id='templar_robe_b']"/>
    <xsl:template match="Item[@id='templar_chain_a']"/>
    <xsl:template match="Item[@id='templar_chain_b']"/>
    <xsl:template match="Item[@id='templar_cape']"/>
    <xsl:template match="Item[@id='templar_cape_b']"/>
    <xsl:template match="Item[@id='templar_cape_c']"/>
    <!-- #endregion -->
	<!-- region Templar Equipment -->
    <xsl:template match="Item[@id='ktemplar_shield']"/>
    <xsl:template match="Item[@id='ktemplar_shield_bw']"/>
    <xsl:template match="Item[@id='ktemplar_shield_cs']"/>
    <xsl:template match="Item[@id='ktemplar_shield_sg']"/>
    <xsl:template match="Item[@id='ktemplar_shield_el']"/>
    <xsl:template match="Item[@id='templar_small_shield_bw']"/>
    <xsl:template match="Item[@id='templar_small_shield_cs']"/>
    <xsl:template match="Item[@id='templar_small_shield_sg']"/>
    <xsl:template match="Item[@id='templar_small_shield_el']"/>
    <xsl:template match="Item[@id='templar_small_shield']"/>
    <xsl:template match="Item[@id='templar_kiteshield']"/>
    <xsl:template match="Item[@id='templar_kiteshield_cs']"/>
    <xsl:template match="Item[@id='templar_kiteshield_el']"/>
    <xsl:template match="Item[@id='templar_kiteshield_sg']"/>
    <xsl:template match="Item[@id='templar_kiteshield_bw']"/>
    <xsl:template match="Item[@id='templar_horsearmor']"/>
    <!-- #endregion -->
</xsl:stylesheet>