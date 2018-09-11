# Cyberscript 
#### By Jeremy Cofield
#### Version 1.2

# Getting started
Download cyberscript from this link [Cyberscript v1.2](https://youtube.com)
After that paste the exe in your batch file directory. There create a script that does this

```bat
@echo off
title Cyberscript
set script="thisbatfile.bat"
cyberscript install all
cyberscript run %script%
cs.secpol lspolicy AccountLoging true
```
#### This application uses the batch++

# Building a script into an executable.

```bat
set script="thisbatfile.bat"
set outputexe="mynewlittscript.exe"
cyberscript compile %script% %outputexe%
```
 Building your application into an executable would mean it does not require an installation of cyberscript and would dynamically install it at runtime.
 
 # Batch Plus Plus enviornmentals
 
 ```bat
 @echo off
 set script="thisbatfile.bat"
 cyberscript run %script%
 env set version "cyberscript version"
 echo env.version
 ```
