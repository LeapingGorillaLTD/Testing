REM this should be run from a VS Dev Command Prompt
rd /q /s packages
rd /q /s LeapingGorilla.Testing.NUnit\bin\Release
rd /q /s LeapingGorilla.Testing.XUnit\bin\Release
rd /q /s packages

nuget restore LeapingGorilla.Testing.sln
dotnet build LeapingGorilla.Testing.sln	-c Release

nuget pack LeapingGorilla.Testing.NUnit\LeapingGorilla.Testing.nuspec -OutputDirectory ./packages
nuget pack LeapingGorilla.Testing.XUnit\LeapingGorilla.Testing.XUnit.nuspec -OutputDirectory ./packages
 