rd /q /s packages

dotnet build LeapingGorilla.Testing.sln	-c Release

nuget pack LeapingGorilla.Testing.NUnit\LeapingGorilla.Testing.nuspec -OutputDirectory ./packages
nuget pack LeapingGorilla.Testing.XUnit\LeapingGorilla.Testing.XUnit.nuspec -OutputDirectory ./packages
 