
--DROP VIEW DirectionGroup

CREATE VIEW own.DirectionGroup
AS

SELECT 
--top 100
	dirs.direct_id,
	dirs.YearObuch,

	groups.group_id,
	groups.group_name,
	groups.nYear_post

FROM hod.Import.Directions as dirs
	
	inner join hod.Import.Groups as groups on groups.direct_id = dirs.direct_id