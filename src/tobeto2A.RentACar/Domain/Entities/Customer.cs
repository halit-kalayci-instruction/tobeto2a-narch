using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
//public class Customer : User
//{
//    public string? CustomerNo { get; set; }
//}
public class Customer : Entity<Guid>
{
    public string? CustomerNo { get; set; }

    public Guid UserId { get; set; }
    public virtual User User { get; set; }
    public virtual CorporateCustomer? CorporateCustomer { get; set; }
    public virtual IndividualCustomer? IndividualCustomer { get; set; }
}