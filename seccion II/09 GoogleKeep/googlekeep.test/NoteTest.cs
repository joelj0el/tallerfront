using googlekeep.Business;
using googlekeep.Entity;

namespace googlekeep.test
{
    public class NoteTest
    {
        public readonly NoteBusiness usuarioBusiness;
        public NoteTest()
        {
            usuarioBusiness = new NoteBusiness();
        }
        [Test]
        public void TestGetAll()
        {
            var result = usuarioBusiness.getAll();
            if (result.Count != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }

        [Test]
        public void TestGetById()
        {
            var result = usuarioBusiness.getById(1);
            if (result.id != 0)
                Assert.Pass("Success");
            else
                Assert.Fail("Failed");
        }
    }
}
