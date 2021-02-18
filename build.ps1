# Get the latest tag from IVF
Push-Location ..\ivf
$version = (git describe)
Pop-Location

# Clean build
# rm -r bin/ -erroraction silentlycontinue 
# rm -r obj/ -erroraction silentlycontinue 
# rm -r docs/ -erroraction silentlycontinue 

# Build docu
#dotnet build -v q

# Create a history docu
mkdir .\history\$version -ErrorAction SilentlyContinue 
<#
/NFL : No File List - don't log file names.
/NDL : No Directory List - don't log directory names.
/NJH : No Job Header.
/NJS : No Job Summary.
/NP  : No Progress - don't display percentage copied.
/NS  : No Size - don't log file sizes.
/NC  : No Class - don't log file classes.
#>
robocopy  docs history\$version /e /NFL /NDL /NJH  /nc /ns /np

# Create history linkes
## Get the historical versions and create links.
$historyItems = (Get-ChildItem .\history -n -dir)

$historyMD = "# Previous versions `n"
foreach ($item in $historyItems){
    $historyMD+="[$item](../../history/$item/index.html)`n`n" 
}

# Write the to a file.
$historyMD > .\previous_versions\index.md

# Start-Process .\_site\index.html
