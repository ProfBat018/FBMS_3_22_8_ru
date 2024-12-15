


using Auth.Application.DTO;
using Microsoft.AspNetCore.Http;

namespace Auth.Core.Interfaces;


public interface IAdminRequestService
{
    public Task<LoginResponse_DTO> CheckRequestAsync(AccessInfo_DTO accessInfo, HttpContext context);
}