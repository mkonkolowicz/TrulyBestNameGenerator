using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace TrulyBestNameGenerator.ViewModel
{
    public partial class MainWindowViewModel : ObservableObject
    {
        const string DefaultText = "Enter Your Name";
        private string _resultantCatSource;
        private string _resultantLabelContent;
        private string _enteredName;
        public byte[] ResultantCatImage
        {
            get { return File.ReadAllBytes(ResultantCatSource); }
        }
        public string ResultantCatSource
        {
            get
            {
                return _resultantCatSource;
            }
            set 
            {
                _resultantCatSource = value;
                RaisePropertyChangedEvent("ResultantCatSource");
                RaisePropertyChangedEvent("ResultantCatImage");
            } 
              
        }
        public string EnteredName
        {
            get
            {
                return _enteredName;
            }
            set
            {
                _enteredName = value;
                RaisePropertyChangedEvent("EnteredName");
            }
        }
        public string ResultantLabelContent
        {
            get
            {
                return _resultantLabelContent;
            }
            set
            {
                _resultantLabelContent = value;
                RaisePropertyChangedEvent("ResultantLabelContent");
            }
        }    
        public ICommand ButtonCommand { get; set; }
        public ICommand ChangePictureCommand
        {
            get { return new DelegateCommand(DecideOnPicture); }
        }
        
        public MainWindowViewModel()
        {
            
            ResultantCatSource = "pictures\\YouCoolMan.jpg";
            EnteredName = DefaultText;
        }
        
        public void DecideOnPicture()
        {
            var enteredNameText = EnteredName;
            EnteredName = string.Empty;

            if ((String.Equals(enteredNameText, DefaultText, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            if((String.Equals(enteredNameText, "Maciek", StringComparison.OrdinalIgnoreCase)))
            {
                ResultantCatSource = "pictures\\OpenMouthCat.gif";
                ResultantLabelContent = string.Format("Cool Name {0}", enteredNameText);
                EnteredName = "Cool...";
                return;
            }
            ResultantCatSource = "pictures\\UnimpressedCat.png";
            ResultantLabelContent = string.Format("{0}, Unimpressed Cat is Unimpressed With Your Name...", enteredNameText);
        }
        public void ChangePictureSource(object obj)
        {
            this.ResultantCatSource = "pictures\\OpenMouthCat.gif";       
        }
    }
}
