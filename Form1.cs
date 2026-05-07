using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        stGamerStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        public enum enPlayer

        { Player1, Player2 }
        enum enWinner
        { Player1 , Player2 , Draw , GameInProgress }
        struct stGamerStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;
        
        }


        void changeImage(Button btn)
        {
            if (btn.Tag.ToString() == "?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:

                        btn.Text = "X";
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;

                        btn.Tag = "X";
                        CheckWinner();
                        break;

                    case enPlayer.Player2:

                        btn.Text = "O";
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }


            }

            else
            {
                MessageBox.Show("Wrong Choice", "Wrong", MessageBoxButtons.OK);
            }
            if (GameStatus.PlayCount == 9 )
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
        }
       public bool CheckVal(Button btn1 , Button btn2  , Button btn3)
        {
            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() &&btn1.Tag.ToString() == btn3.Tag.ToString())
            {
                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }
            GameStatus.GameOver = false;
            return false;
        }
        void CheckWinner()
        {
            if (CheckVal(button1, button2, button3))
                return;
            if (CheckVal(button4, button5, button7))
                return;
            if (CheckVal(button7, button8, button9))
                return;
            if (CheckVal(button1, button4, button7))
                return;
            if (CheckVal(button2, button5, button8))
                return;
            if (CheckVal(button3, button6, button9))
                return;
            if (CheckVal(button1, button5, button9))
                return;
            if (CheckVal(button3, button5, button7))
                return;

        }
        void EndGame()
        {
            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                    lblWinner.Text = "Player 1";
                    break;

                case enWinner.Player2:
                    lblWinner.Text = "Player 2";
                    break;
                default:
                    lblWinner.Text = "Draw";
                    break;


            }

            MessageBox.Show("Gamer OVer", "Gamer Over", MessageBoxButtons.OK , MessageBoxIcon.Information);

        }
       private void RestButton(Button btn)
        {
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
            btn.Text = "?";
            
        }
        private void RestartGame()
        {
            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";
        }
    

        private void button_Click(object sender, EventArgs e)
        {
            changeImage((Button)sender);
        }
    }
}
