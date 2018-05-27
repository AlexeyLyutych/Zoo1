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
using Zoo.Models;
using System.Data.Entity;
using Microsoft.Win32;
using Zoo.ValidationF;



namespace Zoo
{
    
    /// <summary>
    /// Логика взаимодействия для Animal_Window.xaml
    /// </summary>
    public partial class Animal_Window : Window
    {
      
              public string TEXT { get; set; }  
        Animal an = new Animal();
        ZooContex db;
        public Animal_Window()
        {
           
            DataContext = this;
            InitializeComponent();
            db = new ZooContex();
            db.Animals.Load();
            db.Employess.Load();
            AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
            KeeperText.ItemsSource = db.Employess.Local.Where(n => n.Position.Contains("Кипер")).Select(n => n.IDOfCertification).ToList();
           


        }
        private void phonesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Animal p = (Animal)AnimalList.SelectedItem;
            if (p != null)
            {
                KindText.Text = p.KindOfAnimal;
                NumberText.Text = Convert.ToString(p.Number);
                AviaryText.Text = Convert.ToString(p.AviaryNum);
                KeeperText.Text = Convert.ToString(p.KeeperID);
                select_img.Source = new BitmapImage(new Uri(p.ImagePath, UriKind.Absolute)); ;
            }
           
        }

        private void img_openbtn_Click(object sender, RoutedEventArgs e)
        {
           OpenFileDialog open_dialog = new OpenFileDialog()
            
                open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
                if (open_dialog.ShowDialog() == true)
                {
                    try
                    {
                        select_img.Source = new BitmapImage(new Uri(open_dialog.FileName, UriKind.Absolute)); 
                        
                    }
                    catch
                    {

                        MessageBox.Show("Невозможно открыть выбранный файл");

                    }
                  
                }
            
            
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

            
            
            IEnumerable<Animal> an = db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text);
            if (an.Count() == 0)
            {
                MessageBox.Show("Животного такого вида не существует");
            }
            else
            {
                Animal animal = an.First();
                db.Animals.Remove(animal);
                db.SaveChanges();
              
                AviaryText.Clear();
                NumberText.Clear();
                KindText.Clear();
                select_img.Source = null;
            }
        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            int i1 = 0, i2 = 0;
            foreach (UIElement elem in stackpanel.Children)
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

            IEnumerable<Animal> an = db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text);
            foreach(Animal elem in an)
            {
                flag = true;
            }
            if (flag==true && i1==i2 && select_img.Source!=null)
            {
                Animal anim= db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text).First();
                anim.KeeperID= Convert.ToInt32(KeeperText.Text);
                anim.AviaryNum= Convert.ToInt32(AviaryText.Text);
                anim.Number= Convert.ToInt32(NumberText.Text);
               anim.ImagePath = Convert.ToString(select_img.Source); 
                db.SaveChanges();
                
                MessageBox.Show("Изменено!");
               
               AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
                AnimalList.Items.Refresh();
            }
            else if (i1 == i2 && KeeperText.Text != "" &&select_img.Source!=null)
            {
               
                
                
                    Animal animal = new Animal();
                    animal.ImagePath = Convert.ToString(select_img.Source);
                    animal.KindOfAnimal = KindText.Text;
                    animal.KeeperID = Convert.ToInt32(KeeperText.Text);
                    animal.AviaryNum = Convert.ToInt32(AviaryText.Text);
                    animal.Number = Convert.ToInt32(NumberText.Text);
                    db.Animals.Add(animal);
                    db.SaveChanges();
                    AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
                    MessageBox.Show("Добавлено!");
                
               
            }
            else
            {
                MessageBox.Show("Неккоректные данные!");
            }


        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            Output output = new Output();

            output.Show();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            AnimalList.ItemsSource = db.Animals.Local.Where(n => n.KindOfAnimal.Contains(searchtext.Text) || n.KindOfAnimal.ToLower().Contains(searchtext.Text));
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            searchtext.Clear();
            AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            MessageBox.Show(b.Name);
        }

      
    }
}
