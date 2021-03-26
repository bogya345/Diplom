
DROP VIEW dbo.TeacherInfo

CREATE VIEW dbo.TeacherInfo
AS

SELECT
	teachs.fsh_id, 

	emps.emp_id,
	emps.LastName,
	emps.FirstName,
	emps.Otch,

	ranks.educDoc_id as educDOc_rank,
	ranks.rank_name,

	degs.educDoc_id as educDoc_degree,
	degs.deg_name

FROM hod.Import.KafTeachers as teachs
	
	-- Сотрудники (тут интересны только преподаватели, так как нужно найти документы обучения)
	left join hod.Import.Employees as emps on emps.emp_id = teachs.emp_id

	-- Отношение Сотрудник - Документ об обучении
	left join hod.Import.EmpEducDocs as empDocs on empDocs.emp_id = teachs.emp_id

	-- Документы об образовании
	left join hod.Import.EducDocs as educDocs on educDocs.educDoc_id = empDocs.educDoc_id

	-- Тип документа об образования
	left join hod.Import.EducDocTypes as eDocT on eDocT.educDocType_id = educDocs.educDocType_id

	left join (
		SELECT 
			educDocs.educDoc_id,
			emps.emp_id,
			ranks.rank_id,
			ranks.rank_name
		--FROM hod.Import.EducDocs as educDocs
		FROM hod.Import.Employees as emps
		-- Отношение сотрудника - Ranks?
		inner join hod.Import.EmpRanks as empRanks on empRanks.emp_id = emps.emp_id
		inner join hod.Import.EducDocs as educDocs on educDocs.educDoc_id = empRanks.educDoc_id
		-- Ranks?
		inner join hod.Import.Ranks as ranks on ranks.rank_id = empRanks.rank_id
	) as ranks on ranks.emp_id = emps.emp_id

	left join (
		SELECT 
			empDegs.educDoc_id,
			emps.emp_id,
			degs.deg_name
		--FROM hod.Import.EducDocs as educDocs
		FROM hod.Import.Employees as emps
		-- Отношение сотрудника - Degrees?
		inner join hod.Import.EmpDegrees as empDegs on empDegs.emp_id = emps.emp_id
		-- Degrees?
		inner join hod.Import.Degrees as degs on degs.deg_id = empDegs.deg_id
		-- Science Types?
		--inner join hod.Import.ScienceTypes as sciT on sciT.sciType_id = empDegs.sciType_id
		-- List Speciality?
		--inner join hod.Import.ListSpecialities as ls on ls.listSpec_id = empDegs.listSpec_id
	) as degs on degs.emp_id = emps.emp_id
	

--GROUP BY