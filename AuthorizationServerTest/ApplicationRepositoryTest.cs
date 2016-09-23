using CredentialStorage;
using NUnit.Framework;

namespace AuthorizationServerTest
{
    public class ApplicationRepositoryTest
    {
        private readonly ApplicationRepository _repository = new ApplicationRepository();

        [Test]
        public void Insert()
        {
            var item = new Application
            {
                ApplicationBase64Secret = "ApplicationBase64Secret",
                Name = "Name"
            };

            _repository.Insert(item);

            Assert.AreNotEqual(null, item.ApplicationId);

        }

        [Test]
        public void Update()
        {
            const string expected = "expected";           
            var item = AddItem();
            item.Name = expected;

            _repository.Update(item);

            item = _repository.Get(item.ApplicationId);
            Assert.AreEqual(expected, item.Name);
        }

        [Test]
        public void Delete()
        {
            var item = AddItem();
            var id = item.ApplicationId;

            _repository.Delete(item);

            item = _repository.Get(id);
            Assert.AreEqual(null, item);
        }

        private Application AddItem()
        {
            var item = new Application()
            {
                ApplicationBase64Secret = "ApplicationBase64Secret",
                Name = "Name"
            };

            _repository.Insert(item);
            return item;
        }
    }
}
