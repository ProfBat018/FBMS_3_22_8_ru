using System.Runtime.InteropServices.ComTypes;
using AuthData.Configs;
using AuthData.Contexts;
using AuthData.DTO;
using AuthData.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Interfaces;

namespace UserService.Classes;

public class RoleService : IRoleService
{
    private readonly Mapper _mapper;
    private readonly AuthContext _context;

    public RoleService(AuthContext context)
    {
        _context = context;
        _mapper = MappingConfiguration.InitializeConfig();
    }

    public async Task<IEnumerable<RoleDTO>> GetAllRolesAsync()
    {
        try
        {
            var roles = await _context.AppRoles.ToListAsync();
            return _mapper.Map<List<AppRole>, List<RoleDTO>>(roles);
        }
        catch
        {
            throw;
        }
    }

    public async Task AddNewRoleAsync(RoleDTO role)
    {
        try
        {
            var roleToAdd = _mapper.Map<RoleDTO, AppRole>(role);
            await _context.AppRoles.AddAsync(roleToAdd);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }

    public async Task GrantRoleAsync(GrantRoleDTO roleDto)
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == roleDto.email);
        var role = _context.AppRoles.FirstOrDefault(x => x.Name.ToLower() == roleDto.roleName.ToLower());

        var newUserRole = new UserRole()
        {
            RoleId = role.Id,
            UserId = user.Id
        };

        await _context.UserRoles.AddAsync(newUserRole);

        await _context.SaveChangesAsync();

    } 
}



