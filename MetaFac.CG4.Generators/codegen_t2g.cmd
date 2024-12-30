@echo off

:: dotnet tool update --global MetaFac.CG4.CLI --ignore-failed-sources

:: set _cmd=mfcg4
set _cmd=..\MetaFac.CG4.CLI\bin\Debug\net8.0\MetaFac.CG4.CLI.exe

set _prefix=MetaFac.CG4

call :runt2g Contracts
call :runt2g ClassesV2
call :runt2g RecordsV2
call :runt2g MessagePack
call :runt2g JsonNewtonSoft
call :runt2g JsonSystemText

goto :eof

:runt2g
%_cmd% t2g -tf ..\%_prefix%.Template.%1\Template.cs -gf .\Generator.%1.g.cs -gn %_prefix%.Generator.%1 -gs %1
goto :eof
