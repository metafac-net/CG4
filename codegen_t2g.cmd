@echo off

:: dotnet tool update --global MetaFac.CG3.CLI --ignore-failed-sources

:: set _cmd=mfcg3
set _cmd=.\MetaFac.CG3.CLI\bin\Debug\net6.0\MetaFac.CG3.CLI.exe

set _prefix=MetaFac.CG3

call :runt2g Interfaces cs
call :runt2g JsonPoco cs
call :runt2g Freezables cs
call :runt2g Immutables cs
call :runt2g ProtobufNet3 cs
call :runt2g Records cs

call :runt2g Contracts cs
call :runt2g ClassesV2 cs
call :runt2g RecordsV2 cs
call :runt2g MessagePack cs

goto :eof

:runt2g
%_cmd% t2g -tf .\%_prefix%.Template.%1\Template.%2 -gf .\%_prefix%.Generator.%1\Generator.g.cs -gn %_prefix%.Generator.%1 -gs %_prefix%.%1
goto :eof
