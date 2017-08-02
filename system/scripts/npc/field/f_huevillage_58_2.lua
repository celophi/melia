----- Old Man of Andale Village ----- 
----- npcselectdialog.ies | ClassName: HUEVILLAGE_58_2_MQ01_NPC -----
----- Dialog -----
----- QuestIDs: HUEVILLAGE_58_2_MQ01 -----
addnpc(147396, "QUEST_LV_0100_20150317_001999", "f_huevillage_58_2", -187, 274, -1571, 27.47, "npc_QUEST_LV_0100_20150317_001999")
function npc_QUEST_LV_0100_20150317_001999()
msg("HUEVILLAGE_58_2_MQ01_select")
msg("HUEVILLAGE_58_2_MQ01_startnpc")
msg("HUEVILLAGE_58_2_MQ01_startnpc_succ")
msg("HUEVILLAGE_58_2_MQ01_select_Q")
msg("HUEVILLAGE58_2_CHIEF_basic01")
msg("HUEVILLAGE58_2_CHIEF_basic02")
end

----- Andale Village Priest ----- 
----- npcselectdialog.ies | ClassName: HUEVILLAGE_58_2_MQ02_NPC -----
----- Dialog -----
----- QuestIDs: HUEVILLAGE_58_2_MQ01 | HUEVILLAGE_58_2_MQ02 | HUEVILLAGE_58_2_MQ04 -----
addnpc(147409, "QUEST_LV_0100_20150317_002003", "f_huevillage_58_2", -239, 0, -200, 27.39, "npc_QUEST_LV_0100_20150317_002003")
function npc_QUEST_LV_0100_20150317_002003()
msg("HUEVILLAGE_58_2_MQ01_succ")
msg("HUEVILLAGE_58_2_MQ02_select01")
msg("HUEVILLAGE_58_2_MQ02_startnpc")
msg("HUEVILLAGE_58_2_MQ04_select01")
msg("HUEVILLAGE_58_2_MQ04_select01_Q")
msg("HUEVILLAGE_58_2_MQ04_startnpc")
msg("HUEVILLAGE_58_2_MQ04_startnpc_succ")
msg("HUEVILLAGE_58_2_MQ02_select01_Q")
msg("HUEVILLAGE_58_2_MQ04_add")
msg("HUEVILLAGE58_2_PEAPLE_basic01")
msg("HUEVILLAGE58_2_PEAPLE_basic02")
msg("HUEVILLAGE58_2_PEAPLE_MQ01")
end

----- Wood Sap Container ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(151028, "ETC_20150317_009347", "f_huevillage_58_2", -89, 41, 1399, 45, "npc_ETC_20150317_009347")
function npc_ETC_20150317_009347()
msg("HUEVILLAGE_58_2_MQ02_BUCKET01")
end

----- Wood Sap Container ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(151028, "ETC_20150317_009347", "f_huevillage_58_2", -243, 41, 1305, 45, "npc_ETC_20150317_009347")
function npc_ETC_20150317_009347()
msg("HUEVILLAGE_58_2_MQ02_BUCKET01")
end

----- Wood Sap Container ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(151028, "ETC_20150317_009347", "f_huevillage_58_2", -345, 41, 1134, 45, "npc_ETC_20150317_009347")
function npc_ETC_20150317_009347()
msg("HUEVILLAGE_58_2_MQ02_BUCKET01")
end

----- Wood Sap Container ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(151028, "ETC_20150317_009347", "f_huevillage_58_2", 83, 41, 1278, 45, "npc_ETC_20150317_009347")
function npc_ETC_20150317_009347()
msg("HUEVILLAGE_58_2_MQ02_BUCKET01")
end

----- Wood Sap Container ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147354, "ETC_20150317_009347", "f_huevillage_58_2", 181, 41, 1363, 45, "npc_ETC_20150317_009347")
function npc_ETC_20150317_009347()
msg("HUEVILLAGE_58_2_MQ02_BUCKET02")
end

----- Ershike Altar ----- 
----- npcselectdialog.ies | ClassName: HUEVILLAGE_58_2_MQ03_NPC -----
----- Dialog -----
----- QuestIDs: HUEVILLAGE_58_2_MQ03 | HUEVILLAGE_58_2_SQ02 -----
addnpc(147417, "ETC_20150323_009812", "f_huevillage_58_2", -439, 50, 234, 0, "npc_ETC_20150323_009812")
function npc_ETC_20150323_009812()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Obelisk ----- 
----- npcselectdialog.ies | ClassName: HUEVILLAGE_58_2_OBELISK_BEFORE -----
----- Dialog -----
----- QuestIDs: HUEVILLAGE_58_2_MQ04 | HUEVILLAGE_58_2_SQ03 -----
addnpc(147414, "ETC_20150317_007189", "f_huevillage_58_2", 859, 0, 205, -25, "npc_ETC_20150317_007189")
function npc_ETC_20150317_007189()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Veja Ravine ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009562", "f_huevillage_58_2", 440, 274, -1641, 50, "npc_ETC_20150323_009562")
function npc_ETC_20150323_009562()
msg("HUEVILLAGE58_2_TO_HUEVILLAGE58_1")
end

----- Cobalt Forest ----- 
----- Enter -----
addnpc(40001, "QUEST_JOBSTEP_20150323_002351", "f_huevillage_58_2", 1462, -10, 1157, 128, "npc_QUEST_JOBSTEP_20150323_002351")
function npc_QUEST_JOBSTEP_20150323_002351()
msg("HUEVILLAGE58_2_TO_HUEVILLAGE58_3")
end

----- Gravestone ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(47192, "QUEST_20150317_000348", "f_huevillage_58_2", -254, 53, 250, 46, "npc_QUEST_20150317_000348")
function npc_QUEST_20150317_000348()
msg("HUEVILLAGE_58_2_STORN01_DLG")
end

----- Statue of Goddess Vakarine ----- 
----- npcselectdialog.ies | ClassName: STOUP_CAMP -----
----- Enter | Dialog -----
----- QuestIDs: JOB_KRIVI4_3 -----
addnpc(40120, "QUEST_20150317_000002", "f_huevillage_58_2", -516, 272, -1542, 80, "npc_QUEST_20150317_000002")
function npc_QUEST_20150317_000002()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
msg("WARP_F_HUEVILLAGE_58_2")
end

----- Obelisk ----- 
----- Enter -----
addnpc(147414, "ETC_20150317_007189", "f_huevillage_58_2", 859, 0, 205, -25, "npc_ETC_20150317_007189")
function npc_ETC_20150317_007189()
msg("HUEVILLAGE_58_2_OBELISK_AFTER")
end

----- Gytis Settlement Area ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009621", "f_huevillage_58_2", -390, 272, -1618, -53, "npc_ETC_20150323_009621")
function npc_ETC_20150323_009621()
msg("HUEVILLAGE_58_2_SIAUL50_1")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_huevillage_58_2", -862, 6, 203, -45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_huevillage_58_2", -160, 274, -1274, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

