
DROP VIEW dbo.DepDirFac

CREATE VIEW dbo.DepDirFac
AS

SELECT 
--DISTINCT -- по идее это гребанный костыль
	deps.dep_id
	,deps.dep_guid
	,deps.dep_name
	,facs.fac_id
	,facs.fac_name
	,dirs.dir_id
	,dirs.acPl_id
	--,dirs.
	,ebs.eBr_name

FROM hod.Import.Departments as deps

	-- Факультеты
	inner join hod.Import.Facs as facs on facs.dep_guid = deps.dep_guid

	-- Направления
	inner join hod.Import.Directions as dirs on dirs.dep_id = deps.dep_id
	-- Обучение
	inner join hod.Import.EducBranches as ebs on ebs.eBr_id = dirs.eBr_id
