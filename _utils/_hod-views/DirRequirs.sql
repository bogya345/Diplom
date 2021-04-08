
DROP VIEW dbo.DirRequirs

CREATE VIEW dbo.DirRequirs
AS

SELECT 
--DISTINCT -- по идее это гребанный костыль
	dirs.dir_id
	,ebs.eBr_name
	,dirs.acPl_id
	--,grs.group_id
	--,grs.group_name
	,fgos.fgos_num
	,df.settedValue
	,u.unit_name

FROM hod.Import.Directions as dirs

	-- Обучение
	inner join hod.Import.EducBranches as ebs on ebs.eBr_id = dirs.eBr_id

	-- Направление-Требования
	inner join hod.dbo.DirFgos as df on df.dir_id = dirs.dir_id

	-- Требования
	inner join hod.dbo.FgosRequirs as fgos on fgos.fgos_id = df.fgos_id
	
	-- Единицы
	inner join hod.dbo.Units as u on u.unit_id = df.unit_id

	---- Группы
	--inner join hod.Import.Groups as grs on grs.dir_id = dirs.dir_id
	--	and grs.DateExit > getdate()

--ORDER BY dirs.dir_id
--	,fgos.fgos_num
	--, grs.group_id
