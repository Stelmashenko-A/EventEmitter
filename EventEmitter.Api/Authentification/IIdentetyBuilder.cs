using System.Security.Claims;
using EventEmitter.UserServices.Models;

namespace EventEmitter.Api.Authentification
{
    public interface IIdentetyBuilder
    {
        ClaimsIdentity Build(User user, string authenticationType);
    }
}