----- Tiltas Valley ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009576", "f_rokas_29", 2612, 469, 819, 135, "npc_ETC_20150323_009576")
function npc_ETC_20150323_009576()
msg("ROKAS29_ROKAS28")
end

----- King's Plateau ----- 
----- Enter -----
addnpc(40001, "ETC_20150317_001194", "f_rokas_29", -1413, 617, -2079, -107, "npc_ETC_20150317_001194")
function npc_ETC_20150317_001194()
msg("ROKAS29_ROKAS30")
end

----- Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_HALF_SUCCESS1 -----
----- Enter | Dialog -----
addnpc(47413, "QUEST_LV_0100_20150317_000516", "f_rokas_29", -770, 617, -1564, 45, "npc_QUEST_LV_0100_20150317_000516")
function npc_QUEST_LV_0100_20150317_000516()
msg("GM_NPC_HIDE_UNHIDE")
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Adventurer Varkis ----- 
----- npcselectdialog.ies | ClassName: VACYS_LIVE -----
----- Dialog -----
----- QuestIDs: ROKAS29_VACYS1 | ROKAS29_VACYS2 -----
addnpc(152000, "QUEST_LV_0100_20150317_001306", "f_rokas_29", 1641, 471, 758, 315, "npc_QUEST_LV_0100_20150317_001306")
function npc_QUEST_LV_0100_20150317_001306()
msg("VACYS_LIVE_BASIC01")
msg("ROKAS29_VACYS1_select1")
msg("ROKAS29_VACYS1_prog1")
msg("ROKAS29_VACYS2_succ1")
msg("ROKAS29_VACYS3_agree1")
msg("ROKAS29_VACYS9_succ2")
end

----- Adventurer's Bag ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_BAG -----
----- Dialog -----
----- QuestIDs: ROKAS29_VACYS1 -----
addnpc(47161, "ETC_20150317_009461", "f_rokas_29", 2265, 472, 220, 45, "npc_ETC_20150317_009461")
function npc_ETC_20150317_009461()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Bonfire ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_FIRE -----
----- Dialog -----
----- QuestIDs: ROKAS29_VACYS6 -----
addnpc(46011, "ETC_20150317_000359", "f_rokas_29", 163, 681, 769, 45, "npc_ETC_20150317_000359")
function npc_ETC_20150317_000359()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Adventurer Varkis' Spirit ----- 
----- npcselectdialog.ies | ClassName: VACYS_SOUL -----
----- Dialog -----
----- QuestIDs: ROKAS29_VACYS3 | ROKAS29_VACYS4 | ROKAS29_VACYS5 | ROKAS29_VACYS6 -----
addnpc(152000, "ETC_20150317_009462", "f_rokas_29", 169, 681, 792, 315, "npc_ETC_20150317_009462")
function npc_ETC_20150317_009462()
msg("VACYS_SOUL_basic1")
msg("VACYS_SOUL_basic2")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER1 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ1 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", 2332, 468, 666, 45, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("ROKAS29_MQ_REXITHER1_BASIC01")
msg("ROKAS29_MQ1_select")
msg("ROKAS29_MQ1_succ01")
msg("ROKAS29_MQ1_startnpc_01")
msg("ROKAS29_MQ2_select")
msg("ROKAS29_MQ2_startnpc02")
msg("ROKAS29_MQ3_select01")
msg("ROKAS29_MQ3_startnpc01")
msg("ROKAS29_MQ3_succ01")
msg("ROKAS29_MQ4_select01")
msg("ROKAS29_MQ4_startnpc_01")
msg("ROKAS29_MQ4_succ01")
msg("ROKAS29_MQ5_select")
msg("ROKAS29_MQ5_startnpc01")
msg("ROKAS29_MQ5_succ01")
msg("ROKAS29_MQ6_select01")
msg("ROKAS29_MQ6_startnpc01")
msg("ROKAS29_MQ1_select_Q")
msg("ROKAS29_MQ2_succ02")
msg("ROKAS29_MQ_REXITHER2_BASIC01")
msg("ROKAS29_MQ_REXITHER6_BASIC01")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER6 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ6 | ROKAS29_MQ5 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", -384, 681, -413, 45, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("ROKAS29_MQ_REXITHER1_BASIC01")
msg("ROKAS29_MQ1_select")
msg("ROKAS29_MQ1_succ01")
msg("ROKAS29_MQ1_startnpc_01")
msg("ROKAS29_MQ2_select")
msg("ROKAS29_MQ2_startnpc02")
msg("ROKAS29_MQ3_select01")
msg("ROKAS29_MQ3_startnpc01")
msg("ROKAS29_MQ3_succ01")
msg("ROKAS29_MQ4_select01")
msg("ROKAS29_MQ4_startnpc_01")
msg("ROKAS29_MQ4_succ01")
msg("ROKAS29_MQ5_select")
msg("ROKAS29_MQ5_startnpc01")
msg("ROKAS29_MQ5_succ01")
msg("ROKAS29_MQ6_select01")
msg("ROKAS29_MQ6_startnpc01")
msg("ROKAS29_MQ1_select_Q")
msg("ROKAS29_MQ2_succ02")
msg("ROKAS29_MQ_REXITHER2_BASIC01")
msg("ROKAS29_MQ_REXITHER6_BASIC01")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER2 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ1 | ROKAS29_MQ2 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", 1081, 658, -785, -22, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("ROKAS29_MQ_REXITHER1_BASIC01")
msg("ROKAS29_MQ1_select")
msg("ROKAS29_MQ1_succ01")
msg("ROKAS29_MQ1_startnpc_01")
msg("ROKAS29_MQ2_select")
msg("ROKAS29_MQ2_startnpc02")
msg("ROKAS29_MQ3_select01")
msg("ROKAS29_MQ3_startnpc01")
msg("ROKAS29_MQ3_succ01")
msg("ROKAS29_MQ4_select01")
msg("ROKAS29_MQ4_startnpc_01")
msg("ROKAS29_MQ4_succ01")
msg("ROKAS29_MQ5_select")
msg("ROKAS29_MQ5_startnpc01")
msg("ROKAS29_MQ5_succ01")
msg("ROKAS29_MQ6_select01")
msg("ROKAS29_MQ6_startnpc01")
msg("ROKAS29_MQ1_select_Q")
msg("ROKAS29_MQ2_succ02")
msg("ROKAS29_MQ_REXITHER2_BASIC01")
msg("ROKAS29_MQ_REXITHER6_BASIC01")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER3 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ3 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", 1764, 471, 464, 315, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER4 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ3 | ROKAS29_MQ4 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", -66, 682, 575, 45, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Historian Rexipher ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_REXITHER5 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ4 | ROKAS29_MQ5 -----
addnpc(47413, "QUEST_LV_0100_20150317_001308", "f_rokas_29", -666, 682, 390, 45, "npc_QUEST_LV_0100_20150317_001308")
function npc_QUEST_LV_0100_20150317_001308()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zachariel's Epitaph ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_DEVICE1 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ1 -----
addnpc(153053, "ETC_20150804_014186", "f_rokas_29", 1073, 658, -820, -18, "npc_ETC_20150804_014186")
function npc_ETC_20150804_014186()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zachariel's Epitaph ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_DEVICE2 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ2 | ROKAS29_MQ2_BRIDGE -----
addnpc(153053, "ETC_20150804_014186", "f_rokas_29", 1343, 470, 311, -18, "npc_ETC_20150804_014186")
function npc_ETC_20150804_014186()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zachariel's Epitaph ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_DEVICE4 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ4 | ROKAS29_MQ4_BRIDGE -----
addnpc(153053, "ETC_20150804_014186", "f_rokas_29", -680, 681, 360, -18, "npc_ETC_20150804_014186")
function npc_ETC_20150804_014186()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zachariel's Epitaph ----- 
----- npcselectdialog.ies | ClassName: ROKAS29_MQ_DEVICE5 -----
----- Dialog -----
----- QuestIDs: ROKAS29_MQ5 -----
addnpc(153053, "ETC_20150804_014186", "f_rokas_29", -332, 680, -398, -18, "npc_ETC_20150804_014186")
function npc_ETC_20150804_014186()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Mullers Passage ----- 
----- Enter -----
addnpc(40001, "ETC_20150317_001311", "f_rokas_29", -2114, 782, 1614, 135, "npc_ETC_20150317_001311")
function npc_ETC_20150317_001311()
msg("ROKAS29_PCATACOMB1")
end

----- Epitaph ----- 
addnpc(47190, "QUEST_20150317_000341", "f_rokas_29", -484, 617, -2083, 60, "npc_dummy")

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "f_rokas_29", 1115, 658, -1202, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

