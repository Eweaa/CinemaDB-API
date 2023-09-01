using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDB.Domain.Entities;
public class Actor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Movie> Movies { get; } = new();
}
