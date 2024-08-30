using System;
using System.Collections.Generic;

namespace DBFirst_CodeFirst.Entities;

public partial class BookType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
