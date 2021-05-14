
--DROP VIEW dbo.TeacherLoadSuitability;

CREATE VIEW dbo.TeacherLoadSuitability
AS

SELECT 
--DISTINCT -- 
	attAcPl.attAcPl_id,

	fsh.fsh_id,
	fsh.StaffCount,
	fs.fs_id,
	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	CONCAT(emps.LastName, ' ', emps.FIrstName, ' ', emps.MiddleName) as FullName,

	attAcPl.blockRec_id,
	
	acPl.acPl_id,
	dirs.dir_id,
	dirs.eBr_id,
	dirs.eForm_id,

	recs.semestrNum,
	recs.inPlan,
	recs.sub_id,
	subs.sub_name,

	attAcPl.subT_id,
	subT.subT_name,

	dgrs.eDoc_id as edDoc_id_d,
	dgrs.deg_id,
	dgrs.deg_shortname,
	dgrs.dep_name,

	rnks.eDoc_id as edDoc_id_r,
	rnks.rank_id,
	rnks.rankWhere,
	rnks.isAcademicRank,
	rnks.rank_name

FROM hod.dbo.AttachedAcPlans as attAcPl

	inner join hod.Import.FactStaffsHistory as fsh on fsh.fsh_id = attAcPl.fsh_id
	inner join hod.Import.FactStaffs as fs on fs.fs_id = fsh.fs_id
	inner join hod.Import.Employees as emps on emps.emp_id = fs.emp_id

	-- записи учебного плана
	inner join hod.dbo.BlockRecs as recs on recs.blockRec_id = attAcPl.blockRec_id
	-- предметы
	inner join hod.dbo.Subjects as subs on subs.sub_id = recs.sub_id

	inner join hod.dbo.AcPlans as acPl on acPl.acPl_id = recs.acPl_id
	inner join hod.Import.Directions as dirs on dirs.acPl_id = acPl.acPl_id

	-- типы дисциплин
	inner join hod.dbo.SubjectTypes as subT on subT.subT_id = attAcPl.subT_id

		inner join (

		SELECT 
			eed.emp_id,
			eed.eDoc_id,
			ed.deg_id,
			ed.diplWhere,
			ed.deg_date,
			ed.DissertCouncil,
			d.deg_Abbrev,
			d.dep_name,
			d.deg_shortname
		FROM hod.Import.EmpEducDocs as eed

		inner join hod.Import.EducDocs as edoc on edoc.eDoc_id = eed.eDoc_id

		inner join hod.Import.EmpDegrees as ed on ed.eDoc_id = eed.eDoc_id
		inner join hod.Import.Degrees as d on d.deg_id = ed.deg_id

	) as dgrs on dgrs.emp_id = emps.emp_id

	inner join (
		SELECT
			eed.emp_id,
			eed.eDoc_id,
			er.rank_id,
			er.rankWhere,
			r.rank_name,
			r.isAcademicRank
		FROM hod.Import.EmpEducDocs as eed

		inner join hod.Import.EducDocs as edoc on edoc.eDoc_id = eed.eDoc_id

		inner join hod.Import.EmpRanks as er on er.eDoc_id = eed.eDoc_id
		inner join hod.Import.Ranks as r on r.rank_id = er.rank_id

	) as rnks on rnks.emp_id = emps.emp_id

