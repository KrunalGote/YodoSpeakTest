using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestYodoConvertor.ViewModels;

namespace TestYodoConvertor.Commads
{
    class YodoSpeakConvertCommand:ICommand
    {
        public YodoSpeakViewModel viewModel  { get; private set; }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="viewModel"></param>
        public YodoSpeakConvertCommand(YodoSpeakViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return viewModel.CanConvertable;
        }

        public void Execute(object parameter)
        {
            viewModel.ConvertToYodoSpeak();
        }
    }
}
