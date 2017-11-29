using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YodoConvertorService;
using TestYodoConvertor.Models;
using TestYodoConvertor.Commads;
using System.Windows.Input;

namespace TestYodoConvertor.ViewModels
{
   public class YodoSpeakViewModel
    {
        public YodoSpeak YodoSpeak { get; private set; }
        public IConvertorService ConvertService { get; private set; }
        /// <summary>
        /// Disable Convert button if textbox is empty
        /// </summary>
        /// <returns></returns>
        public bool CanConvertable {
            get {
                if (YodoSpeak == null)
                {
                    return false;
                }
                return !string.IsNullOrWhiteSpace(YodoSpeak.InputText);
            }
        }

        public YodoSpeakViewModel(IConvertorService ConvertService)
        {
            YodoSpeak = new YodoSpeak("Convert to Yodo speak.");
            this.ConvertService = ConvertService;
            ConvertCommand = new YodoSpeakConvertCommand(this);
        }

        public ICommand ConvertCommand { get; private set; }
        /// <summary>
        /// Convert InputText To Yodo Speak
        /// </summary>
        public async void ConvertToYodoSpeak()
        {
            YodoSpeak.OutputText = String.Empty;
            YodoSpeak.OutputText = await ConvertService.ConvertEnglishToYodoSpeak(YodoSpeak.InputText);
        }
    }
}
