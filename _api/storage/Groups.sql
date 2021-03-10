DELETE FROM [hod].[dbo].[Groups]

DECLARE @JSON NVARCHAR(MAX) =
N'
{   "ok": true,   "data": {     "assets": {       "Groups": [       	{         "group_id": 1,         "group_name": "ИСТ-16",         "startYear": "01.09.2016",         "qualification_id": 1,         "educForm_id": 1,         "department_id": 1         },          {         "group_id": 2,         "group_name": "ИСТ-16",         "startYear": "01.09.2016",         "qualification_id": 1,         "educForm_id": 2,         "department_id": 1         },         {         "group_id": 3,         "group_name": "ИСТ-17",         "startYear": "01.09.2017",         "qualification_id": 1,         "educForm_id": 1,         "department_id": 1         },         {         "group_id": 4,         "group_name": "ИСТ-17",         "startYear": "01.09.2017",         "qualification_id": 1,         "educForm_id": 2,         "department_id": 1         },         {         "group_id": 5,         "group_name": "ИСТ-18",         "startYear": "01.09.2018",         "qualification_id": 1,         "educForm_id": 1,         "department_id": 1         },         {         "group_id": 6,         "group_name": "ИСТ-18",         "startYear": "01.09.2018",         "qualification_id": 1,         "educForm_id": 2,         "department_id": 1         }       ]     }   } }'
INSERT INTO [hod].[dbo].[Groups]
SELECT * FROM OPENJSON (@JSON, '$.data.assets.Groups')
WITH (
	group_id int, 	group_name NVARCHAR(10), 	startYear datetime, 	qualif_id int, 	educForm_id int, 	dep_id int
)

