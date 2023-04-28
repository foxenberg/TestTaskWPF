using CompanyApp.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Newtonsoft.Json.Converters;

namespace CompanyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static dbSgsEntities db = new dbSgsEntities();
        public MainWindow()
        {
            InitializeComponent();
            cbCity.ItemsSource = db.Company.ToList();
            cbDepartment.ItemsSource = db.Department.ToList();
            cbEmpl.ItemsSource = db.Employee.ToList();
            cbBrig.ItemsSource = db.Brigade.ToList();
            
        }

        private void cbCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selecteditem = (cbCity.SelectedItem as Company).CityId;

            cbDepartment.ItemsSource = db.Department.Where(i => i.CityId == selecteditem).ToList();
            
            
        }

        private  void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            Enterprise enterprise = new Enterprise() 
            {
                City = cbCity.Text,
                Department = cbDepartment.Text,
                Employee = cbEmpl.Text,
                Brigade = cbBrig.Text,
                WorkingTurn = tbTurn.Text

            };

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(@"c:\json.txt"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, enterprise);
                MessageBox.Show("Успешно");
                
            }
        }
    }
}
