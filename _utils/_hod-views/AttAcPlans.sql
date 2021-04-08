
--DROP VIEW dbo.AttAcPlans

--CREATE VIEW dbo.AttAcPlans
--AS

SELECT 
--DISTINCT -- по идее это гребанный костыль
	pls.attAcPl_id
	,pls.blockRec_id
	,pls.group_id
	,grs.group_name
	,grs.dir_id
	,rs.blockNum_id
	,rs.blockNum_name
	,rs.sub_id
	,rs.sub_name

FROM hod.dbo.AttachedAcPlans as pls

	-- 
	inner join hod.dbo.DirGroups as grs on grs.group_id = pls.group_id

	inner join  (
		SELECT
			recs.acPl_id
			,recs.blockRec_id
			,recs.blockNum_id
			,bnums.blockNum_name
			,recs.sub_id
			,subs.sub_name
		FROM hod.dbo.BlockRecs as recs
			inner join hod.dbo.BlockNums as bnums on bnums.blockNum_id = recs.blockNum_id
			inner join hod.dbo.Subjects as subs on subs.sub_id = recs.sub_id
	) as rs on rs.blockRec_id = pls.blockRec_id

