using System;
using System.Collections.Generic;

namespace DBFirst_CodeFirst.Entities;

public partial class StudentBook
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? BookId { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Student? Student { get; set; }
}
