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
    public partial class Form_Rules : MetroFramework.Forms.MetroForm
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

        public Form_Rules()
        {
            InitializeComponent();

            // Windows Form BorderCurved
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void Form_Rules_Load(object sender, EventArgs e)
        {

        }

        // Click To exit The Application
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Click to Back the Form_SelectionDashbaord
        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form_SelectionDashbaord frmselectdash = new Form_SelectionDashbaord();
            frmselectdash.Show();
            this.Hide();
        }
    }
}
