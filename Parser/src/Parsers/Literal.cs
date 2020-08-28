using System;
using System.Linq;
using System.Collections.Generic;

namespace Qkmaxware.Parsing {

/// <summary>
/// Static parsers for literals
/// </summary>
public static class Literal {

    /// <summary>
    /// Parse a boolean value
    /// </summary>
    public static Parser<bool> Boolean() {
        return String.Is("true").Or(String.Is("false")).Map(value => System.Boolean.Parse(value));
    }

    /// <summary>
    /// Parse a whole number (positive integers including 0)
    /// </summary>
    public static Parser<long> Whole() {
        return Character.Digit().OneOrMore().Unless(digits => digits[0] == '0' && digits.Count > 1).Map( digits => long.Parse(string.Concat(digits)) );
    }

    /// <summary>
    /// Parse a fractional portion of a decimal number
    /// </summary>
    private static Parser<double> Fraction() {
        return Character.Is('.').Then(Whole().Map(digits => Double.Parse("0." + digits)));
    }

    /// <summary>
    /// Parse a real number
    /// </summary>
    public static Parser<double> Real() {
        return Whole().Then(
            whole => Fraction().Map(frac => whole + frac)
            );
    }

    private static double power (char sign, double @base, long exp) {
        return (
            sign == '-' 
            ? @base * Math.Pow(10, -(double)exp) 
            : @base * Math.Pow(10, (double)exp)
        );
    }

    /// <summary>
    /// Parse a number in scientific format
    /// </summary>
    public static Parser<double> Scientific() {
        return Real().Then(
            value => ( Character.Is('E').Or(Character.Is('e')) ).Then(
                e => ( Character.Is('-').Or(Character.Is('+') ).Optional()).Then(
                    sign => Whole().Map( exp => power(sign, value, exp) )
                )
            )
        );
    }   

    /// <summary>
    /// Parse a number in any of the standard formats
    /// </summary>
    public static Parser<double> Number() {
        return Scientific().Or(Real()).Or(Whole().Map(integer => (double)integer));
    }

    /// <summary>
    /// Parse a TimeSpan in the format of hh:mm:ss[.fffffff]
    /// </summary>
    public static Parser<TimeSpan> Timespan() {
        return Character.Digit().Repeat(2).Then(
            hours => Character.Digit().Repeat(2).Then(
                minutes => Character.Digit().Repeat(2).Then(
                    seconds => Fraction().Optional().Map(
                        fractionalSeconds => { 
                            var hh =  int.Parse(string.Concat(hours));
                            var mm =  int.Parse(string.Concat(minutes));
                            var ss =  int.Parse(string.Concat(seconds));
                            var fffffff = fractionalSeconds;

                            return TimeSpan.FromHours(hh) + TimeSpan.FromMinutes(mm) + TimeSpan.FromSeconds(ss + fffffff);
                        }
                    )
                )
            )
        );
    }

}

}