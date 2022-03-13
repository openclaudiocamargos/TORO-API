using Domain.Entities;

namespace Application.Commom.Interfaces
{
    public interface IUserAuthenticationService
    {
        string GenerateJWT(string valueId);
    }
}
