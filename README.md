# CG4

[![Build-Deploy](https://github.com/metafac-net/CG4/actions/workflows/dotnet.yml/badge.svg?branch=main)](https://github.com/metafac-net/CG4/actions/workflows/dotnet.yml)

Define your models in C# code using CG4.Schemas, then run the CLI tool to generate source.

## CLI
A Dotnet tool for:
- extracting metadata from assemblies
- reading/writing metadada to JSON files
- generating code from metadata
- creating generators from templates
- creating templates from generators

## Schemas
Attributes for defining data model objects (schemas) in code.
- Allows defintion of entities, members, and proxy types.

## Models
Helpers to write and read CG4 metadata to/from JSON, and from attributed code.

## Generators
C# code generators that use metadata to create POCOs for:
- freezable classes
- immutable records
- polymorphic NewtonSoft.Json DTOs
- polymorphic System.Text.Json DTOs (.NET 7+)
- freezable, polymorphic MessagePack DTOs
- common contracts (interfaces) for all the above.

## Runtimes
Runtime support for generated DTOs.

## Templates
Testable templates for above generators.

## TextProcessing
Bi-directional text processor to convert templates to generators (and back).
