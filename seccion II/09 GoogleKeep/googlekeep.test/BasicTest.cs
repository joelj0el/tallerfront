using googlekeep.Business;
using googlekeep.Entity;

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
            if(result.Count != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void TestGetById()
        {

        }

        [Test]
        public void TestDelete()
        {

        }

        [Test]
        public void TestSaveOrUpdate()
        {
            var result = usuarioBusiness.getById(100) ?? new Usuario();
            result.name = "Tomm";
            result.email = "Tomm@mail.com";
            result.password = "8008080";
            usuarioBusiness.SaveOrUpdate(result!);

            if (result.id != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }
    }
}
