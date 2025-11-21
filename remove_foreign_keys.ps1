$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $content = Get-Content $file.FullName -Raw -Encoding UTF8

    # CONSTRAINT와 FOREIGN KEY를 포함하는 라인을 제거
    # 형식: CONSTRAINT `name` FOREIGN KEY (`col`) REFERENCES `table` (`col`) ON DELETE ...
    $content = $content -replace ",\s*CONSTRAINT\s+`[^`]+`\s+FOREIGN\s+KEY\s+\([^)]+\)\s+REFERENCES\s+`[^`]+`\s+\([^)]+\)(\s+ON\s+DELETE\s+\w+)?", ""

    # 혹시 콤마가 앞에 없는 경우도 처리
    $content = $content -replace "\s+CONSTRAINT\s+`[^`]+`\s+FOREIGN\s+KEY\s+\([^)]+\)\s+REFERENCES\s+`[^`]+`\s+\([^)]+\)(\s+ON\s+DELETE\s+\w+)?[,\s]*", ""

    Set-Content $file.FullName -Value $content -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
