import xml.etree.ElementTree as ET
import os

# ================== CONFIG ==================
SCRIPT_DIR = os.path.dirname(os.path.abspath(__file__))
SPRITE_DATA_FILENAME = "AD1259SpriteData.xml"
SPRITE_DATA_PATH = os.path.join(SCRIPT_DIR, SPRITE_DATA_FILENAME)

# Only these will be added (copy-paste from the extracted list)
NINE_REGION_LIST = [
    ("conversation_frame_9", "Conversation\\conversation_frame", 16, 16, 16, 16),
    ("conversation_frame_canvas_9", "Conversation\\conversation_frame_canvas", 40, 38, 30, 32),
    ("conversation_relation_canvas_9", "Conversation\\conversation_relation_canvas", 6, 6, 6, 6),
    ("dialog_option_canvas_9", "Conversation\\dialog_option_canvas", 7, 23, 21, 21),
    ("dialog_option_canvas_white_9", "Conversation\\dialog_option_canvas_white", 7, 23, 21, 21),
    ("name_shadow_9", "Conversation\\name_shadow", 55, 82, 30, 34),
    ("npc_dialogue_panel_9", "Conversation\\npc_dialogue_panel", 97, 25, 93, 92),
    ("persuasion_extension_canvas_9", "Conversation\\persuasion_extension_canvas", 70, 70, 0, 0),
    ("persuasion_extension_frame_9", "Conversation\\persuasion_extension_frame", 70, 70, 0, 0),
    ("CreditsFlowBg_9", "CreditsFlowBg", 72, 72, 1, 1),
    ("list_closed_divider_9", "Encyclopedia\\list_closed_divider", 32, 2, 1, 1),
    ("list_divider_9", "Encyclopedia\\list_divider", 1, 1, 1, 1),
    ("list_open_divider_9", "Encyclopedia\\list_open_divider", 32, 2, 1, 1),
    ("subpage_slick_frame_9", "Encyclopedia\\subpage_slick_frame", 14, 15, 15, 15),
    ("troop_tree_side_9", "Encyclopedia\\troop_tree_side", 8, 8, 0, 0),
    ("property_slider_bed_9", "FaceGen\\property_slider_bed", 7, 7, 7, 7),
    ("property_slider_fill_9", "FaceGen\\property_slider_fill", 1, 1, 2, 2),
    ("BlankWhiteSquare_9", "BlankWhiteSquare", 1, 1, 1, 1),
    ("button_canvas_9", "button_canvas", 25, 24, 43, 44),
    ("button_frame_9", "button_frame", 37, 37, 43, 44),
    ("GradientDivider_9", "GradientDivider", 65, 65, 1, 1),
    ("horizontal_gradient_divider_9", "horizontal_gradient_divider", 0, 425, 0, 0),
    ("loadingBar_9", "loadingBar", 2, 2, 0, 0),
    ("power_bar_fill_left_9", "power_bar_fill_left", 7, 2, 0, 0),
    ("power_bar_fill_right_9", "power_bar_fill_right", 2, 7, 0, 0),
    ("rounded_canvas_9", "rounded_canvas", 8, 8, 8, 8),
    ("rounded_frame_9", "rounded_frame", 8, 8, 8, 8),
    ("rounded_frame_glow_9", "rounded_frame_glow", 12, 12, 12, 12),
    ("rounded_frame_shadow_9", "rounded_frame_shadow", 8, 8, 8, 8),
    ("SettlementLeftPanelFilter_9", "SettlementLeftPanelFilter", 2, 2, 2, 240),
    ("SquareWRoundedCorners_9", "SquareWRoundedCorners", 14, 14, 14, 14),
    ("SquareWRoundedCornersFrame_9", "SquareWRoundedCornersFrame", 14, 14, 14, 14),
    ("SquareWRoundedCornersFrameGlowy_9", "SquareWRoundedCornersFrameGlowy", 14, 14, 14, 14),
    ("WhiteFrame_9", "WhiteFrame", 3, 3, 3, 3),
    ("switcher_9", "General\\CharacterCreation\\switcher", 6, 6, 6, 6),
    ("main_menu_gradient_left_9", "General\\InitialMenu\\main_menu_gradient_left", 1, 1, 1, 1),
    ("InnerFrame1_canvas", "General\\InnerFrame1\\canvas", 42, 35, 38, 44),
    ("InnerFrame1_shadow", "General\\InnerFrame1\\shadow", 42, 35, 38, 44),
    ("formation_targeter_9", "General\\Mission\\formation_targeter", 19, 19, 19, 19),
    ("mission_health_bar_fill_9", "General\\Mission\\mission_health_bar_fill", 16, 8, 2, 2),
    ("mission_health_bar_fill_damage_9", "General\\Mission\\mission_health_bar_fill_damage", 1, 1, 3, 3),
    ("mission_health_bar_fill_damage_small_9", "General\\Mission\\mission_health_bar_fill_damage_small", 1, 1, 3, 3),
    ("mission_health_bar_fill_small_9", "General\\Mission\\mission_health_bar_fill_small", 16, 4, 2, 2),
    ("order_formation_selector_9", "General\\Mission\\order_formation_selector", 30, 30, 30, 30),
    ("reload_frame_9", "General\\Mission\\reload_frame", 0, 0, 6, 6),
    ("cautiousness_bar_frame_9", "General\\Mission\\Detection\\cautiousness_bar_frame", 7, 7, 7, 18),
    ("disguise_progress_bar_fill_9", "General\\Mission\\Detection\\disguise_progress_bar_fill", 6, 6, 6, 6),
    ("disguise_progress_bar_frame_9", "General\\Mission\\Detection\\disguise_progress_bar_frame", 4, 4, 4, 4),
    ("personal_killfeed_notification_9", "General\\Mission\\PersonalKillfeed\\personal_killfeed_notification_9", 100, 100, 1, 1),
    ("escape_menu_gradient_9", "General\\MPEscapeMenu\\escape_menu_gradient", 0, 0, 5, 5),
    ("Scrollbar.Vertical.Handle", "General\\Scrollbar.Vertical1\\scroller", 0, 0, 13, 13),
    ("scrollbar_9", "General\\Scrollbar1\\scrollbar", 10, 10, 6, 6),
    ("scroll_button_9", "General\\Scrollbar1\\scroll_button", 10, 10, 6, 6),
    ("slider_9", "General\\Slider\\slider", 25, 27, 24, 25),
    ("tooltip_divider_abovestats_9", "General\\TooltipHint\\tooltip_divider_abovestats", 160, 33, 1, 1),
    ("tooltip_frame_white_9", "General\\TooltipHint\\tooltip_frame_white", 8, 8, 0, 0),
    ("mp_chat_background_9", "MPGeneral\\MPChat\\background", 2, 2, 2, 2),
    ("campaing_map_log_bg_9", "MPGeneral\\MPChat\\campaing_map_log_bg", 5, 5, 5, 5),
    ("mp_chat_textbox_9", "MPGeneral\\MPChat\\textbox", 2, 2, 2, 2),
    ("scoreboard_top_divider_9", "MPGeneral\\MPScoreboard\\scoreboard_top_divider", 0, 11, 0, 0),
    ("esc_menu_frame_canvas_9", "SPGeneral\\EscapeMenu\\esc_menu_frame_canvas", 40, 38, 30, 32),
    ("Frame1_canvas", "SPGeneral\\Frame1\\canvas", 1, 1, 1, 1),
    ("Frame1_frame", "SPGeneral\\Frame1\\frame", 28, 28, 29, 30),
    ("Frame1_shadow", "SPGeneral\\Frame1\\shadow", 44, 42, 44, 43),
    ("Frame1Broken_canvas", "SPGeneral\\Frame1.Broken\\canvas", 39, 73, 69, 40),
    ("Frame1Broken_frame", "SPGeneral\\Frame1.Broken\\frame", 39, 73, 69, 40),
    ("game_menu_siege_machine_header_9", "SPGeneral\\GameMenu\\game_menu_siege_machine_header", 11, 1, 11, 1),
    ("slider_fill_white_9", "SPGeneral\\InventoryPartyExtension\\Extension\\slider_fill_white", 5, 5, 0, 0),
    ("leader_frame_9", "SPGeneral\\MapOverlay\\Army\\leader_frame", 20, 20, 20, 20),
    ("battle_header_bar_left_9", "SPGeneral\\MapOverlay\\Encounter\\battle_header_bar_left", 16, 1, 1, 1),
    ("battle_header_bar_right_9", "SPGeneral\\MapOverlay\\Encounter\\battle_header_bar_right", 1, 16, 1, 1),
    ("army_track_frame_9", "SPGeneral\\Nameplates\\army_track_frame", 0, 0, 29, 26),
    ("enemy_castle_9", "SPGeneral\\Nameplates\\enemy_castle", 60, 24, 8, 8),
    ("enemy_town_9", "SPGeneral\\Nameplates\\enemy_town", 60, 24, 8, 8),
    ("enemy_village_9", "SPGeneral\\Nameplates\\enemy_village", 60, 24, 8, 8),
    ("party_track_frame_9", "SPGeneral\\Nameplates\\party_track_frame", 0, 0, 25, 26),
    ("slider_thin_bed_horizontal_9", "SPGeneral\\SPRecruitment\\slider_thin_bed_horizontal", 80, 80, 2, 2),
    ("slider_thin_bed_vertical_9", "SPGeneral\\SPRecruitment\\slider_thin_bed_vertical", 2, 2, 80, 80),
    ("slider_thin_horizontal_9", "SPGeneral\\SPRecruitment\\slider_thin_horizontal", 17, 17, 10, 10),
    ("slider_thin_vertical_9", "SPGeneral\\SPRecruitment\\slider_thin_vertical", 10, 10, 17, 17),
    ("bottom_button_9", "SPGeneral\\SPScoreboard\\bottom_button", 8, 8, 8, 8),
    ("highscore_bar_9", "SPGeneral\\SPScoreboard\\highscore_bar", 30, 30, 0, 0),
    ("highscore_bar_small_9", "SPGeneral\\SPScoreboard\\highscore_bar_small", 5, 5, 5, 5),
    ("power_bar_frame_9", "SPGeneral\\SPScoreboard\\power_bar_frame", 16, 16, 0, 0),
    ("tournament_prize_frame_9", "SPGeneral\\SPScoreboard\\tournament_prize_frame", 44, 44, 44, 44),
    ("gold_frame_9", "SPGeneral\\TownManagement\\gold_frame", 13, 13, 13, 14),
    ("governor_popup_9", "SPGeneral\\TownManagement\\governor_popup", 30, 30, 30, 30),
    ("project_popup_progress_fill_9", "SPGeneral\\TownManagement\\project_popup_progress_fill", 9, 10, 11, 11),
    ("reserve_popup_9", "SPGeneral\\TownManagement\\reserve_popup", 19, 19, 19, 20),
    ("reserve_slider_frame_9", "SPGeneral\\TownManagement\\reserve_slider_frame", 10, 10, 9, 10),
    ("highlight_gradient_9", "SPGeneral\\Tutorial\\highlight_gradient", 8, 8, 8, 8),
    ("shadow_9", "SPGeneral\\Tutorial\\shadow", 153, 143, 124, 146),
    ("tutorial_canvas_9", "SPGeneral\\Tutorial\\tutorial_canvas", 9, 9, 7, 7),
    ("tutorial_frame_9", "SPGeneral\\Tutorial\\tutorial_frame", 23, 23, 21, 22),
    ("banner_editor_collapsible_collapsed_9", "StdAssets\\banner_editor_collapsible_collapsed", 25, 25, 0, 0),
    ("banner_editor_collapsible_expanded_9", "StdAssets\\banner_editor_collapsible_expanded", 25, 25, 0, 0),
    ("banner_editor_collapsible_pressed_9", "StdAssets\\banner_editor_collapsible_pressed", 30, 30, 0, 0),
    ("create_server_dropdown_popup_9", "StdAssets\\create_server_dropdown_popup", 0, 0, 0, 25),
    ("flat_panel_9", "StdAssets\\flat_panel", 65, 65, 0, 0),
    ("frame_small_9", "StdAssets\\frame_small", 9, 9, 9, 9),
    ("minimal_slider_bed_9", "StdAssets\\minimal_slider_bed", 10, 10, 0, 0),
    ("minimal_slider_fill_9", "StdAssets\\minimal_slider_fill", 5, 5, 0, 0),
    ("mp_notification_popup_9", "StdAssets\\mp_notification_popup", 133, 133, 12, 12),
    ("notification_popup_9", "StdAssets\\notification_popup", 280, 280, 43, 43),
    ("panel_background_9", "StdAssets\\panel_background", 25, 25, 25, 25),
    ("panel_dent_9", "StdAssets\\panel_dent", 40, 40, 40, 40),
    ("report_player_popup_frame_9", "StdAssets\\report_player_popup_frame", 54, 54, 54, 54),
    ("role_selection_dropdown_canvas_9", "StdAssets\\role_selection_dropdown_canvas", 17, 17, 0, 0),
    ("ScrollBar01Track@2x_9", "StdAssets\\ScrollBar01Track@2x", 8, 8, 10, 10),
    ("SelectionBorder@2x_9", "StdAssets\\SelectionBorder@2x", 4, 4, 4, 4),
    ("slick_frame_9", "StdAssets\\slick_frame", 10, 11, 10, 11),
    ("text_box_9", "StdAssets\\text_box", 12, 12, 14, 15),
    ("vertical_bar_canvas_9", "StdAssets\\vertical_bar_canvas", 10, 13, 20, 20),
    ("vertical_bar_fill_9", "StdAssets\\vertical_bar_fill", 4, 4, 5, 5),
    ("button_default_9", "StdAssets\\Popup\\button_default", 48, 48, 1, 1),
    ("button_default_hover_9", "StdAssets\\Popup\\button_default_hover", 48, 48, 1, 1),
    ("done_button_9", "StdAssets\\Popup\\done_button", 48, 48, 1, 1),
    ("done_button_hover_9", "StdAssets\\Popup\\done_button_hover", 48, 48, 1, 1),
    ("frame_9", "StdAssets\\Popup\\frame", 27, 27, 27, 27),
    ("order_popup_card_default_9", "StdAssets\\Popup\\order_popup_card_default", 11, 11, 11, 11),
    ("order_popup_card_selected_9", "StdAssets\\Popup\\order_popup_card_selected", 11, 11, 11, 11),
    ("order_popup_frame_white_9", "StdAssets\\Popup\\order_popup_frame_white", 15, 15, 15, 15),
    ("scene_popup_selection_card_9", "StdAssets\\Popup\\scene_popup_selection_card", 20, 20, 78, 20),
    ("scene_popup_selection_card_hover_9", "StdAssets\\Popup\\scene_popup_selection_card_hover", 20, 20, 78, 20),
    ("scrollable_field_9", "StdAssets\\Popup\\scrollable_field", 15, 15, 15, 15),
    ("scrollable_field_gradient_9", "StdAssets\\Popup\\scrollable_field_gradient", 10, 10, 10, 10),
    ("intermission_card_frame_9", "MPIntermission\\intermission_card_frame", 40, 40, 40, 40),
    ("intermission_card_frame_selected_9", "MPIntermission\\intermission_card_frame_selected", 40, 40, 40, 40),
    ("customization_card_frame_9", "MPLobby\\Armory\\customization_card_frame", 12, 12, 12, 12),
    ("customization_card_price_label_9", "MPLobby\\Armory\\customization_card_price_label", 0, 10, 0, 0),
    ("EquippedBorder_9", "MPLobby\\Armory\\EquippedBorder", 8, 8, 8, 8),
    ("lobby_perks_frame_popup_9", "MPLobby\\Armory\\lobby_perks_frame_popup", 16, 16, 16, 0),
    ("lobby_perks_popup_bg_9", "MPLobby\\Armory\\lobby_perks_popup_bg", 20, 20, 20, 20),
    ("lobby_perk_selected_frame_9", "MPLobby\\Armory\\lobby_perk_selected_frame", 11, 11, 11, 11),
    ("create_server_slider_fill_9", "MPLobby\\CustomServer\\create_server_slider_fill", 5, 5, 0, 0),
    ("lobby_slider_9", "MPLobby\\CustomServer\\lobby_slider", 0, 0, 10, 10),
    ("lobby_slider_bed_9", "MPLobby\\CustomServer\\lobby_slider_bed", 0, 0, 10, 10),
    ("server_browser_canvas_9", "MPLobby\\CustomServer\\server_browser_canvas", 0, 0, 50, 50),
    ("friends_list_slider_9", "MPLobby\\Generic\\friends_list_slider", 0, 0, 5, 5),
    ("friends_list_slider_bed_9", "MPLobby\\Generic\\friends_list_slider_bed", 0, 0, 5, 5),
    ("news_grid_box_9", "MPLobby\\Home\\news_grid_box", 25, 25, 25, 25),
    ("player_stats_9", "MPLobby\\Home\\player_stats", 0, 0, 0, 230),
    ("card_hovered_9", "MPLobby\\Matchmaking\\card_hovered", 32, 32, 32, 32),
    ("card_selected_9", "MPLobby\\Matchmaking\\card_selected", 32, 32, 32, 32),
    ("information_panel_body_9", "MPLobby\\Matchmaking\\information_panel_body", 0, 0, 12, 0),
    ("information_panel_divider_9", "MPLobby\\Matchmaking\\information_panel_divider", 0, 15, 0, 0),
    ("region_combobox_bg_9", "MPLobby\\Matchmaking\\region_combobox_bg", 0, 0, 16, 0),
    ("popup_gradient_background_9", "MPLobby\\Popup\\popup_gradient_background", 0, 0, 3, 3),
    ("mp_scroller_9", "MPClassLoadout\\mp_scroller", 5, 5, 0, 0),
    ("mp_scroller_bed_9", "MPClassLoadout\\mp_scroller_bed", 5, 5, 0, 0),
    ("perks_frame_popup_9", "MPClassLoadout\\perks_frame_popup", 16, 16, 16, 0),
    ("perks_popup_bg_9", "MPClassLoadout\\perks_popup_bg", 20, 20, 20, 20),
    ("perk_selected_frame_9", "MPClassLoadout\\perk_selected_frame", 11, 11, 11, 11),
    ("duel_card_fill_9", "MPHud\\duel_card_fill", 8, 8, 8, 8),
    ("duel_card_outline_9", "MPHud\\duel_card_outline", 8, 8, 8, 8),
    ("poll_background_9", "MPHud\\poll_background", 0, 10, 10, 10),
    ("poll_background_pointing_down_9", "MPHud\\poll_background_pointing_down", 10, 10, 0, 10),
    ("power_bar_canvas_9", "MPHud\\power_bar_canvas", 0, 22, 0, 0),
    ("controller_keybind_connector_9", "controller_keybind_connector", 17, 0, 6, 0),
    ("card_header_default_9", "Order\\card_header_default", 25, 25, 0, 0),
    ("card_header_disabled_9", "Order\\card_header_disabled", 25, 25, 0, 0),
    ("card_header_selected_9", "Order\\card_header_selected", 25, 25, 0, 0),
    ("card_canvas_default_9", "OrderOfBattle\\card_canvas_default", 15, 15, 15, 15),
    ("card_canvas_disabled_9", "OrderOfBattle\\card_canvas_disabled", 15, 15, 15, 15),
    ("card_canvas_selected_9", "OrderOfBattle\\card_canvas_selected", 15, 15, 15, 15),
    ("oob_slot_canvas_9", "OrderOfBattle\\oob_slot_canvas", 10, 10, 10, 10),
    ("top_panel_header_9", "OrderOfBattle\\top_panel_header", 40, 40, 0, 0),
    ("photo_mode_slider_fill_9", "PhotoMode\\photo_mode_slider_fill", 5, 5, 0, 0)
    
    
]

# ===========================================

def add_nine_region_sprites(xml_path):
    if not os.path.exists(xml_path):
        print(f"❌ Could not find {SPRITE_DATA_FILENAME}")
        return

    print(f"Processing: {xml_path}\n")

    tree = ET.parse(xml_path)
    root = tree.getroot()
    sprites_elem = root.find("Sprites")
    if sprites_elem is None:
        sprites_elem = ET.SubElement(root, "Sprites")

    added_count = 0

    for name, sprite_part, left, right, top, bottom in NINE_REGION_LIST:
        # IMPORTANT: Only add if the SpritePart actually exists in your file
        if not any(sprite_part in elem.text for elem in root.iter() if elem.text):
            print(f"   Skipped (SpritePart not found) → {name}")
            continue

        # Remove old version if exists
        existing = sprites_elem.find(f".//NineRegionSprite[Name='{name}']")
        if existing is not None:
            sprites_elem.remove(existing)

        # Add new NineRegionSprite
        nrs = ET.SubElement(sprites_elem, "NineRegionSprite")
        ET.SubElement(nrs, "Name").text = name
        ET.SubElement(nrs, "SpritePartName").text = sprite_part
        ET.SubElement(nrs, "LeftWidth").text = str(left)
        ET.SubElement(nrs, "RightWidth").text = str(right)
        ET.SubElement(nrs, "TopHeight").text = str(top)
        ET.SubElement(nrs, "BottomHeight").text = str(bottom)

        added_count += 1
        print(f"   Added → {name}")

    ET.indent(tree, space="    ")
    tree.write(xml_path, encoding="utf-8", xml_declaration=True)

    print(f"\n✅ Done! Added {added_count} NineRegionSprites.")

if __name__ == "__main__":
    print("=== Smart NineRegionSprite Injector ===\n")
    add_nine_region_sprites(SPRITE_DATA_PATH)