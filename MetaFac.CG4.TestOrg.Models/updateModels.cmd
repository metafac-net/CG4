@echo off

:: 
:: update Models
::

:: dotnet tool update --global MetaFac.CG4.CLI --ignore-failed-sources

:: set _cmd=mfcg4
set _cmd=..\MetaFac.CG4.CLI\bin\Debug\net6.0\MetaFac.CG4.CLI.exe

set _prefix=MetaFac.CG4.TestOrg.Schema

%_cmd% a2j -am ..\%_prefix%\bin\Debug\netstandard2.0\%_prefix%.dll -an %_prefix%.Personel -oj Models.json

::
:: generate
::

%_cmd% j2c -g Contracts -jm Models.json -on MetaFac.CG4.TestOrg.Models -o Generator.Contracts.g.cs
%_cmd% j2c -g ClassesV2 -jm Models.json -on MetaFac.CG4.TestOrg.Models -o Generator.ClassesV2.g.cs
%_cmd% j2c -g RecordsV2 -jm Models.json -on MetaFac.CG4.TestOrg.Models -o Generator.RecordsV2.g.cs

