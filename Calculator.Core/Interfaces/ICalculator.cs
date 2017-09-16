using Calculator.Core.Enum;
using System;

namespace Calculator.Core.Interfaces
{
    public interface ICalculator
    {
        Decimal Buffer { get; }
        Operations CurrentAction { get; }
        void Calculate(Decimal currentNumber);
        void ChangeAction(Decimal currentNumber, Operations NewAction);
        void Clear();
    }
}
