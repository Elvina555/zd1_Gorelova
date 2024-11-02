using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace shop
{
    public partial class Form1 : Form
    {
        private Shop shop;

 
        public Form1()
        {
            shop = new Shop();
            InitializeComponent();
        }
       
        //метод для обновления списка товаров
        private void UpdateProductList()
        {
            checkedListBox1.Items.Clear();
            foreach (var product in shop.GetAllProducts())
            {
                checkedListBox1.Items.Add(product.Name);
            }
        }

        //добавление продуктов
        private void button1_Click(object sender, EventArgs e)
        {
            //проверка на пустое поле
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле название продукта");
                return;


            }

            string name = textBox1.Text;

            //проверка, что только буквы
            bool onlyLetters = true;
            foreach (var ch in name)
            {
                if (!char.IsLetter(ch))
                {
                    onlyLetters = false;
                    break;
                }
            }

            if (!onlyLetters)
            {
                MessageBox.Show("Только буквы!!!");
                return;


            }
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();
            double price = Convert.ToDouble(numericUpDown1.Value);
            int quantity = Convert.ToInt32(numericUpDown2.Value);
            shop.CreateProduct(name, price, quantity);
            shop.WriteAllProducts();
            UpdateProductList();

        }

        //покупка продуктов
        private void Купить_Click(object sender, EventArgs e)
        {
            int product = Convert.ToInt32(numericUpDown2.Value);
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string produc = item.ToString();
                shop.Sell(produc, product);
            }
        }

        //поставка на склад
        private void button2_Click(object sender, EventArgs e)
        {
            int product = Convert.ToInt32(numericUpDown2.Value);
            foreach (var item in checkedListBox1.CheckedItems)
            {
                string produc = item.ToString();
                shop.PopolnProduct(produc, product);
            }
        }








        //3
        PlayList playlist = new PlayList();
        Song song = new Song();


        //Обновляет данные о текущей песне
        private void UpdateSong()
        {
            song = playlist.CurrentSong();
            label7.Text = song.Author;
            label8.Text = song.Title;
            label9.Text = song.Filename;
        }
        //добавление плей листа и переход к началу
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text!=""&&textBox4.Text!="")//проверка, что все поля заполнены
            {
                string author, name, filename;
                author = textBox2.Text;
                name = textBox3.Text;
                filename = textBox4.Text;
                playlist.AddSong(author, name, filename);
                textBox2.ResetText();
                textBox3.ResetText();
                textBox4.ResetText();
                MessageBox.Show("Песня добавлена");
                playlist.GoToStart();
                UpdateSong();
            }
            else
            {
                MessageBox.Show("Заполните пожалуйста поля");
            }
        }

        //переход к предыдущему плейлисту
        private void button4_Click(object sender, EventArgs e)
        {
            playlist.Perexodone();
            song = playlist.CurrentSong();
            label7.Text = song.Author;
            label8.Text = song.Title;
            label9.Text = song.Filename;
        }

        //переход к следующему плейлисту 
        private void button5_Click(object sender, EventArgs e)
        {
            playlist.Perexodtwo();
            song = playlist.CurrentSong();
            label7.Text = song.Author;
            label8.Text = song.Title;
            label9.Text = song.Filename;
        }

        //переход по индексу
        private void button6_Click(object sender, EventArgs e)
        {
            playlist.GoToSong(Convert.ToInt32(numericUpDown3.Value));
            UpdateSong();
        }

        //удаление по выбранному пункту
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "")//проверка, что все поля заполнены
            {
                playlist.Remove(song);
                UpdateSong();
            }else
            {
                MessageBox.Show("Заполните поля");
            }
        }

        //удаление по индексу
        private void button8_Click(object sender, EventArgs e)
        {
            playlist.Remove(Convert.ToInt32(numericUpDown4.Value));
            UpdateSong();
        }
    }
}
