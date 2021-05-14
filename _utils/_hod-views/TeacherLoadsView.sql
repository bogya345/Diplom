
--DROP VIEW dbo.TeacherLoadsView;

--CREATE VIEW dbo.TeacherLoadsView
--AS

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

	--docs.eDoc_id,

	--docs.deg_id,
	--docs.deg_shortname,
	--docs.dep_name,

	--docs.rank_id,
	--docs.rankWhere,
	--docs.isAcademicRank,
	--docs.rank_name,

	attAcPl.blockRec_id,
	
	acPl.acPl_id,
	dirs.dir_id,
	dirs.eBr_id,
	dirs.eForm_id,
	eds.eBr_name,
	efs.eForm_name,

	recs.semestrNum,
	recs.inPlan,
	recs.sub_id,
	subs.sub_name,

	

	--attAcPl.group_id, -- no neccessary
	--groups.group_name,	-- no neccessary

	attAcPl.subT_id,
	subT.subT_name
 

FROM hod.dbo.AttachedAcPlans as attAcPl

	inner join hod.Import.FactStaffsHistory as fsh on fsh.fsh_id = attAcPl.fsh_id

	inner join hod.Import.FactStaffs as fs on fs.fs_id = fsh.fs_id

	inner join hod.Import.Employees as emps on emps.emp_id = fs.emp_id

	--left join (
	--	SELECT
	--		eed.emp_id,
	--		max(eed.eDoc_id) as eDoc_id,

	--		ed.deg_id,
	--		d.deg_shortname,
	--		d.dep_name,

	--		er.rank_id,
	--		er.rankWhere,
	--		r.isAcademicRank,
	--		r.rank_name

	--	FROM hod.Import.EmpEducDocs as eed

	--		inner join hod.Import.EducDocs as edoc on edoc.eDoc_id = eed.eDoc_id

	--		left join hod.Import.EmpDegrees as ed on ed.eDoc_id = eed.eDoc_id
	--		left join hod.Import.Degrees as d on d.deg_id = ed.deg_id

	--		left join hod.Import.EmpRanks as er on er.eDoc_id = eed.eDoc_id
	--		left join hod.Import.Ranks as r on r.rank_id = er.rank_id

	--	GROUP BY 
	--		eed.emp_id,
	--		--eed.eDoc_id,

	--		ed.deg_id,
	--		d.deg_shortname,
	--		d.dep_name,

	--		er.rank_id,
	--		er.rankWhere,
	--		r.isAcademicRank,
	--		r.rank_name

	--) as docs on docs.emp_id = emps.emp_id

	-- записи учебного плана
	inner join hod.dbo.BlockRecs as recs on recs.blockRec_id = attAcPl.blockRec_id
	-- предметы
	inner join hod.dbo.Subjects as subs on subs.sub_id = recs.sub_id

	inner join hod.dbo.AcPlans as acPl on acPl.acPl_id = recs.acPl_id
	inner join hod.Import.Directions as dirs on dirs.acPl_id = acPl.acPl_id
	inner join hod.Import.EducBranches as eds on eds.eBr_id = dirs.eBr_id
	inner join hod.Import.EducForms as efs on efs.eForm_id = dirs.eForm_id

	-- Группы
	inner join hod.Import.Groups as groups on groups.group_id = attAcPl.group_id
	-- типы дисциплин
	inner join hod.dbo.SubjectTypes as subT on subT.subT_id = attAcPl.subT_id

	-- 
	--inner join 

