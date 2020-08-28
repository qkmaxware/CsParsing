# Usage

## Identifying Specific Characters

Use `Character.Any` to create a parser that matches any character in the input stream.
```cs
Character.Any()
```

`Character.Is` can be used to create a parser that matches the character provided via the argument.
```cs
Character.Is('x')
```

`Character.IsNot` can be used to create a parser matches any character except one provided via the argument.
```cs
Character.IsNot('u')
```

`Character.OneOf` can be used to create a parser that matches any of the characters provided via the arguments.
```cs
Character.OneOf('a', 'b', 'c')
```

`Character.IsNotOneOf` can be used to create a parser that matches any character except those provided via the arguments.
```cs
Character.IsNotOneOf('d', 'e', 'f')
```

`Character.Letter` can be used to match all alphabetical characters.
```cs
Character.Letter()
```

`Character.Digit` can be used to match all numeric characters.
```cs
Character.Digit()
```

`Character.LetterOrDigit` can be used to match all alphabetical or numeric characters.
```cs
Character.LetterOrDigit()
```

`Character.Whitespace` can be used to match any whitespace characters.
```cs
Character.Whitespace()
```

## Identifying Specific Strings

Use `String.Is` to create parsers that match the exact sequence of characters in the string argument.
```cs
String.Is("Dog")
```

## Parsing Common Types

This library includes some parsers for commonly used programming concepts.

### Boolean
`Boolean` parses boolean truthy values from the literal strings "true" and "false".
```cs
Literal.Boolean();
```

### Numbers
The `Whole`, `Real`, and `Scientific` methods create parsers for parsing numbers from text. `Whole` parses positive integers including 0. `Real` parses decimal numbers. `Scientific` parses numbers in scientific notation where the exponent is provided after the 'e' character.
```cs
Literal.Whole();
Literal.Real();
Literal.Scientific();
```

To parse any number the `Number` method creates a parser that can parse any of the above numerics formats. 
```cs
Literal.Number();
```

### Comments
Line comments can be parsed using the `Line` method. Line comments begin with '//' and end when the line ends.
```cs
Comment.Line();
```

Block comments can be parsed using the `Block` method. Block comments begin with '/\*' and ends when a '\*/' is found. 
```cs
Comment.Block();
```

In certain languages, block comments can be nested. The `NestedBlock` method creates parsers in which block comments can be nested within each other.
```cs
Comment.NestedBlock();
```

## Sequencing Parsers
### Parser Order
The `Then` combinator applies two parsers in sequence and keeps the results of the second parser. The `Before` combinator applies two parsers in sequence and keeps the results of the first combinator. The `Between` combinator returns the results of the middle parser which is surrounded by two other parsers. 

### Alternatives
The `Or` combinator provides alternative branches. The results of the first parser are used if it exists, otherwise the other parsers are tried until one of them is successful.

## Repeating Parsers
The `ZeroOrMore` combinator repeats the given parser zero or more times and returns a list with the results of all the parsers. The `OneOrMore` combinator is the same as the `ZeroOrMore` combinator except that it requires at least one successful repetition of the parser. Additionally these combinators have variations `ZeroOrMoreSeparatedBy` and `OneOrMoreSeparatedBy` which repeats a parser, but only as long as a separator exists between successive elements. 

## Type Conversion
The `Map` combinator transforms the output of one parser into a different type.