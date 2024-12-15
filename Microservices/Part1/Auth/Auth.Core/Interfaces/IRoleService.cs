


using Auth.Application.DTO;

namespace Auth.Core.Interfaces;


public interface IRoleService
{
    public Task<IEnumerable<RoleDTO>> GetAllRolesAsync();
    public Task GrantRoleAsync(GrantRoleDTO roleDto);
    public Task AddNewRoleAsync(RoleDTO role);
}