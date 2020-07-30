using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StringCalculator
{
    public abstract class Operation
    {
        public int Priority { get; set; }
        //100-уровень сложения, 50-уровень умножения. Можно вставлять разные уровни между ними если хочется странного
        public string Symbol { get; set; }
        public bool LeftOperand { get; set; }
        //если захочется реализовать что-то унарное
        public bool RightOperand { get; set; }
        public abstract double GetResult(double a, double b);
    }
}