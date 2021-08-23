using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class_Actions_API.Models.ViewModels
{
    //create a client view model to get the client and the claims of the client
    public class ClientVM
    {
        public Client Client { get; set; }
        public IEnumerable<Claim> ClaimList { get; set; }
    }
}
