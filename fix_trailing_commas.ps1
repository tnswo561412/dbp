$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $content = Get-Content $file.FullName -Raw -Encoding UTF8

    # 괄호 앞의 콤마 제거 (CREATE TABLE 끝부분)
    # 패턴: ,\s*\n\s*\)
    $content = $content -replace ",(\s*[\r\n]+\s*\))", '$1'

    Set-Content $file.FullName -Value $content -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
