using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            buttonDelayBlock.Content = "Done";
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
            buttonDelay.Content = "Done";
        }

        private void ButtonDelay2_Click(object sender, RoutedEventArgs e)
        {
            var text = buttonDelay2.Content.ToString();
            var length = Task.Run(async () => { return await GetLengthAsync(text); }).Result;
            buttonDelay2.Content = $"Total length is {length}";
        }

        private async Task<int> GetLengthAsync(string text)
        {
            await Task.Delay(3000);
            return text.Length;
        }

        private void ButtonDelay3_Click(object sender, RoutedEventArgs e)
        {
            var text = buttonDelay3.Content.ToString();
            var length = GetLengthWithoutContextAsync(text).Result;
            buttonDelay3.Content = $"Button 3 total length is {length}";
        }

        private async Task<int> GetLengthWithoutContextAsync(string text)
        {
            await Task.Delay(3000).ConfigureAwait(false);
            //Cannot access UI thead here, will throw exception
            //buttonDelay3.Content = $"Try to access UI thread";
            return text.Length;
        }
    }
}
