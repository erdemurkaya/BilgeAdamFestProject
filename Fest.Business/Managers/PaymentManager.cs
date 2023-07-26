using Fest.Business.Dtos.Payment;
using Fest.Business.Services;
using Fest.DAL.Abstract;
using Fest.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Managers
{
    public class PaymentManager : IPaymentService
    {

        private readonly IRepository<PaymentEntity> _paymentRepository;

        public PaymentManager(IRepository<PaymentEntity> paymentRepository )
        {
            _paymentRepository = paymentRepository;
        }

        public void Payment(PaymentDto dto)
        {
            var payment = new PaymentEntity
            {
                CardExpiration = dto.ExpirationDate,
                CardHolderName = dto.CardHolderName,
                CardNumber = dto.CardNumber,
                Cvv = dto.Cvv,
                TicketId = dto.TicketId,              
                UserId = dto.UserId,

            };


            _paymentRepository.Add(payment);
        }
    }
}
