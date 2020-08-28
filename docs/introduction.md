# Introduction

## Parsers
Parsers are functions that can be used to identify specific phrases within input text and return a computer friendly data-structure representing the type of parsed content. Any function matching the following signature can be used as a parser.

```cs
Result<T> Parser<T>(IInput input);
```

## Combinators
Combinators are functions that can be used to apply transformations to parsers in order to construct new parsers. Combinators can be stacked to create complicated parsers from simple ones. Any function matching the following signaure can be used as a combinator.

```cs
Parser<O> Combinator<I,O>(Parser<I> parser)
```

This library implements several default combinators which are applied as extension methods on any compatible parser functions. 