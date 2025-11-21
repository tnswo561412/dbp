$files = Get-ChildItem "C:\Users\tnswo\Documents\dumps\Dump20251121\*.sql"

foreach ($file in $files) {
    Write-Host "Processing: $($file.Name)"
    $lines = Get-Content $file.FullName -Encoding UTF8
    $newLines = @()
    $skipNext = $false

    for ($i = 0; $i -lt $lines.Length; $i++) {
        $line = $lines[$i]

        # CONSTRAINT와 FOREIGN KEY를 포함하는 라인 건너뛰기
        if ($line -match "CONSTRAINT.*FOREIGN\s+KEY") {
            Write-Host "  Removing FK line: $($line.Trim())"
            continue
        }

        $newLines += $line
    }

    Set-Content $file.FullName -Value $newLines -Encoding UTF8
    Write-Host "Updated: $($file.Name)"
}

Write-Host "All files updated successfully!"
