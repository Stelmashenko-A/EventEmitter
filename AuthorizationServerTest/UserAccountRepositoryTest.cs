using CredentialStorage;
using NUnit.Framework;

namespace AuthorizationServerTest
{
    public class UserAccountRepositoryTest
    {
        private readonly UserAccountRepository _repository = new UserAccountRepository();
        
        [Test]
        public void Insert()
        {
            var item = new UserAccount
            {
                Name = "Name",
                Base64Secret = "Base64Secret",
                LoginProvider = "LoginProvider",
                ApplicationId = CreateApplication().ApplicationId
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

            item = _repository.Get(item.UserAccountId);
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

        private UserAccount AddItem()
        {
            var item = new UserAccount
            {
                Name = "Name",
                Base64Secret = "Base64Secret",
                LoginProvider = "LoginProvider",
                ApplicationId = CreateApplication().ApplicationId
            };

            _repository.Insert(item);
            return item;
        }

        private Application CreateApplication()
        {
            var repository = new ApplicationRepository();
            var app = new Application()
            {
                Name = "Name",
                ApplicationBase64Secret = "ApplicationBase64Secret"
            };
            repository.Insert(app);
            return app;
        }
    }
}
