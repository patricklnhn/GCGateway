
namespace WinAppMariaDBTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grdPops.DataSource = GetAllPops();
        }

        private List<Pop> GetAllPops()
        {
            using (var db = new juntaContext())
            {
                return (from p in db.Pops
                        select p).ToList<Pop>();
            }
        }

        private List<Category> GetAllCategories()
        {
            using (var db = new juntaContext())
            {
                return (from p in db.Categories
                        select p).ToList<Category>();
            }
        }


        private List<Contact> GetAllContacts()
        {
            using (var db = new juntaContext())
            {
                return (from p in db.Contacts
                        select p).ToList<Contact>();
            }
        }
        //private Contact GetContact(int id)
        //{
        //    using (var db = new juntaContext())
        //    {
        //        return (from p in db.Contacts
        //                select p).FirstOrDefault();
        //    }
        //}

    }
}