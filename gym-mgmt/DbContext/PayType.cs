using System;
using System.Collections.Generic;

namespace GymDbContext;

public partial class PayType
{
    public int ID { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
