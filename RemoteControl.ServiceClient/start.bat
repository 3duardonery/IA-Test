set currentPath=%~dp0
dotnet build %currentPath%
START /WAIT %currentPath%\bin\Debug\netcoreapp3.1\RemoteControl.ServiceClient.exe install
START /WAIT %currentPath%\bin\Debug\netcoreapp3.1\RemoteControl.ServiceClient.exe start