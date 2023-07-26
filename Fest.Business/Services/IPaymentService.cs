using Fest.Business.Dtos.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface IPaymentService
    {

        void Payment(PaymentDto dto);
    }
}
