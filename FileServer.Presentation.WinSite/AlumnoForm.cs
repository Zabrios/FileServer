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
using FileServer.Infrastucture.Repository.Interfaces;
using FileServer.Infrastucture.Repository;

namespace FileServer.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public enum AlumnoFileType { Xml = 0, Json = 1, Txt = 2 }
        public AlumnoForm()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            cboPath.SelectedIndex = 0;
            cboExtension.SelectedIndex = 1;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            IFileManagerFactory fileFactory = new Infrastucture.Repository.Repositories.FileManagerFactory();
            IFileManager fManager = fileFactory.GetFileManager(cboExtension.SelectedIndex, cboPath.SelectedIndex);
            //fManager.CreateFile();
            //log.Debug("Entering the btAdd_Click Method.");
            //log.Debug(string.Format(@"Alumno --> ID = {0} | Nombre = {1} | Apellidos = {2} | DNI = {3}",
            //          txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text));
=======
            try
            {
                int p = 0;
                var num = 5 / p;
            }
            catch(Exception ex)
            {
                LogManager.GetLogger("EmailLogger").Error(ex);

            }
            //BasicConfigurator.Configure();
            log.Debug("Entering the btAdd_Click Method.");
            log.Debug(string.Format(@"Alumno --> ID = {0} | Nombre = {1} | Apellidos = {2} | DNI = {3}",
                      txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text));
>>>>>>> dbcb3fb4225c35dbe315e265804359c4ed1076c7

            var alumnoRepo = new AlumnoRepository();
            FileManager.GetFilePath(cboPath.SelectedIndex, cboExtension.SelectedIndex);
            //FileManager.PathSelector(cboPath.SelectedIndex);
            log.Debug("selectedPath = " + FileManager.FilePath);

            Alumno alumno = new Alumno(txtID.Text, txtNombre.Text, txtApellidos.Text, txtDNI.Text);
            var alumnoRetorno = alumnoRepo.Add(alumno);

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
