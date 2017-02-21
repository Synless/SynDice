using System.Windows.Controls;
using SynDice.ViewModel;

namespace SynDice.View
{
    /// <summary>
    /// Logique d'interaction pour Dice.xaml
    /// </summary>
    public partial class Dice : UserControl
    {
        public Dice()
        {
            DataContext = new DiceViewModel();
            InitializeComponent();
        }
    }
}
