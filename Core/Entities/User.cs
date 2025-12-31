using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

public class User
{
    public Guid Id{get; init;}

    public string Name{get; set;}

    public string Email{get; set;}

    public string HashPassword {private get; init; }

    public string Description {get; set;}

    public string ProfilePicURL {get; set;}

    public string BackgroundPicURL {get; set;}

    public DateTime CreatedAt {get; init;}

}