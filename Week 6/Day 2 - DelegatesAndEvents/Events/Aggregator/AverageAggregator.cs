using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aggregator
{
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class AverageAggregator
    {
        public event ChangedEventHandler Changed; // EventHandler

        private decimal avarage;
        private ICollection<int> numbers;

        public AverageAggregator() 
        {
            this.numbers = new List<int>();
        }

        public decimal Avarage 
        {
            get 
            {
                return this.avarage;
            }
        }

        public void AddNumber(int number) 
        {
            var currentAvarage = this.avarage;
            this.numbers.Add(number);
            CalculateAvarage();
            if (currentAvarage != this.avarage)
            {
                OnChanged();
            }
        }

        private void CalculateAvarage() 
        {
            long sum = 0;
            foreach (var number in this.numbers)
            {
                sum += number;
            }
            this.avarage = sum / this.numbers.Count;
        }

        private void OnChanged()
        {
            if (this.Changed != null)
            {
                this.Changed(this, EventArgs.Empty);
            }
        }
    }
}
