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


namespace WFMovieDB
{
    public partial class Form1 : Form
    {
        /*
        List<Movie> movieTable = new List<Movie>();
        List<Studio> studioTable = new List<Studio>();

        string connStr = "server=10.32.45.68;uid=dbuser;pwd=dbuser;database=MovieDB";
        string movieSQL = "SELECT ID, TITLE, RELEASED, GROSS, STUDIO FROM Movies"; //db name is case sensitive
        string studioSQL = "SELECT ID, NAME FROM Studios";
        */

        MovieDB movieDB = new MovieDB();
        public Form1()
        {
            InitializeComponent();

            /*
            //load the movies
            MySQLDB.MySQLDB.RunQuery(connStr, movieSQL, MakeMovie);

            dataGridView1.DataSource = movieTable; //has to be a list to use dataGridView

            MySQLDB.MySQLDB.RunQuery(connStr, studioSQL, MakeStudio);

            var studioNames = (from s in studioTable
                              select s.Name).Distinct(); //filters out the duplicates

            comboBox1.Items.AddRange(studioNames.ToArray());
            */

            LoadXml();
        }

        /*
        public int MakeStudio(string[] fields)
        {
            
            Studio s = new Studio()
            {
                Id = Convert.ToInt32(fields[0]),
                Name = fields[1]

            };

            studioTable.Add(s);

            return 0;            

        }*/

        /*
        public int MakeMovie(string[] fields)
        {
            
            Movie m = new Movie()
            {
                Id = Convert.ToInt32(fields[0]),
                Title = fields[1],
                Released = Convert.ToInt32(fields[2]),
                Gross = Convert.ToInt32(fields[3]),
                Studio = Convert.ToInt32(fields[4])

            };

            movieTable.Add(m);
            
            return 0; //Func has to return an integer
        }*/


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string studio = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            var movies = from m in movieDB.MovieTable.Movies
                         join s in movieDB.StudioTable.Studios
                         on m.Studio equals s.Id //compare contents of an object
                       where s.Name == studio //compare the references
                         select new { m.Title, m.Released, s.Name };

            dataGridView2.DataSource = movies.ToList();
                       

        }
        void LoadXml()
        {
            WebRequest request = WebRequest.Create("http://mrwrightteacher.net/CIS2561/MovieDB.php");
            WebResponse resp = request.GetResponse();
            Stream dataStr = resp.GetResponseStream();

            XmlSerializer serializer = new XmlSerializer(typeof(MovieDB));
            movieDB = (MovieDB)serializer.Deserialize(dataStr);

            //populate movie table
            dataGridView1.DataSource = movieDB.MovieTable.Movies;

            //populate studio names
            var studioNames = (from s in movieDB.StudioTable.Studios
                              select s.Name).Distinct();
            //populate combo box
            comboBox1.Items.AddRange(studioNames.ToArray());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


    /*
    class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Released { get; set; }
        public int Gross { get; set; }
        public int Studio { get; set; }

    }

    class Studio
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    */

   
}
