@echo off

:: 
:: update Models
::

:: dotnet tool update --global MetaFac.CG4.CLI --ignore-failed-sources

:: set _cmd=mfcg4
set _cmd=..\MetaFac.CG4.CLI\bin\Debug\net6.0\MetaFac.CG4.CLI.exe

set _prefix=MetaFac.CG4.TestOrg.Schema

%_cmd% a2j -am ..\%_prefix%\bin\Debug\netstandard2.0\%_prefix%.dll -an %_prefix%.Personel -oj Personel.Models.json

::
:: generate
::

%_cmd% j2c -g Contracts -jm Personel.Models.json -on MetaFac.CG4.TestOrg.Models.Personel -o Personel.Contracts.g.cs
%_cmd% j2c -g ClassesV2 -jm Personel.Models.json -on MetaFac.CG4.TestOrg.Models.Personel -o Personel.ClassesV2.g.cs
%_cmd% j2c -g RecordsV2 -jm Personel.Models.json -on MetaFac.CG4.TestOrg.Models.Personel -o Personel.RecordsV2.g.cs

