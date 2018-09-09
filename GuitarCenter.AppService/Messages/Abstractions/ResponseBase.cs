using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarCenter.AppService.Messages.Abstractions
{
    public abstract class ResponseBase
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}