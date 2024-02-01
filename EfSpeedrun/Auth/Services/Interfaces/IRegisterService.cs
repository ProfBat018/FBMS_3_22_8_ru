using Auth.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Services;

public interface IRegisterService
{
    public void Register(RegisterModel model);
}