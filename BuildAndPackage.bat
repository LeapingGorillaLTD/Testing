msbuild LeapingGorilla.Testing\LeapingGorilla.Testing.csproj /t:Build /p:Configuration="Release-Net35"
msbuild LeapingGorilla.Testing\LeapingGorilla.Testing.csproj /t:Build /p:Configuration="Release-Net40"
msbuild LeapingGorilla.Testing\LeapingGorilla.Testing.csproj /t:Build;Package /p:Configuration="Release-Net45"