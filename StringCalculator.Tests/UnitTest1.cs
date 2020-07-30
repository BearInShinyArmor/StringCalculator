using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateReturnResult()
        {
            Calculator calculator = new Calculator();
            Assert.IsNotNull(calculator.Calculate("2+2"));
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnResult()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("2+2", out begining, out end);
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnStatmentInBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("1+(2+3)", out begining, out end);
            Assert.AreEqual("2+3",result);
            Assert.AreEqual( 2, begining);
            Assert.AreEqual( 6, end);
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnStatmentIfAllStatmentIsInBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("(1+2+3)", out begining, out end);
            Assert.AreEqual("1+2+3", result);
            Assert.AreEqual(0,begining);
            Assert.AreEqual(6,end);
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnStatmentIfThereIsMultipleBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("(1+(2+3))+4", out begining, out end);
            Assert.AreEqual("1+(2+3)",result );
            Assert.AreEqual(0,begining);
            Assert.AreEqual(8,end);
        }
        [TestMethod]
        public void GetStatmentinBracketsReturnFullStatmentIfThereIsNoBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("1+2+3", out begining, out end);
            Assert.AreEqual("1+2+3",result );
            Assert.AreEqual( 0,begining);
            Assert.AreEqual( 5,end);
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnErrorIfThereMoreOpeningBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets("(1+2+3", out begining, out end);
            Assert.AreEqual( "Непарные скобки",result);
            Assert.AreEqual( -1,begining);
            Assert.AreEqual(-1, end );
        }
        [TestMethod]
        public void GetStatmentInBracketsReturnErrorIfThereMoreClosingBrackets()
        {
            Calculator calculator = new Calculator();
            int begining;
            int end;
            string result = calculator.GetStatmentInBrackets(")1+2+3)", out begining, out end);
            Assert.AreEqual( "Непарные скобки", result);
            Assert.AreEqual( -1, begining);
            Assert.AreEqual( -1, end);
        }

        [TestMethod]
        public void OperationSumReturnCorrectResult()
        {
            OperationSum sum = new OperationSum();
            Assert.AreEqual(11, sum.GetResult(2, 9));
        }
        [TestMethod]
        public void OperationSubstractReturnCorrectResult()
        {
            OperationSubstract sub = new OperationSubstract();
            Assert.AreEqual(-7, sub.GetResult(2, 9));
        }
        [TestMethod]
        public void OperationMultiplyReturnCorrectResult()
        {
            OperationMultiply mult = new OperationMultiply();
            Assert.AreEqual(18, mult.GetResult(2, 9));
        }
        [TestMethod]
        public void OperationDivideReturnCorrectResult()
        {
            OperationDivide div = new OperationDivide();
            Assert.AreEqual(3, div.GetResult(9, 3));
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtSimpleSumStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("2+2");
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtSimpleSubstractStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("2-2");
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtSimpleMultiplyStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("2*2");
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtSimpleDivideStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("2/2");
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtManySummStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("1+2+3+4+5");
            Assert.AreEqual("15", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtManySubstractStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("10-1-2-3");
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtManyMultiplyStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("1*2*3*4*5");
            Assert.AreEqual("120", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtManyDivideStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("20/5/2");
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void DoOperationsReturnCorrectResultAtManyDifferentOperationsStatment()
        {
            Calculator calculator = new Calculator();
            string result = calculator.DoOperations("10+5*2-4/2");
            Assert.AreEqual("18", result);
        }

        [TestMethod]
        public void CalculateReturnCorrectAnsverOnStatmentWithBrackets()
        {
            Calculator calculator = new Calculator();
            string result = calculator.Calculate("(10+5)*2");
            Assert.AreEqual("30", result);
        }
        [TestMethod]
        public void CalculateReturnCorrectAnsverOnStatmentWithMultipleNonCrossingBrackets()
        {
            Calculator calculator = new Calculator();
            string result = calculator.Calculate("(10+5)*(2+4)");
            Assert.AreEqual("90", result);
        }
        [TestMethod]
        public void CalculateReturnCorrectAnsverOnStatmentWithMultipleCrossingBrackets()
        {
            Calculator calculator = new Calculator();
            string result = calculator.Calculate("(((10+5)-2)*(2+4))");
            Assert.AreEqual("78", result);
        }
    }
}
