$ErrorActionPreference="Stop"
$root=Split-Path -Parent $MyInvocation.MyCommand.Path
$out=Join-Path $root "XIM-AI-Setup.exe"
$sed=Join-Path $root "xim-installer.sed"
@"
[Version]
Class=IEXPRESS
SEDVersion=3
[Options]
PackagePurpose=InstallApp
ShowInstallProgramWindow=0
HideExtractAnimation=1
UseLongFileName=1
InsideCompressed=0
CAB_FixedSize=0
CAB_ResvCodeSigning=0
RebootMode=N
InstallPrompt=%InstallPrompt%
DisplayLicense=%DisplayLicense%
FinishMessage=%FinishMessage%
TargetName=%TargetName%
FriendlyName=%FriendlyName%
AppLaunched=%AppLaunched%
PostInstallCmd=%PostInstallCmd%
AdminQuietInstCmd=
UserQuietInstCmd=
SourceFiles=SourceFiles
[Strings]
InstallPrompt=
DisplayLicense=
FinishMessage=
TargetName=$out
FriendlyName=XIM AI Setup
AppLaunched=cmd.exe /c install.cmd
PostInstallCmd=<None>
AdminQuietInstCmd=
UserQuietInstCmd=
FILE0="installer.hta"
FILE1="install.cmd"
[SourceFiles]
SourceFiles0=$root\
[SourceFiles0]
%FILE0%=
%FILE1%=
"@ | Set-Content -Encoding ASCII $sed
& "$env:WINDIR\System32\iexpress.exe" /N /Q $sed
if(Test-Path $out){$mb=[math]::Round((Get-Item $out).Length/1MB,2);Write-Host "Built $out ($mb MB)"}else{throw "IExpress build failed"}