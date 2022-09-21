using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Model.Base;

namespace Model
{
    public class Caller: BaseEntity<Guid>
    {
        public string CallerName { get; set; }
    }
}
