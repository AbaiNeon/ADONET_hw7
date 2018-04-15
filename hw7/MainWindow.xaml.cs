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

namespace hw7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(tblUser user)
        {
            InitializeComponent();

            using (var db = new Model1())
            {
                var users = (from usr in db.tblUsers
                             select usr).ToList();

                myDataGrid.ItemsSource = users;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var loginScreenWndw = new LoginScreenWndw();
            loginScreenWndw.Show();
            this.Close();
        }
    }
}
