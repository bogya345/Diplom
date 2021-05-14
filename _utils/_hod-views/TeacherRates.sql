
--DROP VIEW dbo.TeacherRates;

CREATE VIEW dbo.TeacherRates
AS

SELECT 
--DISTINCT -- 
	fsh.fsh_id,
	fsh.StaffCount,
	
	fs.fs_id,
	fs.workT_id,
	wt.workT_name,
	wt.workT_shortname,
	
	fs.ps_id,
	ps.post_id,
	ps.dep_id,
	p.post_name,

	emps.emp_id,
	emps.LastName,
	emps.FIrstName,
	emps.MiddleName,
	CONCAT(emps.LastName, ' ', emps.FIrstName, ' ', emps.MiddleName) as FullName
 

FROM hod.Import.FactStaffsHistory as fsh

	inner join hod.Import.FactStaffs as fs on fs.fs_id = fsh.fs_id
	left join hod.Import.WorkTypes as wt on wt.workT_id = fs.workT_id

	inner join hod.Import.PlanStaffs as ps on ps.ps_id = fs.ps_id
	left join hod.Import.Posts as p on p.post_id = ps.post_id
	left join hod.Import.PostTypes as pt on pt.postT_id = p.postT_id
	
	inner join hod.Import.Employees as emps on emps.emp_id = fs.emp_id

