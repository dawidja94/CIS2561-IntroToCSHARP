using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml.Serialization;
using System.IO;

namespace Pokemon
{
    public partial class Form1 : Form
    {
        PokemonDB pokemonDB;
        
        public Form1()
        {
            InitializeComponent();
            LoadXml();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           


       

        }
        void LoadXml()
        {
            WebRequest request = WebRequest.Create("http://mrwrightteacher.net/NianticCorp/PokemonDB.php");
            WebResponse resp = request.GetResponse();
            Stream dataStr = resp.GetResponseStream();

            XmlSerializer serializer = new XmlSerializer(typeof(PokemonDB));
            pokemonDB = (PokemonDB)serializer.Deserialize(dataStr);


            //populate lists for players 
            dataGridView4.DataSource = pokemonDB.PlayerTable.Players;
            dataGridView5.DataSource = pokemonDB.PokemonTable.Pokemon;
            dataGridView6.DataSource = pokemonDB.OwnershipTable.Ownership;




            var cityName = (from player in pokemonDB.PlayerTable.Players
                               select player.City).Distinct();
            //populate combo box
         
            //populate combobox for cities
            comboBox1.Items.AddRange(cityName.ToArray());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = from pokemon in pokemonDB.PokemonTable.Pokemon
                         join ownership in pokemonDB.OwnershipTable.Ownership
                         on pokemon.Id equals ownership.PokemonId
                         join player in pokemonDB.PlayerTable.Players
                         on ownership.PlayerId equals player.Id
                         where player.Name == textBox1.Text
                         select new { pokemon.Name, ownership.Level, ownership.NumberOwned };

            dataGridView1.DataSource = result.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = from pokemon in pokemonDB.PokemonTable.Pokemon
                         join ownership in pokemonDB.OwnershipTable.Ownership
                         on pokemon.Id equals ownership.PokemonId
                         join player in pokemonDB.PlayerTable.Players
                         on ownership.PlayerId equals player.Id
                         where player.Id.ToString() == textBox2.Text
                         select new { pokemon.Name, ownership.Level, ownership.NumberOwned };

            dataGridView1.DataSource = result.ToList();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

            string city = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            var result = from player in pokemonDB.PlayerTable.Players
                         where player.City == city
                         select new { player.Id, player.Name, player.Username, player.City, player.Paid };

            dataGridView2.DataSource = result.ToList();

           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var results = from pokemon in pokemonDB.PokemonTable.Pokemon
                          where pokemon.Attack >= Convert.ToInt32(textBox4.Text)
                          orderby pokemon.Attack descending
                          select pokemon;

            dataGridView3.DataSource = results.ToList();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           //  MessageBox.Show("By Dawid Jasionowski, 2018");
        }
       
     

       

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Dawid Jasionowski, 2018", caption: "About");
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var results = from pokemon in pokemonDB.PokemonTable.Pokemon
                          where pokemon.Defense <= Convert.ToInt32(textBox5.Text)
                          orderby pokemon.Defense descending
                          select pokemon;

            dataGridView7.DataSource = results.ToList();
        }
    }
}
