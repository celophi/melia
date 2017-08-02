----- Tenet Garden ----- 
----- Enter -----
addnpc(40001, "ETC_20150323_009561", "d_chapel_57_5", -1258, 1, 1163, 135, "npc_ETC_20150323_009561")
function npc_ETC_20150323_009561()
msg("CHAPEL575_GELE574")
end

----- Tenet Church 1F ----- 
----- Enter -----
addnpc(40001, "ETC_20150317_001164", "d_chapel_57_5", 627, 1, -565, 135, "npc_ETC_20150317_001164")
function npc_ETC_20150317_001164()
msg("CHAPEL575_CHAPEL576")
end

----- Follower Tomas ----- 
----- npcselectdialog.ies | ClassName: CHAPEL_TOMAS -----
----- Dialog -----
----- QuestIDs: CHAPLE575_MQ_04 | CHAPLE575_MQ_02 | CHAPLE575_MQ_03 -----
addnpc(147399, "QUEST_LV_0100_20150317_000784", "d_chapel_57_5", -489, -38, 618, -45, "npc_QUEST_LV_0100_20150317_000784")
function npc_QUEST_LV_0100_20150317_000784()
msg("CHAPLE575_MQ_02_01")
msg("CHAPLE575_MQ_02_02")
msg("CHAPLE575_MQ_04_03")
msg("CHAPLE575_MQ_03_01")
msg("CHAPLE575_MQ_03_02")
msg("CHAPLE575_MQ_03_03")
msg("CHAPLE575_MQ_02_03")
msg("CHAPLE575_MQ_04_01")
msg("CHAPEL_TOMAS_BASIC01")
end

----- Follower Tiberius ----- 
----- npcselectdialog.ies | ClassName: CHAPEL_TABERIJUS -----
----- Dialog -----
----- QuestIDs: CHAPLE575_MQ_05 | CHAPLE575_MQ_06 -----
addnpc(147400, "QUEST_LV_0100_20150317_000787", "d_chapel_57_5", 140, -39, 588, -45, "npc_QUEST_LV_0100_20150317_000787")
function npc_QUEST_LV_0100_20150317_000787()
msg("CHAPLE575_MQ_05_01")
msg("CHAPLE575_MQ_05_02")
msg("CHAPLE575_MQ_06_01")
msg("CHAPLE575_MQ_06_02")
msg("CHAPLE575_MQ_06_01_AG")
msg("CHAPLE575_MQ_05_AG")
msg("CHAPLE575_MQ_05_03")
msg("CHAPLE575_MQ_06_03")
msg("CHAPEL_TABERIJUS_BASIC01")
msg("CHAPEL_TABERIJUS_BASIC03")
end

----- Follower Vaidas ----- 
----- npcselectdialog.ies | ClassName: CHAPEL_VIDAS -----
----- Dialog -----
----- QuestIDs: CHAPLE575_MQ_09 | CHAPLE575_MQ_07 | CHAPLE575_MQ_08 -----
addnpc(147400, "QUEST_LV_0100_20150317_000780", "d_chapel_57_5", -360, 1, -94, -11, "npc_QUEST_LV_0100_20150317_000780")
function npc_QUEST_LV_0100_20150317_000780()
msg("CHAPEL_VIDAS_basic_01")
msg("CHAPLE575_MQ_07_01")
msg("CHAPLE575_MQ_07_02")
msg("CHAPLE575_MQ_08_02")
msg("CHAPLE575_MQ_08_03")
msg("CHAPLE575_MQ_07_AG")
msg("CHAPLE575_MQ_07_03")
msg("CHAPLE575_MQ_08_01")
end

----- Underground Central Altar ----- 
----- Enter -----
addnpc(147358, "ETC_20150317_009231", "d_chapel_57_5", -600, -17, 422, 0, "npc_ETC_20150317_009231")
function npc_ETC_20150317_009231()
msg("CHAPEL575_BASIC_1")
end

----- Statue of Goddess Vakarine ----- 
----- npcselectdialog.ies | ClassName: STOUP_CAMP -----
----- Enter | Dialog -----
----- QuestIDs: JOB_KRIVI4_3 -----
addnpc(40120, "QUEST_20150317_000002", "d_chapel_57_5", -1430, 1, 1034, 30.96, "npc_QUEST_20150317_000002")
function npc_QUEST_20150317_000002()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
msg("WARP_D_CHAPEL_57_5")
end

----- Altar of Purification ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147357, "ETC_20150317_005258", "d_chapel_57_5", 439, 1, -109, 0, "npc_ETC_20150317_005258")
function npc_ETC_20150317_005258()
msg("CHAPLE575_MQ_05_01")
end

----- Lv1 Treasure Chest ----- 
----- npcselectdialog.ies | ClassName:  -----
----- Dialog -----
addnpc(147392, "ETC_20150317_009100", "d_chapel_57_5", 814, 1, -988, 45, "npc_ETC_20150317_009100")
function npc_ETC_20150317_009100()
msg("TREASUREBOX_LV")
end

