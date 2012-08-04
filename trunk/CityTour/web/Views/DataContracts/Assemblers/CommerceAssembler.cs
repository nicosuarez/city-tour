using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Views.DataContracts.Assemblers
{
    public class CommerceAssembler
    {
        public static CommerceData Assemble(Commerce commerce) 
        {
            return new CommerceData
            {
                Address = commerce.Address,
                Name = commerce.Name,
                Description = commerce.Description,
                Location = LocationAssembler.Assemble(commerce.Location)
            };
        }
    }
}