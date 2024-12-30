@echo off

:: dotnet tool update --global MetaFac.CG4.CLI --ignore-failed-sources

:: set _cmd=mfcg4
set _cmd=..\MetaFac.CG4.CLI\bin\Debug\net8.0\MetaFac.CG4.CLI.exe

set _prefix=MetaFac.CG4

call :rung2t Contracts cs
:: call :rung2t ClassesV2 cs
:: call :rung2t RecordsV2 cs
:: call :rung2t MessagePack cs
:: call :rung2t JsonNewtonSoft cs

goto :eof

:rung2t
%_cmd% g2t -gf .\Generator.%1.g.cs -tf ..\%_prefix%.Template.%1\Template.%2
goto :eof
