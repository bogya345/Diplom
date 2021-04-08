
-- отключение ограничений
EXEC sys.sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' 

DELETE FROM hod.Auth.Roles
DELETE FROM hod.Auth.Users

DELETE FROM hod.Import.Posts

DELETE FROM hod.Import.PostTypes

DELETE FROM hod.Import.FactStaffHistories

DELETE FROM hod.Import.KafTeachers

DELETE FROM hod.Import.WorkTypes

DELETE FROM hod.Import.Employees

DELETE FROM hod.Import.EmpEducDocs

DELETE FROM hod.Import.EducDocs

DELETE FROM hod.Import.EmpDegrees
DELETE FROM hod.Import.Degrees
DELETE FROM hod.Import.ScienceTypes
DELETE FROM hod.Import.ListSpecialities

DELETE FROM hod.Import.EmpRanks
DELETE FROM hod.Import.Ranks

DELETE FROM hod.Import.Departments
DELETE FROM hod.Import.DepartmentTypes

DELETE FROM hod.Import.Facs

DELETE FROM hod.Import.Groups

DELETE FROM hod.Import.EducForms

DELETE FROM hod.Import.kat_zaved

DELETE FROM hod.dbo.fgos_requirs
DELETE FROM hod.dbo.Direction_fgos

DELETE FROM hod.Import.Directions

DELETE FROM hod.Import.EducBranches
DELETE FROM hod.Import.EducLevels

-- включение ограничений
EXEC sys.sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL' 
