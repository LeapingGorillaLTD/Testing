C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe LeapingGorilla.Testing\LeapingGorilla.Testing.csproj /t:Build /p:referencePath=C:\Sandbox\LeapingGorilla.Testing\packages  /p:configuration="Release-Net45"
dotnet build .\LeapingGorilla.Testing.NetCore.sln -c Release
nuget pack LeapingGorilla.Testing\LeapingGorilla.Testing.nuspec
 