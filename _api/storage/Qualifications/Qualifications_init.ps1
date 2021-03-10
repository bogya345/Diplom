<#
   CREATE TABLE
#>

$db = "UGTU"
$scheme = "dbo"
$tablename = "Qualifications"

$table = "[" + $db + "].[" + $scheme + "].[" + $tablename + "]"

$res_filaname = $tablename + "_init.sql"
$res_path = "./" + $tablename + "_init.sql"

$info_sql= "./" + $tablename + "/" + "_" + $tablename + "_init.sql"

$flag = 1


Remove-Item -Path $res_path 
New-Item -Path ./ -Name $res_filaname

$content = ""

$content += "DROP TABLE " + $table + "`n`n"

$content += "CREATE TABLE " + $table + "`n"
foreach($line in Get-Content $info_sql){
    if($flag -eq 1){
	$flag = 0
	continue
    }
    $content += $line + "`n"
}

$content += "`n"

Add-Content -Path $res_path -Value $content

pause