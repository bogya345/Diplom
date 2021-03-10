Remove-Item -Path ./Groups.sql
New-Item -Path ./ -Name Groups.sql

$table = "[hod].[dbo].[Groups]"
$tablename = "Groups"

$content = ""

$content += "DELETE FROM " + $table

$content += "`n`n"

$content += "DECLARE @JSON NVARCHAR(MAX) =`n"
$content += "N'`n"
$content += Get-Content -Path ./Groups/Groups.json
$content += "'`n"
$content += "INSERT INTO " + $table + "`n"
$content += "SELECT * FROM OPENJSON (@JSON, '$.data.assets." + $tablename + "')`n"
$content += "WITH (`n"
$content += Get-Content -Path ./Groups/Groups.txt
$content += "`n)`n"

Add-Content -Path ./Groups.sql -Value $content

pause