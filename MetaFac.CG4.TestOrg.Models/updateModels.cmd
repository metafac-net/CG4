@echo off

:: 
:: update Models
::

:: dotnet tool update --global MetaFac.CG4.CLI --ignore-failed-sources

:: set _cmd=mfcg4
set _cmd=..\MetaFac.CG4.CLI\bin\Debug\net9.0\MetaFac.CG4.CLI.exe

set _prefix=MetaFac.CG4.TestOrg.Schema

call :a2c BasicTypes
call :a2c Personel
call :a2c Polymorphic
call :a2c Recursive
call :a2c XtraComplex
goto :eof

:a2c
::
:: parse schema
::
%_cmd% a2j -am ..\%_prefix%\bin\Debug\net9.0\%_prefix%.dll -an %_prefix%.%1 -oj %1.Models.json
::
:: generate
::
%_cmd% j2c -g Contracts -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.Contracts.g.cs
%_cmd% j2c -g ClassesV2 -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.ClassesV2.g.cs
%_cmd% j2c -g RecordsV2 -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.RecordsV2.g.cs
%_cmd% j2c -g MessagePack -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.MessagePack.g.cs
%_cmd% j2c -g JsonNewtonSoft -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.JsonNewtonSoft.g.cs
%_cmd% j2c -g JsonSystemText -jm %1.Models.json -on MetaFac.CG4.TestOrg.Models.%1 -o %1.JsonSystemText.g.cs
goto :eof
