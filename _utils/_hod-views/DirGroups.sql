
DROP VIEW dbo.DirGroups;

CREATE VIEW dbo.DirGroups
AS

SELECT 
--DISTINCT -- ïî èäåå ıòî ãğåáàííûé êîñòûëü
	dirs.dep_id
	,dirs.dir_id
	,dirs.acPl_id
	,grs.group_id
	,grs.group_name
	,grs.DateCreate
	,grs.DateExit
	--,grs.

FROM hod.Import.Directions as dirs
	
	-- Ãğóïïû
	inner join hod.Import.Groups as grs on grs.dir_id = dirs.dir_id
		--and grs.DateExit > getdate()

