
$successPath = "./success/"
$failurePath = "./failure/"

rm *.txt
rm "${failurePath}*"
rm "${successPath}*"

gci ../ -Recurse -Filter "*.sln" | % {

  $solutionFilePath = $_.FullName
  $solutionFileName = $_.Name

  $containingDirectoryPath = [System.IO.Path]::GetDirectoryName($solutionFilePath)
  $parentDirectoryPath = (get-item $containingDirectoryPath).Parent.FullName

  Write-Host "ContainingDirectory: $containingDirectoryPath"
  Write-Host "ParentDirectory: $parentDirectoryPath"

  $containingDirectoryName = [System.IO.Path]::GetFileName($containingDirectoryPath)
  $parentDirectoryName = [System.IO.Path]::GetFileName($parentDirectoryPath)

  $buildOutputFile = "${parentDirectoryName}-${containingDirectoryName}-${solutionFileName}.build.txt"

  Write-Host "OutputFile: $buildOutputFile"

  nuget.exe restore $solutionFilePath

  If (! $?) 
  {
    throw "Could not restore NuGet packages for $solutionFilePath"
  }

  msbuild $solutionFilePath > $buildOutputFile

  If ($?) 
  {
    mv $buildOutputFile $successPath
  }
  Else
  {
    mv $buildOutputFile $failurePath    
  }
}

$failureCount = (gci $failurePath).Count
$successCount = (gci $successPath).Count

Write-Host -BackgroundColor Red -ForegroundColor White "Failed: $failureCount"
Write-Host -ForegroundColor Green "Succeeded: $successCount"
