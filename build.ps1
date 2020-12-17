# Get the latest tag from IVF
Push-Location ..\ivf
$version = (git describe)
Pop-Location

# Clean build
# rm -r bin/ -erroraction silentlycontinue 
# rm -r obj/ -erroraction silentlycontinue 
# rm -r docs/ -erroraction silentlycontinue 

# Build docu
dotnet build -v q

# Create a history docu
mkdir .\history\$version -ErrorAction SilentlyContinue 
Copy-Item .\docs\* .\history\$version -Recurse -Force 

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