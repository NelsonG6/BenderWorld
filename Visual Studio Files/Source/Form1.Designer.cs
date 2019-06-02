using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReinforcementLearning
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listboxBenderhistory = new System.Windows.Forms.ListBox();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.groupboxCurrentposition = new System.Windows.Forms.GroupBox();
            this.textboxEncodedas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxCurrentsquare = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textboxUp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textboxDown = new System.Windows.Forms.TextBox();
            this.textboxRight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxLeft = new System.Windows.Forms.TextBox();
            this.buttonStartAlgorithm = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textboxEpisodesinput = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupboxInitialsettings = new System.Windows.Forms.GroupBox();
            this.textboxY = new System.Windows.Forms.TextBox();
            this.textboxN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textboxNumberofepisodes = new System.Windows.Forms.TextBox();
            this.textboxNumberofsteps = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textboxStepsinput = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.textboxNinput = new System.Windows.Forms.TextBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.textboxYinput = new System.Windows.Forms.TextBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.groupboxConfiguration = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textboxAdvancestepsinput = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.textboxAdvanceepisodesinput = new System.Windows.Forms.TextBox();
            this.groupboxAlgorithmprogress = new System.Windows.Forms.GroupBox();
            this.groupboxSessionprogress = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupboxCurrentposition.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupboxInitialsettings.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupboxConfiguration.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupboxAlgorithmprogress.SuspendLayout();
            this.groupboxSessionprogress.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(43, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1063, 55);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listboxBenderhistory
            // 
            this.listboxBenderhistory.Enabled = false;
            this.listboxBenderhistory.FormattingEnabled = true;
            this.listboxBenderhistory.ItemHeight = 16;
            this.listboxBenderhistory.Items.AddRange(new object[] {
            "Bender\'s history will go here."});
            this.listboxBenderhistory.Location = new System.Drawing.Point(1409, 435);
            this.listboxBenderhistory.Margin = new System.Windows.Forms.Padding(4);
            this.listboxBenderhistory.Name = "listboxBenderhistory";
            this.listboxBenderhistory.Size = new System.Drawing.Size(476, 324);
            this.listboxBenderhistory.TabIndex = 3;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Enabled = false;
            this.buttonRestart.Location = new System.Drawing.Point(1112, 734);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(289, 25);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.reset_settings);
            // 
            // groupboxCurrentposition
            // 
            this.groupboxCurrentposition.Controls.Add(this.textboxEncodedas);
            this.groupboxCurrentposition.Controls.Add(this.label6);
            this.groupboxCurrentposition.Controls.Add(this.textboxCurrentsquare);
            this.groupboxCurrentposition.Controls.Add(this.label5);
            this.groupboxCurrentposition.Controls.Add(this.textboxUp);
            this.groupboxCurrentposition.Controls.Add(this.label3);
            this.groupboxCurrentposition.Controls.Add(this.textboxDown);
            this.groupboxCurrentposition.Controls.Add(this.textboxRight);
            this.groupboxCurrentposition.Controls.Add(this.label4);
            this.groupboxCurrentposition.Controls.Add(this.label2);
            this.groupboxCurrentposition.Controls.Add(this.label1);
            this.groupboxCurrentposition.Controls.Add(this.textboxLeft);
            this.groupboxCurrentposition.Enabled = false;
            this.groupboxCurrentposition.Location = new System.Drawing.Point(1408, 281);
            this.groupboxCurrentposition.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxCurrentposition.Name = "groupboxCurrentposition";
            this.groupboxCurrentposition.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxCurrentposition.Size = new System.Drawing.Size(477, 146);
            this.groupboxCurrentposition.TabIndex = 6;
            this.groupboxCurrentposition.TabStop = false;
            this.groupboxCurrentposition.Text = "Current position";
            // 
            // textboxEncodedas
            // 
            this.textboxEncodedas.Location = new System.Drawing.Point(24, 100);
            this.textboxEncodedas.Margin = new System.Windows.Forms.Padding(4);
            this.textboxEncodedas.Name = "textboxEncodedas";
            this.textboxEncodedas.Size = new System.Drawing.Size(432, 22);
            this.textboxEncodedas.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 76);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Encoded as";
            // 
            // textboxCurrentsquare
            // 
            this.textboxCurrentsquare.Location = new System.Drawing.Point(376, 48);
            this.textboxCurrentsquare.Margin = new System.Windows.Forms.Padding(4);
            this.textboxCurrentsquare.Name = "textboxCurrentsquare";
            this.textboxCurrentsquare.Size = new System.Drawing.Size(80, 22);
            this.textboxCurrentsquare.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Current square";
            // 
            // textboxUp
            // 
            this.textboxUp.Location = new System.Drawing.Point(288, 48);
            this.textboxUp.Margin = new System.Windows.Forms.Padding(4);
            this.textboxUp.Name = "textboxUp";
            this.textboxUp.Size = new System.Drawing.Size(79, 22);
            this.textboxUp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Up";
            // 
            // textboxDown
            // 
            this.textboxDown.Location = new System.Drawing.Point(200, 48);
            this.textboxDown.Margin = new System.Windows.Forms.Padding(4);
            this.textboxDown.Name = "textboxDown";
            this.textboxDown.Size = new System.Drawing.Size(80, 22);
            this.textboxDown.TabIndex = 3;
            // 
            // textboxRight
            // 
            this.textboxRight.Location = new System.Drawing.Point(112, 48);
            this.textboxRight.Margin = new System.Windows.Forms.Padding(4);
            this.textboxRight.Name = "textboxRight";
            this.textboxRight.Size = new System.Drawing.Size(80, 22);
            this.textboxRight.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(109, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Down";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Left";
            // 
            // textboxLeft
            // 
            this.textboxLeft.Location = new System.Drawing.Point(24, 48);
            this.textboxLeft.Margin = new System.Windows.Forms.Padding(4);
            this.textboxLeft.Name = "textboxLeft";
            this.textboxLeft.Size = new System.Drawing.Size(80, 22);
            this.textboxLeft.TabIndex = 1;
            // 
            // buttonStartAlgorithm
            // 
            this.buttonStartAlgorithm.Location = new System.Drawing.Point(15, 361);
            this.buttonStartAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartAlgorithm.Name = "buttonStartAlgorithm";
            this.buttonStartAlgorithm.Size = new System.Drawing.Size(259, 28);
            this.buttonStartAlgorithm.TabIndex = 7;
            this.buttonStartAlgorithm.Text = "Start algorithm";
            this.buttonStartAlgorithm.UseVisualStyleBackColor = true;
            this.buttonStartAlgorithm.Click += new System.EventHandler(this.start_algorithm);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textboxEpisodesinput);
            this.groupBox2.Controls.Add(this.comboBox2);
            this.groupBox2.Location = new System.Drawing.Point(15, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(259, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "How many episodes will there be?";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(157, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.set_episode_from_textbox);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(157, 18);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.set_episode_from_dropdown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "or";
            // 
            // textboxEpisodesinput
            // 
            this.textboxEpisodesinput.Location = new System.Drawing.Point(29, 50);
            this.textboxEpisodesinput.Name = "textboxEpisodesinput";
            this.textboxEpisodesinput.Size = new System.Drawing.Size(121, 22);
            this.textboxEpisodesinput.TabIndex = 1;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(29, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 0;
            // 
            // groupboxInitialsettings
            // 
            this.groupboxInitialsettings.Controls.Add(this.textboxY);
            this.groupboxInitialsettings.Controls.Add(this.textboxN);
            this.groupboxInitialsettings.Controls.Add(this.label11);
            this.groupboxInitialsettings.Controls.Add(this.label10);
            this.groupboxInitialsettings.Controls.Add(this.label8);
            this.groupboxInitialsettings.Controls.Add(this.textboxNumberofepisodes);
            this.groupboxInitialsettings.Controls.Add(this.textboxNumberofsteps);
            this.groupboxInitialsettings.Controls.Add(this.label9);
            this.groupboxInitialsettings.Location = new System.Drawing.Point(1407, 13);
            this.groupboxInitialsettings.Name = "groupboxInitialsettings";
            this.groupboxInitialsettings.Size = new System.Drawing.Size(478, 127);
            this.groupboxInitialsettings.TabIndex = 10;
            this.groupboxInitialsettings.TabStop = false;
            this.groupboxInitialsettings.Text = "Initial Settings";
            // 
            // textboxY
            // 
            this.textboxY.Location = new System.Drawing.Point(270, 93);
            this.textboxY.Margin = new System.Windows.Forms.Padding(4);
            this.textboxY.Name = "textboxY";
            this.textboxY.ReadOnly = true;
            this.textboxY.Size = new System.Drawing.Size(186, 22);
            this.textboxY.TabIndex = 13;
            // 
            // textboxN
            // 
            this.textboxN.Location = new System.Drawing.Point(24, 94);
            this.textboxN.Margin = new System.Windows.Forms.Padding(4);
            this.textboxN.Name = "textboxN";
            this.textboxN.ReadOnly = true;
            this.textboxN.Size = new System.Drawing.Size(187, 22);
            this.textboxN.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 74);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 24);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(135, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Number of episodes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 73);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "N";
            // 
            // textboxNumberofepisodes
            // 
            this.textboxNumberofepisodes.Location = new System.Drawing.Point(25, 47);
            this.textboxNumberofepisodes.Margin = new System.Windows.Forms.Padding(4);
            this.textboxNumberofepisodes.Name = "textboxNumberofepisodes";
            this.textboxNumberofepisodes.ReadOnly = true;
            this.textboxNumberofepisodes.Size = new System.Drawing.Size(187, 22);
            this.textboxNumberofepisodes.TabIndex = 13;
            // 
            // textboxNumberofsteps
            // 
            this.textboxNumberofsteps.Location = new System.Drawing.Point(272, 47);
            this.textboxNumberofsteps.Margin = new System.Windows.Forms.Padding(4);
            this.textboxNumberofsteps.Name = "textboxNumberofsteps";
            this.textboxNumberofsteps.ReadOnly = true;
            this.textboxNumberofsteps.Size = new System.Drawing.Size(185, 22);
            this.textboxNumberofsteps.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(265, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Number of steps per episode";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textboxStepsinput);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Location = new System.Drawing.Point(15, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 80);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "How many steps per episode?";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(157, 48);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "Set";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.set_steps_from_textbox);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(157, 18);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 3;
            this.button8.Text = "Set";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.set_steps_from_dropdown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "or";
            // 
            // textboxStepsinput
            // 
            this.textboxStepsinput.Location = new System.Drawing.Point(29, 50);
            this.textboxStepsinput.Name = "textboxStepsinput";
            this.textboxStepsinput.Size = new System.Drawing.Size(121, 22);
            this.textboxStepsinput.TabIndex = 1;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(29, 18);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.textboxNinput);
            this.groupBox5.Controls.Add(this.comboBox4);
            this.groupBox5.Location = new System.Drawing.Point(15, 193);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(259, 80);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "N";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(157, 48);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "Set";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.set_n_from_textbox);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(157, 18);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "Set";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.set_n_from_dropdown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 17);
            this.label13.TabIndex = 2;
            this.label13.Text = "or";
            // 
            // textboxNinput
            // 
            this.textboxNinput.Location = new System.Drawing.Point(29, 50);
            this.textboxNinput.Name = "textboxNinput";
            this.textboxNinput.Size = new System.Drawing.Size(121, 22);
            this.textboxNinput.TabIndex = 1;
            // 
            // comboBox4
            // 
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(29, 18);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(121, 24);
            this.comboBox4.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button11);
            this.groupBox6.Controls.Add(this.button12);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.textboxYinput);
            this.groupBox6.Controls.Add(this.comboBox5);
            this.groupBox6.Location = new System.Drawing.Point(15, 279);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(259, 80);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "y";
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(157, 48);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 4;
            this.button11.Text = "Set";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.set_y_from_textbox);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(157, 18);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 3;
            this.button12.Text = "Set";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.set_y_from_dropdown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "or";
            // 
            // textboxYinput
            // 
            this.textboxYinput.Location = new System.Drawing.Point(29, 50);
            this.textboxYinput.Name = "textboxYinput";
            this.textboxYinput.Size = new System.Drawing.Size(121, 22);
            this.textboxYinput.TabIndex = 1;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(29, 18);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 24);
            this.comboBox5.TabIndex = 0;
            // 
            // groupboxConfiguration
            // 
            this.groupboxConfiguration.Controls.Add(this.groupBox2);
            this.groupboxConfiguration.Controls.Add(this.groupBox6);
            this.groupboxConfiguration.Controls.Add(this.buttonStartAlgorithm);
            this.groupboxConfiguration.Controls.Add(this.groupBox5);
            this.groupboxConfiguration.Controls.Add(this.groupBox3);
            this.groupboxConfiguration.Location = new System.Drawing.Point(1112, 12);
            this.groupboxConfiguration.Name = "groupboxConfiguration";
            this.groupboxConfiguration.Size = new System.Drawing.Size(289, 415);
            this.groupboxConfiguration.TabIndex = 11;
            this.groupboxConfiguration.TabStop = false;
            this.groupboxConfiguration.Text = "Configuration";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button1);
            this.groupBox8.Controls.Add(this.comboBox6);
            this.groupBox8.Controls.Add(this.button2);
            this.groupBox8.Controls.Add(this.textboxAdvancestepsinput);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Location = new System.Drawing.Point(6, 25);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(268, 80);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Advance steps";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(166, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Step";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(38, 21);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(121, 24);
            this.comboBox6.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Step";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textboxAdvancestepsinput
            // 
            this.textboxAdvancestepsinput.Location = new System.Drawing.Point(38, 53);
            this.textboxAdvancestepsinput.Name = "textboxAdvancestepsinput";
            this.textboxAdvancestepsinput.Size = new System.Drawing.Size(121, 22);
            this.textboxAdvancestepsinput.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 17);
            this.label15.TabIndex = 7;
            this.label15.Text = "or";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.button4);
            this.groupBox9.Controls.Add(this.comboBox7);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.button13);
            this.groupBox9.Controls.Add(this.textboxAdvanceepisodesinput);
            this.groupBox9.Location = new System.Drawing.Point(6, 119);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(268, 80);
            this.groupBox9.TabIndex = 10;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Advance episodes";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(166, 51);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 24);
            this.button4.TabIndex = 14;
            this.button4.Text = "Step";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(38, 21);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 24);
            this.comboBox7.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 17);
            this.label16.TabIndex = 12;
            this.label16.Text = "or";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(166, 21);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 24);
            this.button13.TabIndex = 13;
            this.button13.Text = "Step";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // textboxAdvanceepisodesinput
            // 
            this.textboxAdvanceepisodesinput.Location = new System.Drawing.Point(38, 53);
            this.textboxAdvanceepisodesinput.Name = "textboxAdvanceepisodesinput";
            this.textboxAdvanceepisodesinput.Size = new System.Drawing.Size(121, 22);
            this.textboxAdvanceepisodesinput.TabIndex = 11;
            // 
            // groupboxAlgorithmprogress
            // 
            this.groupboxAlgorithmprogress.Controls.Add(this.groupBox8);
            this.groupboxAlgorithmprogress.Controls.Add(this.groupBox9);
            this.groupboxAlgorithmprogress.Enabled = false;
            this.groupboxAlgorithmprogress.Location = new System.Drawing.Point(1113, 435);
            this.groupboxAlgorithmprogress.Name = "groupboxAlgorithmprogress";
            this.groupboxAlgorithmprogress.Size = new System.Drawing.Size(289, 207);
            this.groupboxAlgorithmprogress.TabIndex = 12;
            this.groupboxAlgorithmprogress.TabStop = false;
            this.groupboxAlgorithmprogress.Text = "Algorithm progress";
            // 
            // groupboxSessionprogress
            // 
            this.groupboxSessionprogress.Controls.Add(this.textBox1);
            this.groupboxSessionprogress.Controls.Add(this.textBox2);
            this.groupboxSessionprogress.Controls.Add(this.label17);
            this.groupboxSessionprogress.Controls.Add(this.label18);
            this.groupboxSessionprogress.Controls.Add(this.label19);
            this.groupboxSessionprogress.Controls.Add(this.textBox3);
            this.groupboxSessionprogress.Controls.Add(this.textBox4);
            this.groupboxSessionprogress.Controls.Add(this.label20);
            this.groupboxSessionprogress.Location = new System.Drawing.Point(1407, 147);
            this.groupboxSessionprogress.Name = "groupboxSessionprogress";
            this.groupboxSessionprogress.Size = new System.Drawing.Size(478, 127);
            this.groupboxSessionprogress.TabIndex = 18;
            this.groupboxSessionprogress.TabStop = false;
            this.groupboxSessionprogress.Text = "Session progress";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(269, 93);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(188, 22);
            this.textBox1.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 94);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(187, 22);
            this.textBox2.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(265, 74);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 17);
            this.label17.TabIndex = 12;
            this.label17.Text = "Y";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(21, 24);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 17);
            this.label18.TabIndex = 12;
            this.label18.Text = "Number of episodes";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 73);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(18, 17);
            this.label19.TabIndex = 16;
            this.label19.Text = "N";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(25, 47);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(187, 22);
            this.textBox3.TabIndex = 13;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(270, 48);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(187, 22);
            this.textBox4.TabIndex = 15;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(265, 24);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(191, 17);
            this.label20.TabIndex = 14;
            this.label20.Text = "Number of steps per episode";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1986, 896);
            this.Controls.Add(this.groupboxSessionprogress);
            this.Controls.Add(this.groupboxAlgorithmprogress);
            this.Controls.Add(this.groupboxConfiguration);
            this.Controls.Add(this.groupboxInitialsettings);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.listboxBenderhistory);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupboxCurrentposition);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupboxCurrentposition.ResumeLayout(false);
            this.groupboxCurrentposition.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupboxInitialsettings.ResumeLayout(false);
            this.groupboxInitialsettings.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupboxConfiguration.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupboxAlgorithmprogress.ResumeLayout(false);
            this.groupboxSessionprogress.ResumeLayout(false);
            this.groupboxSessionprogress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox1;
        private ListBox listboxBenderhistory;
        private Button buttonRestart;
        private GroupBox groupboxCurrentposition;
        private TextBox textboxEncodedas;
        private Label label6;
        private TextBox textboxCurrentsquare;
        private Label label5;
        private TextBox textboxUp;
        private Label label3;
        private TextBox textboxRight;
        private Label label4;
        private TextBox textboxDown;
        private Label label2;
        private TextBox textboxLeft;
        private Label label1;
        private Button buttonStartAlgorithm;
        private GroupBox groupBox2;
        private Button button6;
        private Button button5;
        private Label label7;
        private TextBox textboxEpisodesinput;
        private ComboBox comboBox2;
        private GroupBox groupboxInitialsettings;
        private TextBox textboxY;
        private TextBox textboxN;
        private Label label11;
        private Label label10;
        private Label label8;
        private TextBox textboxNumberofepisodes;
        private TextBox textboxNumberofsteps;
        private Label label9;
        private GroupBox groupBox3;
        private Button button7;
        private Button button8;
        private Label label12;
        private TextBox textboxStepsinput;
        private ComboBox comboBox3;
        private GroupBox groupBox5;
        private Button button9;
        private Button button10;
        private Label label13;
        private TextBox textboxNinput;
        private ComboBox comboBox4;
        private GroupBox groupBox6;
        private Button button11;
        private Button button12;
        private Label label14;
        private TextBox textboxYinput;
        private ComboBox comboBox5;
        private GroupBox groupboxConfiguration;
        private GroupBox groupBox8;
        private Button button1;
        private ComboBox comboBox6;
        private Button button2;
        private TextBox textboxAdvancestepsinput;
        private Label label15;
        private GroupBox groupBox9;
        private Button button4;
        private ComboBox comboBox7;
        private Label label16;
        private Button button13;
        private TextBox textboxAdvanceepisodesinput;
        private GroupBox groupboxAlgorithmprogress;
        private GroupBox groupboxSessionprogress;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label17;
        private Label label18;
        private Label label19;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label20;
    }
}

