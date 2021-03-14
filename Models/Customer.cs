using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Timers;

namespace ProjectDataWPF.Models
{
    public class Customer : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public long CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string CustomerAddress1 { get; set; }
        public string CustomerAddress2 { get; set; }
        public long CustomerMobileNumber { get; set; }

        private static Timer aTimer;

        public Customer()
        {
            CustomerNumber = 1;
            CustomerName = "James Holden";
            CustomerAge = 32;
            CustomerAddress1 = "123 Penny Lane";
            CustomerAddress2 = "Apt #3C";
            CustomerMobileNumber = 0001112222;

            SetTimer();
        }

        public void SetTimer()
        {
            aTimer = new Timer(1000);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CustomerNumber++;
            OnPropertyChanged("CustomerNumber");
        }
    }
}
