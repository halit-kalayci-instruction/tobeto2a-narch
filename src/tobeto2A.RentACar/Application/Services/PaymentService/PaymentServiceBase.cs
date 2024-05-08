using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.PaymentService;
public abstract class PaymentServiceBase
{
    public abstract Task<bool> Pay(string cardHolderName, string creditCartNo, string cvc, double price, DateTime expiryDate);
}
