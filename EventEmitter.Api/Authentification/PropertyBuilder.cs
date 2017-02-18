using System.Collections.Generic;
using EventEmitter.UserServices.Models;
using Microsoft.Owin.Security;

namespace EventEmitter.Api.Authentification
{
    public class PropertyBuilder : IPropertyBuilder
    {
        public AuthenticationProperties Build(User user)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", user.Name }
            };
            return new AuthenticationProperties(data);
        }
    }
}