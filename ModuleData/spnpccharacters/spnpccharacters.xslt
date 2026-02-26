<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

        <!-- hide native troops in Encyclopedia -->

        <xsl:template match="NPCCharacter[
            @id='aserai_recruit' or 
            @id='aserai_tribesman' or 
            @id='aserai_footman' or 
            @id='aserai_skirmisher' or 
            @id='aserai_archer' or 
            @id='aserai_master_archer' or 
            @id='aserai_infantry' or 
            @id='aserai_veteran_infantry' or 
            @id='aserai_mameluke_soldier' or 
            @id='aserai_mameluke_regular' or 
            @id='aserai_mameluke_cavalry' or 
            @id='aserai_mameluke_heavy_cavalry' or 
            @id='aserai_mameluke_axeman' or 
            @id='aserai_mameluke_guard' or 
            @id='mamluke_palace_guard' or 
            @id='aserai_youth' or 
            @id='aserai_tribal_horseman' or 
            @id='aserai_faris' or 
            @id='aserai_veteran_faris' or 
            @id='aserai_vanguard_faris' or 
            @id='battanian_volunteer' or 
            @id='battanian_clanwarrior' or 
            @id='battanian_trained_warrior' or 
            @id='battanian_picked_warrior' or 
            @id='battanian_oathsworn' or 
            @id='battanian_scout' or 
            @id='battanian_mounted_skirmisher' or 
            @id='battanian_horseman' or 
            @id='battanian_woodrunner' or 
            @id='battanian_raider' or 
            @id='battanian_skirmisher' or 
            @id='battanian_wildling' or 
            @id='battanian_falxman' or 
            @id='battanian_veteran_skirmisher' or 
            @id='battanian_veteran_falxman' or 
            @id='battanian_highborn_youth' or 
            @id='battanian_highborn_warrior' or 
            @id='battanian_hero' or 
            @id='battanian_fian' or 
            @id='battanian_fian_champion' or 
			@id='galloglass_tier_1' or
			@id='galloglass_tier_2' or
			@id='galloglass_tier_3' or
            @id='imperial_recruit' or 
            @id='imperial_infantryman' or 
            @id='imperial_vigla_recruit' or 
            @id='imperial_equite' or 
            @id='imperial_heavy_horseman' or 
            @id='imperial_cataphract' or 
            @id='imperial_elite_cataphract' or 
            @id='imperial_trained_infantryman' or 
            @id='imperial_veteran_infantryman' or 
            @id='imperial_legionary' or 
            @id='imperial_archer' or 
            @id='bucellarii' or 
            @id='imperial_trained_archer' or 
            @id='imperial_veteran_archer' or 
            @id='imperial_palatine_guard' or 
            @id='imperial_menavliaton' or 
            @id='imperial_elite_menavliaton' or 
            @id='imperial_crossbowman' or 
            @id='imperial_sergeant_crossbowman' or 
			@id='guardians_tier_1' or 
			@id='guardians_tier_2' or 
			@id='guardians_tier_3' or 
            @id='khuzait_nomad' or 
            @id='khuzait_footman' or 
            @id='khuzait_tribal_warrior' or 
            @id='khuzait_noble_son' or 
            @id='khuzait_hunter' or 
            @id='khuzait_spearman' or 
            @id='khuzait_raider' or 
            @id='khuzait_horseman' or 
            @id='khuzait_qanqli' or 
            @id='khuzait_archer' or 
            @id='khuzait_spear_infantry' or 
            @id='khuzait_horse_archer' or 
            @id='khuzait_lancer' or 
            @id='khuzait_torguud' or 
            @id='khuzait_marksman' or 
            @id='khuzait_darkhan' or 
            @id='khuzait_heavy_horse_archer' or 
            @id='khuzait_heavy_lancer' or 
            @id='khuzait_kheshig' or 
            @id='khuzait_khans_guard' or 
            @id='sturgian_recruit' or 
            @id='sturgian_warrior' or 
            @id='sturgian_soldier' or 
            @id='sturgian_shock_troop' or 
            @id='sturgian_veteran_warrior' or 
            @id='sturgian_warrior_son' or 
            @id='varyag' or 
            @id='varyag_veteran' or 
            @id='druzhinnik' or 
            @id='druzhinnik_champion' or 
            @id='sturgian_woodsman' or 
            @id='sturgian_hunter' or 
            @id='sturgian_archer' or 
            @id='sturgian_veteran_bowman' or 
            @id='sturgian_brigand' or 
            @id='sturgian_hardened_brigand' or 
            @id='sturgian_horse_raider' or 
            @id='sturgian_berzerker' or 
            @id='sturgian_spearman' or 
            @id='sturgian_ulfhednar' or 
            @id='vlandian_recruit' or 
            @id='vlandian_footman' or 
            @id='vlandian_spearman' or 
            @id='vlandian_billman' or 
            @id='vlandian_voulgier' or 
            @id='vlandian_pikeman' or 
            @id='vlandian_infantry' or 
            @id='vlandian_swordsman' or 
            @id='vlandian_sergeant' or 
            @id='vlandian_light_cavalry' or 
            @id='vlandian_cavalry' or 
            @id='vlandian_vanguard' or 
            @id='vlandian_levy_crossbowman' or 
            @id='vlandian_crossbowman' or 
            @id='vlandian_hardened_crossbowman' or 
            @id='vlandian_sharpshooter' or 
            @id='vlandian_gallant' or 
            @id='vlandian_knight' or 
            @id='vlandian_champion' or 
            @id='vlandian_banner_knight']">
            <xsl:copy>
                <xsl:apply-templates select="@*"/>
                <xsl:attribute name="is_hidden_encyclopedia">true</xsl:attribute>
                <xsl:apply-templates select="node()"/>
            </xsl:copy>
        </xsl:template>

        <xsl:template match="NPCCharacter[
            @id='caravan_master_aserai' or 
            @id='caravan_master_battania' or 
            @id='caravan_master_empire' or 
            @id='caravan_master_khuzait' or 
            @id='caravan_master_sturgia' or 
            @id='caravan_master_vlandia' or 
            @id='armed_trader_aserai' or 
            @id='armed_trader_battania' or 
            @id='armed_trader_empire' or 
            @id='armed_trader_khuzait' or 
            @id='armed_trader_sturgia' or 
            @id='armed_trader_vlandia' or 
            @id='caravan_guard_aserai' or 
            @id='caravan_guard_battania' or 
            @id='caravan_guard_empire' or 
            @id='caravan_guard_khuzait' or 
            @id='caravan_guard_sturgia' or 
            @id='caravan_guard_vlandia' or 
            @id='veteran_caravan_guard_aserai' or 
            @id='veteran_caravan_guard_battania' or 
            @id='veteran_caravan_guard_empire' or 
            @id='veteran_caravan_guard_khuzait' or 
            @id='veteran_caravan_guard_sturgia' or 
            @id='veteran_caravan_guard_vlandia' or 
            @id='aserai_militia_archer' or 
            @id='aserai_militia_veteran_archer' or 
            @id='aserai_militia_spearman' or 
            @id='aserai_militia_veteran_spearman' or 
            @id='vlandian_militia_archer' or 
            @id='vlandian_militia_veteran_archer' or 
            @id='vlandian_militia_spearman' or 
            @id='vlandian_militia_veteran_spearman' or 
            @id='battanian_militia_archer' or 
            @id='battanian_militia_veteran_archer' or 
            @id='battanian_militia_spearman' or 
            @id='battanian_militia_veteran_spearman' or 
            @id='imperial_militia_archer' or 
            @id='imperial_militia_veteran_archer' or 
            @id='imperial_militia_spearman' or 
            @id='imperial_militia_veteran_spearman' or 
            @id='sturgian_militia_archer' or 
            @id='sturgian_militia_veteran_archer' or 
            @id='sturgian_militia_spearman' or 
            @id='sturgian_militia_veteran_spearman' or 
            @id='khuzait_militia_archer' or 
            @id='khuzait_militia_veteran_archer' or 
            @id='khuzait_militia_spearman' or 
            @id='khuzait_militia_veteran_spearman']">
            <xsl:copy>
                <xsl:apply-templates select="@*"/>
                <xsl:attribute name="is_hidden_encyclopedia">true</xsl:attribute>
                <xsl:apply-templates select="node()"/>
            </xsl:copy>
        </xsl:template>


        <xsl:template match="NPCCharacter[
            @id='brotherhood_of_woods_tier_1' or 
            @id='brotherhood_of_woods_tier_2' or 
            @id='brotherhood_of_woods_tier_3' or 
            @id='company_of_the_boar_tier_1' or 
            @id='company_of_the_boar_tier_2' or 
            @id='company_of_the_boar_tier_3' or 
            @id='villager_vlandia' or 
            @id='villager_aserai' or 
            @id='villager_battania' or 
            @id='villager_empire' or 
            @id='villager_sturgia' or 
            @id='villager_khuzait' or 
            @id='vlandian_squire' or 
            @id='beni_zilal_tier_1' or 
            @id='beni_zilal_tier_2' or 
            @id='beni_zilal_tier_3' or 
            @id='jawwal_tier_1' or 
            @id='jawwal_tier_2' or 
            @id='jawwal_tier_3' or 
            @id='forest_people_tier_1' or 
            @id='forest_people_tier_2' or 
            @id='forest_people_tier_3' or 
            @id='karakhuzaits_tier_1' or 
            @id='karakhuzaits_tier_2' or 
            @id='karakhuzaits_tier_3' or 
            @id='lakepike_tier_1' or 
            @id='lakepike_tier_2' or 
            @id='lakepike_tier_3' or 
            @id='ghilman_tier_1' or 
            @id='ghilman_tier_2' or 
            @id='ghilman_tier_3' or 
            @id='skolderbrotva_tier_1' or 
            @id='skolderbrotva_tier_2' or 
            @id='skolderbrotva_tier_3' or 
            @id='wolfskins_tier_1' or 
            @id='wolfskins_tier_2' or 
            @id='wolfskins_tier_3' or 
            @id='embers_of_flame_tier_1' or 
            @id='embers_of_flame_tier_2' or 
            @id='embers_of_flame_tier_3' or 
            @id='eleftheroi_tier_1' or 
            @id='eleftheroi_tier_2' or 
            @id='eleftheroi_tier_3' or 
            @id='sword_sisters_sister_t3' or 
            @id='sword_sisters_sister_t4' or 
            @id='sword_sisters_sister_t5' or 
            @id='legion_of_the_betrayed_tier_1' or 
            @id='legion_of_the_betrayed_tier_2' or 
            @id='legion_of_the_betrayed_tier_3' or 
            @id='disguise_officer_character' or 
            @id='disguise_shadow_target' or                
            @id='hidden_hand_tier_1' or 
            @id='hidden_hand_tier_2' or 
            @id='hidden_hand_tier_3']">
            <xsl:copy>
                <xsl:apply-templates select="@*"/>
                <xsl:attribute name="is_hidden_encyclopedia">true</xsl:attribute>
                <xsl:apply-templates select="node()"/>
            </xsl:copy>
        </xsl:template>

       

        <!-- NavalDLC -->
        <xsl:template match="NPCCharacter[
            @id='sword_sisters_sister_t3' or 
            @id='sword_sisters_sister_t4' or 
            @id='sword_sisters_sister_t5' or 
            @id='sword_sisters_sister_infantry_t5' or 
            @id='eastern_mercenary' or 
            @id='eastern_mercenary_t4' or 
			@id='eastern_mercenary_t5' or 
            @id='eastern_mounted_mercenary_t4' or 
            @id='eastern_mounted_mercenary_t5' or 
            @id='western_mercenary' or 
            @id='western_mercenary_t4' or 
            @id='western_mercenary_t5' or 
            @id='western_crossbow_t4' or 
            @id='western_crossbow_t5']">
            <xsl:copy>
                <xsl:apply-templates select="@*"/>
                <xsl:attribute name="is_hidden_encyclopedia">true</xsl:attribute>
                <xsl:apply-templates select="node()"/>
            </xsl:copy>
        </xsl:template>


</xsl:stylesheet>