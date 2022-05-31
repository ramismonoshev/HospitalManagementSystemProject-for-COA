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
    /// Interaction logic for NursePanelUc.xaml
    /// </summary>
    public partial class NursePanelUc : UserControl
    {
        login3 login;
        Nurse owner;
        HMSFACTORY hmsfac = new HMSFACTORY();
        List<IndoorPatient> patList;
        List<Room> roomList;

        public NursePanelUc(User ownerUser,login3 login)
        {
            InitializeComponent();
            this.owner = hmsfac.getNurseByUid(ownerUser.user_id);
            this.login = login;
            patList = hmsfac.getMyPatient(owner);
            roomList = hmsfac.getMyRooms(owner);

            dataGrid_MyRoom.ItemsSource = roomList;
            dataGrid_MyPatient.ItemsSource = patList;
        }

        private void filelogoutnurse_Click(object sender, RoutedEventArgs e)
        {
            Switcher.stacktest.Navigate(new login3());
        }

        private void searchpattxt_nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            string filter = t.Text;
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_MyPatient.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    IndoorPatient indo = o as IndoorPatient;
                    if (searchpatcombo_nurse.SelectedValue != null)
                    {
                        String selected = searchpatcombo_nurse.Text.ToString().ToLower();
                        if (selected == "name")
                            return (indo.Patient.pat_name.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "gender")
                            return (indo.Patient.pat_gender.ToLower().StartsWith(filter.ToLower()));
                        else if (selected == "room no")
                            return (indo.room_id.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
        }

        private void searchroomtxt_nurse_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;

            String filter = t.Text;
            int filt;
            bool result = Int32.TryParse(filter,out filt);
            Console.WriteLine(filter);
            ICollectionView cv = CollectionViewSource.GetDefaultView(dataGrid_MyRoom.ItemsSource);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    Room indo = o as Room;
                    if (searchroomcombo_nurse.SelectedValue != null)
                    {
                        String selected = searchroomcombo_nurse.Text.ToString().ToLower();
                        Console.WriteLine(selected);
                        if (selected.Equals("available beds"))
                        {
                            Console.WriteLine("write here");
                            return (indo.availbeds.ToString().StartsWith(filter.ToLower()));
                        }
                        else if (selected == "total beds")
                        {
                            Console.WriteLine("write here 2");
                            return (indo.totalbeds.ToString().StartsWith(filter.ToLower()));
                        }
                        else if (selected == "room no")
                            return (indo.room_id.ToString().ToLower().StartsWith(filter.ToLower()));
                        else
                            return false;
                    }
                    return false;
                };
            }
        }
    }
}
