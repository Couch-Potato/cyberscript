# Cyberscript 
#### By Jeremy Cofield
#### Version 1.2

# Getting started
Download cyberscript from this link [Cyberscript v1.2](https://youtube.com)
After that paste the exe in your batch file directory. Next create a script called "thisbatfile.bat" in that directory. This will be your script that will be executed. Next, create another script that will run the script you just created.

```bat
@echo off
title Cyberscript
set script="thisbatfile.bat"
cyberscript install all
cyberscript run %script%
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

This will allow you to create variables that will be reflected upon all scripts in the directory. This will run `cyberscript version` and then return the response. You cannot but regular bare strings in this, only valid windows or cyberscript commands.
