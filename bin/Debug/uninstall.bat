reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v LogiNumLockLEDInd /f
taskkill /IM "Logitech NumLock LED Indicator.exe"
del "Logitech NumLock LED Indicator.exe"
del "Logitech NumLock LED Indicator.exe.config"
del "LogitechLedEnginesWrapper.dll"
del "uninstall.bat"