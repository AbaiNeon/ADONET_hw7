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

namespace hw7
{
    /// <summary>
    /// Логика взаимодействия для AddUserWndw.xaml
    /// </summary>
    public partial class AddUserWndw : Window
    {
        public AddUserWndw()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if ( !(ValidateRegistration()) )
            {
                return;
            }

            string login = txtBoxLogin.Text;
            string password = txtBoxPswrd.Text;
            string address = txtBoxAddress.Text;
            string tel = txtBoxTel.Text;
            int num = Convert.ToInt32(txtBoxIsAdmin.Text);
            bool _isAdmin = Convert.ToBoolean(num);

            using (var db = new Model1())
            {
                var users = (from user in db.tblUsers
                             where user.NikName == login
                             select user).ToList();

                if (users.Count == 1)
                {
                    MessageBox.Show("User with current Login is exist");
                    return;
                }

                tblUser newUser = new tblUser() { NikName = login, Password = password, Address = address, Tel = tel, IsAdmin = _isAdmin };
                db.tblUsers.Add(newUser);
                db.SaveChanges();
            }

            LoginScreenWndw loginScreenWndw = new LoginScreenWndw();
            loginScreenWndw.Show();
            this.Close();
        }

        private bool ValidateRegistration()
        {
            if (txtBoxLogin.Text == "" || txtBoxPswrd.Text == "" || txtBoxAddress.Text == "" || txtBoxTel.Text == "" || txtBoxIsAdmin.Text == "")
            {
                MessageBox.Show("Please, fill the all poles");
                return false;
            }
            return true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            LoginScreenWndw loginScreenWndw = new LoginScreenWndw();
            loginScreenWndw.Show();
            this.Close();
        }
    }
}
