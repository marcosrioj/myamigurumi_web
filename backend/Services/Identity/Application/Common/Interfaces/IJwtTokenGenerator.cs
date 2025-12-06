using Identity.Domain.Entities;

namespace Identity.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string CreateToken(AppUser user);
}
