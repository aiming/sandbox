set DEVENV_PATH=C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\Devenv.com
set SLN_PATH=WpfSandbox.sln
set PROJECT_FILE_PATH=InstallerProject\InstallerProject.vdproj
set BUILD_ENV=Release

"%DEVENV_PATH%" WpfSandbox.sln /Project "%PROJECT_FILE_PATH%" /Build "%BUILD_ENV%"