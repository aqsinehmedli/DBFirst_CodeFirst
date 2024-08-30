using System;
using System.Collections.Generic;

namespace DBFirst_CodeFirst.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? PageCounts { get; set; }

    public int? AuthorId { get; set; }

    public int? BookTypeId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual BookType? BookType { get; set; }

    public virtual ICollection<StudentBook> StudentBooks { get; set; } = new List<StudentBook>();
}
