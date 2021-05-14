
-- DROP VIEW dbo.TeacherEducDocs

CREATE VIEW dbo.TeacherEducDocs
AS

SELECT 
--DISTINCT -- 
	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	CONCAT(emps.LastName, ' ', emps.FIrstName, ' ', emps.MiddleName) as FullName,

	docs.eDoc_id,
	docs.eDocT_id,
	docs.eDocT_name,

	docs.deg_id,
	docs.deg_shortname,
	docs.dep_name,

	docs.rank_id,
	docs.rankWhere,
	docs.isAcademicRank,
	docs.rank_name
 

FROM hod.Import.Employees as emps

	left join (
		SELECT
			eed.emp_id,
			eed.eDoc_id,

			edoc.eDocT_id,
			edocT.eDocT_name,

			ed.deg_id,
			d.deg_shortname,
			d.dep_name,

			er.rank_id,
			er.rankWhere,
			r.isAcademicRank,
			r.rank_name

		FROM hod.Import.EmpEducDocs as eed
			inner join hod.Import.EducDocs as edoc on edoc.eDoc_id = eed.eDoc_id
			inner join hod.Import.EducDocTypes as edocT on edocT.eDocT_id = edoc.eDocT_id

			left join hod.Import.EmpDegrees as ed on ed.eDoc_id = eed.eDoc_id
			left join hod.Import.Degrees as d on d.deg_id = ed.deg_id

			left join hod.Import.EmpRanks as er on er.eDoc_id = eed.eDoc_id
			left join hod.Import.Ranks as r on r.rank_id = er.rank_id

		--GROUP BY

	) as docs on docs.emp_id = emps.emp_id

