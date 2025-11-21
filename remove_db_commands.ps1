$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $content = Get-Content $file.FullName -Raw -Encoding UTF8

    # CREATE DATABASE 라인 제거
    $content = $content -replace "CREATE DATABASE.*?;\r?\n", ""

    # USE database 라인 제거
    $content = $content -replace "USE `s5701454`;\r?\n", ""

    Set-Content $file.FullName -Value $content -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
