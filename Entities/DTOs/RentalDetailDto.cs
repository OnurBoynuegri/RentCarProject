﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CarModel { get; set; }
        public decimal DailyPrice { get; set; }
        public string BrandName { get; set; }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public string CompanyName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
