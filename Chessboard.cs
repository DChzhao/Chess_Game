using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess_Game
{
    public partial class Chessboard : Form
    {
        private Brush LightColor;
        private Brush DarkColor;
        private Brush Highlighted;
        private ChessGame Game;
        private Square Picked;
        private Square Dropped;
        private Point PickedLocation;
        private SoundPlayer TenSecLeft = new SoundPlayer(Properties.Resources.time);
        private SoundPlayer timeLose = new SoundPlayer(Properties.Resources.timeLose);
        private Dictionary<Piece,Bitmap> PieceImages;//BlackPawn,WhitePawn,BlackRook,WhiteRook,BlackKnight,WhiteKnight,BlackBishop,WhiteBishop
                                                     //,BlackKing, WhiteKing, BlackQueen, WhiteQueen;
        private bool gameStarted = ChessGame.gameStarted;

        internal Chessboard(Color Light, Color Dark, ChessGame Game)
        {
            InitializeComponent();

            PieceImages = new Dictionary<Piece, Bitmap>();
            PieceImages.Add(Piece.BPAWN, new Bitmap(new Bitmap(@"bp.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WPAWN, new Bitmap(new Bitmap(@"wp.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BROOK, new Bitmap(new Bitmap(@"br.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WROOK, new Bitmap(new Bitmap(@"wr.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BKNIGHT, new Bitmap(new Bitmap(@"bkn.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WKNIGHT, new Bitmap(new Bitmap(@"wkn.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BBISHOP, new Bitmap(new Bitmap(@"bb.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WBISHOP, new Bitmap(new Bitmap(@"wb.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BKING, new Bitmap(new Bitmap(@"bk.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WKING, new Bitmap(new Bitmap(@"wk.png"), new Size(64, 64)));
            PieceImages.Add(Piece.BQUEEN, new Bitmap(new Bitmap(@"bq.png"), new Size(64, 64)));
            PieceImages.Add(Piece.WQUEEN, new Bitmap(new Bitmap(@"wq.png"), new Size(64, 64)));
            LightColor = new SolidBrush(Light);
            DarkColor = new SolidBrush(Dark);
            Highlighted = new SolidBrush(Color.FromArgb(100, Color.FromName("yellow")));
            this.Game = Game;
            Player1.Text = Game.Player1Name;
            Player2.Text = Game.Player2Name;
            Game.Promote += Game_Promote;
            // Game.Moved += Piece_Moved;
            // Game.Move += Game_Started;
            //Game.Castled += Casteled;
            Game.TenSecLeft += TenSec;
            Picked = new Square(0,'z');
            Dropped = new Square(0, 'z');
            Board.Image = new Bitmap(512,512);
            Board_Paint(null,null);
            listBox1.DataSource = Game.Moves;
            Binding p1Time = new Binding("Text", Game.WhiteTimeLimit, "", true);
            Player1Time.DataBindings.Add(p1Time);
            Binding p2Time = new Binding("Text", Game.BlackTimeLimit, "", true);
            Player2Time.DataBindings.Add(p2Time);
            //     Player1Time.Text = Game.WhiteTimeLimit;
            //      Player2Time.Text = Game.BlackTimeLimit;
            //   Player1Time.DataBindings.Add("Text", Game.WhiteTimeLimit, "");
            //Player2Time.DataBindings.Add("Text", Game.BlackTimeLimit, "");
   
             
    }
        private object Game_Promote(Move move)
        {

            int piece=0;
            Promotion newPiece = Promotion.BKNIGHT;
            // make changes...
            MainTimer.Stop();
            if ((int) move.MovedPiece % 2 == 0){
               
                BlackPromotion BP = new BlackPromotion();
               // MethodInfo m = BP.GetType().GetMethod("Test");
                if (BP.ShowDialog(this) == DialogResult.OK)
                {                 
                }
                if (BlackPromotion.pieceForPromotion == 1)
                    newPiece = Promotion.BKNIGHT;
                else if (BlackPromotion.pieceForPromotion == 2)
                    newPiece = Promotion.BBISHOP;
                //  return Promotion.BBISHOP;
                else if (BlackPromotion.pieceForPromotion == 3)
                    newPiece = Promotion.BROOK;
                // return Promotion.BROOK;
                else if (BlackPromotion.pieceForPromotion == 4)
                    newPiece = Promotion.BQUEEN;
                //  return Promotion.BQUEEN;
              
            }
            else
            {
                WhitePromotion WP = new WhitePromotion();
                if (WP.ShowDialog(this) == DialogResult.OK)
                {   
                }
                if (WhitePromotion.pieceForPromotion == 1)
                    newPiece = Promotion.WKNIGHT;
                // return Promotion.BKNIGHT;
                else if (WhitePromotion.pieceForPromotion == 2)
                    newPiece = Promotion.WBISHOP;
                // return Promotion.BBISHOP;
                else if (WhitePromotion.pieceForPromotion == 3)
                    newPiece = Promotion.WROOK;
                // return Promotion.BROOK;
                else if (WhitePromotion.pieceForPromotion == 4)
                    newPiece = Promotion.WQUEEN;
                // return Promotion.BQUEEN;
          
            }
            //     return ((int)move.MovedPiece % 2 == 0) ? Promotion.BQUEEN : Promotion.WQUEEN;
            MainTimer.Start();
            return newPiece;
        }
       
        private void Board_MouseDown(object sender, MouseEventArgs e)
        {
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            int X = e.X / (2*sizeUnit);
            int Y = e.Y / (2 * sizeUnit);
            if (Game.Board[X][Y].Occupant == Piece.NONE)
                return;
            Picked = new Square(Game.Board[X][Y].Rank,
                                Game.Board[X][Y].File,
                                Game.Board[X][Y].Occupant);
            PickedLocation = new Point(e.Location.X - sizeUnit, e.Location.Y - sizeUnit);
            Board.Refresh();
        }
        private void Board_MouseUp(object sender, MouseEventArgs e)
        {
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            if (Picked.Occupant == Piece.NONE)
                return;
            if (e.X >= Board.Width || e.Y >= Board.Height || e.X < 0 || e.Y < 0)
            {
                Picked = new Square(0, 'z');
                Board.Invalidate();
                return;
            }
            int X = e.X / (2 * sizeUnit);
            int Y = e.Y / (2 * sizeUnit);
            bool Success = Game.Move(new Move(Picked.File - 'a', 8 - Picked.Rank, X, Y));
            if(Success)
                Dropped = new Square(Game.Board[X][Y].Rank,
                                    Game.Board[X][Y].File,
                                    Game.Board[X][Y].Occupant);
            Picked.Occupant = Piece.NONE ;
         //   gameStarted = true;
       
            Board.Invalidate();
        }
        private void TenSec()
        {
            TenSecLeft.Play();
        }
        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            int sizeUnit = (int)Math.Round(Board.Image.Width / 16.0);
            if (Picked.Occupant != Piece.NONE)
            {
                PickedLocation = new Point(e.Location.X - sizeUnit, e.Location.Y - sizeUnit);
                if (e.X >= Board.Width)
                    PickedLocation.X = Board.Width - sizeUnit;
                if (e.X < 0)
                    PickedLocation.X = -sizeUnit;
                if (e.Y >= Board.Height)
                    PickedLocation.Y = Board.Height - sizeUnit;
                if (e.Y < 0)
                    PickedLocation.Y = -sizeUnit;
            }
          
            Board.Invalidate();
            

        }
        private void Board_Paint(object sender, PaintEventArgs e)
        {
            int squareWidth = (int)Math.Round(Board.Image.Width / 8.0);
            using (Graphics g = Graphics.FromImage(Board.Image))
            {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if ((i + j) % 2 == 0)
                            g.FillRectangle(LightColor, new Rectangle(squareWidth * i, squareWidth * j, squareWidth, squareWidth));
                        else
                            g.FillRectangle(DarkColor, new Rectangle(squareWidth * i, squareWidth * j, squareWidth, squareWidth));
                for (int i = 0; i < 8; i++)
                {
                    g.DrawString("" + (8 - i), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                        (i % 2 == 0) ? DarkColor : LightColor, new Point(0, 3 * squareWidth / 64 + squareWidth * i));
                    g.DrawString("" + (char)('a' + i), new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold),
                        (i % 2 == 1) ? DarkColor : LightColor, new Point(54 * squareWidth/64 + squareWidth * i, 498));
                }
                if(Dropped.Occupant != Piece.NONE)
                    g.FillRectangle(Highlighted, new Rectangle(squareWidth * (Dropped.File - 'a'), squareWidth * (8 - Dropped.Rank), squareWidth, squareWidth));
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                    {
                        if (Game.Board[i][j].Occupant == Piece.NONE)//empty square
                            continue;
                        if (Picked.Occupant != Piece.NONE)
                            if (Game.Board[i][j].Rank == Picked.Rank && Game.Board[i][j].File == Picked.File)
                                continue;
                        g.DrawImage(PieceImages[Game.Board[i][j].Occupant], new Point(squareWidth * i, squareWidth * j));
                    }
                if (Picked.Occupant == Piece.NONE)
                    return;
                g.FillRectangle(Highlighted,
                    new Rectangle(squareWidth * (Picked.File - 'a'), squareWidth * (8 - Picked.Rank), squareWidth, squareWidth));
                g.DrawImage(PieceImages[Picked.Occupant], PickedLocation);
            }
        }

        private void ChessBoard_MouseMove(object sender, MouseEventArgs e)
        {
            Board.Invalidate();
        }

        private void Board_MouseLeave(object sender, EventArgs e)
        {
            Board.Invalidate();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (ChessGame.GameOver != true)
            {
                if (Game.WhiteTurn)
                {
                    if (ChessGame.gameStarted == true)
                    {
                        if (Game.WLimit <= MainTimer.Interval)
                        {
                            Game.WhiteTimeLimit = "0.00";
                            Game.WLimit = 0;
                            MainTimer.Stop();
                            MessageBox.Show(Game.Player1Name + " lost by timeout");
                            timeLose.Play();
                        }
                        else
                            Game.WhiteTimeLimit = Game.TimeToString(Game.WLimit -= MainTimer.Interval);
                         Player1Time.Text = Game.WhiteTimeLimit;
                     


                    }
                }
                else
                {
                    if (Game.BLimit <= MainTimer.Interval)
                    {
                        Game.BlackTimeLimit = "0.00";
                        Game.BLimit = 0;
                        MainTimer.Stop();
                        MessageBox.Show(Game.Player2Name + " lost by timeout");
                        timeLose.Play();
                    }
                    else
                        Game.BlackTimeLimit = Game.TimeToString(Game.BLimit -= MainTimer.Interval);
                   Player2Time.Text = Game.BlackTimeLimit;
                  
                }
            }
            else
            {
                MainTimer.Stop();
            }

      
        }

        private void Chessboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainTimer.Stop();
            ChessGame.GameOver = false;
            ChessGame.gameStarted = false;
        }

        private void Player2Time_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Chessboard_Load(object sender, EventArgs e)
        {
           
        }
    }
}
