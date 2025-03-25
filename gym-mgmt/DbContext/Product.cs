using System;
using System.Collections.Generic;

namespace GymDbContext;

public partial class Product
{
    public int ID { get; set; }

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public int PayType { get; set; }

    public int ProductType { get; set; }

    public int Period { get; set; }

    public virtual ICollection<MemberProduct> MemberProducts { get; set; } = new List<MemberProduct>();

    public virtual PayType PayTypeNavigation { get; set; } = null!;

    public virtual ProductType ProductTypeNavigation { get; set; } = null!;
}
