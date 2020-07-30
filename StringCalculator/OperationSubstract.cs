using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StringCalculator
{
    public class OperationSubstract : Operation
    {
        public OperationSubstract()
        {
            Symbol = "-";
            Priority = 100;
            LeftOperand = true;
            RightOperand = true;
        }
        public override double GetResult(double a, double b)
        {
            return a - b;
        }
    }
}