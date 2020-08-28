using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Qkmaxware.Parsing.Test {

[TestClass]
public class TestCommentParsers {

    [TestMethod]
    public void TestCommentLine() {
        InputString text = "// This is a line comment";
        InputString raw = "This is a line comment";

        Assert.AreEqual(" This is a line comment", Comment.Line()(text).Value);
        Assert.AreEqual(false,  Comment.Line()(raw).HasValue);
    }

    [TestMethod]
    public void TestCommentBlock() {
        InputString comment = "/* Comment */";
        InputString nested = "/* comment /* nested comment */*/";
        InputString none = "Doggie";

        Assert.AreEqual(" Comment ", Comment.Block()(comment).Value);
        Assert.AreEqual(" comment /* nested comment ", Comment.Block()(nested).Value);
        Assert.AreEqual(false, Comment.Block()(none).HasValue);
    }

    [TestMethod]
    public void TestCommentNestedBlock() {
        InputString comment = "/* Comment */";
        InputString nested = "/* comment /* nested comment */*/";
        InputString none = "Doggie";

        Assert.AreEqual(" Comment ", Comment.NestedBlock()(comment).Value);
        Assert.AreEqual(" comment  nested comment ", Comment.NestedBlock()(nested).Value);
        Assert.AreEqual(false, Comment.NestedBlock()(none).HasValue);
    }

}

}