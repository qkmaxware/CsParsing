using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestPositionParsers {
    [TestMethod]
    public void TestPositionStart() {
        InputString text = "Dog";

        Assert.AreEqual(0, Position.Start()(text).Value);
    }

    [TestMethod]
    public void TestPositionAt() {
        InputString text = "Dog";

        Assert.AreEqual(0, Position.At(0)(text).Value);
    }

    [TestMethod]
    public void TestPositionEnd() {
        InputString text = "D";

        Assert.AreEqual(0, Position.Start()(text).Value);
    }

}

}