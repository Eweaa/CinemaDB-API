namespace CinemaDB.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string userName { get; set; }
    public required string Password { get; set; }
}
