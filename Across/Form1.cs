using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Across
{
    public partial class Form1 : Form
    {
        public Random rnd;
        Felt[,] felt;
        int count;

        Label rightOne;
        Label rightTwo;
        Label rightThree;
        Label downOne;
        Label downTwo;
        Label downThree;

        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
            Start();
            MakeLabels();
        }

        // Laver de forskellige labels, bliver kaldt i starten
        public void MakeLabels()
        {
            rightOne = new Label {
                Text = "hej",
                Name = "oppe1",
                AutoSize = true,
                Location = new Point(400, 125),
                Visible = true,
            };
            rightTwo = new Label {
                Text = "hej",
                Name = "oppe2",
                AutoSize = true,
                Location = new Point(400, 225),
                Visible = true,
            };
            rightThree = new Label {
                Text = "jeg er label 3",
                Name = "oppe3",
                AutoSize = true,
                Location = new Point(400, 325),
                Visible = true,
            };

            downOne = new Label {
                Text = "hej",
                Name = "oppe1",
                AutoSize = true,
                Location = new Point(122, 400),
                Visible = true,
            };
            downTwo = new Label {
                Text = "hej",
                Name = "oppe2",
                AutoSize = true,
                Location = new Point(222, 400),
                Visible = true,
            };
            downThree = new Label {
                Text = "hej",
                Name = "oppe3",
                AutoSize = true,
                Location = new Point(322, 400),
                Visible = true,
            };
            this.Controls.Add(rightOne);
            this.Controls.Add(rightTwo);
            this.Controls.Add(rightThree);

            this.Controls.Add(downOne);
            this.Controls.Add(downTwo);
            this.Controls.Add(downThree);

            if (rightThree.Name == "oppe3") {
                Console.WriteLine("oppe 3 eksistere" + rightThree.Text);
            }

            LabelInformation();

        }

        public void LabelInformation()
        {
            int oppe1 = 0;
            int oppe2 = 0;
            int oppe3 = 0;
            int nede1 = 0;
            int nede2 = 0;
            int nede3 = 0;

            if (felt[0, 0].ShowReal()) {
                oppe1 += 1;
                nede1 += 1;
            }
            if (felt[1, 0].ShowReal()) {
                oppe1 += 1;
                nede2 += 1;
            }
            if (felt[2, 0].ShowReal()) {
                oppe1 += 1;
                nede3 += 1;
            }

            if (felt[0, 1].ShowReal()) {
                oppe2 += 1;
                nede1 += 1;
            }
            if (felt[1, 1].ShowReal()) {
                oppe2 += 1;
                nede2 += 1;
            }
            if (felt[2, 1].ShowReal()) {
                oppe2 += 1;
                nede3 += 1;
            }

            if (felt[0, 2].ShowReal()) {
                oppe3 += 1;
                nede1 += 1;
            }
            if (felt[1, 2].ShowReal()) {
                oppe3 += 1;
                nede2 += 1;
            }
            if (felt[2, 2].ShowReal()) {
                oppe3 += 1;
                nede3 += 1;
            }
            rightOne.Text = oppe1.ToString();
            rightTwo.Text = oppe2.ToString();
            rightThree.Text = oppe3.ToString();
            downOne.Text = nede1.ToString();
            downTwo.Text = nede2.ToString();
            downThree.Text = nede3.ToString();
        }

        public void Start()
        {
            Console.WriteLine("det er startet");
            felt = new Felt[3, 3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    felt[i,j] = new Felt(rnd, this, i, j);
                }
            }

            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    //felt[i,j].Randomize();
                    Console.WriteLine("felt " + i + j + " er " + felt[i,j].ShowReal());
                }
            }
        }

            // 1. check() on all felt objects in a loop. 
            // 2. count all "false" corrects on all the objects
            // 3. If there is 0 false. YOU WIN
            // else nothing happens and continue to play
        public void CheckForWin()
        {
            count = 0;
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    felt[i, j].Check();
                    if (felt[i,j].correct == false){
                        count += 1;
                    }
                }
            }
            if (count == 0) {
                MessageBox.Show("You Win!");
            }
        }
    }
}
