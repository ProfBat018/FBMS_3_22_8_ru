using System;
using System.Collections.Generic;

namespace ControllerFirst.Data.Models;


public  class UserRole
{
    public Guid UserRoleId { get; set; } = new Guid();

    public string UserNameRef { get; set; } 

    public string RoleNameRef { get; set; } 

    public  Role RoleNameRefNavigation { get; set; } 

    public  User UserNameRefNavigation { get; set; } 
}
