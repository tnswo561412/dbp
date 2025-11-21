$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $content = Get-Content $file.FullName -Raw -Encoding UTF8
    $content = $content -replace 'dbp_messenger', 's5701454'
    Set-Content $file.FullName -Value $content -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
