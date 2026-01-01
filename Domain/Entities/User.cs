using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace Domain.Entities;

public class User
{
    public Guid Id{get; init;}

    public string Name{get; set;} = string.Empty;

    public string Email{get; set;} = string.Empty;

    public string HashPassword {get; init; } = string.Empty;

    public string Description {get; set;} = string.Empty;

    public string ProfilePicURL {get; set;} = string.Empty;

    public string BackgroundPicURL {get; set;} = string.Empty;

    public DateTime CreatedAt {get; init;}

}