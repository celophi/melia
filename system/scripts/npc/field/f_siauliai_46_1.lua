----- Gate Route ----- 
----- Enter -----
addnpc(40001, "ETC_20150317_001182", "f_siauliai_46_1", -624, 262, -1920, 25, "npc_ETC_20150317_001182")
function npc_ETC_20150317_001182()
msg("SIAULIAI46_1_THORN19")
end

----- Uskis Arable Land ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009586", "f_siauliai_46_1", -1872, 260, -427, 225, "npc_ETC_20150323_009586")
function npc_ETC_20150323_009586()
msg("SIAULIAI46_1_SIAULIAI46_2")
end

----- Priest Dazine ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_MQ01_NPC -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_MQ_01 | SIAULIAI_46_1_MQ_02 | SIAULIAI_46_1_MQ_03 | SIAULIAI_46_1_MQ_04 -----
addnpc(147492, "QUEST_LV_0200_20150317_001109", "f_siauliai_46_1", -1353, 262, -156, -45, "npc_QUEST_LV_0200_20150317_001109")
function npc_QUEST_LV_0200_20150317_001109()
msg("SIAULIAI_46_1_MQ01_NPC_basic01")
msg("SIAULIAI_46_1_MQ01_NPC_basic02")
msg("SIAULIAI_46_1_MQ01_NPC_basic03")
msg("SIAULIAI_46_1_MQ01_NPC_basic04")
msg("SIAULIAI_46_1_MQ_01_select")
msg("SIAULIAI_46_1_MQ_01_AG")
msg("SIAULIAI_46_1_MQ_01_PG")
msg("SIAULIAI_46_1_add")
msg("SIAULIAI_46_1_MQ_02_succ")
msg("SIAULIAI_46_1_MQ_03_select")
msg("SIAULIAI_46_1_MQ_03_succ")
msg("SIAULIAI_46_1_MQ_04_select")
msg("SIAULIAI_46_1_MQ_04_add")
msg("SIAULIAI_46_1_MQ_04_start_prog")
end

----- Austeja Altar ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_ALTAR -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_MQ_02 | SIAULIAI_46_1_SQ_01 -----
addnpc(151024, "ETC_20150317_005345", "f_siauliai_46_1", -130, 325, 10, 135, "npc_ETC_20150317_005345")
function npc_ETC_20150317_005345()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Rankis Seal Tower ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_DEADTREE01 -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_MQ_04 | SIAULIAI_46_1_SQ_02 -----
addnpc(147501, "ETC_20150317_009498", "f_siauliai_46_1", -217, 235, -869, 0, "npc_ETC_20150317_009498")
function npc_ETC_20150317_009498()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Ranka Seal Tower ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_DEADTREE02 -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_MQ_05 -----
addnpc(147501, "ETC_20150317_009499", "f_siauliai_46_1", 311, 212, -871, -45, "npc_ETC_20150317_009499")
function npc_ETC_20150317_009499()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Merchant Dulke ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_SQ_03_NPC -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_SQ_03 -----
addnpc(20102, "QUEST_LV_0200_20150317_001123", "f_siauliai_46_1", -1776, 262, -1027, 46, "npc_QUEST_LV_0200_20150317_001123")
function npc_QUEST_LV_0200_20150317_001123()
msg("SIAULIAI_46_1_SQ_03_NPC_basic01")
msg("SIAULIAI_46_1_SQ_03_NPC_basic02")
msg("SIAULIAI_46_1_SQ_03_select")
msg("SIAULIAI_46_1_SQ_03_add")
msg("SIAULIAI_46_1_SQ_03_start_prog")
msg("SIAULIAI_46_1_SQ_03_succ")
end

----- Villager Emil ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_SQ_04_NPC -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_SQ_04 -----
addnpc(147484, "QUEST_LV_0200_20150317_001129", "f_siauliai_46_1", 1975, 390, 855, -75, "npc_QUEST_LV_0200_20150317_001129")
function npc_QUEST_LV_0200_20150317_001129()
msg("SIAULIAI_46_1_SQ_04_NPC_basic01")
msg("SIAULIAI_46_1_SQ_04_NPC_basic02")
msg("SIAULIAI_46_1_SQ_04_select")
msg("SIAULIAI_46_1_SQ_04_start_prog")
msg("SIAULIAI_46_1_SQ_04_succ")
end

----- Pharmacist Tiana ----- 
----- npcselectdialog.ies | ClassName: SIAULIAI_46_1_SQ_05_NPC -----
----- Dialog -----
----- QuestIDs: SIAULIAI_46_1_SQ_05 -----
addnpc(147493, "QUEST_LV_0200_20150317_001133", "f_siauliai_46_1", 1714, 390, 890, -45, "npc_QUEST_LV_0200_20150317_001133")
function npc_QUEST_LV_0200_20150317_001133()
msg("SIAULIAI_46_1_SQ_05_NPC_basic01")
msg("SIAULIAI_46_1_SQ_05_NPC_basic02")
msg("SIAULIAI_46_1_SQ_05_select")
msg("SIAULIAI_46_1_SQ_05_start_prog")
msg("SIAULIAI_46_1_SQ_05_succ")
end

----- Glade Hillroad ----- 
----- Enter -----
addnpc(40001, "ETC_20150714_011734", "f_siauliai_46_1", 586, 391, 1320, 155, "npc_ETC_20150714_011734")
function npc_ETC_20150714_011734()
msg("SIAULIAI46_1_THORN39_2")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_siauliai_46_1", 954, 391, 1021, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

