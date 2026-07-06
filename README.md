# VM Odin Extensions

Odin Inspector attributes, drawers, and validation helpers used by VMFramework-based Unity projects.

This package contains reusable editor tooling that improves inspector workflows for common project data: value dropdowns, validation attributes, helper UI, custom value drawers, and context-menu utilities.

## Installation

Add the package through Unity Package Manager using the Git URL:

```text
https://github.com/VM233/VMOdinExtensions.git
```

For a fixed revision, use:

```text
https://github.com/VM233/VMOdinExtensions.git#44090874fccc60e4f3cd2fa5079877566927c866
```

## Requirements

- Unity 2022.3 or newer.
- Odin Inspector.
- VMCore runtime/editor assemblies used by several drawers and utilities.

The package keeps the existing assembly names:

- `VMOdinExtensions`
- `VMOdinExtensions.Editor`

## Feature Areas

- Attribute drawers for buttons, collections, conditions, helper text, placeholders, and previews.
- Value dropdowns for animator parameters, build scenes, layers, namespaces, sorting layers, derived types, and Visual Effect Graph names.
- Validation attributes for null/empty checks, duplicate detection, type validation, list length, component requirements, numeric min/max, and range slider rules.
- Custom value drawers for scenes, physics scenes, strings, numeric values, vectors, and rectangle-like data.
- Shared editor utilities for drawing, type-name lists, and dropdown item handling.

## Unity 6000.5 Compatibility

Unity 6000.5 changed `SceneHandle` so implicit conversion to `int` is obsolete. The `SceneDrawer` uses `SceneHandle.GetRawData()` on Unity 6000.5 or newer, while older Unity versions keep the legacy handle path.

## Namespace

Use the package with:

```csharp
using VMFramework.OdinExtensions;
```

