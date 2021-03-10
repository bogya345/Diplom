$path = "./Groups_init.sql"

Remove-Item -Path $path
New-Item -Path ./ -Name Groups_init.sql

$table = "[hod].[dbo].[Groups]"
$tablename = "Groups"
$flag = 1

$content = ""

$content += "DROP FROM " + $table + "`n`n"


$content += "CREATE TABLE " + $table + "`n"
foreach($line in Get-Content ./Groups/Groups_.sql) {
    if($flag -eq 1){
	$flag = 0
	continue
    }
    $content += $line + "`n"
}

$content += "`n"

Add-Content -Path $path -Value $content

pause