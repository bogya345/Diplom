
DROP VIEW dbo.TeacherDeps

CREATE VIEW dbo.TeacherDeps
AS

SELECT
	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	
	fs.fs_id,
	fs.workT_id,
	wt.workT_name,

	ps.dep_id,
	ps.post_id,

	fsh.fsh_id,
	fsh.StaffCount,
	fsh.DateBegin
	--fsh.


FROM hod.Import.Employees as emps

	inner join hod.Import.FactStaffs as fs on fs.emp_id = emps.emp_id
	left join hod.Import.WorkTypes as wt on wt.workT_id = fs.workT_id

	inner join hod.Import.PlanStaffs as ps on ps.ps_id = fs.ps_id
	left join hod.Import.Posts as p on p.post_id = ps.post_id
	inner join hod.Import.Departments as deps on deps.dep_id = ps.dep_id

	inner join hod.Import.FactStaffsHistory as fsh on fsh.fs_id = fs.fs_id

