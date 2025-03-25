using System;
using System.Collections.Generic;

namespace GymDbContext;

public partial class MemberProduct
{
    public string MemberAccount { get; set; } = null!;

    public int ProductID { get; set; }

    public int MemberProductID { get; set; }

    public virtual Member MemberAccountNavigation { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
