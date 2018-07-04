using System;
using FileServer.Common.Model;
using FileServer.Infrastucture.Repository;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FileServer.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        public AlumnoForm()
        {
            InitializeComponent();
            cboPath.SelectedIndex = 0;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            var alumnoRepo = new AlumnoRepository();
            var fileManager = new FileManager();
            var selectedPath = fileManager.PathSelector(cboPath.SelectedIndex);
            Alumno alumno = new Alumno(txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text);
            var alumnoRetorno = alumnoRepo.Add(alumno, selectedPath);
            if (alumnoRetorno.Equals(alumno))
            {
                MessageBox.Show("Alumno añadido correctamente.", "AlumnoJSON"); 
            }
            else
            {
                MessageBox.Show("Error al añadir un alumno.", "AlumnoJSON");

            }
            txtID.Clear(); txtNombre.Clear(); txtApellidos.Clear(); txtDNI.Clear();
        }
    }
}
