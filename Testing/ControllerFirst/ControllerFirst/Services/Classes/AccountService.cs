using System.Net;
using System.Net.Mail;
using System.Text;
using AutoMapper;
using ControllerFirst.Contexts;
using ControllerFirst.Data.Models;
using ControllerFirst.DTO.Requests;
using ControllerFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace ControllerFirst.Services.Classes;

public class AccountService : IAccountService
{
    private readonly IMapper _mapper;
    private readonly AuthContext _context;
    private readonly IConfiguration _config;
    private readonly ITokenService _tokenService;

    public AccountService(IMapper mapper, AuthContext authContext, IConfiguration config, ITokenService tokenService)
    {
        _mapper = mapper;
        _context = authContext;
        _config = config;
        _tokenService = tokenService;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        
        var user = _mapper.Map<User>(request);

        user.Password = HashPassword(user.Password);

        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        await _context.UserRoles.AddAsync(new UserRole
        {
            UserNameRef = user.UserName,
            RoleNameRef = "AppUser"
        });

        await _context.SaveChangesAsync();
    }

    public async Task ConfirmEmailAsync(ConfirmRequest request, HttpContext context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == request.username);

        SmtpClient client = new SmtpClient()
        {
            Port = 587,
            EnableSsl = true,
            Host = _config["Smtp:Host"],
            Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"])
        };

        using FileStream fs = new("../ControllerFirst/wwwroot/email.html", FileMode.Open);
        using StreamReader sr = new(fs);
        StringBuilder sb = new(await sr.ReadToEndAsync());

        var link =
            $"{context.Request.Scheme}://{context.Request.Host}/api/v1/Account/VerifyEmail?token={await _tokenService.CreateEmailTokenAsync(request.username)}";

        sb.Replace("{username}", request.username);
        sb.Replace("{link}", link);

        MailMessage message = new()
        {
            From = new MailAddress(_config["Smtp:Username"]),
            Subject = "Email confirmation",
            Body = sb.ToString(),
            IsBodyHtml = true
        };


        message.To.Add(user.Email);

        client.Send(message);
    }

    public async Task VerifyEmailAsync(string token)
    {
        var name = await _tokenService.GetNameFromToken(token);

        bool res = await _tokenService.ValidateEmailTokenAsync(token);
        
        if (res)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == name);

            user.IsEmailConfirmed = true;

            await _context.SaveChangesAsync();
        }
    }
}