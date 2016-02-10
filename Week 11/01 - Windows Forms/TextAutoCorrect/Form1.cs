using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAutoCorrect
{
    public partial class Form1 : Form
    {
        private string[] words;

        public Form1()
        {
            InitializeComponent();

            words = File.ReadAllText(@"..\..\wordsEn.txt").Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void txt_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Space)
            {
                var lastWord = this.textBox1.Text.Split(' ').LastOrDefault();
                if (words.Contains(lastWord))
                {
                    return;
                }

                var currect = string.Empty;
                int min = 10;
                foreach (var word in words)
                {
                    var num = CalcLevenshteinDistance(lastWord, word);

                    if (num < min)
                    {
                        min = num;
                        currect = word;
                        if (num == 1)
                        {
                            break;
                        }
                    }
                }

                if (currect == "")
                {
                    currect = lastWord;
                }

                var text = this.textBox1.Text.Split(' ');
                text[text.Length - 1] = currect;
                var newText = string.Join(" ", text);
                this.textBox1.Text = newText;
                int length = textBox1.Text.Length;
                this.textBox1.SelectionStart = length;
            }
        }

        private int CalcLevenshteinDistance(string a, string b)
        {
            if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b)) return 0;

            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            return distances[lengthA, lengthB];
        }
    }
}
