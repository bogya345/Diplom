DECLARE @JSON NVARCHAR(MAX) =
N'{
  "ok": true,
  "data": {
    "assets": {
      "Groups": [{
        "group_id": 1,
        "group_name": "ÈÑÒ-16"
        } 
      ]
    }
  }
}'

print(@JSON)


--SELECT @JSON 

SELECT * FROM OPENJSON (@JSON, '$.data.assets.Groups')
WITH (group_id int, 
		group_name NVARCHAR(10)
) 

--FROM OPENROWSET 
--(BULK 'C:\file-location\my-data.json', SINGLE_CLOB) 
--AS j