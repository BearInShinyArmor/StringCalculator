using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StringCalculator
{
    public class OperationSum : Operation
    {
        public OperationSum()
        {
            Symbol = "+";
            Priority = 100;
            LeftOperand = true;
            RightOperand = true;
        }
        public override double GetResult(double a, double b)
        {
            return a + b;
        }
    }
}