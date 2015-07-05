properties {
# *** CONFIGURE ***
  $baseFolder = Resolve-Path .
  $outFolder = "$baseFolder\bin"
  $configuration = "Debug"
  $platform = "Any CPU"
  $target = "Build"
  $solution = "$baseFolder\src\csharp\AeonFlux\AeonFlux.sln"
  $contracts = "CONTRACTS_FULL"

# *** ENVIRONMENT ***
  $msbuildPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"
  # $nunit = Get-ChildItem . -Filter "nunit-console.exe" -Recurse | foreach{$_.FullName}
  # $nunitTestFrameworkVersion = "4.0.30319"
}

task Default -depends Test

task Test -depends CompileSolution, Clean { 
  # run tests
  # $testBinaries = Get-ChildItem $outFolder\*Tests.dll
  # $testAssemblies = ""
  # $testBinaries | Foreach-Object {$testAssemblies +=  """.\bin\" + $_.Name + """ "}
  # &$nunit /framework=$nunitTestFrameworkVersion $testAssemblies.Trim()
}

function Compile($solution) {
  Assert($solution -ne $null) "'solution' should not be null" 
  
  # if build utilities v3.5 is loaded, the system cannot load any v4.0 assemblies :(
  $msbuild = $msbuildPath
  &$msbuild /target:"$target" /p:Configuration="$configuration" /p:Platform="$platform" /p:OutDir="$outFolder"\\ "$solution" /m
}

task CompileSolution -depends Clean { 
  Compile($solution)
}

task Clean { 
  Remove-Item -force $outFolder -Recurse -ErrorAction SilentlyContinue | Out-Null
}