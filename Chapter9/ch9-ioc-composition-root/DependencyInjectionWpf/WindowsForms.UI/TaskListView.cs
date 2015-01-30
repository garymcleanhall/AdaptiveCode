using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms.UI
{
    public partial class TaskListView : Form
    {
        public TaskListView(TaskListController controller)
        {
            InitializeComponent();

            //this.controller = controller;
            controller.OnLoad();
            this.taskListControllerBindingSource.DataSource = controller;
        }

        private void TaskListView_Load(object sender, EventArgs e)
        {
            //controller.OnLoad();
        }
    }
}
