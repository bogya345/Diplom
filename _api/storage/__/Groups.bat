Remove-Item -Path ./Groups.sql
New-Item -Path . -Name Groups.sql

$content = Get-Content -Path ./_commons/part1.txt
$content += Get-Content -Path ./Groups.json
$content += Get-Content -Path ./_commons/part2.txt
$content += "[hod].[dbo].[Groups]"
$content += "SELECT * FROM OPENJSON (@JSON, '$.data.assets." + "Groups" + "')"
$content += Get-Content -Path ./_commons/part4.txt
$content += Get-Content -Path ./Groups.txt
$content += Get-Content -Path ./_commons/part5.txt

Add-Content -Path ./Groups.sql -Value $content