﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ClientSideSaleNotify.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string CustomerType { get; set; }
    }
}
