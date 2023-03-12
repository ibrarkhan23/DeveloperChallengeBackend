using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperChallenge.Models.Dtos.OutputDtos
{
    public class ShipperDetailOutPutDto
    {
        public int shipmentId { get; set; }
        public string shipperName { get; set; }
        public string carrierName { get; set; }
        public string shipmentDescription { get; set; }
        public decimal shipmentWeight { get; set; }
        public string shipmentRateDescription { get; set; }
    }
    public class ShipperNameOutPutDto
    {
        public int shipperId { get; set; }
        public string shipperName { get; set; }
    }
}
