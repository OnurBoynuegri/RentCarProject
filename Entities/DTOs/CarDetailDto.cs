﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public string CarModel { get; set; }
        public decimal DailyPrice { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }

    }
}
