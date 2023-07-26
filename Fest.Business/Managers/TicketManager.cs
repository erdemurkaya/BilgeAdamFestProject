using Fest.Business.Dtos.Ticket;
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
    public class TicketManager : ITicketService
    {
        private readonly IRepository<TicketEntity> _ticketrepository;

        private readonly IRepository<FestEntity> _festRpository;

        public TicketManager(IRepository<TicketEntity> ticketRepository, IRepository<FestEntity> festRepository)
        {
            _ticketrepository = ticketRepository;
            _festRpository = festRepository;
        }

        public int TicketBuy(TicketDto dto, int festId)
        {

            var fest=_festRpository.GetByID(festId);


            var ticket = new TicketEntity
            {
                Id=dto.Id,
                Status = dto.Status,
                TicketPrice = fest.TicketPrice * dto.Quantity,
                UserId = dto.UserId,
                FestId = festId

            };

            _ticketrepository.Add(ticket);


            return ticket.Id;
           
        }

       
    }
}
