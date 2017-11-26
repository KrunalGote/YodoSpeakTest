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
using YodoConvertorService;
namespace TestYodoConvertor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConvertorService convertorService;
        public MainWindow(IConvertorService convertorService)
        {
            this.convertorService = convertorService;
            InitializeComponent();
        }

        private async void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            lblOutput.Content = string.Empty;
            lblOutput.Content = await convertorService.ConvertEnglishToYodoSpeak(txtInput.Text);
        }
    }
}
