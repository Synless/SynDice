using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace SynDice.ViewModel
{
    class DiceViewModel : INotifyPropertyChanged
    {
        #region Variables
        System.Random rng = new System.Random(1024);
        private string min = "1";
        public string Min
        {
            get
            {
                return min;
            }
            set
            {
                try
                {
                    int tmp = int.Parse(value);
                    if (tmp < int.Parse(Max))
                    {
                        min = value;
                        
                    }                    
                }
                catch
                {

                }
                OnPropertyChanged("Min");
            }
        }
        private string max = "20";
        public string Max
        {
            get
            {
                return max;
            }
            set
            {
                try
                {
                    int tmp = int.Parse(value);
                    if (tmp > int.Parse(Min))
                    {
                        max = value;
                        
                    }
                }
                catch
                {

                }
                OnPropertyChanged("Max");
            }
        }
        private string res = "";
        public string Res
        {
            get
            {
                return res;
            }
            set
            {
                res = value;
                OnPropertyChanged("Res");
            }
        }
        #endregion
        #region ICommand declaration
        public ICommand Roll { get; set; }
        #endregion

        public DiceViewModel()
        {
            Roll = new Command(roll);
        }
        public void roll(object _message)
        {            
            //Res = rng.Next(min, max+1);
            try
            {
                int _min = int.Parse(min);
                int _max = int.Parse(max);
                Res = rng.Next(_min, _max + 1).ToString();
            }
            catch
            {
                MessageBox.Show("Stop entrer n'importe quoi !");
            }
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}