# CG4

*todo build badge*

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
