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

        Label[,] labels = new Label[2,3];

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
            int posX = 0;
            int posY = 0;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {
                    if (i == 0) {
                        posX = 400;
                        switch (j) {
                            case 0:
                                posY = 122;
                                break;
                            case 1:
                                posY = 222;
                                break;
                            case 2:
                                posY = 322;
                                break;
                        }
                    } 
                    if (i == 1) {
                        posY = 400;
                        switch (j) {
                            case 0:
                                posX = 125;
                                break;
                            case 1:
                                posX = 225;
                                break;
                            case 2:
                                posX = 325;
                                break;
                        }
                    }
                    labels[i, j] = new Label {
                        Text = "ny",
                        AutoSize = true,
                        Location = new Point(posX,posY),
                    };
                }
            }

            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {
                this.Controls.Add(labels[i,j]);
                }
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
            labels[0, 0].Text = oppe1.ToString();
            labels[0, 1].Text = oppe2.ToString();
            labels[0, 2].Text = oppe3.ToString();
            labels[1, 0].Text = nede1.ToString();
            labels[1, 1].Text = nede2.ToString();
            labels[1, 2].Text = nede3.ToString();
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
