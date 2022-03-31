using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game
{
    public partial class BlackPromotion : Form
    {
        public static int pieceForPromotion = 4;
        public static bool formClosed = false;
       public BlackPromotion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                pieceForPromotion = 1;//1 is knight
            else if(radioButton2.Checked == true)
                pieceForPromotion = 2;//2 is bishop
            else if (radioButton3.Checked == true)
                pieceForPromotion = 3;//3 is Rook
            else if (radioButton4.Checked == true)
                pieceForPromotion = 4;//4 is Queen
            this.Close();

        }

        private void BlackPromotion_Load(object sender, EventArgs e)
        {

        }
    }
}
