using Fest.Business.Dtos.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fest.Business.Services
{
    public interface ITicketService
    {

        int TicketBuy(TicketDto dto,int festId);



    }
}
