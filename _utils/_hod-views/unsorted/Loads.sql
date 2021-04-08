
DROP VIEW Loads

CREATE VIEW Loads
AS

SELECT
	teachs.fsh_id,
	teachs.dep_guid,
	teachs.post_guid,

	loads.LoadValue,
	--loads.

	recs.acPlan_id,
	recs.blockRec_id,

	subs.sub_id,
	subs.sub_name,
	subType.subType_id,
	subType.subType_name

FROM hod.Import.KafTeachers as teachs

	-- Нагрузка преподаваталей
	inner join hod.dbo.TeacherLoads as loads on loads.fsh_id = teachs.fsh_id

	-- Виды предметов
	inner join hod.dbo.SubjectTypes as subType on subType.subType_id = loads.subType_id

	-- Запись в учебном плане (дисциплина - часы - все семестры...)
	inner join hod.dbo.BlockRecs as recs on recs.blockRec_id = loads.blocRec_id

	-- Предметы
	inner join hod.dbo.Subjects as subs on subs.sub_id = recs.sub_id