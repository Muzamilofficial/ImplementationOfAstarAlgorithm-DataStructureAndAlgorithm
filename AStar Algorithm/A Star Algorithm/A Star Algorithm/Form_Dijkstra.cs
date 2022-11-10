using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Star_Algorithm
{
    public partial class Form_Dijkstra : MetroFramework.Forms.MetroForm
    {
        public Form_Dijkstra()
        {
            InitializeComponent();

            // Initialize The Values To Nodes
        }

        private void Form_Dijkstra_Load(object sender, EventArgs e)
        {
            label111.Visible = false;
            
            graph_panel.AutoScroll = false;
            graph_panel.HorizontalScroll.Enabled = false;
            graph_panel.HorizontalScroll.Visible = false;
            graph_panel.HorizontalScroll.Maximum = 0;
            graph_panel.AutoScroll = true;
            
            Btn_Forward.Visible = false;
            
            // Hiding The Gaol Found And Not Found Label
            Label_GoalNotFound.Visible = false;
            Label_GoalFound.Visible = false;

            // Hiding Labels On Form Load
            HidingGraph();

            // Add formula Heading To form Load In ListBox
            IntroOfFormula();
        }

        // Method For The UnHiding Of Graph Boundries
        public void GraphBoundriesUnHiding()
        {
            label82.Visible = true;
            label83.Visible = true;
            label80.Visible = true;
            label103.Visible = true;
            label104.Visible = true;
            label79.Visible = true;
            label78.Visible = true;
            label81.Visible = true;
            label105.Visible = true;
            label110.Visible = true;
            label109.Visible = true;
            label108.Visible = true;
            label106.Visible = true;
            label107.Visible = false;
            label120.Visible = false;
            label118.Visible = false;
            label119.Visible = false;
            label112.Visible = false;
        }

        // Function Of Hiding Labels On Form Load
        public void HidingGraph()
        {
            button25.Visible = false;
            button20.Visible = false;
            button18.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button19.Visible = false;
            button29.Visible = false;
            button32.Visible = false;
            button31.Visible = false;
            button30.Visible = false;
            button28.Visible = false;

            label82.Visible = false;
            label83.Visible = false;
            label80.Visible = false;
            label103.Visible = false;
            label104.Visible = false;
            label79.Visible = false;
            label78.Visible = false;
            label81.Visible = false;
            label105.Visible = false;
            label110.Visible = false;
            label109.Visible = false;
            label108.Visible = false;
            label106.Visible = false;
            label107.Visible = false;
            label120.Visible = false;
            label118.Visible = false;
            label119.Visible = false;
            label112.Visible = false;
        }

        // Add formula Heading To form Load In ListBox
        public void IntroOfFormula()
        {
            listBox1.Items.Add("----------------------------------------------------------");
            listBox1.Items.Add("                    F(n) = G(n) + H(n)                    ");
            listBox1.Items.Add("----------------------------------------------------------");
            listBox1.Items.Add("");
        }

        // If Goal Node No Found So Call This Function
        public void GoalNotFound()
        {
            if (Label_GoalFound.Visible == true && Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
            {
                Label_GoalNotFound.Visible = true;
                Label_GoalNotFound.Visible = false;
            }
        }

        // Event Of Exit The Application When Form Is Closing
        private void Form_Dijkstra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // To Exit The Application
        private void button22_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Check Whether The values Of Checkboxes Are Selected Or Not
        public void OKButtonFuction()
        {
            // First Validate That All TextBoxes Are Selected Or Not
            if (Combobox_StartNode.Text != "" && Combobox_EndNode.Text != "")
            {
                // Disabled Submit Button Control For Stop Further Changes Until Output Is Generated
                btn_Submit.Enabled = false;

                // Disabled ComboBox Control For Stop Further Changes Until Output Is Generated
                Combobox_StartNode.Enabled = false;
                Combobox_EndNode.Enabled = false;

                // Calling Of Function ClearControl For Clear All Components From Panel_City
                ClearControls();

                // Copy The Text From ComboBox_StartNode And Send It To Hidden Label
                HiddenTextbox.Text = Combobox_StartNode.Text;

                SameNode();
            }

            // If Textboxes Are Not Selected So Display This Error
            else
            {
                MessageBox.Show("Starting or Goal state is missing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // In This Method We Generate The Neighbours Of Nodes
        public void GenerateNeighbours()
        {
            GoalNotFound();
            // Calling The Nieghbours Of Karachi
            KarachiNieghbours();

            // Calling The Nieghbours Of Hyderabad
            HyderabadNieghbours();

            // Calling The Nieghbours Of Mirpurkhas
            MirpurkhasNieghbours();

            // Calling The Nieghbours Of Nawabshah
            NawabshahNieghbours();

            // Calling The Neighbours Of Sukkar
            SukkarNieghbours();

            // Calling Of Neighbour Of Nasirabad
            NasirabadNieghbours();

            // Calling The Neighbour Of Chaman
            ChamanNeighbours();

            // Calling Of Zhob Neighbours
            ZhobNieghbours();

            // Calling Of Multan Nieghbours
            MultanNieghbours();

            // Calling Of Turbat Neighbours
            TurbatNieghbours();

            // Calling Of Gwader Nieghbours
            GwaderNieghbours();

            // Calling Of LahoreNieghbours
            LahoreNieghbours();

            // Calling Of Islamabad Neighbours
            IslamabadNieghbours();
        }

        // Karachi Neighbours
        public  void KarachiNieghbours()
        {
            // Karachi Neighbours
            if (Textbox_PrevoiusNode.Text == "Karachi")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;

                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_Karachi"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Button_Karachi"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label42"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label2"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label90"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label23"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label25"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label48"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label97"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label18"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button9"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label57"))
                            {
                                btn.Show();
                            }


                            int FN = 380 + 0;
                            listBox1.Items.Add("Karachi To Karachi 380 + 0 = " + FN);

                            int FN2 = 71 + 374;
                            listBox1.Items.Add("Karachi To Hyderabad 71 + 374 = " + FN2);

                            int FN3 = 151 + 253;
                            listBox1.Items.Add("Karachi To Gwader 151 + 253 = " + FN3);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Gwader");

                            listBox5.Items.Add("Sucessors Of Karachi => Hyderabad => Gwader");
                            listBox3.Items.Add("Hyderabad "+ FN2);
                            listBox4.Items.Add("Gwader " + FN3);


                            label57.Text = ("F(n) = " + FN3);

                            HiddenTextbox.Text = "Gwader";
                            Textbox_PrevoiusNode.Text = "";

                            button25.Visible = true;
                            button16.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Hyderabad Neighbours
        public void HyderabadNieghbours()
        {
            // Karachi Neighbours
            if (Textbox_PrevoiusNode.Text == "Hyderabad")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_MipurKhas"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Button_MipurKhas"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label92"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label1"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label43"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label5"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label91"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_Hyderabad"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label4"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Btn_Hyderabad"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label67"))
                            {
                                btn.Show();
                            }


                            int FN = 3 + 0;
                            listBox1.Items.Add("Hyderabad To Hyderabad 3 + 0 = " + FN);

                            int FN2 = 75 + 374;
                            listBox1.Items.Add("Hyderabad To Mipur Khas 75 + 374 = " + FN2);

                            int FN3 = 71 + 380;
                            listBox1.Items.Add("Hyderabad To Karachi 71 + 380 = " + FN3);

                            listBox5.Items.Clear();

                            listBox5.Items.Add("Sucessors Of Hyderabad => Karachi => Mirpur Khas");
                            listBox3.Items.Add("Karachi " + FN3);
                            listBox4.Items.Add("Mirpur Khas " + FN2);


                            label67.Text = ("F(n) = " + FN2);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Mipur Khas");

                            HiddenTextbox.Text = "Mipur Khas";
                            Textbox_PrevoiusNode.Text = "";

                            button18.Visible = true;
                            button20.Visible = true;


                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }
        
        // Mirpur Khas Nighbours
        public void MirpurkhasNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Mipur Khas")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;

                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_MipurKhas"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Button_MipurKhas"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label20"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label21"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label49"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label18"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label97"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label92"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label1"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label61"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button9"))
                            {
                                btn.Show();
                            }


                            int FN = 366 + 0;
                            listBox1.Items.Add("Mipur Khas To Mipur Khas 366 + 0 = " + FN);

                            int FN2 = 75 + 374;
                            listBox1.Items.Add("Mipur Khas To Hyderabad 75 + 374 = " + FN2);

                            int FN3 = 140 + 253;
                            listBox1.Items.Add("Mipur Khas To Gwader 140 + 253 = " + FN3);

                            int FN4 = 140 + 253;
                            listBox1.Items.Add("Mipur Khas To NawabShah 111 + 329 = " + FN4);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Gwader");

                            HiddenTextbox.Text = "Gwader";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Clear();
                            listBox5.Items.Add("Sucessors Of Mirpur Khas => Hyderabad => Gwader => NawabShah");
                            listBox3.Items.Add("Hyderabad " + FN2);
                            listBox3.Items.Add("Nawabshah " + FN3);
                            listBox4.Items.Add("Gwader " + FN3);

                            label61.Text = ("F(n) = " + FN3);

                            button18.Visible = true;
                            button16.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }
        
        // Nawabshah Neighbours
        public void NawabshahNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Nawabshah")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label93"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button3"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label6"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label113"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label9"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label45"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label8"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label94"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label114"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label113"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label65"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button4"))
                            {
                                btn.Show();
                            }


                            int FN = 1 + 0;
                            listBox1.Items.Add("Nawabshah Khas To Nawabshah Khas 1 + 0 = " + FN);

                            int FN2 = 111 + 244;
                            listBox1.Items.Add("Nawabshah To Sukkar 111 + 7 = " + FN2);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Sukkur");

                            HiddenTextbox.Text = "Sukkur";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of NawabShah => Sukkar");
                            listBox4.Items.Add("Sukkar " + FN2);



                            label65.Text = ("F(n) = " + FN2);


                            button26.Visible = true;
                            button27.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Sukkar Neighbours
        public void SukkarNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Sukkur")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label8"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button4"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label94"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label46"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label114"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label95"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label10"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label115"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label11"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label63"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button5"))
                            {
                                btn.Show();
                            }


                            int FN = 244 + 0;
                            listBox1.Items.Add("Sukkur To Sukkur 244 + 0 = " + FN);

                            int FN2 = 70 + 241;
                            listBox1.Items.Add("Sukkur To Nasirabad 70 + 241 = " + FN2);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Nasirabad");

                            HiddenTextbox.Text = "Nasirabad";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of Sukkar => Nasirabad");
                            listBox4.Items.Add("Nasirabad " + FN2);


                            label63.Text = ("F(n) = " + FN2);

                            button27.Visible = true;
                            button29.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Nasirabad Neighbours
        public void NasirabadNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Nasirabad")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label10"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button5"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label95"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label115"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label47"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label13"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label124"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label96"))
                            {
                                btn.Show();
                            }
                            //foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label2"))
                            //{
                            //    btn.Show();
                            //}
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label64"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button6"))
                            {
                                btn.Show();
                            }


                            int FN = 8 + 0;
                            listBox1.Items.Add("Nasirabad To Nasirabad 8 + 0 = " + FN);

                            int FN2 = 75 + 15;
                            listBox1.Items.Add("Nasirabad To Chaman 75 + 15 = " + FN2);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Chaman");

                            listBox5.Items.Add("Sucessors Of Nasirabad => Chaman");
                            listBox3.Items.Add("Chaman " + FN2);


                            label64.Text = ("F(n) = " + FN2);
                            HiddenTextbox.Text = "Chaman";
                            Textbox_PrevoiusNode.Text = "";

                            button29.Visible = true;
                            button30.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Chaman Neighbours
        public void ChamanNeighbours()
        {
            if (Textbox_PrevoiusNode.Text == "Chaman")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label12"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button6"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label15"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label124"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label96"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label99"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label122"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label14"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label130"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label71"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button7"))
                            {
                                btn.Show();
                            }


                            int FN = 242 + 0;
                            listBox1.Items.Add("Chaman To Chaman 242 + 0 = " + FN);

                            int FN2 = 13 + 160;
                            listBox1.Items.Add("Chaman To Zhob 13 + 160 = " + FN2);

                            int FN3 = 75 + 241;
                            listBox1.Items.Add("Chaman To Nasirabad 75 + 241 = " + FN3);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Zhob");

                            listBox5.Items.Add("Sucessors Of Chaman => Zhob => Nasirabad");
                            listBox3.Items.Add("Nasirabad "+ FN3);
                            listBox4.Items.Add("Zhob " + FN2);


                            label71.Text = ("F(n) = " + FN2);

                            HiddenTextbox.Text = "Zhob";
                            Textbox_PrevoiusNode.Text = "";

                            button30.Visible = true;
                            button31.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Zhob Neighbours
        public void ZhobNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Zhob")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label14"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button7"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label99"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label122"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label31"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label32"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label33"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label53"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label121"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label101"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label29"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label62"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button12"))
                            {
                                btn.Show();
                            }


                            int FN = 160 + 0;
                            listBox1.Items.Add("Zhob To Zhob 160 + 0 = " + FN);

                            int FN2 = 146 + 193;
                            listBox1.Items.Add("Zhob To Turbat 146 + 193 = " + FN2);

                            int FN3 = 138 + 100;
                            listBox1.Items.Add("Zhob To Multan 138 + 100 = " + FN3);

                            int FN4 = 13 + 242;
                            listBox1.Items.Add("Zhob To Chaman 13 + 242 = " + FN4);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Multan");

                            listBox5.Items.Add("Sucessors Of Zhob => Turbat => Multan => Chaman");
                            listBox3.Items.Add("Chaman "+ FN4);
                            listBox3.Items.Add("Turbat " + FN2);
                            listBox4.Items.Add("Multan " + FN3);


                            label62.Text = ("F(n) = " + FN3);

                            button31.Visible = true;
                            button32.Visible = true;

                            HiddenTextbox.Text = "Multan";
                            Textbox_PrevoiusNode.Text = "";

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Multan Nieghbours
        public void MultanNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Multan")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label29"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button12"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label121"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label101"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label55"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label54"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label41"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label34"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label102"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label123"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label39"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label34"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label59"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button13"))
                            {
                                btn.Show();
                            }


                            int FN = 100 + 0;
                            listBox1.Items.Add("Multan To Multan 100 + 0 = " + FN);

                            int FN2 = 101 + 0;
                            listBox1.Items.Add("Multan To Islamabad 101 + 0 = " + FN2);

                            int FN3 = 97 + 193;
                            listBox1.Items.Add("Multan To Turbat 97 + 193 = " + FN3);
                            
                            int FN4 = 97 + 193;
                            listBox1.Items.Add("Multan To Zhob 138 + 160 = " + FN4);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Islamabad");


                            HiddenTextbox.Text = "Islamabad";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of Multan => Islamabad => Turbat => Zhob");
                            listBox3.Items.Add("Turbat "+ FN3);
                            listBox3.Items.Add("Zhob " + FN4);
                            
                            listBox4.Items.Add("Islamabad " + FN2);


                            label59.Text = ("F(n) = " + FN3);

                            button32.Visible = true;
                            button19.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Turbat Neighbours
        public void TurbatNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Turbat")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label16"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button8"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label98"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label118"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label51"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label19"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label97"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label18"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label60"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button9"))
                            {
                                btn.Show();
                            }


                            int FN = 193 + 0;
                            listBox1.Items.Add("Turbat To Turbat 193 + 0 = " + FN);

                            int FN2 = 97 + 100;
                            listBox1.Items.Add("Turbat To Multan 97 + 100 = " + FN2);

                            int FN3 = 146 + 160;
                            listBox1.Items.Add("Turbat To Zhob 146 + 160 = " + FN3);

                            int FN4 = 80 + 253;
                            listBox1.Items.Add("Turbat To Gwader 80 + 253 = " + FN4);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Gwader");

                            HiddenTextbox.Text = "Gwader";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of Turbat => Multan => Zhob => Gwader");
                            listBox3.Items.Add("Multan " + FN2);
                            listBox3.Items.Add("Zhob " + FN3);
                            listBox4.Items.Add("Gwader " + FN4);


                            label60.Text = ("F(n) = " + FN3);

                            button28.Visible = true;
                            button16.Visible = true;

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Gwader Neighbours
        public void GwaderNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Gwader")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label18"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button9"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label97"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label24"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label26"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label116"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label50"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label100"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label22"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label61"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button10"))
                            {
                                btn.Show();
                            }


                            int FN = 253 + 0;
                            listBox1.Items.Add("Gwader To Gwader 253 + 0 = " + FN);

                            int FN2 = 140 + 366;
                            listBox1.Items.Add("Gwader To Mipur Khas 140 + 366 = " + FN2);

                            int FN3 = 151 + 380;
                            listBox1.Items.Add("Gwader To Karachi 151 + 380 = " + FN3);

                            int FN5 = 80 + 193;
                            listBox1.Items.Add("Gwader To Turbat 151 + 380 = " + FN5);

                            int FN4 = 99 + 176;
                            listBox1.Items.Add("Gwader To Lahore 99 + 176 = " + FN4);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Lahore");

                            listBox5.Items.Add("Sucessors Of Gwader => Mirpur Khas => Karachi => Lahore");
                            listBox3.Items.Add("Mipur Khas " + FN2);
                            listBox3.Items.Add("Karachi " + FN3);
                            listBox3.Items.Add("Turbat " + FN5);
                            listBox4.Items.Add("Lahore " + FN4);


                            label61.Text = ("F(n) = " + FN3);

                            button16.Visible = true;
                            button17.Visible = true;

                            HiddenTextbox.Text = "Lahore";
                            Textbox_PrevoiusNode.Text = "";

                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Lahore Neighbours
        public void LahoreNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Lahore")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label22"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button10"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label100"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label116"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label38"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label37"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label28"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label40"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label102"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label123"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label34"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label58"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button13"))
                            {
                                btn.Show();
                            }


                            int FN = 10 + 176;
                            listBox1.Items.Add("Lahore To Lahore 10 + 176 = " + FN);

                            int FN2 = 211 + 0;
                            listBox1.Items.Add("Lahore To Islamabad 211 + 0 = " + FN2);

                            int FN3 = 99 + 253;
                            listBox1.Items.Add("Lahore To Gwader 99 + 253 = " + FN3);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Islamabad");

                            HiddenTextbox.Text = "Islamabad";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of Lahore => Islamabad => Gwader");
                            listBox3.Items.Add("Gwader " + FN3);
                            listBox4.Items.Add("Islamabad " + FN2);


                            label58.Text = ("F(n) = " + FN3);

                            button17.Visible = true;
                            button19.Visible = true;


                            lbl.Show();
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        // Islamabad Neighbours
        public void IslamabadNieghbours()
        {
            if (Textbox_PrevoiusNode.Text == "Islamabad")
            {
                if (Combobox_StartNode != Combobox_EndNode)
                {
                    if (Textbox_PrevoiusNode.Text != Textbox_GoalNode.Text)
                    {
                        Btn_Forward.Visible = true;
                        Btn_Back.Visible = true;
                        btn_Submit.Enabled = false;
                        Combobox_StartNode.Enabled = false;
                        Combobox_EndNode.Enabled = false;


                        IntroOfFormula();

                        foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label34"))
                        {
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button13"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label123"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label102"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label41"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label39"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label55"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label54"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label56"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label72"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label29"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label101"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label121"))
                            {
                                btn.Show();
                            }
                            foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button12"))
                            {
                                btn.Show();
                            }


                            int FN = 101 + 100;
                            listBox1.Items.Add("Islamabad To Multan 19 + 0 = " + FN);

                            int FN2 = 211 + 176;
                            listBox1.Items.Add("Islamabad To lahore 90 + 2 = " + FN2);

                            listBox1.Items.Add("");
                            listBox1.Items.Add("So It Will Move To Multan");

                            HiddenTextbox.Text = "Multan";
                            Textbox_PrevoiusNode.Text = "";

                            listBox5.Items.Add("Sucessors Of Islamabad => Multan => Lahore");
                            listBox4.Items.Add("Multan " + FN);
                            listBox3.Items.Add("Lahore " + FN2);


                            label72.Text = ("F(n) = " + FN);

                            lbl.Show();

                            button32.Visible = true;
                            button19.Visible = true;

                            Label_GoalFound.Visible = true;

                            Btn_Forward.Visible = false;
                            Btn_Back.Visible = false;
                            btn_Submit.Enabled = true;
                            Combobox_StartNode.Enabled = true;
                            Combobox_EndNode.Enabled = true;
                        }
                    }
                    else
                    {
                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";
                    }
                }

                else
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    Btn_Back.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }


        // Method Call When Starting And End Node Are Same
        public void SameNode()
        {
            if (Combobox_StartNode.Text == Combobox_EndNode.Text)
            {
                // For Same Node Of Karachi
                if (HiddenTextbox.Text == "Karachi")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_Karachi"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Button_Karachi"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label90"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label2"))
                        {
                            btn.Show();
                        }

                        int FN = 380 + 0;
                        listBox1.Items.Add("Karachi To Karachi 380 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Hyderabad
                if (HiddenTextbox.Text == "Hyderabad")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_Hyderabad"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Btn_Hyderabad"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label91"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label4"))
                        {
                            btn.Show();
                        }

                        int FN = 374 + 0;
                        listBox1.Items.Add("Hyderabad To Hyderabad 374 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Mirpur Khas
                if (HiddenTextbox.Text == "Mipur Khas")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_MipurKhas"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "Button_MipurKhas"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label92"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label1"))
                        {
                            btn.Show();
                        }

                        int FN = 366 + 0;
                        listBox1.Items.Add("Mipur Khas To Mipur Khas 366 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Nawabshah
                if (HiddenTextbox.Text == "Nawabshah")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label6"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button3"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label93"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label113"))
                        {
                            btn.Show();
                        }

                        int FN = 329 + 0;
                        listBox1.Items.Add("Nawabshah To Nawabshah 329 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Sukkur
                if (HiddenTextbox.Text == "Sukkur")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label8"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button4"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label94"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label114"))
                        {
                            btn.Show();
                        }

                        int FN = 244 + 0;
                        listBox1.Items.Add("Sukkur To Sukkur 244 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Nasirabad
                if (HiddenTextbox.Text == "Nasirabad")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label10"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button5"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label95"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label115"))
                        {
                            btn.Show();
                        }

                        int FN = 241 + 0;
                        listBox1.Items.Add("Nasirabad To Nasirabad 241 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Sukkur
                if (HiddenTextbox.Text == "Chaman")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label12"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button6"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label96"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label124"))
                        {
                            btn.Show();
                        }

                        int FN = 242 + 0;
                        listBox1.Items.Add("Chaman To Chaman 242 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Zhob
                if (HiddenTextbox.Text == "Zhob")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label14"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button7"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label99"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label122"))
                        {
                            btn.Show();
                        }

                        int FN = 160 + 0;
                        listBox1.Items.Add("Zhob To Zhob 160 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Turbat
                if (HiddenTextbox.Text == "Turbat")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label16"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button8"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label98"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label118"))
                        {
                            btn.Show();
                        }

                        int FN = 193 + 0;
                        listBox1.Items.Add("Turbat To Turbat 193 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Gwader
                if (HiddenTextbox.Text == "Gwader")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label18"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button9"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label97"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label117"))
                        {
                            btn.Show();
                        }

                        int FN = 253 + 0;
                        listBox1.Items.Add("Gwader To Gwader 253 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Bharwalpur
                if (HiddenTextbox.Text == "Bharwalpur")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label60"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button14"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label119"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label107"))
                        {
                            btn.Show();
                        }

                        int FN = 80 + 0;
                        listBox1.Items.Add("Bharwalpur To Bharwalpur 80 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Rahim Yar Khan
                if (HiddenTextbox.Text == "Rahim Yar Khan")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label65"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button15"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label108"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label129"))
                        {
                            btn.Show();
                        }

                        int FN = 151 + 0;
                        listBox1.Items.Add("Rahim Yar Khan To Rahim Yar Khan 151 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Multan
                if (HiddenTextbox.Text == "Multan")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label29"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button12"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label101"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label121"))
                        {
                            btn.Show();
                        }

                        int FN = 100 + 0;
                        listBox1.Items.Add("Multan To Multan 100 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Lahore
                if (HiddenTextbox.Text == "Lahore")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label22"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button10"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label100"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label116"))
                        {
                            btn.Show();
                        }

                        int FN = 176 + 0;
                        listBox1.Items.Add("Lahore To Lahore 176 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Islamabad
                if (HiddenTextbox.Text == "Islamabad")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label34"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button13"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label123"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label102"))
                        {
                            btn.Show();
                        }

                        int FN = 0 + 0;
                        listBox1.Items.Add("Islamabad To Islamabad 0 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Rawalpindi
                if (HiddenTextbox.Text == "Rawalpindi")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label57"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button11"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label103"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label120"))
                        {
                            btn.Show();
                        }

                        int FN = 77 + 0;
                        listBox1.Items.Add("Rawalpindi To Rawalpindi 77 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }

                // For Same Node Of Murree
                if (HiddenTextbox.Text == "Murree")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label75"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button17"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label72"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label106"))
                        {
                            btn.Show();
                        }

                        int FN = 199 + 0;
                        listBox1.Items.Add("Murree To Murree 199 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Peshawer
                if (HiddenTextbox.Text == "Peshawer")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label78"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button18"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label105"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label125"))
                        {
                            btn.Show();
                        }

                        int FN = 226 + 0;
                        listBox1.Items.Add("Peshawer To Peshawer 226 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Abbottabad
                if (HiddenTextbox.Text == "Abbottabad")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label82"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button19"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label104"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label126"))
                        {
                            btn.Show();
                        }

                        int FN = 234 + 0;
                        listBox1.Items.Add("Abbottabad To Abbottabad 234 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
                // For Same Node Of Chitral
                if (HiddenTextbox.Text == "Chitral")
                {
                    listBox1.Items.Clear();
                    IntroOfFormula();

                    foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label68"))
                    {
                        foreach (var btn in Panel_City.Controls.OfType<Button>().Where(x => x.Name == "button16"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label71"))
                        {
                            btn.Show();
                        }
                        foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "label109"))
                        {
                            btn.Show();
                        }

                        int FN = 161 + 0;
                        listBox1.Items.Add("Chitral To Chitral 161 + 0 = " + FN);

                        listBox1.Items.Add("");
                        listBox1.Items.Add("So It Will Not Move Further");

                        Label_GoalFound.Visible = true;

                        Btn_Forward.Visible = false;
                        Btn_Back.Visible = false;
                        btn_Submit.Enabled = true;
                        Combobox_StartNode.Enabled = true;
                        Combobox_EndNode.Enabled = true;

                        Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
                        HiddenTextbox.Text = "";

                        lbl.Show();
                    }
                }
            }
            
            // If Same Node Is Not Available So Run The Else Block
            else
            {
                GenerateNeighbours();
            }

        }

        // Hide The Controls On Button Click Of Panel_City
        public void ClearControls()
        {
            foreach (var lbl in Panel_City.Controls.OfType<Label>())
            {
                foreach (var btn in Panel_City.Controls.OfType<Button>())
                {
                    btn.Hide();
                }

                lbl.Hide();
            }
        }

        // Function To Show The Default Map
        public void ShowDefaultMap()
        {
            // Unhide All Labels
            foreach (var lbl in Panel_City.Controls.OfType<Label>())
            {
                foreach (var btn in Panel_City.Controls.OfType<Button>())
                {
                    btn.Show();
                }

                lbl.Show();
            }

            //Unhide All Labels Except The Goal Nodes Start And End Instructions
            foreach (var lbl in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_GoalNotFound"))
            {
                foreach (var btn in Panel_City.Controls.OfType<Label>().Where(x => x.Name == "Label_GoalFound"))
                {
                    btn.Hide();
                }
                lbl.Hide();
            }

            btn_Submit.Enabled = true;
            Btn_Forward.Visible = false;
            listBox1.Items.Clear();
            listBox5.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            HiddenTextbox.Text = "";
            IntroOfFormula();
        }

        // Submit Button Coding
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            // Calling Of OKButtonFunction
            OKButtonFuction();
            if (Combobox_StartNode.Text != "" && Combobox_EndNode.Text != "")
            {
                Btn_Forward.Visible = true;
                if (HiddenTextbox.Text == Combobox_EndNode.Text)
                {
                    Label_GoalFound.Visible = true;

                    Btn_Forward.Visible = false;
                    btn_Submit.Enabled = true;
                    Combobox_StartNode.Enabled = true;
                    Combobox_EndNode.Enabled = true;
                }
            }
        }

        private void Btn_Forward_Click(object sender, EventArgs e)
        {
            //VisibleControls();

            // Calling Of GenerateNeighbours Function
            GenerateNeighbours();

            if (HiddenTextbox.Text == Combobox_EndNode.Text)
            {
                Label_GoalFound.Visible = true;

                //Btn_Forward.Visible = false;
                btn_Submit.Enabled = true;
                Combobox_StartNode.Enabled = true;
                Combobox_EndNode.Enabled = true;
                GraphBoundriesUnHiding();
            }
            else
            {
                Label_GoalNotFound.Visible = true;
                Label_GoalFound.Visible = false;
                if (Btn_Forward.Visible == false)
                {
                    label111.Visible = true;
                    GraphBoundriesUnHiding();
                }
            }
        }

        private void Textbox_PrevoiusNode_DoubleClick_1(object sender, EventArgs e)
        {
            Textbox_PrevoiusNode.Text = HiddenTextbox.Text;
        }

        private void Btn_Back_Click(object sender, EventArgs e)
        {
            Form_SelectionDashbaord fsd = new Form_SelectionDashbaord();
            fsd.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Calling Of ShowDefaultMap Function To Unhide Or Show All Controls Of Panel
            ShowDefaultMap();

            Combobox_EndNode.Enabled = true;
            Combobox_StartNode.Enabled = true;
        }

        private void label112_Click(object sender, EventArgs e)
        {

        }
    }
}