using System;
using System.Collections.Generic;

namespace GymDbContext;

public partial class Member
{
    public string Account { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly? BirthDay { get; set; }

    public string? Email { get; set; }

    public bool? IsEmailValid { get; set; }

    public string? Barcode { get; set; }

    public string? Address { get; set; }

    public string EmgContact { get; set; } = null!;

    public string EmgContactTel { get; set; } = null!;

    public virtual ICollection<MemberCheckIn> MemberCheckIns { get; set; } = new List<MemberCheckIn>();

    public virtual ICollection<MemberProduct> MemberProducts { get; set; } = new List<MemberProduct>();
}
