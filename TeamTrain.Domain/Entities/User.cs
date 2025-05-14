using TeamTrain.Domain.Enums;
using TeamTrain.Domain.Interfaces;

namespace TeamTrain.Domain.Entities;

public class User : IEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public RoleType Role { get; set; }
}