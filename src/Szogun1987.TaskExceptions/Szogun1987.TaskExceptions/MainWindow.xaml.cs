using System;
using System.Threading.Tasks;
using System.Windows;

namespace Szogun1987.TaskExceptions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void WithAwait_Click(object sender, RoutedEventArgs e)
        {
            await ThrowException();
        }

        private void WithoutAwait_Click(object sender, RoutedEventArgs e)
        {
            ThrowException();
        }

        private Task ThrowException()
        {
            return Task.Run(() => { throw new Exception(); });
        }

        private void GCCollect_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
