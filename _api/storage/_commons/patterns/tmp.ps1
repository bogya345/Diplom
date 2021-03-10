
funciton Create-DataFile {
    param (
        $db,
        $scheme,
        $tablename,
        $dirpath
    )

    
    $inner_data = 
    "
    <#
       INSERT INTO
    #>

    `$db = `"`${`$db}`"
    `$scheme = `"`${`$scheme}`"
    `$tablename = `"`${`$tablename}`"

    `$table = '[' + `$db + '].[' + `$scheme + '].[' + `$tablename + ']'

    `$info_txt = './' + `$tablename + '/' + '_' + `$tablename + '.txt'
    `$info_json = './' + `$tablename + '/' + '_' + `$tablename + '.json'

    `$res_filename = `$tablename + '.sql'
    `$res_path = './' + `$res_filename 


    Remove-Item -Path `$res_path
    New-Item -Path ./ -Name `$res_filename


    `$content = `"`"

    `$content += 'DELETE FROM ' + `$table

    `$content += `"`n`n`"

    `$content += `"DECLARE @JSON NVARCHAR(MAX) =`n`"
    `$content += `"N'`n`"
    `$content += Get-Content -Path `$info_json 
    `$content += `"'`n`"
    `$content += 'INSERT INTO ' + `$table + `"`n`"
    `$content += `"SELECT * FROM OPENJSON (@JSON, '`$.data.assets.`" + `$tablename + `"')`n`"
    `$content += `"WITH (`n`"
    `$content += Get-Content -Path `$info_txt
    `$content += `"`n)`n`"

    Add-Content -Path `$res_path -Value `$content

    pause
    "

    New-Item -Path $dirpath -Name $tablename -Value $inner_data


}
