using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DorfmantikHelper
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

        private void SearchForText_TextChanged(object sender, TextChangedEventArgs e)
        {
            StringBuilder results = new StringBuilder();
            if (SearchForText.Text.Length != 6)
            {
                ResultsText.Text = "need 6 chars to continue";
                return;
            }
            var thisTile = new DorfTile(SearchForText.Text); 
            var lines = AvailableText.Text.Split(Environment.NewLine);
            int lineNo = 0;
            for (; lineNo < lines.Length; lineNo++)
            {
                string? line = lines[lineNo];
                if (line.Length >= 6)
                {
                    var dorfTile = new DorfTile(line);
                    if (thisTile.Match(dorfTile))
                    {

                        results.AppendLine($"Line: {lineNo + 1} {line} matches permutation {SearchForText.Text}");
                    }
                }
            }
            results.AppendLine($"Done checking {lineNo} lines");
            ResultsText.Text = results.ToString();
        }
    }
}
