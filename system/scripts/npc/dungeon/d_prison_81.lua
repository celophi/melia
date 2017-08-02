----- Solitary Cells ----- 
----- Enter -----
addnpc(40001, "ETC_20170330_027527", "d_prison_81", -1689, 169, -961, 224, "npc_ETC_20170330_027527")
function npc_ETC_20170330_027527()
msg("PRISON81_PRISON80")
end

----- Investigation Room ----- 
----- Enter -----
addnpc(40001, "ETC_20170330_027529", "d_prison_81", 499, 224, -740, 225, "npc_ETC_20170330_027529")
function npc_ETC_20170330_027529()
msg("PRISON81_PRISON82")
end

----- Statue of Goddess Vakarine ----- 
----- npcselectdialog.ies | ClassName: STOUP_CAMP -----
----- Enter | Dialog -----
----- QuestIDs: JOB_KRIVI4_3 -----
addnpc(40120, "QUEST_20150317_000002", "d_prison_81", 817, 192, -726, 45, "npc_QUEST_20150317_000002")
function npc_QUEST_20150317_000002()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
msg("WARP_D_PRISON_81")
end

----- Zanas' Soul ----- 
----- npcselectdialog.ies | ClassName: PRISON_81_NPC_1 -----
----- Dialog -----
----- QuestIDs: PRISON_81_MQ_1 | PRISON_81_MQ_2 -----
addnpc(151107, "ETC_20160723_022699", "d_prison_81", -1171, 169, -1044, 180, "npc_ETC_20160723_022699")
function npc_ETC_20160723_022699()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zanas' Soul ----- 
----- npcselectdialog.ies | ClassName: PRISON_81_NPC_2 -----
----- Dialog -----
----- QuestIDs: PRISON_81_MQ_4 | PRISON_81_MQ_5 | PRISON_81_MQ_6 -----
addnpc(151107, "ETC_20160723_022699", "d_prison_81", -890, 233, 1230, -45, "npc_ETC_20160723_022699")
function npc_ETC_20160723_022699()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Zanas' Soul ----- 
----- npcselectdialog.ies | ClassName: PRISON_81_NPC_3 -----
----- Dialog -----
----- QuestIDs: PRISON_81_MQ_8 | PRISON_81_MQ_9 -----
addnpc(151107, "ETC_20160723_022699", "d_prison_81", 898, 183, 940, 0, "npc_ETC_20160723_022699")
function npc_ETC_20160723_022699()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Demon Barrier ----- 
----- npcselectdialog.ies | ClassName: PRISON_81_MQ_10_TRIGGER -----
----- Enter | Dialog -----
----- QuestIDs: PRISON_81_MQ_10 | PRISON_81_MQ_10 -----
addnpc(147469, "ETC_20150317_009354", "d_prison_81", 584, 184, -168, 45, "npc_ETC_20150317_009354")
function npc_ETC_20150317_009354()
msg("GM_NPC_HIDE_UNHIDE")
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

----- Letter ----- 
----- npcselectdialog.ies | ClassName: PRISON_81_SQ_OBJ_1 -----
----- Dialog -----
----- QuestIDs: PRISON_81_SQ_1 -----
addnpc(147312, "QUEST_20151022_002807", "d_prison_81", 20, 170, 327, 45, "npc_QUEST_20151022_002807")
function npc_QUEST_20151022_002807()
msg("GM_QUEST_MODIFY_PC_SEL")
msg("GM_NPC_HIDE_UNHIDE")
end

