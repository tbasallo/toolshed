using Toolshed;
namespace ToolGrinder
{
    [TestClass]
    public class CollectionTests
    {
        [TestMethod]
        public void GetBeforeAndAfterValues_Valid_IsValid()
        {

            var list = new List<double>() { 25.5, 27.5, 30, 45 };
            var (a, b) = list.GetBeforeAndAfterValues(28);
            Assert.AreEqual(27.5, a);
            Assert.AreEqual(30, b);
        }
    }
}