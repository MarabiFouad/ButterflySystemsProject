using ButterflySystems.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ButterflySystems.Models.DTOs
{
    public class CalculationResponse
    {
        public decimal Number1 { get; set; }

        public decimal Number2 { get; set; }

        public decimal Result { get; set; }

        public string Operator { get; set; }

        public string ClientDefaultDisplay
        {
            get
            {
                return $"{Number1} {Operator} {Number2} = {Result}";
            }
        }
    }
}
