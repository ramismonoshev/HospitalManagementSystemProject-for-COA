using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for PatientBills.xaml
    /// </summary>
    public partial class PatientBills : Window
    {
        public PatientBills(Bill bill,String patname)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.patient_name.Content = patname;
            this.patient_type.Content = bill.pat_type;
            if (bill.pat_type.Equals("outdoor"))
            {
                this.patient_noofday.Content = "-";
                this.patient_roomchrg.Content = "-";
                this.patient_admitdate.Content = "-";
                this.patient_leavedate.Content = "-";
            }
            else
            {
                this.patient_roomchrg.Content = bill.room_charge;
                this.patient_noofday.Content = bill.no_of_days;
                this.patient_leavedate.Content = bill.leave_date;
                this.patient_admitdate.Content = bill.admit_date;
            }
            this.patient_totalbill.Content = bill.total_bill;
            this.patient_docchrg.Content = bill.doctor_charge;
            this.patient_medchrg.Content = bill.med_charge;
            this.doc_name.Content = bill.doc_name;
        }
    }
}
