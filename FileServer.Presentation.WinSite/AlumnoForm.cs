using System;
using FileServer.Common.Model;
using FileServer.Infrastucture.Repository.Repositories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using log4net;
using log4net.Config;
using FileServer.Infrastucture.Repository;
using Serilog;

namespace FileServer.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {

        public AlumnoForm()
        {
            InitializeComponent();
            cboPath.SelectedIndex = 0;
            cboExtension.SelectedIndex = 1;
            //Log.Logger = new LoggerConfiguration()
            //                .WriteTo.File("log.txt",
            //                rollOnFileSizeLimit: true,
            //                fileSizeLimitBytes: 20_971_520).CreateLogger();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            Log.Debug("Entering btAdd_Click");
            AbstractFileFactory fFactory = new FileManagerFactory();
            var alumnoRepo = new AlumnoRepository(fFactory, cboExtension.SelectedIndex, cboPath.SelectedIndex);

            Alumno alumno = new Alumno(txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text);
            var alumnoRetorno = alumnoRepo.Add(alumno);

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
