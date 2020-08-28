using System;
using System.Linq;
using System.Collections.Generic;

namespace Qkmaxware.Parsing {

/// <summary>
/// Static parsers for characters
/// </summary>
public static class Character {

    /// <summary>
    /// Parse any character
    /// </summary>
    public static Parser<char> Any() {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                return next;
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }   

    /// <summary>
    /// Parse the given character
    /// </summary>
    public static Parser<char> Is(char c) {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (c == parsed)
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting {c}, but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }   

    /// <summary>
    /// Parse the characters except the given character
    /// </summary>
    public static Parser<char> IsNot(char c) {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (c != parsed)
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Character {c} is not allowed here"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse any of the given characters
    /// </summary>
    public static Parser<char> OneOf(params char[] chars) {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (chars.Contains(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting one of {{ {string.Join(",", chars)} }} but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse a character not in the given set
    /// </summary>
    public static Parser<char> IsNotOneOf(params char[] chars) {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (!chars.Contains(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Character {parsed} is not allowed here"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse any letter
    /// </summary>
    public static Parser<char> Letter() {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (Char.IsLetter(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting letter but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse any digit
    /// </summary>
    public static Parser<char> Digit() {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (Char.IsDigit(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting digit but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse any letter or digit
    /// </summary>
    public static Parser<char> LetterOrDigit() {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (Char.IsLetterOrDigit(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting letter or digit but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

    /// <summary>
    /// Parse any whitespace character
    /// </summary>
    public static Parser<char> Whitespace() {
        return input => {
            var next = input.NextChar();
            char parsed;
            if (next.TryGetValue(out parsed)) {
                if (Char.IsWhiteSpace(parsed))
                    return next;
                else 
                    return new Result<char>(new ArgumentException($"Expecting whitespace but found {parsed}"), input);
            } else {
                return new Result<char>(new ArgumentException("End of character stream"), input);
            }
        };
    }

}

}