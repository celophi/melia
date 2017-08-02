----- Myrkiti Farm ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009638", "f_siauliai_47_4", -2167, 110, -154, -129, "npc_ETC_20150323_009638")
function npc_ETC_20150323_009638()
msg("SIAUL47_4_TO_FARM_47_3")
end

----- Gytis Settlement Area ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009621", "f_siauliai_47_4", 2445, 210, -1355, -50, "npc_ETC_20150323_009621")
function npc_ETC_20150323_009621()
msg("SIAUL47_4_TO_SIAUL50_1")
end

----- Tenants' Farm ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009636", "f_siauliai_47_4", 653, 110, 1596, 140, "npc_ETC_20150323_009636")
function npc_ETC_20150323_009636()
msg("SIAUL47_4_TO_FARM_47_1")
end

----- Tadas ----- 
----- npcselectdialog.ies | ClassName: FARM47_TADAS -----
----- Dialog -----
----- QuestIDs: FARM47_4_SQ_010 | FARM47_4_SQ_020 | FARM47_4_SQ_050 -----
addnpc(20144, "QUEST_LV_0200_20150323_003464", "f_siauliai_47_4", 1409, 87, -166, -13, "npc_QUEST_LV_0200_20150323_003464")
function npc_QUEST_LV_0200_20150323_003464()
msg("FARM47_4_SQ_010_ADD")
msg("FARM47_4_SQ_010_AC")
msg("FARM47_4_SQ_010_PRST")
msg("FARM47_4_SQ_010_COMP")
msg("FARM47_4_SQ_010_ST")
msg("FARM47_4_SQ_020_ST")
msg("FARM47_4_SQ_020_ADD")
msg("FARM47_4_SQ_020_AC")
msg("FARM47_4_SQ_020_PRST")
msg("FARM47_4_SQ_050_COMP")
msg("FARM47_TADAS_BASIC01")
msg("FARM47_TADAS_BASIC02")
msg("FARM47_TADAS_BASIC03")
msg("FARM47_TADAS_BASIC04")
end

----- Stepas ----- 
----- npcselectdialog.ies | ClassName: FARM47_STEPAS -----
----- Dialog -----
----- QuestIDs: FARM47_4_SQ_060 | FARM47_4_SQ_070 | FARM47_4_SQ_080 -----
addnpc(20143, "QUEST_LV_0200_20150323_003406", "f_siauliai_47_4", 323, 197, -684, 19, "npc_QUEST_LV_0200_20150323_003406")
function npc_QUEST_LV_0200_20150323_003406()
msg("FARM47_4_SQ_060_ST")
msg("FARM47_4_SQ_060_ADD")
msg("FARM47_4_SQ_060_AC")
msg("FARM47_4_SQ_060_PRST")
msg("FARM47_4_SQ_060_COMP")
msg("FARM47_4_SQ_070_ST")
msg("FARM47_4_SQ_070_AC")
msg("FARM47_4_SQ_070_PRST")
msg("FARM47_4_SQ_080_COMP")
msg("FARM47_STEPAS_BASIC01")
msg("FARM47_STEPAS_BASIC02")
end

----- Jaunius ----- 
----- npcselectdialog.ies | ClassName: FARM47_JAUNIUS -----
----- Dialog -----
----- QuestIDs: FARM47_4_SQ_030 | FARM47_4_SQ_040 | FARM47_4_SQ_050 -----
addnpc(20117, "QUEST_LV_0200_20150323_003399", "f_siauliai_47_4", 579, 87, -1443, 135, "npc_QUEST_LV_0200_20150323_003399")
function npc_QUEST_LV_0200_20150323_003399()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Marius ----- 
----- npcselectdialog.ies | ClassName: FARM47_MARIUS -----
----- Dialog -----
----- QuestIDs: FARM47_4_SQ_090 | FARM47_4_SQ_100 | FARM47_4_SQ_120 -----
addnpc(20118, "QUEST_LV_0200_20150323_003422", "f_siauliai_47_4", -1135, 110, -883, 45, "npc_QUEST_LV_0200_20150323_003422")
function npc_QUEST_LV_0200_20150323_003422()
msg("FARM47_4_SQ_090_ST")
msg("FARM47_4_SQ_090_AC")
msg("FARM47_4_SQ_090_PROG")
msg("FARM47_4_SQ_090_COMPST")
msg("FARM47_4_SQ_090_NOITEM")
msg("FARM47_4_SQ_090_ITEM")
msg("FARM47_4_SQ_090_CORRUPT_ITEM")
msg("FARM47_4_SQ_100_COMP")
msg("FARM47_4_SQ_120_ST")
msg("FARM47_4_SQ_120_ST_2")
msg("FARM47_4_SQ_120_AC")
msg("FARM47_4_SQ_120_PRST")
msg("FARM47_4_SQ_120_COMP")
msg("FARM47_4_SQ_120_COMP_2")
msg("FARM47_MARIUS_BASIC01")
msg("FARM47_MARIUS_BASIC02")
end

----- Dalius ----- 
----- npcselectdialog.ies | ClassName: FARM47_DALIUS -----
----- Enter | Dialog -----
----- QuestIDs: FARM47_4_SQ_080 | FARM47_4_SQ_070 | FARM47_4_SQ_090 | FARM47_4_SQ_100 -----
addnpc(20138, "QUEST_LV_0200_20150323_003416", "f_siauliai_47_4", -598, 103, 806, 59, "npc_QUEST_LV_0200_20150323_003416")
function npc_QUEST_LV_0200_20150323_003416()
msg("FARM47_DALIUS_CORRUPT")
msg("FARM47_4_SQ_070_COMP")
msg("FARM47_4_SQ_080_ST")
msg("FARM47_4_SQ_080_COMPST")
msg("FARM47_4_SQ_080_COMP_MSG")
msg("FARM47_4_SQ_090_COMP")
msg("FARM47_4_SQ_090_CORRUPT")
msg("FARM47_4_SQ_100_ST")
msg("FARM47_4_SQ_100_AC")
msg("FARM47_4_SQ_100_PRST")
msg("FARM47_4_SQ_100_COMPST")
msg("FARM47_DALIUS_basic02")
msg("FARM47_DALIUS_basic01")
end

----- Sleeping Scorpio ----- 
----- npcselectdialog.ies | ClassName: FARM47_SCORPIO -----
----- Dialog -----
----- QuestIDs: FARM47_4_SQ_060 -----
addnpc(152021, "ETC_20150323_010410", "f_siauliai_47_4", 1456, 16, 935, 224, "npc_ETC_20150323_010410")
function npc_ETC_20150323_010410()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_siauliai_47_4", 2146, 210, -768, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

----- Laterous ----- 
----- npcselectdialog.ies | ClassName: SIAU474_RP_1_NPC -----
----- Dialog -----
----- QuestIDs: SIAU474_RP_1 -----
addnpc(20139, "QUEST_LV_0100_20160718_015077", "f_siauliai_47_4", 582, 204, 54, 45, "npc_QUEST_LV_0100_20160718_015077")
function npc_QUEST_LV_0100_20160718_015077()
msg("SIAU474_RP_1_1")
msg("SIAU474_RP_1_2")
msg("SIAU474_RP_1_3")
msg("SIAU474_RP_1_NPC_basic1")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_siauliai_47_4", 1152, 44, 171, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

