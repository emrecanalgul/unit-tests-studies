using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitStudies.APP.Calculator
{
    public class Calculator
    {
        private ICalculatorService _calculatorService;
        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public int Add(int a, int b)
        {
            return _calculatorService.Add(a, b);
        }

        public int Divide(int a, int b)
        {
            return (_calculatorService.Divide(a, b));
        }
    }
}
