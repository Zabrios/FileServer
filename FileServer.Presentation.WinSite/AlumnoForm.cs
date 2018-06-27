using System;
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
            //this.cboPath.Properties.TextEditStyle = DisableTextEditor;
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            //string filePath;
            Common.Model.FileManager.CreateJSONFileIfNonexistent(Common.Model.FileManager.PathSelector(cboPath.SelectedIndex));
        }
    }
}
