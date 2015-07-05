properties {
# *** CONFIGURE ***
  $baseFolder = Resolve-Path -Relative .
  $outFolder = "$baseFolder\..\..\bin"
  $configuration = "Debug"
  $platform = "Any CPU"
  $target = "Build"
  $solution = "$baseFolder\AeonFlux\AeonFlux.sln"
  $contracts = "CONTRACTS_FULL"

# *** ENVIRONMENT ***
  $msbuildPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
  $xunitRunner = Get-ChildItem . -Filter "xunit.console.exe" -Recurse | foreach {$_.FullName}
}


# *** functions for clean, compile, test-runner, package, etc. ***
function RemoveFolder($folder) {
  Assert($folder -ne $null) "'folder' must not be null"
  Remove-Item -force $folder -Recurse -ErrorAction SilentlyContinue | Out-Null
}

function CreateFolder($folder) {
  Assert($folder -ne $null) "'folder' must not be null"
  New-Item -ItemType Directory -Force -Path "$folder" | Out-Null
}

function Compile($solution, $target) {
  Assert($solution -ne $null) "'solution' must not be null" 
  Assert($target -ne $null) "'' must not be null"
  $msbuild = $msbuildPath
  &$msbuild /target:"$target" /p:Configuration="$configuration" /p:Platform="$platform" "$solution" /m /noconlog /fl "/flp:errorsonly;logfile=""$outFolder\errors.log"""
}




task CompileSolution -depends Clean { 
  Compile $solution $target
}

task Clean { 
  RemoveFolder($outFolder)
  CreateFolder($outFolder)
}

task Test -depends CompileSolution, Clean { 
  $testBinaries = Get-ChildItem "$outFolder\csharp\*Tests.dll"
  $testAssemblies = ""
  $testBinaries | Foreach-Object {$testAssemblies += """..\..\bin\csharp\" + $_.Name + """ "} 
  &$xunitRunner $testAssemblies.Trim() -nologo -quiet -xml "$outFolder\xunit.xml"
}

task Default -depends Test
