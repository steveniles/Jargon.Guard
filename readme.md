# Jargon Guard
[![nuget](https://img.shields.io/nuget/v/Jargon.Guard.svg)](https://www.nuget.org/packages/Jargon.Guard/)
[![release](https://img.shields.io/github/release-date/steveniles/Jargon.Guard.svg)](https://github.com/steveniles/Jargon.Guard/releases)
[![license](https://img.shields.io/github/license/steveniles/Jargon.Guard.svg)](https://github.com/steveniles/Jargon.Guard/blob/master/license.txt)

Instread of writing
```csharp
if (parameter == null)
{
    throw new ArgumentNullException();
}
```
you can simply write
```csharp
Guard.CannotBeNull(parameter);
```
or using fluent syntax
```csharp
parameter.CannotBeNull();
```

## Optional arguments
You can optionally provide the parameter name or a custom error message (or both)
```csharp
parameter.CannotBeNull("parameter", "Custom Error Message");
```
is the same as
```csharp
if (parameter == null)
{
    throw new ArgumentNullException(paramName: "parameter", message: "Custom Error Message");
}
```

## Clause expressions
All clauses return the input parameter, so you can guard and consume it on the same line
```csharp
this.SomeProperty = parameter.CannotBeNull();
```
Nullable structs return non-nullable version
```csharp
int number = input.MaybeNullNumber.CannotBeNull();
```

## Other clauses
*Clauses are granular to provide maximum control of possible values*

### Collections
Ensure arrays and collections are not empty
```csharp
items.CannotBeEmpty(); //allows null but not empty
items.CannotBeEmpty().CannotBeNull() //prevents both
```
### Strings
Ensure strings are not empty (`""`) or blank (non-zero whitespace e.g. `" "`)
```csharp
name.CannotBeEmpty().CannotBeBlank();
```

### Guids
Ensure guids are not empty (`00000000-0000-0000-0000-000000000000`)
```csharp
id.CannotBeEmpty();
```
