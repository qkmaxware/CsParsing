using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestStringParsers {
    [TestMethod]
    public void TestStringIs() {
        InputString text = "Dog";

        Assert.AreEqual(true, String.Is("Dog")(text).HasValue);
        Assert.AreEqual(false, String.Is("Cat")(text).HasValue);
    }

}

}