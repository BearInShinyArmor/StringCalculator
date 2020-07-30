using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StringCalculator
{
    public class OperationDivide : Operation
    {
        public OperationDivide()
        {
            Symbol = "/";
            Priority = 50;
            LeftOperand = true;
            RightOperand = true;
        }
        public override double GetResult(double a, double b)
        {
            return a / b;
        }
    }
}