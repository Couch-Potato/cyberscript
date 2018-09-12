@echo off
title Test
cyberscript install > env/directory.string
set /p directory=<env/directory.string 
echo %directory%
pause
