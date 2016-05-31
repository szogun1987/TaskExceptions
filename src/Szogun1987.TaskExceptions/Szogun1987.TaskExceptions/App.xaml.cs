using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Szogun1987.TaskExceptions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskExceptions;
        }

        private void TaskScheduler_UnobservedTaskExceptions(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }
        
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleException(e.Exception);
        }

        private void HandleException(Exception ex)
        {
            var messageBuilder = new StringBuilder();
            var exception = ex;
            do
            {
                messageBuilder
                    .Append("Message:")
                    .AppendLine(exception.Message)
                    .AppendLine("Stack trace: ")
                    .Append(exception.StackTrace)
                    .AppendLine();
                exception = exception.InnerException;
                if (exception != null)
                {
                    messageBuilder
                        .Append("Caused by:")
                        .AppendLine();
                }
            }
            while (exception != null);

            MessageBox.Show(messageBuilder.ToString());
        }
    }
}
