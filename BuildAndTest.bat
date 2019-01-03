rd /q /s packages
rd /q /s LeapingGorilla.Testing\bin\Release
nuget restore LeapingGorilla.Testing.sln
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe LeapingGorilla.Testing.sln /t:Build /p:configuration="Release"

rd /q /s packages
nuget restore LeapingGorilla.Testing.NetCore.sln
dotnet build .\LeapingGorilla.Testing.NetCore.sln -c Release

"C:\Program Files (x86)\NUnit.org\nunit-console\nunit3-console.exe" LeapingGorilla.Testing.Tests\bin\Release\LeapingGorilla.Testing.Tests.dll
dotnet test .\LeapingGorilla.Testing.Tests\LeapingGorilla.Testing.Tests.NetCore.csproj
