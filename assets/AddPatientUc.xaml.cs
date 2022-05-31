﻿using DataAccessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for AddPatientUc.xaml
    /// </summary>
    public partial class AddPatientUc : UserControl
    {
        HMSFACTORY hmsfac;
        List<Patient> patientList;
        public AddPatientUc(List<Patient> patientList)
        {
            InitializeComponent();
            hmsfac = new HMSFACTORY();
            this.patientList = patientList;
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            comboCat.ItemsSource = hmsfac.getCategories();
            comboCat.DisplayMemberPath = "cat_name";
            comboCat.SelectedValuePath = "cat_id";
        }
        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            Patient p = new Patient();
            //if (comboCat.SelectedIndex == -1) return;
           
            try
            {
                int catid = int.Parse(comboCat.SelectedValue.ToString());
                String type = "in processes";
                Doctor doc = new Doctor();
                doc = hmsfac.getDoctorId(catid);
                String patientname = patienttxt.Text;
                DateTime dob = new DateTime();
                dob = (DateTime)datepicker.SelectedDate;
                String gender = "male";
                if (radiofemale.IsChecked ?? false)
                {
                    gender = "female";
                }
                if (!string.IsNullOrEmpty(patientname) && ((radiofemale.IsChecked ?? false) || (radiomale.IsChecked ?? false))
                   && dob != null)
                {
                    p.pat_name = patientname;
                    p.pat_dob = dob;
                    p.pat_gender = gender;
                    p.cat_id = catid;
                    p.pat_type = type;
                    p.Doctor = doc;
                    hmsfac.addPatient(p);

                    patienttxt.Text = "";
                    datepicker.Text = "";
                    radiomale.IsChecked = true;
                    comboCat.Text = "";
                    this.Save_btn.IsEnabled = false;
                }
                else
                {
                    MessageBox.Show("All fields are required.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.Save_btn.IsEnabled = true;
                    return;
                }
                this.Save_btn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("All fields are required.+ex", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                Console.WriteLine(ex);
                return;
            }
            this.patientList.Add(p);
            
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new admincontrol());
        }       
    }
}
