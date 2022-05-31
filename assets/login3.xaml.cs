using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for login3.xaml
    /// </summary>
    public partial class login3 : UserControl
    {
        HMSFACTORY hmsfac = new HMSFACTORY();
        public login3()
        {
            InitializeComponent();
            txtName.Focus();
            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    this.CurrentTime.Content = DateTime.Now.ToLongTimeString();
                }, this.Dispatcher);
        }
        private void login_click(object sender, RoutedEventArgs e)
        {
            login_btn.IsEnabled = false;
            String user = txtName.Text;
            String pass = txtpassword.Password;
            User loguser;
            new Thread(() =>
            {
                if ((loguser = hmsfac.getUser(user, pass)) != null)
                {
                    if (loguser.user_type.Equals("admin"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                            {
                                Switcher.stacktest.Navigate(new admincontrol());
                            }));
                    }
                    else if (loguser.user_type.Equals("pharmacist"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                            {
                                Switcher.stacktest.Navigate(new PharmacistPanelUc());
                            }));
                    }
                    else if (loguser.user_type.Equals("doctor"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                            {
                                Switcher.stacktest.Navigate(new DoctorPanelUc(loguser, this));
                            }));
                    }
                    else if (loguser.user_type.Equals("nurse"))
                    {
                        this.Dispatcher.Invoke(new Action(delegate
                            {
                                Switcher.stacktest.Navigate(new NursePanelUc(loguser, this));
                            }));
                    }
                    else
                        return;
                }
                else
                {
                    this.Dispatcher.Invoke(new Action(delegate
                    {
                        txtName.Text = "";
                        txtpassword.Password = "";
                        txtName.Focus();
                        lberror.Content = " Invalid username/password!";
                        login_btn.IsEnabled = true;
                    }));
                }
            }).Start();
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                login_click(null,null);
            }
        }
    }
}
