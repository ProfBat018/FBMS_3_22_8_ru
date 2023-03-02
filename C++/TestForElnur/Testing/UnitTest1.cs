using TestForElnur;
using Testing;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddTest()
        {
            Test t = new();

            var res = t.add(1.2f, 2.8f);

            Assert.AreEqual(4f, res);
        }
    }
}