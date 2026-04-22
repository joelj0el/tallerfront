using googlekeep.Business;

namespace googlekeep.test
{
    public class BasicTest
    {
        public readonly UsuarioBusiness usuarioBusiness;
        public BasicTest()
        {
            usuarioBusiness = new UsuarioBusiness();
        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetAll()
        {
            var result = usuarioBusiness.getAll();
            if(result.Count == 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }
    }
}
