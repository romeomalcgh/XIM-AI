# XIM AI Installer
Small Windows bootstrap installer for XIM AI.
The installer itself is designed to stay below 20 MB. It downloads the current XIM payload from the latest GitHub Release and installs it locally.
## Release asset
The bootstrapper expects: `XIM-Payload.zip`
## Build
Run `build-installer.ps1` on Windows. It uses the built-in IExpress tool, so no third-party installer builder is required.