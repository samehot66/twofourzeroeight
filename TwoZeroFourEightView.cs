﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;

        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel)m).GetBoard()); //Update board
            UpdateScore(((TwoZeroFourEightModel)m).GetScore());//Update score
            UpdateWin(((TwoZeroFourEightModel)m).Checkgamewin()); //Check win
            UpdateFull(((TwoZeroFourEightModel)m).Checkboardfull()); //Check full
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            }
            else
            {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Gray;
                    break;
                case 2:
                    l.BackColor = Color.DarkGray;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }

        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00, board[0, 0]);
            UpdateTile(lbl01, board[0, 1]);
            UpdateTile(lbl02, board[0, 2]);
            UpdateTile(lbl03, board[0, 3]);
            UpdateTile(lbl10, board[1, 0]);
            UpdateTile(lbl11, board[1, 1]);
            UpdateTile(lbl12, board[1, 2]);
            UpdateTile(lbl13, board[1, 3]);
            UpdateTile(lbl20, board[2, 0]);
            UpdateTile(lbl21, board[2, 1]);
            UpdateTile(lbl22, board[2, 2]);
            UpdateTile(lbl23, board[2, 3]);
            UpdateTile(lbl30, board[3, 0]);
            UpdateTile(lbl31, board[3, 1]);
            UpdateTile(lbl32, board[3, 2]);
            UpdateTile(lbl33, board[3, 3]);
        }

        private void UpdateScore(int score)
        {
            lblScore.Text = Convert.ToString(score); //convert int score to string and show
        }

        private void UpdateWin(bool win)//check win and output
        {
            if (win == true )
            {
                lblWin.Text = "Game Win";
                btnUp.Enabled = false; //block input
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
            }
            else
                lblWin.Text = "";
        } 

        private void UpdateFull(bool full)//check board full and output
        {
            if (full == true)
            {
                lblFull.Text = "Game Over";
                btnUp.Enabled = false; //block input
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
               
            }
            else
                lblFull.Text = "";
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }
        
        private void TwoZeroFourEightView_KeyDown(object sender, KeyEventArgs e) //Allow input by keyboard
        {
            switch (e.KeyData)
            {
                case Keys.W:
                case Keys.Up:
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    break;
                case Keys.S:
                case Keys.Down:
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;
                case Keys.A:
                case Keys.Left:
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case Keys.D:
                case Keys.Right:
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
            }
        }

        private void TwoZeroFourEightView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)//Allow input arrow
        {
           switch (e.KeyCode)
           {
                case Keys.Right:
                case Keys.Left:
                case Keys.Down:
                case Keys.Up:
                    e.IsInputKey = true;
                break;
           }
        }

        private void btnUp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TwoZeroFourEightView_PreviewKeyDown(sender, e);
        }

        private void btnDown_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TwoZeroFourEightView_PreviewKeyDown(sender, e);
        }

        private void btnLeft_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TwoZeroFourEightView_PreviewKeyDown(sender, e);
        }

        private void btnRight_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            TwoZeroFourEightView_PreviewKeyDown(sender, e);
        }
    }
}
