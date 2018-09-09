using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Messages.Users
{
    public class DeleteUserRequest
    {
        public Guid UserId { get; set; }
    }
}