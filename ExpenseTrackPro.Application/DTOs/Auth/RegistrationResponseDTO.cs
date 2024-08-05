using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackPro.Application.DTOs.Auth
{
    public class RegistrationResponseDTO
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
    }
}
