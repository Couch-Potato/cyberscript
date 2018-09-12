@echo off
echo ==============================
echo  Cyberscript Project Builder
echo ==============================
echo Make sure you have built all the other files and applications before
echo staging.
pause
echo Setting up main cyberscript engine
cd ../
mkdir CyberScript_build
cd CyberScript_build
mkdir cs
cd cs
mkdir comp
cd ../../
set path=%cd%
copy "%path%\bpp_compiled\Program.cs" "CyberScript_build\cs\comp\comp.bin"
copy "%path%\cyberscript\bin\Debug\cyberscript.exe" "CyberScript_build\cyberscript.exe"
copy "%path%\bpp_env\bin\Debug\bpp_env.dll" "CyberScript_build\bpp_env.dll"
copy "%path%\bpp_bpp\bin\Debug\bpp_bpp.dll" "CyberScript_build\bpp_bpp.dll"
pause
