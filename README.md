# CG4
[![Build Status](https://dev.azure.com/MetaFac/OSR/_apis/build/status%2FCG4?branchName=main)](https://dev.azure.com/MetaFac/OSR/_build/latest?definitionId=14&branchName=main)

## Attributes
C# attributes for defining CG4 models in code.

## CLI
A Dotnet tool for:
- extracting metadata from assemblies
- reading/writing metadada to JSON files
- generating code from metadata
- creating generators from templates
- creating templates from generators

## Models
Helpers to write and read CG4 metadata to/from JSON, and from attributed code.

## Generators
C# code generators that use metadata to create POCOs for:
- ordinary classes
- polymorphic JSON DTOs (NewtonSoft)
- polymorphic MessagePack DTOs
- records
- common contracts (interfaces) for all the above.

## Runtimes
Runtime support for generated DTOs.

## Templates
Testable templates for above generators.

## TextProcessing
Bi-directional text processor to convert templates to generators (and back).

## SourceGenerator (dev)
Experimental Roslyn-based source generator