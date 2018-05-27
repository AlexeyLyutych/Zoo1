using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Zoo.Models;
using System.Resources;
using Zoo.ValidationF;
namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для ProvidersWindow.xaml
    /// </summary>
   
    public partial class ProvidersWindow : Window
    {
        

        ZooContex db;
       public string Text { get; set; }
       public string Hour { get; set; }
        public string Numbera { get; set; }
        
        public ProvidersWindow()
        {
            
            InitializeComponent();
            db = new ZooContex();
            db.Providers.Load();
            db.Supplies.Load();
            ProvidersGrid.ItemsSource = db.Providers.Local.ToBindingList();
            SupplyGrid.ItemsSource = db.Supplies.Local.ToBindingList();
            DataContext = this;
            namebox.ItemsSource = db.Providers.Local.Select(n => n.СompanyName).ToList();
            
        }

        private void addSupplybtn_Click(object sender, RoutedEventArgs e)
        {
            int i1 = 0, i2 = 0;
            foreach (UIElement elem in SupplyAddGrid.Children)
            {
                TextBox textbox = new TextBox();
                if (elem is TextBox)
                {
                    textbox = elem as TextBox;
                    i1++;
                    if (textbox.Text != "" && !Validation.GetHasError(textbox))
                    {
                        i2++;
                    }
                }
            }
            if (i1 == i2 && namebox.Text!="" && datepicker.Text!="")
            {
                Supply supply = new Supply();
                supply.Company = namebox.Text;
                supply.Amount = Convert.ToInt32(AmountTextBox.Text);
                supply.SupDate = Convert.ToDateTime(datepicker.Text + " " + HourTextBox.Text + ":" + MinuteTextBox.Text);
                db.Supplies.Add(supply);
                db.SaveChanges();
                MessageBox.Show("Добавлено!");
                namebox.Text = "";
                AmountTextBox.Clear();
                datepicker.Text = "";
                HourTextBox.Clear();
                MinuteTextBox.Clear();
                
            }
            else
            {
                MessageBox.Show("Неккоректные данные");
            }
           

        }

        private void AddProviderbtn_Click(object sender, RoutedEventArgs e)
        {
          
           
            int i1=0, i2=0;
            foreach(UIElement elem in stacktextbox.Children)
            {
                TextBox textbox = new TextBox();
                if (elem is TextBox)
                {
                    textbox = elem as TextBox;
                    i1++;
                    if (textbox.Text != "" && !Validation.GetHasError(textbox))
                    {
                        i2++;
                    }
                }
            }
            
            if (i1==i2 && CheckCompany(CompanyTextBox.Text))
            {

                Provider provider = new Provider();
                provider.CheckingAccount = AccountTextBox.Text;
                provider.PhoneNumber = NumberTextBox.Text;
                provider.TypeOfProduct = TypeTextBox.Text;
                provider.СompanyName = CompanyTextBox.Text;
                db.Providers.Add(provider);
                db.SaveChanges();
                MessageBox.Show("Добавлено!");
                NameboxRefresh();
                AccountTextBox.Clear();
                NumberTextBox.Clear();
                TypeTextBox.Clear();
                CompanyTextBox.Clear();

            }
            else if (i1 != i2) { MessageBox.Show("Данные введены неккоректно!"); }
            else
            {
                MessageBox.Show("Такая фирма уже существует!");
            }
        }

     
        private bool CheckCompany(string str)
        {
            IEnumerable<Provider> provider = db.Providers.Local.Where(n => n.СompanyName == str);
            if (provider.Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            searchtext.Clear();
            ProvidersGrid.ItemsSource = db.Providers.Local.ToBindingList();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            ProvidersGrid.ItemsSource = db.Providers.Local.Where(n => n.СompanyName.Contains(searchtext.Text) || 
            n.СompanyName.ToLower().Contains(searchtext.Text));
        }

        private void deleteButton1_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < SupplyGrid.SelectedItems.Count; i++)
                {
                    Models.Supply emp = SupplyGrid.SelectedItems[i] as Models.Supply;
                    if (emp != null)
                    {
                        db.Supplies.Remove(emp);
                    }
                }
            }
            db.SaveChanges();
        }


        private void NameboxRefresh()
        {
            namebox.ItemsSource = db.Providers.Local.Select(n => n.СompanyName).ToList();
            namebox.Items.Refresh();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
        
            if (ProvidersGrid.SelectedItems.Count > 0 )
            {
                for (int i = 0; i < ProvidersGrid.SelectedItems.Count; i++)
                {
                    Models.Provider emp = ProvidersGrid.SelectedItems[i] as Models.Provider;
                    if (emp != null && !CheckSupply(emp.СompanyName))
                    {
                        db.Providers.Remove(emp);
                    }
                    else
                    {
                        MessageBox.Show("У вас поставка у этой фирмы!");
                    }
                }
            }
            db.SaveChanges();
            NameboxRefresh();
        }
        private bool CheckSupply(string str)
        {
            IEnumerable<Supply> provider = db.Supplies.Local.Where(n => n.Company==str );
            if (provider.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
