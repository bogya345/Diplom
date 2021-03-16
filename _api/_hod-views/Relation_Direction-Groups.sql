
CREATE VIEW Submits
AS
	SELECT 
		fs.factStaff_id,	--
		s.subject_name,		-- название предмета
		st.subType_name,	-- название типа предмета
		tl.hours,			-- часов
		emp.employee_id,	-- ID сотрудника


	FROM hod.Import.TeacherLoads as tl

		-- 
		inner join hod.Import.FactStaffs as fs on tl.factStaff_id = fs.factStaff_id

		-- 
		inner join hod.Import.FactStaffHistorys as fsh on fs.factStaff_id = fsh.factStaff_id

		--
		inner join hod.Import.Subjects as s on tl.subject_id = st.subject_id

		--
		inner join hod.Import.SubjectTypes as st on tl.subType_id = st.subType_id

		-- 
		inner join hod.Import.PlanStaffs as ps on fs.planStaff_id = ps.planStaff_id

		--
		inner join hod.Import.Employees as emp on fs.employee_id = emp.employee_id

		--
		inner join hod.Import.EmployeeEducDocs as eed on emp.employee_id = eed.employee_id

		--
		inner join hod.Impoer.EducDocs as ed on eed.educDoc_id = ed.educDoc_id

		--
		inner join hod.Import.EmployeeRanks as er on ed.empRank_id = er.empRank_id

		--
		inner join hod.Import.Rank as r on er.rank_id = r.rank_id

		--
		inner join hod.Import.EmployeeDegrees as edeg on ed.educDoc_id = edeg.educDoc_id

		--
		inner join hod.Import.ScienceTypes as scit on edeg.sciType_id = scit.sciType_id

		--
		inner join hod.Import.Degrees as d on edeg.degree_id = d.degree_id

		--
		inner join hod.Import.ListSpeciality as ls on edeg.lSpec_id = ls.lSpec_id