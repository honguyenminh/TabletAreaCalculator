using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TabletAreaCalculator
{
    public class MainWindowData : INotifyPropertyChanged
    {
        private int _screenHeight;
        public int ScreenHeight
        {
            get => _screenHeight;
            set
            {
                _screenHeight = Math.Abs(value);
                OnPropertyChanged();
            }
        }
        
        private int _screenWidth;
        public int ScreenWidth
        {
            get => _screenWidth;
            set
            {
                _screenWidth = Math.Abs(value);
                OnPropertyChanged();
            }
        }

        private double _scaleFactor;
        public double ScaleFactor
        {
            get => _scaleFactor;
            set
            {
                if (value > 100) value = 100;
                else if (value < 0) value = 0;
                value = Math.Round(value, 2);
                _scaleFactor = value;
                OnPropertyChanged();
            }
        }
        // TODO: delete these default values after done using them
        private int _tabletWidth = 4000;
        public int TabletWidth
        {
            get => _tabletWidth;
            set
            {
                _tabletWidth = Math.Abs(value);
                OnPropertyChanged();
            }
        }
        
        private int _tabletHeight = 3000;
        public int TabletHeight
        {
            get => _tabletHeight;
            set
            {
                _tabletHeight = Math.Abs(value);
                OnPropertyChanged();
            }
        }

        private int _finalHeight;
        public int FinalHeight
        {
            get => _finalHeight;
            protected set
            {
                _finalHeight = value;
                OnPropertyChanged();
            }
        }
        
        private int _finalWidth;
        public int FinalWidth
        {
            get => _finalWidth;
            protected set
            {
                _finalWidth = value;
                OnPropertyChanged();
            }
        }
        
        private void CalculateFinalResolution()
        {
            double tabletRatio = (double)TabletWidth / TabletHeight;
            double screenRatio = (double)ScreenWidth / ScreenHeight;
            bool keepWidth = tabletRatio < screenRatio;
            if (keepWidth)
            {
                FinalHeight = (int)((float)TabletWidth / ScreenWidth * ScreenHeight * ScaleFactor / 100);
                FinalWidth = (int)(TabletWidth * ScaleFactor / 100);
            }
            else
            {
                FinalWidth = (int)((float)TabletHeight / ScreenHeight * ScreenWidth * ScaleFactor / 100);
                FinalHeight = (int)(TabletHeight * ScaleFactor / 100);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName != nameof(FinalHeight) && propertyName != nameof(FinalWidth))
                CalculateFinalResolution();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}