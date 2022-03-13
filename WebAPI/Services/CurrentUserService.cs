using Application.Commom.Interfaces;
using System.Security.Claims;

namespace WebAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        int? ICurrentUserService.UserId => GetUserId();

        private int? GetUserId()
        {
            var claim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Sid);
            if (claim != null)
                return Convert.ToInt32(claim);
            else
                return default;
        }
    }
}
