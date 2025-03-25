using System;
using System.Collections.Generic;

namespace GymDbContext;

public partial class MemberCheckIn
{
    public string MemberAccount { get; set; } = null!;

    public int ID { get; set; }

    public DateTime EnterTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public virtual Member MemberAccountNavigation { get; set; } = null!;
}
