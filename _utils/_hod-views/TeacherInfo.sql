
SELECT 
	kfs.employee_id,

	-- отделы
	deps.dep_id,
	deps.dep_name,

	-- должность
	kfs.post_guid,
	posts.post_name,

	-- трудоустройство
	fsh.workType_id,
	works.workType_name,


FROM Import.KafTeachers as kfs

	-- Отделы (+кафедры)
	INNER JOIN Import.Departments as deps ON deps.dep_guid = kfs.dep_guid

	-- Должность
	INNER JOIN Import.Posts as posts ON posts.post_guid = kfs.post_guid

	-- Вид трудоустройства (через FactStaffHistories)
	INNER JOIN Import.FactStaffHistories as fsh ON fsh.fsh_id = kfs.fsh_id
	INNER JOIN Import.WorkTypes as works ON works.workType_id = fsh.workType_id

	-- Документы об образовании (степени, уровни...)


	INNER JOIN Import.Degrees 
	INNER JOIN Import.EmpDegrees ON Import.Degrees.deg_id = Import.EmpDegrees.deg_id ON Import.Employees.emp_id = Import.EmpDegrees.emp_id
	INNER JOIN Import.EmpRanks ON Import.Employees.emp_id = Import.EmpRanks.emp_id, Import.EducDocTypes
	INNER JOIN Import.EducDocs ON Import.EducDocTypes.educDocType_id = Import.EducDocs.educDocType_id, Import.Posts, Import.KafTeachers
	