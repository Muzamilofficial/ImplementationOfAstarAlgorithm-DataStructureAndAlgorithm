using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Star_Algorithm
{
    public partial class Form_SelectionDashbaord : MetroFramework.Forms.MetroForm
    {
        // Make Windows Form Border Radius Curved
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int RightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public Form_SelectionDashbaord()
        {
            InitializeComponent();

            // Windows Form BorderCurved
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Click To Exit the Application
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Click To Display Rule's Of Dijkstra's
        private void btn_DisplayRules_Click(object sender, EventArgs e)
        {
            Form_Rules frmrules = new Form_Rules();
            frmrules.Show();
            this.Hide();
        }

        // Click To Start The Dijkstra's
        private void btn_Start_Click(object sender, EventArgs e)
        {
            Form_Dijkstra frmdijkstra = new Form_Dijkstra();
            frmdijkstra.Show();
            this.Hide();
        }
    }
}
