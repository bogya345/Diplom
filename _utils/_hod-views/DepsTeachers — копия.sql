
--CREATE VIEW dbo.DepsTeachers
--AS

SELECT
	deps.dep_id,
	--deps.dep_name,
	subs.sub_id,
	subs.sub_name


FROM hod.Import.Departments as deps
	
	-- ��������
	inner join hod.dbo.Subjects as subs on subs.dep_id = deps.dep_id

	inner join (
		SELECT
			emps.emp_id,
			deps.dep_id

		FROM hod.Import.Employees as emps
			inner join hod.Import.FactStaffs as fs on fs.emp_id = emps.emp_id
			inner join hod.Import.PlanStaffs as ps on ps.ps_id = fs.ps_id
				and ps.post_id in (
					'48',	-- ������������� ���
					'47',	-- ������� �������������
					'46',	-- ������
					'753',	-- ������ (�.�.)
					'754',	-- ������ (�.�.)
					'748',	-- ������� ������������� (�.�.)
					'759'	-- ������������� (���) (�.�.)
				)
				--and ps.post_guid in (
				--	'DF3AEDE9-68C0-E111-8738-0018FE865BEC',	-- ������������� ���
				--	'E13AEDE9-68C0-E111-8738-0018FE865BEC',	-- ������� �������������
				--	'E23AEDE9-68C0-E111-8738-0018FE865BEC',	-- ������
				--	'7FEDA297-0AD1-48B6-9B4D-20611BD593A3',	-- ������ (�.�.)
				--	'648C0496-E7F6-4661-9C35-6FED730E567A'	-- ������ (�.�.)
				--	)
			inner join hod.Import.FactStaffsHistory as fsh on fsh.fs_id = fs.fs_id
			inner join hod.Import.Departments as deps on deps.dep_id = ps.dep_id
	) as teachs on teachs.emp_id = 

	-- ����
	inner join hod.Auth.Roles as roles on roles.role_id = users.role_id

	-- �������������
	left join hod.Import.KafTeachers as teachs on teachs.fsh_id = users.fsh_id
