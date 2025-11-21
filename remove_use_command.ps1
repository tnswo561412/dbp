$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $lines = Get-Content $file.FullName -Encoding UTF8

    # USE 명령어가 포함된 라인을 필터링하여 제거
    $filteredLines = $lines | Where-Object { $_ -notmatch "^USE " }

    Set-Content $file.FullName -Value $filteredLines -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
