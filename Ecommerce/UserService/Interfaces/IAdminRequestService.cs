using AuthData.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Interfaces;

public interface IAdminRequestService
{
    public Task<LoginResponse_DTO> CheckRequestAsync(AccessInfo_DTO accessInfo, HttpContext context);
}