using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string userName { get; set; }
    public required string Password { get; set; }
}
