using System;
using System.Collections.Generic;
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

namespace AsyncBlockSample
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

        private void ButtonDelayBlock_Click(object sender, RoutedEventArgs e)
        {
            Delay100msAsync().Wait();
            this.buttonDelayBlock.Content = "Done";
        }

        private async Task Delay100msAsync()
        {
            await Task.Delay(100);
        }

        private async Task Delay100msWithoutContextAsync()
        {
            await Task.Delay(100).ConfigureAwait(false);
        }

        private void ButtonDelay_Click(object sender, RoutedEventArgs e)
        {
            Delay100msWithoutContextAsync().Wait();
            this.buttonDelay.Content = "Done";
        }
    }
}
