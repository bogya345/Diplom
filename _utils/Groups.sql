DECLARE @JSON NVARCHAR(MAX) =
N'
{   "ok": true,   "data": {     "assets": {       "Groups": [       	{         "group_id": 1,         "group_name": "ИСТ-16"         },          {         "group_id": 2,         "group_name": "ИСТ-17"         },         {         "group_id": 3,         "group_name": "ИСТ-18"         },          {         "group_id": 4,         "group_name": "ИСТ-19"         },         {         "group_id": 5,         "group_name": "ИСТ-20"         }       ]     }   } }'
INSERT INTO [hod].[dbo].[Groups]
SELECT * FROM OPENJSON (@JSON, '$.data.assets.Groups')
WITH (
	group_id int, 	group_name NVARCHAR(10))

DECLARE @JSON NVARCHAR(MAX) =
N'
{   "ok": true,   "data": {     "assets": {       "Groups": [       	{         "group_id": 1,         "group_name": "ИСТ-16"         },          {         "group_id": 2,         "group_name": "ИСТ-17"         },         {         "group_id": 3,         "group_name": "ИСТ-18"         },          {         "group_id": 4,         "group_name": "ИСТ-19"         },         {         "group_id": 5,         "group_name": "ИСТ-20"         }       ]     }   } }'
INSERT INTO [hod].[dbo].[Groups]
SELECT * FROM OPENJSON (@JSON, '$.data.assets.Groups')
WITH (
	group_id int, 	group_name NVARCHAR(10))

