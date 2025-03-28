namespace It4see.Domain;

public class Person(string email, string password)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
}