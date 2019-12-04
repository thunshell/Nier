using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nier
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        //private DrawingBrush _gridBrush;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            Task.Run(() =>
            {
                while (true)
                {
                    List<int> list = new List<int>();
                    for (int i = 0; i < 50; i++)
                    {
                        list.Add(random.Next(1,100));
                    }
                    Dispatcher.Invoke(() => BuffersView.ItemsSource = list);
                    System.Threading.Thread.Sleep(300);
                }
            });
            Task.Run(() =>
            {
                List<Point> list = new List<Point>();
                while (true)
                {
                    if (list.Count > 10)
                        list.RemoveAt(0);
                    list.Add(new Point(random.Next(500), random.Next(200)));
                    Dispatcher.Invoke(() => PixCanvas.ItemsSource = new List<Point>(list));
                    System.Threading.Thread.Sleep(300);
                }
            });
            //if (_gridBrush == null)
            //{
            //    _gridBrush = new DrawingBrush(new GeometryDrawing(
            //        new SolidColorBrush(Colors.White),
            //             new Pen(new SolidColorBrush(Colors.LightGray), 1.0),
            //                 new RectangleGeometry(new Rect(0, 0, 10, 10))));
            //    _gridBrush.Stretch = Stretch.None;
            //    _gridBrush.TileMode = TileMode.Tile;
            //    _gridBrush.Viewport = new Rect(0.0, 0.0, 10, 10);
            //    _gridBrush.ViewportUnits = BrushMappingMode.Absolute;
            //    //grid.Background = _gridBrush;
            //}
        }
    }
}
