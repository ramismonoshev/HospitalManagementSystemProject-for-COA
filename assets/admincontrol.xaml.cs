using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for admincontrol.xaml
    /// </summary>
    public partial class admincontrol : UserControl
    {
        List<Patient> patientList;
        List<Doctor> doctorList;
        List<Nurse> nurseList;
        HMSFACTORY hmsfac;
        List<Room> roomList;
        List<IndoorPatient> indpatList;
        List<Prescription> prescList;
        List<Bill> billpatlist;
        int indexselected = -1;
        Doctor docselected = null;
        Nurse nurselected = null;
        Patient patselected = null;
        Room roomselected = null;
        Bill billselected = null;
        public admincontrol()
        {
            InitializeComponent();
            hmsfac = new HMSFACTORY();
            this.firstnametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.lastnametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.datepicker_update.Visibility = System.Windows.Visibility.Hidden;
            this.cellno_update.Visibility = System.Windows.Visibility.Hidden;

            this.usernametxt_update.Visibility = System.Windows.Visibility.Hidden;
            this.passwordbox_update.Visibility = System.Windows.Visibility.Hidden;
            this.specialization_update.Visibility = System.Windows.Visibility.Hidden;
            this.salary_update.Visibility = System.Windows.Visibility.Hidden;
            this.datepicker_update.Visibility = System.Windows.Visibility.Hidden;
            this.btn_delete.Visibility = System.Windows.Visibility.Hidden;
            this.btn_update.Visibility = System.Windows.Visibility.Hidden;
            //this.rbFemale_update.Visibility = System.Windows.Visibility.Hidden;
            //this.rbMale_update.Visibility = System.Windows.Visibility.Hidden;
            //this.delete_btn.Visibility = System.Windows.Visibility.Hidden;
            //this.update_btn.Visibility = System.Windows.Visibility.Hidden;
            this.firstnamelbl.Visibility = System.Windows.Visibility.Hidden;
            this.lastnamelbl.Visibility = System.Windows.Visibility.Hidden;
            this.passwordlbl.Visibility = System.Windows.Visibility.Hidden;
            this.phonelbl.Visibility = System.Windows.Visibility.Hidden;
            this.salarylbl.Visibility = System.Windows.Visibility.Hidden;
            this.speciallbl.Visibility = System.Windows.Visibility.Hidden;
            this.doblbl.Visibility = System.Windows.Visibility.Hidden;
            this.genderlbl.Visibility = System.Windows.Visibility.Hidden;
            this.unamelbl.Visibility = System.Windows.Visibility.Hidden;
            this.rbMale_update.Visibility = System.Windows.Visibility.Hidden;
            this.rbFemale_update.Visibility = System.Windows.Visibility.Hidden;
        }
        public void LoadData(object sender, DoWorkEventArgs e)
        {
            doctorList = hmsfac.getDoctor();
            nurseList = hmsfac.getNurse();
            patientList = hmsfac.getPatient();
            roomList = hmsfac.getRoom();
            indpatList = hmsfac.getIndoorPatient();
            prescList = hmsfac.getPrescriptions();
            billpatlist = hmsfac.getBills();
            this.Dispatcher.Invoke(new Action(delegate
                {
                    dataGrid_Doctor.ItemsSource = doctorList;
                    dataGrid_Nurse.ItemsSource = nurseList;
                    dataGrid_Patient.ItemsSource = patientList;
                    dataGrid_Room.ItemsSource = roomList;
                    dataGrid_IndoorPatients.ItemsSource = indpatList;
                    dataGrid_Patients_Bill.ItemsSource = billpatlist;

                    specialization_update.ItemsSource = hmsfac.getCategories();
                    governedbytxt_update.ItemsSource = nurseList;
                    cboselroom_no.ItemsSource = roomList;

                    patname_bill.ItemsSource = patientList;
                    patname_bill.SelectedValuePath = "pat_id";
                    patname_bill.DisplayMemberPath = "pat_name";
                    patcombobox_updatedoc.ItemsSource = doctorList;
                }));
        }
        private void Window_loaded(object sender, RoutedEventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += LoadData;
            worker.RunWorkerAsync();

        }
        private void AddDoctor_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddDoctorUc(doctorList));
            dataGrid_Doctor.Items.Refresh();
        }
        private void AddNurse_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddNurseUc(nurseList));
            dataGrid_Nurse.Items.Refresh();
        }

        private void AddPatient_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddPatientUc(patientList));
            dataGrid_Doctor.Items.Refresh();
        }

        private void AddRoom_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddRoomUc(nurseList,roomList,hmsfac));
            dataGrid_Patient.Items.Refresh();
        }
        private void Logout_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void AddPharmacist_Btn_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new AddPharmacistUc());
        }

        private void dataGrid_Doctor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.btn_delete.IsEnabled = true;
            this.btn_update.IsEnabled = true;
            this.firstnametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.lastnametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.datepicker_update.Visibility = System.Windows.Visibility.Visible;
            this.cellno_update.Visibility = System.Windows.Visibility.Visible;

            this.usernametxt_update.Visibility = System.Windows.Visibility.Visible;
            this.passwordbox_update.Visibility = System.Windows.Visibility.Visible;
            this.specialization_update.Visibility = System.Windows.Visibility.Visible;
            this.salary_update.Visibility = System.Windows.Visibility.Visible;
            this.datepicker_update.Visibility = System.Windows.Visibility.Visible;
            this.btn_delete.Visibility = System.Windows.Visibility.Visible;
            this.btn_update.Visibility = System.Windows.Visibility.Visible;
            this.rbFemale_update.Visibility = System.Windows.Visibility.Visible;
            this.rbMale_update.Visibility = System.Windows.Visibility.Visible;
            this.firstnamelbl.Visibility = System.Windows.Visibility.Visible;
            this.lastnamelbl.Visibility = System.Windows.Visibility.Visible;
            this.passwordlbl.Visibility = System.Windows.Visibility.Visible;
            this.phonelbl.Visibility = System.Windows.Visibility.Visible;
            this.salarylbl.Visibility = System.Windows.Visibility.Visible;
            this.speciallbl.Visibility = System.Windows.Visibility.Visible;
            this.doblbl.Visibility = System.Windows.Visibility.Visible;
            this.unamelbl.Visibility = System.Windows.Visibility.Visible;
            this.genderlbl.Visibility = System.Windows.Visibility.Visible;
            this.rbFemale_update.Visibility = System.Windows.Visibility.Visible;
            this.rbFemale_update.Visibility = System.Windows.Visibility.Visible;
            this.indexselected = dataGrid_Doctor.SelectedIndex;
            if (indexselected == -1 || doctorList.Count <= indexselected)
            {
                docselected = null;
                this.btn_delete.IsEnabled = false;
                this.btn_update.IsEnabled = false;
                return;
            }
            this.btn_update.IsEnabled = true;
            this.btn_update.IsEnabled = true;
            docselected = (Doctor)dataGrid_Doctor.SelectedItem;

            this.firstnametxt_update.Text = docselected.Employee.emp_firstname;
            this.lastnametxt_update.Text = docselected.Employee.emp_lastname;
            this.usernametxt_update.Text = docselected.Employee.User.user_name;
            this.passwordbox_update.Password = docselected.Employee.User.user_password;
            this.specialization_update.Text = docselected.Category.cat_name;
            this.cellno_update.Text = docselected.Employee.emp_phone;
            this.salary_update.Text = docselected.Employee.emp_salary.ToString();
            this.datepicker_update.Text = docselected.Employee.emp_dob.ToString();
            if (docselected.Employee.emp_gender.Equals("female"))
            {
                rbFemale_update.IsChecked = true;
            }
            else
            {
                rbMale_update.IsChecked = true;
            }
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (docselected == null)
            {
                return;
            }

            String updated_firstname = firstnametxt_update.Text;
            String updated_lastname = lastnametxt_update.Text;
            String updated_username = usernametxt_update.Text;
            String updated_password = passwordbox_update.Password;
            String updated_cellno = cellno_update.Text;
            int updated_salary = int.Parse(salary_update.Text);
            DateTime dob = new DateTime();
            dob = (DateTime)datepicker_update.SelectedDate;
            int catid = int.Parse(specialization_update.SelectedValue.ToString());
            String type = "doctor";
            String gender = "male";
            if (rbFemale_update.IsChecked ?? false)
            {
                gender = "female";
            }

            docselected.Employee.emp_firstname = updated_firstname;
            docselected.Employee.emp_lastname = updated_lastname;
            docselected.Employee.emp_phone = updated_cellno;
            docselected.Employee.emp_gender = gender;
            docselected.Employee.emp_salary = updated_salary;
            docselected.Employee.emp_dob = dob;
            docselected.cat_id = catid;

            docselected.Employee.User.user_type = type;
            docselected.Employee.User.user_password = updated_password;
            docselected.Employee.User.user_name = updated_username;

            hmsfac.updateDoctor(docselected);
            dataGrid_Doctor.Items.Refresh();
            patientList = hmsfac.getPatient();
            dataGrid_Patient.Items.Refresh();

            this.btn_update.IsEnabled = false;
            this.btn_delete.IsEnabled = false;
            firstnametxt_update.Text = "";
            lastnametxt_update.Text = "";
            usernametxt_update.Text = "";
            passwordbox_update.Password = "";
            datepicker_update.Text = "";
            specialization_update.Text = "";
            salary_update.Text = "";
            rbMale_update.IsChecked = false;
            rbFemale_update.IsChecked = false;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (docselected == null)
            {
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete " + docselected.Employee.emp_firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result))
            {
                return;
            }
            docselected.cat_id = int.Parse(this.specialization_update.SelectedValue.ToString());
            hmsfac.remove(docselected);
            doctorList.Remove(docselected);
            dataGrid_Doctor.Items.Refresh();
            dataGrid_Patient.Items.Refresh();
            this.btn_delete.IsEnabled = false;
            firstnametxt_update.Text = "";
            lastnametxt_update.Text = "";
            usernametxt_update.Text = "";
            passwordbox_update.Password = "";
            datepicker_update.Text = "";
            specialization_update.Text = "";
            salary_update.Text = "";
            rbMale_update.IsChecked = false;
            rbFemale_update.IsChecked = false;

        }
        private void dataGrid_Nurse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.nurse_btnDelete.IsEnabled = true;
            this.nurse_btnUpdate.IsEnabled = true;
            this.indexselected = dataGrid_Nurse.SelectedIndex;
            if (indexselected == -1 || nurseList.Count < indexselected)
            {
                nurselected = null;
                this.nurse_btnDelete.IsEnabled = false;
                this.nurse_btnUpdate.IsEnabled = false;
                return;
            }
            nurselected = (Nurse)dataGrid_Nurse.SelectedItem;

            this.fnametxt_nurseUpdate.Text = nurselected.Employee.emp_firstname;
            this.lnametxt_nurseUpdate.Text = nurselected.Employee.emp_lastname;
            this.unametxt_nurseUpdate.Text = nurselected.Employee.User.user_name;
            this.passtxt_nurseUpdate.Password = nurselected.Employee.User.user_password;
            this.spectxt_nurseUpdate.Text = nurselected.nurse_experience;
            this.cellno_nurseUpdate.Text = nurselected.Employee.emp_phone;
            this.saltxt_nurseUpdate.Text = nurselected.Employee.emp_salary.ToString();
            this.datepicker_nurseUpdate.Text = nurselected.Employee.emp_dob.ToString();

        }

        private void btn_UpdateNurse_Click(object sender, RoutedEventArgs e)
        {
            if (nurselected == null)
            {
                return;
            }

            String firstname = fnametxt_nurseUpdate.Text;
            String lastname = lnametxt_nurseUpdate.Text;
            String username = unametxt_nurseUpdate.Text;
            String password = passtxt_nurseUpdate.Password;
            String experience = spectxt_nurseUpdate.Text;
            String phone = cellno_nurseUpdate.Text;
            DateTime dob = (DateTime)datepicker_nurseUpdate.SelectedDate;
            int salary = int.Parse(saltxt_nurseUpdate.Text);
            String gender = "female";
            String type = "nurse";
            nurselected.Employee.emp_firstname = firstname;
            nurselected.Employee.emp_lastname = lastname;
            nurselected.Employee.emp_phone = phone;
            nurselected.Employee.emp_salary = salary;
            nurselected.Employee.emp_gender = gender;
            nurselected.Employee.emp_dob = dob;
            nurselected.nurse_experience = experience;

            nurselected.Employee.User.user_name = username;
            nurselected.Employee.User.user_password = password;
            nurselected.Employee.User.user_type = type;

            hmsfac.updateNurse(nurselected);
            dataGrid_Nurse.Items.Refresh();
            roomList = hmsfac.getRoom();
            dataGrid_Room.ItemsSource = roomList;
            this.fnametxt_nurseUpdate.Text = "";
            this.lnametxt_nurseUpdate.Text = "";
            this.unametxt_nurseUpdate.Text = "";
            this.passtxt_nurseUpdate.Password = "";
            this.datepicker_nurseUpdate.Text = "";
            this.cellno_nurseUpdate.Text = "";
            this.spectxt_nurseUpdate.Text = "";
            this.saltxt_nurseUpdate.Text = "";
            this.nurse_btnUpdate.IsEnabled = false;
        }

        private void btn_Nursedelete_Click(object sender, RoutedEventArgs e)
        {
            if (nurselected == null) return;

            MessageBoxResult result = MessageBox.Show("Do you want to delete " + nurselected.Employee.emp_firstname + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hmsfac.remove(nurselected);
            nurseList.Remove(nurselected);
            dataGrid_Nurse.Items.Refresh();
            dataGrid_Room.Items.Refresh();

            this.fnametxt_nurseUpdate.Text = "";
            this.lnametxt_nurseUpdate.Text = "";
            this.unametxt_nurseUpdate.Text = "";
            this.passtxt_nurseUpdate.Password = "";
            this.datepicker_update.Text = "";
            this.cellno_nurseUpdate.Text = "";
            this.spectxt_nurseUpdate.Text = "";
            this.saltxt_nurseUpdate.Text = "";
            this.nurse_btnDelete.IsEnabled = false;
        }
        private void dataGrid_Patient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.patbtn_delete.IsEnabled = true;
            this.patbtn_update.IsEnabled = true;
            this.indexselected = dataGrid_Patient.SelectedIndex;
            if (indexselected == -1 || patientList.Count <= indexselected)
            {
                patselected = null;
                this.nurse_btnDelete.IsEnabled = false;
                this.nurse_btnUpdate.IsEnabled = false;
                return;
            }
            patselected = (Patient)dataGrid_Patient.SelectedItem;
            if (patselected.Doctor == null)
            {
                this.patcombobox_updatedoc.Text = "";
            }
            else
            {
                this.patcombobox_updatedoc.Text = patselected.Doctor.Employee.emp_firstname;
            }
            this.patnametxt_update.Text = patselected.pat_name;
            this.patdatepicker_update.Text = patselected.pat_dob.ToString();
            
            if (patselected.pat_gender.Equals("female"))
                patrbfemale_update.IsChecked = true;
            else
                patrbmale_update.IsChecked = true;
        }

        private void patbtn_update_Click(object sender, RoutedEventArgs e)
        {
            if (patselected == null) return;



            String fullname = patnametxt_update.Text;
            DateTime dob = (DateTime)patdatepicker_update.SelectedDate;
            String gender = "male";
            if (((patrbfemale_update.IsChecked ?? false) || (patrbfemale_update.IsChecked ?? false))
                && !string.IsNullOrEmpty(patdatepicker_update.Text))
            {
                if (patrbfemale_update.IsChecked ?? false)
                    gender = "female";
            }

            patselected.pat_name = fullname;
            patselected.pat_dob = dob;
            patselected.pat_gender = gender;
            patselected.doc_id = int.Parse(patcombobox_updatedoc.SelectedValue.ToString());
            var catid = doctorList.Where(x => x.doc_id == patselected.doc_id).Select(x => x.cat_id).FirstOrDefault();
            patselected.cat_id = catid;

            hmsfac.updatePatient(patselected);


            MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            dataGrid_Patient.Items.Refresh();
            this.patnametxt_update.Text = "";
            this.patdatepicker_update.Text = "";
            this.patcombobox_updatedoc.Text = "";
            this.patbtn_update.IsEnabled = false;
            this.patrbmale_update.IsChecked = false;
            this.patrbfemale_update.IsChecked = false;
        }

        private void patbtn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (patselected == null)
            {
                return;
            }


            MessageBoxResult result = MessageBox.Show("Do you want to delete " + patselected.pat_name + "'s record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result)) return;
            hmsfac.remove(patselected);
            patientList.Remove(patselected);
            dataGrid_Patient.Items.Refresh();
            indpatList = hmsfac.getIndoors();
            dataGrid_IndoorPatients.Items.Refresh();
            this.patnametxt_update.Text = "";
            this.patdatepicker_update.Text = "";
            this.patcombobox_updatedoc.Text = "";
            this.patbtn_delete.IsEnabled = false;
            this.patrbmale_update.IsChecked = false;
            this.patrbfemale_update.IsChecked = false;
        }

        private void dataGrid_Room_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            this.roombtn_update.IsEnabled = true;
            this.roombtn_update.IsEnabled = true;
            this.indexselected = dataGrid_Room.SelectedIndex;
            if (indexselected == -1 || roomList.Count <= indexselected)
            {
                roomselected = null;
                roombtn_update.IsEnabled = false;
                return;
            };

            roombtn_update.IsEnabled = true;
            //roomSelected = (room)RoomList.ElementAt<room>(dataGrid_Room.SelectedIndex);
            
            roomselected = (Room)dataGrid_Room.SelectedItem;
            noofbedstxt_update.Text = roomselected.totalbeds.ToString();
            if (roomselected.Nurse == null)
            {
                governedbytxt_update.Text = "";
            }
            else
            {

                governedbytxt_update.Text = roomselected.Nurse.Employee.emp_firstname;
            }
        }

        private void roombtn_update_Click(object sender, RoutedEventArgs e)
        {
            if (roomselected == null) return;

            String TotalBeds = noofbedstxt_update.Text;
            String strNid;
            if (!string.IsNullOrEmpty(TotalBeds) && !string.IsNullOrEmpty(governedbytxt_update.Text))
            {
                strNid = governedbytxt_update.SelectedValue.ToString();

                try
                {

                    int newBeds = int.Parse(TotalBeds);
                    int nid = int.Parse(strNid);
                    int prevBeds = roomselected.totalbeds;
                    int diffBeds = newBeds - prevBeds;
                    roomselected.totalbeds = newBeds;
                    roomselected.availbeds += diffBeds;
                    roomselected.nurse_id = nid;
                    hmsfac.updateRoom(roomselected);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was some error.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Console.WriteLine(ex);
                    return;
                }

                MessageBox.Show("Record updated success.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                dataGrid_Room.Items.Refresh();

                this.noofbedstxt_update.Text = "";
                this.governedbytxt_update.Text = "";
                this.roombtn_update.IsEnabled = false;
            }
        }

        private void assignroom_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (String.IsNullOrEmpty(cboselroom_no.Text))
                {
                    MessageBox.Show("Please select a room no.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                IndoorPatient indo = (IndoorPatient)dataGrid_IndoorPatients.SelectedItem;


                if (indo.indpat_status == "discharged")
                {
                    MessageBox.Show("Cannot assign room to discharged patient.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (indo.room_id != null && indo.indpat_status == "admitted")
                {
                    Room currentRoom = hmsfac.getRoomByRid(indo.room_id);
                    currentRoom.availbeds++;
                    hmsfac.updateRoom(currentRoom);
                }


                indo.room_id = int.Parse(cboselroom_no.Text);

                Room newRoom = hmsfac.getRoomByRid(indo.room_id);

                if (newRoom.availbeds == 0)
                {
                    MessageBox.Show("Beds not available in this room. Please select any other room.", "Reminder", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                newRoom.availbeds--;

                hmsfac.updateIndoor(indo);
                hmsfac.updateRoom(newRoom);

                MessageBox.Show("Room Assigned successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                dataGrid_IndoorPatients.Items.Refresh();
                roomList = hmsfac.getRoom();
                dataGrid_Room.Items.Refresh();

                this.roombtn_update.IsEnabled = false;
                this.assignroom_btn.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please first select the patient from Grid", "Reminder", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                Console.WriteLine(ex.Message);
            }
        }

        private void docsearchtxt_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Doctor.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Doctor d = o as Doctor;
                    if (cbosearchdoc.SelectedValue != null)
                    {
                        String selected = cbosearchdoc.Text.ToString().ToLower();
                        Console.WriteLine(selected);
                        if (selected == "first name")
                            return (d.Employee.emp_firstname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "last name")
                            return (d.Employee.emp_lastname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (d.Employee.emp_gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "username")
                            return (d.Employee.User.user_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "phone")
                            return (d.Employee.emp_phone.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            this.totalbill_bill.IsEnabled = true;
            if (patname_bill.SelectedIndex == -1) return;
            String patientname = patname_bill.SelectedValue.ToString();
            Console.WriteLine(patientname);
            if (patientname == null || pat_docchrg.Text == "")
            {
                return;
            }
            String ptype = patient_type.Text;
            String pname = patname_bill.Text;
            Console.WriteLine(pname);
            Console.WriteLine(ptype);
            //String pdocchg = pat_docchrg.Text;
            //Console.WriteLine(pdocchg);
            double medprice = double.Parse(medchrge_bill.Text);
           
            double dochrge = double.Parse(pat_docchrg.Text);
            Console.WriteLine(dochrge);
            int nod = int.Parse(noofday_bill.Text);
            int pid = int.Parse(patientname);
            var dateofadmit = indpatList.Where(x => x.pat_id == pid).Select(x => x.admit_date).FirstOrDefault();
            var docid = patientList.Where(x=> x.pat_id == pid).Select(x=> x.doc_id).FirstOrDefault();
            var docname = doctorList.Where(x=> x.doc_id == docid).Select(x=> x.Employee.emp_firstname).FirstOrDefault();
            double totalbill;
            Bill bill = new Bill();
           
            if (ptype.Equals("outdoor"))
            {
                bill.pat_id = pid;
                bill.pat_name = pname;
                bill.pat_type = ptype;
                bill.med_charge = medprice;
                bill.doctor_charge = dochrge;
                bill.room_charge = null;
                bill.no_of_days = null;
                totalbill = medprice + dochrge;
                bill.total_bill = totalbill ;
                bill.doc_name = docname;
                bill.admit_date = null;
                hmsfac.addBill(bill);
                billpatlist.Add(bill);
                dataGrid_Patients_Bill.Items.Refresh();
                new PatientBills(bill,patname_bill.Text).ShowDialog();
                hmsfac.removePatientById(pid);
                patientList = hmsfac.getPatient();
                patname_bill.ItemsSource = patientList;
                dataGrid_Patient.ItemsSource = patientList;
                dataGrid_Patient.Items.Refresh();
                //indpatList = hmsfac.getIndoorPatient();
                //dataGrid_IndoorPatients.Items.Refresh();
                
            }
            else if (ptype.Equals("indoor"))
            {
                double roomchrge = double.Parse(roomchrg_bill.Text);
                bill.pat_id = pid;
                bill.pat_type = ptype;
                bill.pat_name = pname;
                bill.med_charge = medprice;
                bill.room_charge = roomchrge;
                bill.no_of_days = nod;
                bill.doctor_charge = dochrge;
                totalbill = medprice + dochrge + (roomchrge*nod);
                bill.admit_date = dateofadmit;
                bill.leave_date = DateTime.Today;
                bill.doc_name = docname;
                bill.total_bill = totalbill;
                hmsfac.addBill(bill);
                billpatlist.Add(bill);
                dataGrid_Patients_Bill.Items.Refresh();
                new PatientBills(bill,patname_bill.Text).ShowDialog();
                hmsfac.removePatientById(pid);
                patientList = hmsfac.getPatient();
                dataGrid_Patient.Items.Refresh();
                patname_bill.ItemsSource = patientList;
                dataGrid_Patient.ItemsSource = patientList;
                indpatList = hmsfac.getIndoorPatient();
                dataGrid_IndoorPatients.Items.Refresh();
                
            }
            else
            {
                Console.WriteLine("i am here");
                return;
            }
            this.patname_bill.Text = "";
            this.patient_type.Text = "";
            this.pat_docchrg.Text = "";
            this.medchrge_bill.Text = "";
            this.roomchrg_bill.Text = "";
            this.noofday_bill.Text = "";
        }

        private void patname_bill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (patname_bill.SelectedIndex == -1)
            {
                this.medchrge_bill.Text = "";
                this.patient_type.Text = "";
                this.noofday_bill.Text = "";
                return;
            }
            else
            {
                String patientname = patname_bill.SelectedValue.ToString();

                double medprice = 0.0;
                int pid = int.Parse(patientname);
                Console.WriteLine(pid);
                
                var patstatus = indpatList.Where(x=> x.pat_id == pid).Select(x=> x.indpat_status).FirstOrDefault();
                var patname = patientList.Where(x => x.pat_id == pid).Select(x => x.pat_name).FirstOrDefault();
                var pattype = patientList.Where(x=> x.pat_id == pid).Select(x=> x.pat_type).FirstOrDefault();
                if (patstatus == "admitted" || pattype == "in processes") 
                {
                    MessageBoxResult result = MessageBox.Show("Patient "+patname+" has not been discharged/examined yet!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (!(MessageBoxResult.Yes == result))
                    {
                        return;
                    }
                }
                //var patype = patientList.Where(x => x.pat_id == pid).Select(x => x.pat_type).FirstOrDefault();
                var dateofadmit = indpatList.Where(x => x.pat_id == pid).Select(x => x.admit_date).FirstOrDefault();
                TimeSpan nod = DateTime.Today - dateofadmit;
                patient_type.Text = pattype;
                if (patient_type.Text.Equals("outdoor"))
                {
                    roomchrg_bill.IsEnabled = false;
                    noofday_bill.IsEnabled = false;
                }
                var medchg = prescList.Where(x => x.pat_id == pid).Select(x => x.Medicine.med_price).ToArray();
                foreach (var chg in medchg)
                {
                    medprice += (double)chg;
                }
                medchrge_bill.Text = medprice.ToString();
                if (nod.Days == 0)
                {
                    Console.WriteLine("I am here!");
                    noofday_bill.Text = "1";
                }
                else
                {
                    noofday_bill.Text = nod.Days.ToString();
                }
                this.totalbill_bill.IsEnabled = false;


            }
        }

       /* private void dataGrid_Patients_Bill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.indexselected = dataGrid_Patients_Bill.SelectedIndex;
            if (indexselected == -1 || billpatlist.Count <= indexselected)
            {
                billpatlist = null;
                return;
            }
            billselected = (Bill)dataGrid_Patients_Bill.SelectedItem;
            this.patient_type.Text = billselected.pat_type;
            this.pat_docchrg.Text = billselected.doctor_charge.ToString();
            this.medchrge_bill.Text = billselected.med_charge.ToString();
            this.patname_bill.Text = billselected.pat_name.ToString();
            if (billselected.pat_type.Equals("outdoor"))
            {
                this.noofday_bill.IsEnabled = false;
                this.roomchrg_bill.IsEnabled = false;
            }
            else
            {
                this.noofday_bill.Text = billselected.no_of_days.ToString();
                this.roomchrg_bill.Text = billselected.room_charge.ToString();
            }
            this.totalbill_bill.Text = billselected.total_bill.ToString();
        }*/

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (billselected == null)
            {
                return;
            }
            MessageBoxResult result = MessageBox.Show("Do you want to delete this's record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (!(MessageBoxResult.Yes == result))
            {
                return;
            }
            hmsfac.removePatientBill(billselected);
            billpatlist.Remove(billselected);
            dataGrid_Patients_Bill.Items.Refresh();
        }

        private void update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (billselected == null)
            {
                return;
            }
            billselected = (Bill)dataGrid_Patients_Bill.SelectedItem;

            String pname = patname_bill.Text;
            String ptype = patient_type.Text;
            double totalbil;
            double medchrg;
            double docchrg;
            if (ptype.Equals("outdoor"))
            {
                billselected.no_of_days = null;
                billselected.room_charge = null;
                medchrg = double.Parse(medchrge_bill.Text);
                docchrg = double.Parse(pat_docchrg.Text);
                totalbil = medchrg + docchrg;
                this.totalbill_bill.Text = totalbil.ToString();
            }
            else
            {
                int nod = int.Parse(noofday_bill.Text);
                int roomchrg = int.Parse(roomchrg_bill.Text);
                billselected.no_of_days = nod;
                billselected.room_charge = roomchrg;
                medchrg = double.Parse(medchrge_bill.Text);
                docchrg = double.Parse(pat_docchrg.Text);
                totalbil = medchrg + docchrg + (nod * roomchrg);
                this.totalbill_bill.Text = totalbil.ToString();
            }
            
            billselected.pat_name = pname;
            billselected.pat_type = ptype;
            billselected.med_charge = medchrg;
            billselected.doctor_charge = docchrg;
            billselected.total_bill = totalbil;
            hmsfac.updateBill(billselected);
            dataGrid_Patients_Bill.Items.Refresh();
        }

        private void searchtxt_bill_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            String filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Patients_Bill.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Bill bil = o as Bill;
                    if (cbosearch_Bill.SelectedValue != null)
                    {
                        Console.WriteLine("Here");
                        String selected = cbosearch_Bill.Text.ToString().ToLower();
                        Console.WriteLine(selected);
                        if (selected == "patient name")
                            return (bil.pat_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "patient type")
                            return (bil.pat_type.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void searchtxt_indpat_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            String filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_IndoorPatients.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    IndoorPatient indp = o as IndoorPatient;
                    if (cbosearchindpat_Indpat.SelectedValue != null)
                    {
                        String selected = cbosearchindpat_Indpat.Text.ToString().ToLower();
                        if (selected == "patient name")
                            return (indp.Patient.pat_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (indp.Patient.pat_gender.ToLower().StartsWith(filter.ToLower()));
                        else if(selected == "disease")
                            return (indp.indpat_disease.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void searchtxt_room_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            String filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Room.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Room room = o as Room;
                    if (cbosearch_room.SelectedValue != null)
                    {
                        String selected = cbosearch_room.Text.ToString().ToLower();
                        if (selected == "room no")
                            return (room.room_id.ToString().StartsWith(filter));
                        else if (selected == "total beds")
                            return (room.totalbeds.ToString().StartsWith(filter));
                        else if (selected == "nurse name")
                            return (room.Nurse.Employee.emp_firstname.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void searchtxt_patient_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            String filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Patient.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Patient pat = o as Patient;
                    if (cbosearch_patient.SelectedValue != null)
                    {
                        String selected = cbosearch_patient.Text.ToString().ToLower();
                        if (selected == "name")
                            return (pat.pat_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (pat.pat_gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "type")
                            return (pat.pat_type.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "doctor name")
                            return (pat.Doctor.Employee.emp_firstname.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void searchtxt_nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_Nurse.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Nurse nrs = o as Nurse;
                    if (cbosearch_nurse.SelectedValue != null)
                    {
                        String selected = cbosearch_nurse.Text.ToString().ToLower();
                        Console.WriteLine(selected);
                        if (selected == "first name")
                            return (nrs.Employee.emp_firstname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "last name")
                            return (nrs.Employee.emp_lastname.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "username")
                            return (nrs.Employee.User.user_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "phone")
                            return (nrs.Employee.emp_phone.ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    else
                        return false;
                };
            }
        }

        private void roombtn_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
