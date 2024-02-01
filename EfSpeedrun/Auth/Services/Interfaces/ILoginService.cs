using Auth.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Services;

public interface ILoginService
{
    public void Login(LoginModel model);
}


