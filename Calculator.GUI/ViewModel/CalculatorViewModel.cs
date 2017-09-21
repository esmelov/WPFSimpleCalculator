using Calculator.Core.Enum;
using Calculator.Core.Interfaces;
using Calculator.GUI.Command;
using System;
using System.ComponentModel;
using CalculatorModel = Calculator.Core.Concrete.Calculator;

namespace Calculator.GUI.ModelView
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        private ICalculator _calculatorModel;
        private String _buffer;
        private Boolean _error;
        private RelayCommand _changeValue;
        private RelayCommand _choiseAction;
        private RelayCommand _clear;
        private RelayCommand _calculate;
        private RelayCommand _changeSign;
        private RelayCommand _trimLastChar;

        public RelayCommand ChangeValue
        {
            get
            {
                return _changeValue ??
                    (_changeValue = new RelayCommand(obj =>
                    {
                        if (!_error)
                            Buffer += obj;
                    }));
            }
        }

        public RelayCommand ChangeSign
        {
            get
            {
                return _changeSign ??
                    (_changeSign = new RelayCommand(obj =>
                    {
                        if (Buffer != "0" && !_error)
                        {
                            Buffer = Buffer.StartsWith("-") ? Buffer.TrimStart('-') : ("-" + Buffer);
                        }
                    }));
            }
        }

        public RelayCommand ChoiceAction
        {
            get
            {
                return _choiseAction ??
                    (_choiseAction = new RelayCommand(obj =>
                    {
                        if (obj is Operations curAct && !_error)
                        {
                            try
                            {
                                _calculatorModel.ChangeAction(Convert.ToDecimal(Buffer), curAct);
                                Buffer = "0";
                                OnPropertyChanged("InnerBuffer");
                            }
                            catch
                            {
                                Buffer = "ERROR";
                                _error = true;
                            }
                        }
                    }));
            }
        }

        public RelayCommand Clear
        {
            get
            {
                return _clear ??
                    (_clear = new RelayCommand(obj =>
                    {
                        _calculatorModel.Clear();
                        Buffer = "0";
                        _error = false;
                        OnPropertyChanged("InnerBuffer");
                    }));
            }
        }

        public RelayCommand Calculate
        {
            get
            {
                return _calculate ??
                    (_calculate = new RelayCommand(obj =>
                    {
                        try
                        {
                            _calculatorModel.Calculate(Convert.ToDecimal(Buffer));
                            Buffer = _calculatorModel.Buffer.ToString();
                            _calculatorModel.Clear();
                            OnPropertyChanged("InnerBuffer");
                        }
                        catch
                        {
                            Buffer = "ERROR";
                            _error = true;
                        }
                    }));
            }
        }

        public RelayCommand TrimLastChar
        {
            get
            {
                return _trimLastChar ??
                    (_trimLastChar = new RelayCommand(obj =>
                    {
                        if (Buffer.Length > 1)
                        {
                            Buffer = Buffer.Substring(0, Buffer.Length - 1);
                        }
                        else
                        {
                            Buffer = "0";
                            _error = false;
                        }
                    }));
            }
        }

        public String Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;
                _buffer = (_buffer.Length > 1) ? _buffer.TrimStart('0') : _buffer;
                _buffer = _buffer == "" ? "0" : _buffer;
                OnPropertyChanged();
            }
        }

        public String InnerBuffer
        {
            get
            {
                return _calculatorModel.Buffer.ToString();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public CalculatorViewModel(ICalculator calculatorModel)
        {
            _calculatorModel = new CalculatorModel();
            _buffer = "0";
            _error = false;
        }

        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}