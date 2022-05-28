using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepository01
{
    public partial class Form1 : Form
    {

        private int index_autor;

        public Form1()
        {
            InitializeComponent();
            index_autor = 9;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(var db = new ModelAutores())
            {
                var unitOfWork = new Repositories.UnitOfWork(db);
                var query = unitOfWork.AutorRepository.Entities.ToList();

                string msg = "";
                query.ForEach(a => msg += a.idautor + " " + a.autor + "\r\n");

                textBox1.Text = msg;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new ModelAutores())
            {
                index_autor++;
                var a = new autores { autor = "autor" + index_autor };

                var unitOfWork = new Repositories.UnitOfWork(db);
                unitOfWork.AutorRepository.Add(a);
                unitOfWork.Commit();

                textBox1.Text = "autor ha sido adicionado";
            }
        }
    }
}
