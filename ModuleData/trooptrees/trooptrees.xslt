<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output omit-xml-declaration="yes"/>
    <xsl:template match="@*|node()">
        <xsl:copy>
            <xsl:apply-templates select="@*|node()"/>
        </xsl:copy>
    </xsl:template>

    <xsl:template match="NPCCharacter[@id='aserai_recruit']"/>
	<xsl:template match="NPCCharacter[@id='aserai_tribesman']"/>
	<xsl:template match="NPCCharacter[@id='aserai_footman']"/>
	<xsl:template match="NPCCharacter[@id='aserai_skirmisher']"/>
	<xsl:template match="NPCCharacter[@id='aserai_archer']"/>
	<xsl:template match="NPCCharacter[@id='aserai_master_archer']"/>
	<xsl:template match="NPCCharacter[@id='aserai_infantry']"/>
	<xsl:template match="NPCCharacter[@id='aserai_veteran_infantry']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_soldier']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_regular']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_cavalry']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_heavy_cavalry']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_axeman']"/>
	<xsl:template match="NPCCharacter[@id='aserai_mameluke_guard']"/>
	<xsl:template match="NPCCharacter[@id='mamluke_palace_guard']"/>
	<xsl:template match="NPCCharacter[@id='aserai_youth']"/>
	<xsl:template match="NPCCharacter[@id='aserai_tribal_horseman']"/>
	<xsl:template match="NPCCharacter[@id='aserai_faris']"/>
	<xsl:template match="NPCCharacter[@id='aserai_veteran_faris']"/>
	<xsl:template match="NPCCharacter[@id='aserai_vanguard_faris']"/>
	<xsl:template match="NPCCharacter[@id='battanian_volunteer']"/>
	<xsl:template match="NPCCharacter[@id='battanian_clanwarrior']"/>
	<xsl:template match="NPCCharacter[@id='battanian_trained_warrior']"/>
	<xsl:template match="NPCCharacter[@id='battanian_picked_warrior']"/>
	<xsl:template match="NPCCharacter[@id='battanian_oathsworn']"/>
	<xsl:template match="NPCCharacter[@id='battanian_scout']"/>
	<xsl:template match="NPCCharacter[@id='battanian_mounted_skirmisher']"/>
	<xsl:template match="NPCCharacter[@id='battanian_horseman']"/>
	<xsl:template match="NPCCharacter[@id='battanian_woodrunner']"/>
	<xsl:template match="NPCCharacter[@id='battanian_raider']"/>
	<xsl:template match="NPCCharacter[@id='battanian_skirmisher']"/>
	<xsl:template match="NPCCharacter[@id='battanian_wildling']"/>
	<xsl:template match="NPCCharacter[@id='battanian_falxman']"/>
	<xsl:template match="NPCCharacter[@id='battanian_veteran_skirmisher']"/>
	<xsl:template match="NPCCharacter[@id='battanian_veteran_falxman']"/>
	<xsl:template match="NPCCharacter[@id='battanian_highborn_youth']"/>
	<xsl:template match="NPCCharacter[@id='battanian_highborn_warrior']"/>
	<xsl:template match="NPCCharacter[@id='battanian_hero']"/>
	<xsl:template match="NPCCharacter[@id='battanian_fian']"/>
	<xsl:template match="NPCCharacter[@id='battanian_fian_champion']"/>
	<xsl:template match="NPCCharacter[@id='imperial_recruit']"/>
	<xsl:template match="NPCCharacter[@id='imperial_infantryman']"/>
	<xsl:template match="NPCCharacter[@id='imperial_vigla_recruit']"/>
	<xsl:template match="NPCCharacter[@id='imperial_equite']"/>
	<xsl:template match="NPCCharacter[@id='imperial_heavy_horseman']"/>
	<xsl:template match="NPCCharacter[@id='imperial_cataphract']"/>
	<xsl:template match="NPCCharacter[@id='imperial_elite_cataphract']"/>
	<xsl:template match="NPCCharacter[@id='imperial_trained_infantryman']"/>
	<xsl:template match="NPCCharacter[@id='imperial_veteran_infantryman']"/>
	<xsl:template match="NPCCharacter[@id='imperial_legionary']"/>
	<xsl:template match="NPCCharacter[@id='imperial_archer']"/>
	<xsl:template match="NPCCharacter[@id='bucellarii']"/>
	<xsl:template match="NPCCharacter[@id='imperial_trained_archer']"/>
	<xsl:template match="NPCCharacter[@id='imperial_veteran_archer']"/>
	<xsl:template match="NPCCharacter[@id='imperial_palatine_guard']"/>
	<xsl:template match="NPCCharacter[@id='imperial_menavliaton']"/>
	<xsl:template match="NPCCharacter[@id='imperial_elite_menavliaton']"/>
	<xsl:template match="NPCCharacter[@id='imperial_crossbowman']"/>
	<xsl:template match="NPCCharacter[@id='imperial_sergeant_crossbowman']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_nomad']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_footman']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_tribal_warrior']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_noble_son']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_hunter']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_spearman']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_raider']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_horseman']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_qanqli']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_archer']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_spear_infantry']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_horse_archer']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_lancer']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_torguud']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_marksman']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_darkhan']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_heavy_horse_archer']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_heavy_lancer']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_kheshig']"/>
	<xsl:template match="NPCCharacter[@id='khuzait_khans_guard']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_recruit']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_warrior']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_soldier']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_shock_troop']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_veteran_warrior']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_warrior_son']"/>
	<xsl:template match="NPCCharacter[@id='varyag']"/>
	<xsl:template match="NPCCharacter[@id='varyag_veteran']"/>
	<xsl:template match="NPCCharacter[@id='druzhinnik']"/>
	<xsl:template match="NPCCharacter[@id='druzhinnik_champion']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_woodsman']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_hunter']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_archer']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_veteran_bowman']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_brigand']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_hardened_brigand']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_horse_raider']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_berzerker']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_spearman']"/>
	<xsl:template match="NPCCharacter[@id='sturgian_ulfhednar']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_recruit']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_footman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_spearman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_billman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_voulgier']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_pikeman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_infantry']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_swordsman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_sergeant']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_light_cavalry']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_cavalry']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_vanguard']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_levy_crossbowman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_crossbowman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_hardened_crossbowman']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_sharpshooter']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_squire']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_gallant']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_knight']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_champion']"/>
	<xsl:template match="NPCCharacter[@id='vlandian_banner_knight']"/>
	
	<xsl:template match="NPCCharacter[@id='looter']"/>
	<xsl:template match="NPCCharacter[@id='deserter']"/>
	<xsl:template match="NPCCharacter[@id='sea_raiders_bandit']"/>
	<xsl:template match="NPCCharacter[@id='sea_raiders_raider']"/>
	<xsl:template match="NPCCharacter[@id='sea_raiders_chief']"/>
	<xsl:template match="NPCCharacter[@id='mountain_bandits_bandit']"/>
	<xsl:template match="NPCCharacter[@id='mountain_bandits_raider']"/>
	<xsl:template match="NPCCharacter[@id='mountain_bandits_chief']"/>
	<xsl:template match="NPCCharacter[@id='forest_bandits_bandit']"/>
	<xsl:template match="NPCCharacter[@id='forest_bandits_raider']"/>
	<xsl:template match="NPCCharacter[@id='forest_bandits_chief']"/>
	<xsl:template match="NPCCharacter[@id='desert_bandits_bandit']"/>
	<xsl:template match="NPCCharacter[@id='desert_bandits_raider']"/>
	<xsl:template match="NPCCharacter[@id='desert_bandits_chief']"/>
	<xsl:template match="NPCCharacter[@id='steppe_bandits_bandit']"/>
	<xsl:template match="NPCCharacter[@id='steppe_bandits_raider']"/>
	<xsl:template match="NPCCharacter[@id='steppe_bandits_chief']"/>
	<xsl:template match="NPCCharacter[@id='sea_raiders_boss']"/>
	<xsl:template match="NPCCharacter[@id='mountain_bandits_boss']"/>
	<xsl:template match="NPCCharacter[@id='forest_bandits_boss']"/>
	<xsl:template match="NPCCharacter[@id='desert_bandits_boss']"/>
	<xsl:template match="NPCCharacter[@id='steppe_bandits_boss']"/>
	<xsl:template match="NPCCharacter[@id='mounted_pillager']"/>
	<xsl:template match="NPCCharacter[@id='mounted_ransacker']"/>
	
	<xsl:template match="NPCCharacter[@id='ghilman_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='ghilman_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='ghilman_tier_3']"/>

   
    <xsl:template match="NPCCharacter[@id='embers_of_flame_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='embers_of_flame_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='embers_of_flame_tier_3']"/>

    <xsl:template match="NPCCharacter[@id='jawwal_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='jawwal_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='jawwal_tier_3']"/>

    <xsl:template match="NPCCharacter[@id='skolderbrotva_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='skolderbrotva_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='skolderbrotva_tier_3']"/>
	
	
	
	
	<xsl:template match="NPCCharacter[@id='company_of_the_boar_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='company_of_the_boar_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='company_of_the_boar_tier_3']"/>

	<xsl:template match="NPCCharacter[@id='beni_zilal_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='beni_zilal_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='beni_zilal_tier_3']"/>
	
	<xsl:template match="NPCCharacter[@id='wolfskins_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='wolfskins_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='wolfskins_tier_3']"/>

	<xsl:template match="NPCCharacter[@id='hidden_hand_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='hidden_hand_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='hidden_hand_tier_3']"/>

	<xsl:template match="NPCCharacter[@id='brotherhood_of_woods_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='brotherhood_of_woods_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='brotherhood_of_woods_tier_3']"/>

	<xsl:template match="NPCCharacter[@id='lakepike_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='lakepike_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='lakepike_tier_3']"/>

	<xsl:template match="NPCCharacter[@id='forest_people_tier_1']"/>
	<xsl:template match="NPCCharacter[@id='forest_people_tier_2']"/>
	<xsl:template match="NPCCharacter[@id='forest_people_tier_3']"/>
	
	<xsl:template match="NPCCharacter[@id='karakhuzaits_tier_1']"/>
	<xsl:template match="NPCCharacter[@id='karakhuzaits_tier_2']"/>
	<xsl:template match="NPCCharacter[@id='karakhuzaits_tier_3']"/>

    <xsl:template match="NPCCharacter[@id='eleftheroi_tier_1']"/>
	<xsl:template match="NPCCharacter[@id='eleftheroi_tier_2']"/>
	<xsl:template match="NPCCharacter[@id='eleftheroi_tier_3']"/>
	
	<xsl:template match="NPCCharacter[@id='legion_of_the_betrayed_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='legion_of_the_betrayed_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='legion_of_the_betrayed_tier_3']"/>
	
    <xsl:template match="NPCCharacter[@id='galloglass_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='galloglass_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='galloglass_tier_3']"/>

    <xsl:template match="NPCCharacter[@id='beni_zilal_tier_1']"/>
    <xsl:template match="NPCCharacter[@id='beni_zilal_tier_2']"/>
    <xsl:template match="NPCCharacter[@id='beni_zilal_tier_3']"/>


</xsl:stylesheet>