using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly2.Models;

namespace vidly2.ViewModels
{
    public class CustomerMembershipTypeViewModel
    {
        public IEnumerable<MembershipType>  MembershipTypes{ get; set; }
        public Customer Customer { get; set; }

        public string Title
        {
            get
            {
                if (Customer!= null && Customer.Id!=0)
                    return "Edit Customer";
                 else
                {
                    return "New Customer";
                }

               
            }
        }
    }
}