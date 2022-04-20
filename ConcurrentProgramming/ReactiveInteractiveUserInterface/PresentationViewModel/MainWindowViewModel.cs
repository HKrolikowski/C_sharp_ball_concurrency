
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using TP.ConcurrentProgramming.PresentationModel;
using TP.ConcurrentProgramming.PresentationViewModel.MVVMLight;

namespace TP.ConcurrentProgramming.PresentationViewModel
{
  public class MainWindowViewModel : ViewModelBase

  {  
        private IList _balls;
        private int _radius;
        private ModelAbstractApi ModelLayer = ModelAbstractApi.CreateApi();
        //private int b_Content;
        private int _width;
        private int _height;
        private int _number;


        public MainWindowViewModel() : this(ModelAbstractApi.CreateApi())
        {
        }

        public MainWindowViewModel(ModelAbstractApi modelAbstractApi)
        {
          ModelLayer = modelAbstractApi;
          _radius = ModelLayer.Radius;
          ButtonClick = new RelayCommand(() => ClickHandler());
          _height = ModelLayer.Height + 4;
          _width = ModelLayer.Width + 4;  
          _balls = ModelLayer.CreateBalls(_number);
           Trace.WriteLine("Wywolano konstruktor");
        }


        public int Radius
        {
          get
          {
            return Radius;
          }
        }


        public ICommand ButtonClick { get; set; }

        private void ClickHandler()
        {
               ModelLayer.CreateBalls(_number);
                
                ModelLayer.Moving();
            Trace.WriteLine("dsa");
            //if(_number == 2)
            //    this.Close();
        }

        private void Close()
        {
          throw new System.NotImplementedException();
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

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                if (value.Equals(_number))
                    return;
                if (value < 0 && value > 100)
                    value = 2;
                _number = value;
                RaisePropertyChanged(nameof(Number));
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