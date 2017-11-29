using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestYodoConvertor.Models
{
    public class YodoSpeak : INotifyPropertyChanged
    {
        /// <summary>
        /// Inilitizition of new instance of YodoSpeak class
        /// </summary>
        /// <param name="nputText"></param>
        public YodoSpeak(string inputText)
        {
            this.InputText = inputText;
        }

        private string _InputText;
        /// <summary>
        /// Set YodoSpeak input text
        /// </summary>
        public string InputText
        {
            get { return _InputText; }
            set {
                _InputText = value;
                OnPropertyChanged("InputText");
            }
        }

        private string _OutputText;

        public string OutputText 
        {
            get { return _OutputText; }
            set {
                _OutputText = value;
                OnPropertyChanged("OutputText");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(string ProperyName)
        {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProperyName));

        }
    }
}
