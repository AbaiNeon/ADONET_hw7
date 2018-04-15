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
    /// Логика взаимодействия для LoginScreenWndw.xaml
    /// </summary>
    public partial class LoginScreenWndw : Window
    {
        public LoginScreenWndw()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var userName = txtBoxUserName.Text;
            var userPswrd = txtBoxPassword.Text;

            using (var db = new Model1())
            {
                var users = (from user in db.tblUsers
                             where user.NikName == userName && user.Password == userPswrd
                             select user).ToList();

                if (users.Count == 1)
                {
                    MainWindow mainWindow = new MainWindow(users[0]);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect enter");
                }
            }
            
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            AddUserWndw addUserWndw = new AddUserWndw();
            addUserWndw.Show();
            this.Close();
        }
    }
}
