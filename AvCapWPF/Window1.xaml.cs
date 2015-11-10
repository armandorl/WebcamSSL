using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace AvCapWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();

            Thread t1 = new Thread(doWork);
            t1.Start();
        }

        public void doWork()
        {
            double counter = 0;
            while (true)
            {
                Console.WriteLine("Working");

                this.Dispatcher.Invoke((Action)(() =>
                    {
                        myLine.X1 = 0;
                        myLine.Y1 = 0;
                        myLine.X2 = counter * 10;
                        myLine.Y2 = counter * 10;
                    }));
                
                counter++;
                Thread.Sleep(1000);  
  
            }
            
        }

    }

    public class ScaleConverter : IMultiValueConverter
    {


        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            float v = (float)values[0];
            double m = (double)values[1];
            return v * m / 50;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
