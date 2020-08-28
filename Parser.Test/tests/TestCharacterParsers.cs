using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestCharacterParsers {
    [TestMethod]
    public void TestCharacterAny() {
        InputString input = "Dog";
        InputString none = string.Empty;

        Assert.AreEqual(true, Character.Any()(input).HasValue);
        Assert.AreEqual(false, Character.Any()(none).HasValue);
    }

    [TestMethod]
    public void TestCharacterIs() {
        InputString input = "Dog";

        Assert.AreEqual('D', Character.Is('D')(input).Value);
        Assert.AreEqual(false, Character.Is('C')(input).HasValue);
    }

    [TestMethod]
    public void TestCharacterIsNot() {
        InputString input = "Dog";

        Assert.AreEqual('D', Character.IsNot('C')(input).Value);
        Assert.AreEqual(false, Character.IsNot('D')(input).HasValue);
    }

    [TestMethod]
    public void TestCharacterOneOf() {
        InputString input = "Dog";

        Assert.AreEqual('D', Character.OneOf('A', 'B', 'C', 'D')(input).Value);
        Assert.AreEqual(false, Character.OneOf('E', 'F', 'G', 'H')(input).HasValue);
    }

    [TestMethod]
    public void TestCharacterLetter() {
        InputString letters = "Dog";
        InputString digits = "1234";

        Assert.AreEqual('D', Character.Letter()(letters).Value);
        Assert.AreEqual(false, Character.Letter()(digits).HasValue);
    }

    [TestMethod]
    public void TestCharacterDigit() {
        InputString letters = "Dog";
        InputString digits = "1234";

        Assert.AreEqual(false, Character.Digit()(letters).HasValue);
        Assert.AreEqual('1', Character.Digit()(digits).Value);
    }

    [TestMethod]
    public void TestCharacterLetterOrDigit() {
        InputString letters = "Dog";
        InputString digits = "1234";
        InputString symbols = "*/#?";

        Assert.AreEqual('D', Character.LetterOrDigit()(letters).Value);
        Assert.AreEqual('1', Character.LetterOrDigit()(digits).Value);
        Assert.AreEqual(false, Character.LetterOrDigit()(symbols).HasValue);
    }

    [TestMethod]
    public void TestCharacterWhitespace() {
        InputString letters = "Dog";
        InputString whitespace = " \n\t";

        Assert.AreEqual(false, Character.Whitespace()(letters).HasValue);
        Assert.AreEqual(true, Character.Whitespace()(whitespace).HasValue);
    }

}

}
