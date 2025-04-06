using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ToroTrader.Application.Features.Users.CreateUser;

public class CreateUserRequest
{
    [DefaultValue("")]
    public string Name { get; set; }

    [DefaultValue("")]
    public string DocumentNumber { get; set; }

    public decimal Balance { get; set; }
}
