using Calculator.Core.Enum;
using Calculator.Core.Interfaces;
using Calculator.Core.Factory;
using System;

namespace Calculator.Core.Concrete
{
    public class Calculator : ICalculator
    {
        public Decimal Buffer { get; private set; }
        public Operations CurrentAction { get; private set; }

        public Calculator()
        {
            Buffer = 0;
            CurrentAction = Operations.Adition;
        }

        public void Calculate(Decimal currentNumber)
        {
            ICalculation calculation = CalculationFactory.Create(CurrentAction);
            Buffer = calculation.Calculate(Buffer, currentNumber);
        }

        public void ChangeAction(Decimal currentNumber, Operations NewAction)
        {
            Calculate(currentNumber);
            CurrentAction = NewAction;
        }

        public void Clear()
        {
            Buffer = 0;
            CurrentAction = Operations.Adition;
        }
    }
}