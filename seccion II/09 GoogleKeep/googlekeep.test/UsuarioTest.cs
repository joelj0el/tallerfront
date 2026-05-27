using FluentNHibernate.Conventions;
using googlekeep.Business;
using googlekeep.Entity;

namespace googlekeep.test
{
    public class UsuarioTest
    {
        public readonly UsuarioBusiness usuarioBusiness;
        public UsuarioTest()
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
            // implementar
            var usuario = usuarioBusiness.getAll().FirstOrDefault();
            var result = usuarioBusiness.getById(usuario!.id);
            if (result.id != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void TestDelete()
        {
            // implementar
            //var usuario = usuarioBusiness.getAll().FirstOrDefault();
            var usuarioId = usuarioBusiness.getLastId();
            usuarioBusiness.delete(new Usuario() { id = usuarioId});
            var result = usuarioBusiness.getById(usuarioId);
            if (result == null)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void TestSaveOrUpdate()
        {
            var result = usuarioBusiness.getById(15000) ?? new Usuario();
            result.name = "franzvladimir.mamani";
            //result.email = "thistest91@gmail.com";
            //result.password = "4dm1n15tr4d0r";
            result.email = "franzvladimir.mamani@uab.edu.bo";
            result.password = "u483dub0";
            usuarioBusiness.SaveOrUpdate(result!);

            if (result.id != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void SendEmail()
        {
            var clientEmail = "franzvladimir.mamani@uab.edu.bo";
            usuarioBusiness.SendEmail(clientEmail);

            if (clientEmail.IsEmpty())
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void Login()
        {
            var email = "franzvladimir.mamani@uab.edu.bo";
            usuarioBusiness.Login(email, "u483dub0");
            if (!email.IsEmpty())
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void IsValidCode()
        {
            var email = "thistest91@gmail.com";
            var code2Factor = 735468;
            var result = usuarioBusiness.isValidCode(email, code2Factor);
            if (result)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }
    }
}
