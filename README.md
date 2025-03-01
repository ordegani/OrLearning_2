* DRY PRINCIPAL* Code Reusability: DRY encourages developers to write code in a way that minimizes redundancy. Instead of duplicating code, developers should create reusable components, functions, or modules that can be shared and applied in multiple parts of the codebase.
Maintenance and Updates: By adhering to DRY, developers reduce the likelihood of errors and bugs that can arise from inconsistent updates. Since a particular piece of logic or knowledge exists in only one place, any changes or enhancements can be made in a centralized location, making maintenance more efficient.
Readability: DRY contributes to code readability by eliminating unnecessary repetition. When developers follow the principle, it becomes easier for others (or even themselves) to understand and navigate the codebase since there are fewer instances of similar or identical code scattered throughout.
Consistency: DRY promotes consistency in the codebase. When a specific functionality is encapsulated in a single location, it ensures that all instances of that functionality behave consistently. This is crucial for creating reliable and predictable software.
Reduced Development Time: By reusing code instead of rewriting it, developers can significantly reduce the time and effort required for development. This is particularly valuable when building large and complex software systems, as it streamlines the development process.
Facilitates Collaboration: DRY enhances collaboration among team members. When code is modular and reusable, it becomes easier for multiple developers to work on different parts of the system without interfering with each other. Each developer can focus on a specific component or module without duplicating efforts.
Avoidance of Copy-Paste Errors: Copying and pasting code can introduce errors, especially if changes are made inconsistently across duplicated sections. DRY minimizes the need for copy-pasting by encouraging the creation of reusable units of code, reducing the risk of introducing errors.
Testability: Reusable and modular code is often easier to test since specific functionalities are encapsulated in distinct units. This makes it simpler to write unit tests and ensure that changes do not inadvertently affect unrelated parts of the system.



[Source](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names), but we have a bit of a polished version:

# Unity style
- Instead of using `public` fields to edit them in Inspector - use `[SerializedField] private`
- In case you need the public value in another class - use property
```csharp
public class Calculations : MonoBehavior
{
    [SerializedField] private float _valueA;
    [SerializedField] private float _valueB;

    public float ValueA => _valueA;

    // or you can use the methods that returns the value
    public float GetValueB()
    {
        return _valueB;
    }
}
```

# C# identifier naming rules and conventions

An **identifier** is the name you assign to a type (class, interface, struct, delegate, or enum), member, variable, or namespace.

## Naming rules

Valid identifiers must follow these rules. The C# compiler produces an error for any identifier that doesn't follow these rules:

- Identifiers must start with a letter or underscore (`_`).
- Identifiers can contain Unicode letter characters, decimal digit characters, Unicode connecting characters, Unicode combining characters, or Unicode formatting characters. For more information on Unicode categories, see the [Unicode Category Database](https://www.unicode.org/reports/tr44/).

You can declare identifiers that match C# keywords by using the `@` prefix on the identifier. The `@` isn't part of the identifier name. For example, `@if` declares an identifier named `if`. These [verbatim identifiers](https://github.com/dotnet/docs/blob/main/docs/csharp/language-reference/tokens/verbatim.md) are primarily for interoperability with identifiers declared in other languages.

For a complete definition of valid identifiers, see the [Identifiers article in the C# Language Specification](https://github.com/dotnet/docs/blob/main/docs/csharp/fundamentals/coding-style/~/_csharpstandard/standard/lexical-structure.md#643-identifiers).

> [!IMPORTANT]
> [The C# language specification](https://github.com/dotnet/docs/blob/main/docs/csharp/fundamentals/coding-style/~/_csharpstandard/standard/lexical-structure.md#643-identifiers) only allows letter (Lu, Ll, Lt, Lm, Lo or Nl), digit (Nd), connecting (Pc), combining (Mn or Mc), and formatting (Cf) categories. Anything outside that is automatically replaced using `_`. This might impact certain Unicode characters.

## Naming conventions

In addition to the rules, conventions for identifier names are used throughout the .NET APIs. These conventions provide consistency for names, but the compiler doesn't enforce them. You're free to use different conventions in your projects.

By convention, C# programs use `PascalCase` for type names, namespaces, and all public members. In addition, the `dotnet/docs` team uses the following conventions, adopted from the [.NET Runtime team's coding style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md):

- Interface names start with a capital `I`.
- Attribute types end with the word `Attribute`.
- Enum types use a singular noun for nonflags, and a plural noun for flags.
- Identifiers shouldn't contain two consecutive underscore (`_`) characters. Those names are reserved for compiler-generated identifiers.
- Use meaningful and descriptive names for variables, methods, and classes.
- Prefer clarity over brevity.
- Use PascalCase for class names and method names.
- Use camelCase for method arguments, local variables, and private fields.
- Use PascalCase for constant names, both fields and local constants.
- Use PascalCase for Static fields
- Private instance fields start with an underscore (`_`).
- Avoid using abbreviations or acronyms in names, except for widely known and accepted abbreviations.
- Use meaningful and descriptive namespaces that follow the reverse domain name notation.
- Choose assembly names that represent the primary purpose of the assembly.
- Avoid using single-letter names, even for simple loops, instead you can use name - `index`, or in complex loops - `bulletIndex`, `npcIndex`, etc.
- The boolean fields/properties or methods that return a boolean should have the answer `true` or `false`
- Try to avoid using `var` if it's possible

> [!TIP]
> You can enforce naming conventions that concern capitalization, prefixes, suffixes, and word separators by using [code-style naming rules](https://github.com/dotnet/docs/blob/main/docs/fundamentals/code-analysis/style-rules/naming-rules.md).

In the following examples, guidance pertaining to elements marked `public` is also applicable when working with `protected` and `protected internal` elements, all of which are intended to be visible to external callers.

### Pascal case

Use pascal casing ("PascalCasing") when naming a `class`, `interface`, `struct`, or `delegate` type.

```csharp
public class DataService
{
}
```

```csharp
public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);
```

```csharp
public struct ValueCoordinate
{
}
```

```csharp
public delegate void DelegateType(string message);
```

When naming an `interface`, use pascal casing in addition to prefixing the name with an `I`. This prefix clearly indicates to consumers that it's an `interface`.

```csharp
public interface IWorkerQueue
{
}
```

When naming `public` members of types, such as fields, properties, events, use pascal casing. Also, use pascal casing for all methods and local functions.

```csharp
public class ExampleEvents
{
    // A public field, these should be used sparingly
    public bool IsValid;

    // An init-only property
    public IWorkerQueue WorkerQueue { get; init; }

    // An event
    public event Action EventProcessing;

    // Method
    public void StartEventProcessing()
    {
        // Local function
        static int CountQueueItems() => WorkerQueue.Count;
        // ...
    }
}
```

When writing positional records, use pascal casing for parameters as they're the public properties of the record.

```csharp
public record PhysicalAddress(
    string Street,
    string City,
    string StateOrProvince,
    string ZipCode);
```

For more information on positional records, see [Positional syntax for property definition](https://github.com/dotnet/docs/blob/main/docs/csharp/language-reference/builtin-types/record.md#positional-syntax-for-property-definition).

### Camel case

Use camel casing ("camelCasing") when naming `private` or `internal` fields and prefix them with `_`. Use camel casing when naming local variables, including instances of a delegate type.

```csharp
public class DataService
{
    private IWorkerQueue _workerQueue;
}
```

> [!TIP]
> When editing C# code that follows these naming conventions in an IDE that supports statement completion, typing `_` will show all of the object-scoped members.

When writing method parameters, use camel casing.

```csharp
public T SomeMethod<T>(int someNumber, bool isValid)
{
}
```

For more information on C# naming conventions, see the [.NET Runtime team's coding style](https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md).

### Type parameter naming guidelines

The following guidelines apply to type parameters on generic type parameters. Type parameters are the placeholders for arguments in a generic type or a generic method. You can read more about [generic type parameters](https://github.com/dotnet/docs/blob/main/docs/csharp/programming-guide/generics/generic-type-parameters.md) in the C# programming guide.

- **Do** name generic type parameters with descriptive names, unless a single letter name is completely self explanatory and a descriptive name wouldn't add value.

```csharp
public interface ISessionChannel<TSession> { /*...*/ }
public delegate TOutput Converter<TInput, TOutput>(TInput from);
public class List<T> { /*...*/ }
```

- **Consider** using `T` as the type parameter name for types with one single letter type parameter.
```csharp
public int IComparer<T>() { return 0; }
public delegate bool Predicate<T>(T item);
public struct Nullable<T> where T : struct { /*...*/ }
```
   
- **Do** prefix descriptive type parameter names with "T".
```
public interface ISessionChannel<TSession>
{
    TSession Session { get; }
}
```

- **Consider** indicating constraints placed on a type parameter in the name of parameter. For example, a parameter constrained to `ISession` might be called `TSession`.

The code analysis rule [CA1715](/visualstudio/code-quality/ca1715) can be used to ensure that type parameters are named appropriately.

### Extra naming conventions

- Examples that don't include [using directives](https://github.com/dotnet/docs/blob/main/docs/csharp/language-reference/keywords/using-directive.md), use namespace qualifications. If you know that a namespace is imported by default in a project, you don't have to fully qualify the names from that namespace. Qualified names can be broken after a dot (.) if they're too long for a single line, as shown in the following example.

```
var currentPerformanceCounterCategory = new System.Diagnostics.
PerformanceCounterCategory();
```

- You don't have to change the names of objects that were created by using the Visual Studio designer tools to make them fit other guidelines.
