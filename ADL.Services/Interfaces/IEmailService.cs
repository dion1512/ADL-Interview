using ADL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
