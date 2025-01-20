using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DynamicallyAddAndRemoveObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Brush customColor;
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;

                myCanvas.Children.Remove(activeRectangle);
            }
            else
            {
                customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));

                Rectangle newRextangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = customColor,
                    StrokeThickness = 3,
                    Stroke = Brushes.Black
                };
                
                Canvas.SetLeft(newRextangle, Mouse.GetPosition(myCanvas).X);
                Canvas.SetTop(newRextangle, Mouse.GetPosition(myCanvas).Y);

                myCanvas.Children.Add(newRextangle);
            }

        }
    }
}