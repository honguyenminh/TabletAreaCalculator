using System;
using System.Windows;
using System.Windows.Controls;

namespace TabletAreaCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainWindowData _data;
        public MainWindow()
        {
            InitializeComponent();
            _data = new MainWindowData();
            DataContext = _data;
            AutoSetResolutionButton_OnClick(null, null);
        }

        private void AutoSetResolutionButton_OnClick(object sender, RoutedEventArgs e)
        {
            _data.ScreenWidth = (int)SystemParameters.PrimaryScreenWidth;
            _data.ScreenHeight = (int)SystemParameters.PrimaryScreenHeight;
        }
    }
}