
--DROP VIEW dbo.TeacherSuitability;

--CREATE VIEW dbo.TeacherSuitability
--AS

SELECT 
--DISTINCT -- 
	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	CONCAT(emps.LastName, ' ', emps.FIrstName, ' ', emps.MiddleName) as FullName,

	edoc.eDoc_id,

	ed.deg_id,
	d.deg_shortname,
	d.dep_name,

	er.rank_id,
	er.rankWhere,
	r.isAcademicRank,
	r.rank_name
 

FROM hod.Import.Employees as emps

	inner join hod.Import.EmpEducDocs as eed on eed.emp_id = emps.emp_id

	inner join (

		SELECT 

		FROM hod.Import.EmpEducDocs as eed

		inner join hod.Import.EducDocs as edoc on edoc.eDoc_id = eed.eDoc_id

		left join hod.Import.EmpDegrees as ed on ed.eDoc_id = eed.eDoc_id
		left join hod.Import.Degrees as d on d.deg_id = ed.deg_id

		left join hod.Import.EmpRanks as er on er.eDoc_id = eed.eDoc_id
		left join hod.Import.Ranks as r on r.rank_id = er.rank_id

	)

