using EventEmitter.UserServices.Models;
using Microsoft.Owin.Security;

namespace EventEmitter.Api.Authentification
{
    public interface IPropertyBuilder
    {
        AuthenticationProperties Build(User user);
    }
}