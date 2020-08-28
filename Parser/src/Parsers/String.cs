using System;

namespace Qkmaxware.Parsing {

/// <summary>
/// Static parsers for strings
/// </summary>
public static class String {
    /// <summary>
    /// Parse the given string
    /// </summary>
    public static Parser<string> Is(string str) {
        return input => {
            var currentStep = input;
            foreach (var c in str) {
                var next = currentStep.NextChar();
                char parsed;
                if (next.TryGetValue(out parsed)) {
                    if (parsed == c) {
                        // Char is RIGHT
                        currentStep = next.Remainder;
                        continue;
                    } else {
                        // Char is wrong
                        return new Result<string>(new ArgumentException($"Expecting {c} in string {str} but found {parsed}"), input);
                    }
                } else {
                    // Char not found
                    return new Result<string>(new ArgumentException("End of character stream"), input);
                }
            }
            return new Result<string>(str, currentStep);
        };
    }

}

}