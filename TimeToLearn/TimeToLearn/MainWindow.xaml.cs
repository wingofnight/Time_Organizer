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
using static System.Net.Mime.MediaTypeNames;

namespace TimeToLearn
{
    public partial class MainWindow : Window
    {
        public Dictionary<string,Exercise> exercise = new Dictionary<string, Exercise>();

        public int SumRaito = 0;
        public float allTime = 0;
        public int nameSize = 30;
        public MainWindow()
        {
            InitializeComponent();

            cbx_raito.SelectedIndex = 0;

            for (int i = 1; i <= 10; i++)
            {
                cbx_raito.Items.Add(i);
            }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
                txtbl_info.Items.Clear();
            try
            {
                allTime = Convert.ToInt32(txtbx_alltime.Text);
                Сounting();
                txtbl_wrong.Text = "";
            }
            catch (FormatException)
            {

                txtbl_wrong.Text = "Введите ЧИСЛО в общее свободное время в неделю";
            }

            
        }

        public void Сounting()
        {
            if (!exercise.ContainsKey(txtbx_learnName.Text) && txtbx_learnName.Text != "" && txtbx_alltime.Text != "")
            {
                SumRaito += Convert.ToInt32(cbx_raito.Text);

                Exercise Ex = new Exercise(txtbx_learnName.Text, Convert.ToInt32(cbx_raito.Text), allTime, SumRaito);

                exercise.Add(txtbx_learnName.Text, Ex);
                txtbx_learnName.Clear();

            }
            else
            {
                if (txtbx_learnName.Text != "" && txtbx_alltime.Text != "")
                {
                    txtbl_wrong.Text = "Такое занятие уже есть";
                }
                else if (txtbx_learnName.Text == "")
                {
                    txtbl_wrong.Text = "Введите название занятия";
                }
                else
                {
                    txtbl_wrong.Text = "Введите общее свободное время в неделю";
                }
            }


            foreach (var item in exercise)
            {
                string name = item.Value.name;
                
                for (int i = 0; i < nameSize - item.Value.name.Length; i++)
                {
                    name += "-";
                }
                
                item.Value.hawMuchTime(allTime, SumRaito);
                txtbl_info.Items.Add(name + " | " + item.Value.coast + " | " + item.Value.time + " | " + item.Value.timeToDay);
            }
        }
    }
}
