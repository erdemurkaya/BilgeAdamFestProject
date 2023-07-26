using Fest.Business.Dtos.Payment;
using Fest.Business.Dtos.Ticket;
using Fest.Business.Services;
using Fest.WebUI.Models.ViewModel.PaymentVM;
using Fest.WebUI.Models.ViewModel.TicketVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Fest.WebUI.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class PaymentController : Controller
    {

        private readonly ITicketService _ticketService;

        private readonly IPaymentService _paymentService;

        public PaymentController(ITicketService ticketService,IPaymentService paymentService)
        {
            _ticketService = ticketService;
            _paymentService = paymentService;
        }


        [HttpGet]
        public IActionResult Pay(int festId)
        {
            ViewBag.FestId = festId;

            return View(new PaymentViewModel());
        }
        [HttpPost]
        public IActionResult Pay(PaymentViewModel formData,int festId)
        {


            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "id")?.Value);

            ViewBag.FestId = festId;

            if (ModelState.IsValid)
            {
                var ticket = new TicketDto
                {
                    
                    FestId = festId,
                    Quantity = 1,
                    Status = true,
                    UserId = userId,
                    

                };

                

                int ticketCreated = _ticketService.TicketBuy(ticket,festId);

                if (ticketCreated != null)
                {

                    

                    var payment = new PaymentDto
                    {
                        
                        CardHolderName = formData.CardHolderName,
                        CardNumber = formData.CardNumber,
                        Cvv = formData.Cvv,
                        ExpirationDate=formData.CardExpirationDate,
                        TicketId=ticketCreated,
                        UserId=userId,
                    };

                    _paymentService.Payment(payment);


                    return RedirectToAction("Index", "Home");

                }


            }

            return View();
        }
    }
}
