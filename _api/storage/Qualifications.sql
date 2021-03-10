DELETE FROM [UGTU].[dbo].[Qualifications]

DECLARE @JSON NVARCHAR(MAX) =
N'
{   "ok": true,   "data": {     "assets": {       "Qualifications": [       	{         "qualif_id": 1,         "qualif_name": "Квалификация1"         },         {         "qualif_id": 2,         "qualif_name": "Квалификация2"         },         {         "qualif_id": 3,         "qualif_name": "Квалификация3"         }       ]     }   } }'
INSERT INTO [UGTU].[dbo].[Qualifications]
SELECT * FROM OPENJSON (@JSON, '$.data.assets.Qualifications')
WITH (
	qualif_id int, 	qualif_name NVARCHAR(100)
)

