
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase

  {  
        private IList _balls;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
        private int _width;
        private int _height;
        private int _number;
        private string _text;


        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
          ModelLayer = modelAbstractApi;
          StartClick = new RelayCommand(() => CreateBalls());
          StopClick = new RelayCommand(() => StopBalls());
          _height = ModelLayer.Height + 4;
          _width = ModelLayer.Width + 4;  
          _balls = ModelLayer.CreateBalls(_number);
        }

        public ICommand StartClick { get; set; }

        private void CreateBalls()
        {
            ModelLayer.CreateBalls(_number);
            ModelLayer.Moving();
        }

        public ICommand StopClick { get; set; }

        private void StopBalls()
        {
            ModelLayer.StopBalls();     
        }

        public int Height
        {
            get
            {
                return _height;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                try
                {
                    int val = System.Int32.Parse(_text);
                    if (val > 0)
                    {
                        _number = val;
                        RaisePropertyChanged(nameof(Number));
                    }
                }
                catch (System.FormatException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Format");
                    _number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
                catch (System.OverflowException)
                {
                    Trace.WriteLine("Text() z viewModel rzucil wyjatek Overflow");
                    _number = 0;
                    RaisePropertyChanged(nameof(Number));
                }
            }
        }

        public int Number
        {
            get
            {
                return _number;
            }         
        }

        public IList Balls
        {
            get
            {
                return _balls;
            }
            set
            {
                if (value.Equals(_balls))
                    return;
                _balls = value;
                RaisePropertyChanged(nameof(Balls));
            }
        }
  }
}