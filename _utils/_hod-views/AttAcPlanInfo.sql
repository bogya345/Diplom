
--DROP VIEW dbo.AttAcPlanInfo

--CREATE VIEW dbo.AttAcPlanInfo
--AS

SELECT 
--DISTINCT -- 
	attAcPl.attAcPl_id,

	attAcPl.blockRec_id,
	recs.semestrNum,
	recs.inPlan,
	recs.sub_id,
	subs.sub_name,


	attAcPl.group_id,
	groups.group_name,

	attAcPl.subT_id,
	subT.subT_name
 

FROM hod.dbo.AttachedAcPlans as attAcPl

	-- записи учебного плана
	inner join hod.dbo.BlockRecs as recs on recs.blockRec_id = attAcPl.blockRec_id
	-- предметы
	inner join hod.dbo.Subjects as subs on subs.sub_id = recs.sub_id


	-- Группы
	inner join hod.Import.Groups as groups on groups.group_id = attAcPl.group_id

	-- типы дисциплин
	inner join hod.dbo.SubjectTypes as subT on subT.subT_id = attAcPl.subT_id

	-- 
	--inner join 

