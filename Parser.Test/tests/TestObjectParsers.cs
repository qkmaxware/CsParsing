using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestObjectParsers {
    [TestMethod]
    public void TestObjectValue() {
        InputString text = "Dog";

        Assert.AreEqual("rulz", Obj.Value("rulz")(text).Value);
    }

}

}