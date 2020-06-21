using RevolverGame.Data;
using RevolverGame.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevolverGame
{
    public partial class GameScreen : Form
    {

        RevolverCylinder cylider;
        System.Media.SoundPlayer player;
        int remainingChance,pos;
        Random random;

        public GameScreen()
        {
            InitializeComponent();
            btnLoad.Enabled = btnPress.Enabled = btnSpin.Enabled = false;
            random = new Random();
        }

        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
            Application.Exit();
        }

        

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            pos = random.Next(0, 6);
            lblMessage.Text = "Loading The Bullet at Chamber No: " + ( pos + 1 );
            cylider.LoadTheBullet(pos);
            await Task.Delay(1000);
            btnSpin.Enabled = true;
            lblMessage.Text = "Click to Spin the Chamber...";
        }

        private async void btnSpin_Click(object sender, EventArgs e)
        {
            btnSpin.Enabled = false;
            lblMessage.Text = "Spinning the Chamber...";
            cylider.LoadTheBullet(pos);
            await Task.Delay(1000);
            btnPress.Enabled = true;
            lblMessage.Text = "Click to Press the Trigger For Fire Bullet...";
            lblRemaining.Text = "Your Remaining Luck Test : " + remainingChance;
            pos = 0;
        }

        private async void btnPress_Click(object sender, EventArgs e)
        {
            player = new System.Media.SoundPlayer();
            if (cylider.FireBullet(pos))
            {
                player.Stream = Resources.GunShot;
                player.Play();
                ChangePicture(Resources.blood);
                await Task.Delay(1000);
                lblRemaining.Text = "Your Luck is not With You";
                MessageBox.Show("Sorry!!! Now You are going to heaven...");
                this.Close();
                return;
            }
            else
            {
                player.Stream = Resources.Empty;
                player.Play();
                await Task.Delay(1000);
            }
            pos++;
            remainingChance--;
            if (remainingChance == 0)
            {
                lblRemaining.Text = "Your Luck is With You!!!";
                ChangePicture(Resources.lucky);
                await Task.Delay(500);
                MessageBox.Show("Congratulation. Your Luck make you Win!!!");
                this.Close();
            }
            else
            {
                lblRemaining.Text = "Your Remaining Luck Test : " + remainingChance;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text.Contains("Start"))
            {
                btnStart.Text = "End Game";
                lblMessage.Text = "Click To Load The Bullet in Revolver Cylinder...";
                remainingChance = 3;
                cylider = new RevolverCylinder();
                btnLoad.Enabled = true;
            }
            else
            {
                MessageBox.Show("I Think. You are Scared!!!");
                this.Close();
            }
        }

        private void ChangePicture(Bitmap image)
        {
            pictureImage.Image = image;
        }
    }
}
