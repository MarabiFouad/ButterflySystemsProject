using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ButterflySystems.Models.Enums
{
    public enum CalculatorOperator
    {
        [Description("+")]
        Add = 0,
        [Description("-")]
        Subtract = 1,
        [Description("*")]
        Multiply = 2,
        [Description("/")]
        Divide = 3
    }
}
