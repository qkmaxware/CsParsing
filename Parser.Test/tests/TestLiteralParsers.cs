using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestLiteralParsers {
    [TestMethod]
    public void TestLiteralBoolean() {
        InputString @true = "true";
        InputString @false = "false";
        InputString notbool = "Dog";

        Assert.AreEqual(true, Literal.Boolean()(@true).Value);
        Assert.AreEqual(false, Literal.Boolean()(@false).Value);
        Assert.AreEqual(false, Literal.Boolean()(notbool).HasValue);
    }

    [TestMethod]
    public void TestLiteralWhole() {
        InputString correct = "1234";
        InputString incorrect = "012";
        InputString notnumber = "abc";

        Assert.AreEqual(1234, Literal.Whole()(correct).Value);
        Assert.AreEqual(false, Literal.Whole()(incorrect).HasValue);
        Assert.AreEqual(false, Literal.Whole()(notnumber).HasValue);
    }

    [TestMethod]
    public void TestLiteralReal() {
        InputString correct = "12.5";
        InputString incorrect = "abc";

        Assert.AreEqual(12.5, Literal.Real()(correct).Value);
        Assert.AreEqual(false, Literal.Real()(incorrect).HasValue);
    }

    [TestMethod]
    public void TestLiteralScientific() {
        InputString correct = "12.5e-2";

        Assert.AreEqual(0.125, Literal.Scientific()(correct).Value);
    }

}

}