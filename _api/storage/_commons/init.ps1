

function Create-JsonDataPSFile {
    param (
        $dbName,
        $schemeName,
        $tablenameName,
        $dirpathName,
        $filenameName
    )

    
    $inner_data = 
    "
<#
    INSERT INTO
#>

`$db = `"$dbName`"
`$scheme = `"$schemeName`"
`$tablename = `"$tablenameName`"

`$table = '[' + `$db + '].[' + `$scheme + '].[' + `$tablename + ']'

`$info_txt = './' + `$tablename + '/' + '_' + `$tablename + '.txt'
`$info_json = './' + `$tablename + '/' + '_' + `$tablename + '.json'

`$res_filename = `$tablename + '.sql'
`$res_path = './' + `$res_filename 


Remove-Item -Path `$res_path
New-Item -Path ./ -Name `$res_filename


`$content = `"`"

`$content += 'DELETE FROM ' + `$table

`$content += `"``n``n`"

`$content += `"DECLARE @JSON NVARCHAR(MAX) =``n`"
`$content += `"N'``n`"
`$content += Get-Content -Path `$info_json 
`$content += `"'``n`"
`$content += 'INSERT INTO ' + `$table + `"`n`"
`$content += `"SELECT * FROM OPENJSON (@JSON, '`$.data.assets.`" + `$tablename + `"')``n`"
`$content += `"WITH (``n`"
`$content += Get-Content -Path `$info_txt
`$content += `"``n)``n`"

Add-Content -Path `$res_path -Value `$content

pause
    "

    New-Item -Path $dirpathName -Name $filenameName -Value $inner_data


}

function Create-ForceDataPSFile {
    param (
        $dbName,
        $schemeName,
        $tablenameName,
        $dirpathName,
        $filenameName
    )

    
    $inner_data = 
    "
<#
    INSERT INTO
#>

`$db = `"$dbName`"
`$scheme = `"$schemeName`"
`$tablename = `"$tablenameName`"

`$table = '[' + `$db + '].[' + `$scheme + '].[' + `$tablename + ']'

`$info_txt = './' + '_' + `$tablename + '.txt'
`$info_json = './' + '_' + `$tablename + '.json'
`$info_data = './' + '@' + `$tablename + '_data.txt'

`$res_filename = '#sql_' + `$tablename + '.sql'
`$res_path = './' + `$res_filename 


Remove-Item -Path `$res_path
New-Item -Path ./ -Name `$res_filename


`$content = `"`"

`$content += 'DELETE FROM ' + `$table

`$content += `"``n``n`"

`$content += 'INSERT INTO ' + `$table + `"``n`"

`$content += `"VALUES``n`"

`$data_ = Get-Content -Path `$info_data

foreach(`$line in `$(`$data_ -split `"``r``n`")) {

    `$append = `"(N'`" + `$line.replace(`"``t`", `"',``tN'`") + `"')`" + `",``n`"
    `$content += `$append.replace(`"N'NULL'`",'NULL')
}

Add-Content -Path `$res_path -Value `$content

pause
    "

    New-Item -Path $dirpathName -Name $filenameName -Value $inner_data


}

function Create-InitPSFile {
    param (
        $dbName,
        $schemeName,
        $tablenameName,
        $dirpathName,
        $filenameName
    )

    
    $inner_data = 
    "
<#
    CREATE TABLE
#>

`$db = `"$dbName`"
`$scheme = `"$schemeName`"
`$tablename = `"$tablenameName`"

`$table = '[' + `$db + '].[' + `$scheme + '].[' + `$tablename + ']'

`$res_filaname = `$tablename + '_init.sql'
`$res_path = './' + `$tablename + '_init.sql'

`$info_sql= './' + `$tablename + '/' + '_' + `$tablename + '_init.sql'

`$flag = 1


Remove-Item -Path `$res_path 
New-Item -Path ./ -Name `$res_filaname

`$content = `"`"
    
`$content += 'DROP TABLE ' + `$table + `"``n``n`"

`$content += 'CREATE TABLE ' + `$table + `"``n`"
foreach(`$line in Get-Content `$info_sql){
    if(`$flag -eq 1){
	`$flag = 0
	continue
    }
    `$content += `$line + `"``n`"
}

`$content += `"``n`"

Add-Content -Path `$res_path -Value `$content

pause
    "

    New-Item -Path $dirpathName -Name $filenameName -Value $inner_data


}

$pats_path = "./_commons/patterns/"

$db = Read-Host -Prompt 'Input database name'
$scheme = Read-Host -Prompt 'Input scheme name'
$tablename = Read-Host -Prompt 'Input table name'

$pats_res_path = "./" + $tablename + '/'


if($db -eq "" -or $db -eq " ") 
{
$db = "hod"
Write-Output "Database == hod" 
}
if($scheme -eq "" -or $scheme -eq " ") 
{
$scheme = "Import"
Write-Output "Scheme == Import" 
}
if($tablename -eq "" -or $tablename -eq " ") 
{
$tablename = "TEMP"
Write-Output "Tablename == TEMP" 
}


<# Create Directory #>
New-Item -Path . -Name $tablename -ItemType "directory"

<# Copy patterns #>

$res_dir = './' + $tablename + '/'
$res_txt = $pats_res_path + '' + $tablename + ".txt"
$name = '@' + $tablename + '.txt'
New-Item -Path $res_dir -Name $name -ItemType "file"

$res_dir = './' + $tablename + '/'
$res_json = $pats_res_path + '@' + $tablename + ".json"
$name = '@' + $tablename + '.json'
$inner = "
{
  `"ok`": true,
  `"data`": {
    `"assets`": {
      `"$($tablename)`": [
        {
        `"_id`": 0,
        `"_name`": `"`"
        },
      ]
    }
  }
}
"
New-Item -Path $res_dir -Name $name -ItemType "file" -Value $inner

$res_dir = './' + $tablename + '/'
$name = '@' + $tablename + '_init.sql'
$inner = 'CREATE TABLE ' + "$db.$scheme.$tablename" + "`n(`n`n)"
New-Item -Path $res_dir -Name $name -ItemType "file" -Value $inner

$name = '@' + $tablename + '_data.txt'
New-Item -Path $res_dir -Name $name -ItemType "file"


<# Create PowerShell File #>

$dirpath = './' + $tablename 
$filename_pw1 = 'PW1_' + $tablename + '.ps1'
Create-ForceDataPSFile -dbName $db -schemeName $scheme -tablenameName $tablename -dirpathName $dirpath -filenameName $filename_pw1

$dirpath = './' + $tablename 
$filename_pw2 = 'PW2_' +  $tablename + '_init.ps1'
Create-InitPSFile -dbName $db -schemeName $scheme -tablenameName $tablename -dirpathName $dirpath -filenameName $filename_pw2


<# Create bats #>

$root_path = './' + $tablename + '/'

$filename_bat1 = '#bat_' + $tablename + '.bat'
$inner_runner = "Powershell -File " + $filename_pw1
New-Item -Path $root_path -Name $filename_bat1 -Value $inner_runner


$filename_bat2 = '#bat_' + $tablename + '_init.bat'
$inner_runner = "Powershell -File " + $filename_pw1
New-Item -Path $root_path -Name $filename_bat2 -Value $inner_runner

pause