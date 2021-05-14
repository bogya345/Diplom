
--DROP VIEW dbo.TeacherSuitability;

CREATE VIEW dbo.TeacherSuitability
AS

SELECT 
--DISTINCT -- 
	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	CONCAT(emps.LastName, ' ', emps.FIrstName, ' ', emps.MiddleName) as FullName,

	dgrs.eDoc_id as edDoc_id_d,
	dgrs.deg_id,
	dgrs.deg_shortname,
	dgrs.dep_name,

	rnks.eDoc_id as edDoc_id_r,
	rnks.rank_id,
	rnks.rankWhere,
	rnks.isAcademicRank,
	rnks.rank_name
 

FROM hod.Import.Employees as emps

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

