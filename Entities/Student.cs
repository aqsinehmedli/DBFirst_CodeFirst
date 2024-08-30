using System;
using System.Collections.Generic;

namespace DBFirst_CodeFirst.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int SchoolNumber { get; set; }

    public int? Gender { get; set; }

    public string Birthday { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<StudentBook> StudentBooks { get; set; } = new List<StudentBook>();
}
