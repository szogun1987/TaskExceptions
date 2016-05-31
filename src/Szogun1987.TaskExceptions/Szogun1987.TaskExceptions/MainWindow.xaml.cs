using System;
using System.Threading;
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
            await ThrowExceptioAsync();
        }

        private void WithoutAwait_Click(object sender, RoutedEventArgs e)
        {
            ThrowExceptioAsync();
        }

        private async void WithAwaitAndCompletionSource_Click(object sender, RoutedEventArgs e)
        {
            await ThrowExceptionTaskCompletionSourceAsync();
        }

        private void WithoutAwaitButWithCompletionSource_Click(object sender, RoutedEventArgs e)
        {
            ThrowExceptionTaskCompletionSourceAsync();
        }

        private Task ThrowExceptioAsync()
        {
            return Task.Run(() => { throw new Exception(); });
        }

        private Task ThrowExceptionTaskCompletionSourceAsync()
        {
            var completionSource = new TaskCompletionSource<bool>();

            new Thread(p => completionSource.SetException(new Exception())).Start();

            return completionSource.Task;
        }

        private void GCCollect_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }
    }
}
