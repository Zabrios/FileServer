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
using log4net;
using log4net.Config;

namespace FileServer.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (typeof(AlumnoForm));
        public AlumnoForm()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
            cboPath.SelectedIndex = 0;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //BasicConfigurator.Configure();
            log.Debug("Entering the btAdd_Click Method.");
            log.Debug(string.Format(@"Alumno --> ID = {0} | Nombre = {1} | Apellidos = {2} | DNI = {3}",
                      txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text));

            var alumnoRepo = new AlumnoRepository();
            var fileManager = new FileManager();
            var selectedPath = fileManager.PathSelector(cboPath.SelectedIndex);

            log.Debug("selectedPath = " + selectedPath);

            Alumno alumno = new Alumno(txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text);
            var alumnoRetorno = alumnoRepo.Add(alumno, selectedPath);

            log.Debug("Alumno retorno --> " + alumnoRetorno.ToString());

            if (alumnoRetorno.Equals(alumno))
            {
                MessageBox.Show("Alumno añadido correctamente.", "AlumnoJSON");
            }
            else
            {
                log.Error("Error al añadir un alumno.");
                MessageBox.Show("Error al añadir un alumno.", "AlumnoJSON");

            }
            txtID.Clear(); txtNombre.Clear(); txtApellidos.Clear(); txtDNI.Clear();
        }
    }
}
