using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StringCalculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        List<Operation> operations;
       public Calculator()
        {
            operations = new List<Operation>();
            operations.Add(new OperationSum());
            operations.Add(new OperationSubstract());
            operations.Add(new OperationMultiply());
            operations.Add(new OperationDivide());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text=Calculate(TextBox1.Text);
        }

        public string Calculate(string text)
        {
            int begining, end;
            string result = GetStatmentInBrackets(text, out begining, out end);
            if (begining==0 && end==text.Length)
            {
                //скобок нет
                result= DoOperations(text);
            }
            else
            {
                result = Calculate(text.Substring(0, begining ) + Calculate(result) + text.Substring(end+1));
            }

           
            return result;
        }

        public string DoOperations(string text)
        {
            operations.Sort((x, y) => x.Priority.CompareTo(y.Priority));
            foreach(Operation operation in operations)
            {
               while (text.Contains(operation.Symbol))
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text.Substring(i, operation.Symbol.Length) == operation.Symbol)
                        {
                            string LeftOperand="";
                            string RightOperand="";
                            int pointerLeft = i-1;
                            while(pointerLeft>=0 && "0123456789.,".Contains(text[pointerLeft]))
                            {
                                LeftOperand += text[pointerLeft];
                                pointerLeft--;
                            }
                            LeftOperand = new string(LeftOperand.ToCharArray().Reverse().ToArray());
                            int pointerRight = i + operation.Symbol.Length;
                            while (pointerRight < text.Length && "0123456789.,".Contains(text[pointerRight]))
                            {
                                RightOperand += text[pointerRight];
                                pointerRight++;
                            }
                            double operationResult = operation.GetResult(double.Parse(LeftOperand), double.Parse(RightOperand));
                            text = text.Substring(0, pointerLeft+1) + operationResult + text.Substring(pointerRight);
                            break;
                        }
                    }
                }
            }
            return text;
           
        }

        public string GetStatmentInBrackets(string text, out int Begining, out int End)
        {
            //тут придется учитывать, что может быть более одной пары скобок, не быть скобок или вообще непарные скобки
            if(!text.Contains('(')&& !text.Contains(')')){
                Begining = 0;
                End = text.Length;
                return text;
            }
            Begining = -1;
            End = -1;
            string result="Непарные скобки";
            int OpeningBracketsNumber = 0;
            int ClosingBracketsNumber = 0;
            int Pointer = 0;
            while (Pointer < text.Length)
            {
                if (text[Pointer] == '(')
                {
                    OpeningBracketsNumber++;
                }
                else if (text[Pointer] == ')')
                {
                    ClosingBracketsNumber++;
                }
                if (OpeningBracketsNumber > 0 && OpeningBracketsNumber == ClosingBracketsNumber)
                {
                    //нашли нужную закрывающущю скобку
                    Begining = text.IndexOf('(');
                    End = Pointer;
                    result = text.Substring(Begining + 1, End - Begining - 1);
                    break;
                }
                Pointer++;
            }
            return result;
        }
    }
}