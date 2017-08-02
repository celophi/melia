----- Sirdgela Forest ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009572", "d_thorn_21", -412, 221, -37, -127, "npc_ETC_20150323_009572")
function npc_ETC_20150323_009572()
msg("THORN21_THORN20")
end

----- Believer Bronius ----- 
----- npcselectdialog.ies | ClassName: THORN21_BELIEVER -----
----- Dialog -----
----- QuestIDs: THORN21_MQ01 | THORN21_RP_2 -----
addnpc(147389, "QUEST_LV_0100_20150317_001989", "d_thorn_21", 3652, 401, -233, -51, "npc_QUEST_LV_0100_20150317_001989")
function npc_QUEST_LV_0100_20150317_001989()
msg("THORN21_MQ02_select01")
msg("THORN21_MQ02_startnpc_prog01")
msg("THORN21_MQ02_succ01")
msg("THORN21_MQ02_startnpc01")
msg("THORN21_BELIEVER02_basic01")
end

----- Sunset Flag Forest ----- 
----- Enter -----
addnpc(40001, "ETC_20150317_009282", "d_thorn_21", 985, 208, -1550, 315, "npc_ETC_20150317_009282")
function npc_ETC_20150317_009282()
msg("THORN21_THORN23")
end

----- Believer Samantha ----- 
----- npcselectdialog.ies | ClassName: THORN21_BELIEVER02 -----
----- Dialog -----
----- QuestIDs: THORN21_MQ02 -----
addnpc(147386, "QUEST_LV_0100_20150317_002081", "d_thorn_21", 692, 223, -945, 45, "npc_QUEST_LV_0100_20150317_002081")
function npc_QUEST_LV_0100_20150317_002081()
msg("THORN21_MQ02_select01")
msg("THORN21_MQ02_startnpc_prog01")
msg("THORN21_MQ02_succ01")
msg("THORN21_MQ02_startnpc01")
msg("THORN21_BELIEVER02_basic01")
end

----- Believer Kazis ----- 
----- npcselectdialog.ies | ClassName: THORN21_BELIEVER03 -----
----- Dialog -----
----- QuestIDs: THORN21_MQ06 | THORN21_RP_1 -----
addnpc(147398, "QUEST_LV_0100_20150317_002092", "d_thorn_21", 1498, 332, 151, 45, "npc_QUEST_LV_0100_20150317_002092")
function npc_QUEST_LV_0100_20150317_002092()
msg("THORN21_MQ06_select01")
msg("THORN21_MQ06_startnpc01")
msg("THORN21_MQ06_succ01")
msg("THORN21_MQ06_PG")
msg("THORN21_BELIEVER03_basic01")
msg("THORN21_BELIEVER03_basic02")
msg("THORN21_RP_1_1")
msg("THORN21_RP_1_2")
msg("THORN21_RP_1_3")
end

----- Believer Jurga ----- 
----- npcselectdialog.ies | ClassName: THORN21_BELIEVER04 -----
----- Dialog -----
----- QuestIDs: THORN21_MQ09 | THORN21_MQ04 | THORN21_MQ03 | THORN21_MQ05 -----
addnpc(147397, "QUEST_LV_0100_20150317_001991", "d_thorn_21", -111, 221, 116, 45, "npc_QUEST_LV_0100_20150317_001991")
function npc_QUEST_LV_0100_20150317_001991()
msg("THORN21_MQ03_succ01")
msg("THORN21_MQ04_select01")
msg("THORN21_MQ04_select_startnpc01")
msg("THORN21_MQ05_succ01")
msg("THORN21_MQ04_startnpc_prog")
msg("THORN21_MQ04_succ01")
msg("THORN21_MQ04_select_startnpc02")
msg("THORN21_MQ03_2_select01")
msg("THORN21_MQ03_2_startnpc_prog01")
msg("THORN21_MQ03_2_succ01")
msg("THORN21_MQ03_2_AG")
msg("THORN21_MQ07_select01")
msg("THORN21_MQ07_startnpc_prog01")
msg("THORN21_MQ07_startnpc01")
msg("THORN21_BELIEVER04_basic01")
msg("THORN21_BELIEVER04_after_basic01")
end

----- Believer Jurga ----- 
----- npcselectdialog.ies | ClassName: THORN21_BELIEVER04_AFTER -----
----- Dialog -----
----- QuestIDs: THORN21_MQ07 -----
addnpc(147397, "QUEST_LV_0100_20150317_001991", "d_thorn_21", 4566, 333, -58, 45, "npc_QUEST_LV_0100_20150317_001991")
function npc_QUEST_LV_0100_20150317_001991()
msg("THORN21_MQ03_succ01")
msg("THORN21_MQ04_select01")
msg("THORN21_MQ04_select_startnpc01")
msg("THORN21_MQ05_succ01")
msg("THORN21_MQ04_startnpc_prog")
msg("THORN21_MQ04_succ01")
msg("THORN21_MQ04_select_startnpc02")
msg("THORN21_MQ03_2_select01")
msg("THORN21_MQ03_2_startnpc_prog01")
msg("THORN21_MQ03_2_succ01")
msg("THORN21_MQ03_2_AG")
msg("THORN21_MQ07_select01")
msg("THORN21_MQ07_startnpc_prog01")
msg("THORN21_MQ07_startnpc01")
msg("THORN21_BELIEVER04_basic01")
msg("THORN21_BELIEVER04_after_basic01")
end

----- Bramble's Root ----- 
----- npcselectdialog.ies | ClassName: THORN21_BRAMBLE01_ROOT -----
----- Dialog -----
----- QuestIDs: THORN21_MQ03 -----
addnpc(153011, "ETC_20150317_007291", "d_thorn_21", 2800, 122, -1325, 32, "npc_ETC_20150317_007291")
function npc_ETC_20150317_007291()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Bramble's Root ----- 
----- npcselectdialog.ies | ClassName: THORN21_BRAMBLE02_ROOT -----
----- Dialog -----
----- QuestIDs: THORN21_MQ05 -----
addnpc(153011, "ETC_20150317_007291", "d_thorn_21", 3305, 332, 1084, 37, "npc_ETC_20150317_007291")
function npc_ETC_20150317_007291()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Altar of Purification ----- 
----- npcselectdialog.ies | ClassName: THORN21_MQ02_TRACK -----
----- Dialog -----
----- QuestIDs: THORN21_MQ02 -----
addnpc(46213, "ETC_20150317_005258", "d_thorn_21", 1012, 208, -1241, -62, "npc_ETC_20150317_005258")
function npc_ETC_20150317_005258()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Altar of Purification ----- 
----- npcselectdialog.ies | ClassName: THORN21_MQ06_TRACK -----
----- Dialog -----
----- QuestIDs: THORN21_MQ06 -----
addnpc(46213, "ETC_20150317_005258", "d_thorn_21", 2003, 331, -3, 45, "npc_ETC_20150317_005258")
function npc_ETC_20150317_005258()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Warning ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(40070, "QUEST_20150317_000566", "d_thorn_21", 1085, 208, -1446, 135, "npc_QUEST_20150317_000566")
function npc_QUEST_20150317_000566()
msg("UPPER_WARNING_D_THORN_21")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "d_thorn_21", -456, 221, -407, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

