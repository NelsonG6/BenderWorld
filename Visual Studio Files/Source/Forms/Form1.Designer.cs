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
            this.groupboxInitialsettings = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textboxInitialNumberofsteps = new System.Windows.Forms.TextBox();
            this.textboxInitialNinitial = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textboxInitialY = new System.Windows.Forms.TextBox();
            this.textboxInitialEpsilon = new System.Windows.Forms.TextBox();
            this.groupboxRewards = new System.Windows.Forms.GroupBox();
            this.textboxInitialBeerreward = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textboxInitialEmptysquare = new System.Windows.Forms.TextBox();
            this.textboxRewardssuccessmove = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.textboxInitialWallpunishment = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textboxInitialNumberofepisodes = new System.Windows.Forms.TextBox();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.comboboxQmatrixselect = new System.Windows.Forms.ComboBox();
            this.textboxQmatrixcurrent = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textboxQmatrixup = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textboxQmatrixdown = new System.Windows.Forms.TextBox();
            this.textboxQmatrixright = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.textboxQmatrixleft = new System.Windows.Forms.TextBox();
            this.groupboxQmatrix = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxQmatrixentries = new System.Windows.Forms.TextBox();
            this.groupboxQmatrixselect = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.comboboxCurrentsquare = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.comboboxUp = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.comboboxDown = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.comboboxRight = new System.Windows.Forms.ComboBox();
            this.comboboxLeft = new System.Windows.Forms.ComboBox();
            this.groupboxQmatrixview = new System.Windows.Forms.GroupBox();
            this.comboboxHistoryepisode = new System.Windows.Forms.ComboBox();
            this.groupboxHistory = new System.Windows.Forms.GroupBox();
            this.comboboxHistorystep = new System.Windows.Forms.ComboBox();
            this.groupboxAlgorithmprogress = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.comboboxDelayms = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboboxAdvanceepisodes = new System.Windows.Forms.ComboBox();
            this.comboboxAdvancesteps = new System.Windows.Forms.ComboBox();
            this.buttonAdvancestepsdropdown = new System.Windows.Forms.Button();
            this.groupboxCountdown = new System.Windows.Forms.GroupBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.label48 = new System.Windows.Forms.Label();
            this.textboxProgresssteps = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textboxCountdown = new System.Windows.Forms.TextBox();
            this.groupboxConfiguration = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label45 = new System.Windows.Forms.Label();
            this.comboboxMovedwithoutwall = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.comboboxEmptysquare = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.comboboxBeer = new System.Windows.Forms.ComboBox();
            this.comboboxWallpunishment = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.buttonStartAlgorithm = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.comboboxEpisode = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboboxN = new System.Windows.Forms.ComboBox();
            this.comboboxE = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboboxSteps = new System.Windows.Forms.ComboBox();
            this.comboboxY = new System.Windows.Forms.ComboBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.pictureBox26 = new System.Windows.Forms.PictureBox();
            this.pictureBox27 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBox18 = new System.Windows.Forms.PictureBox();
            this.pictureBox19 = new System.Windows.Forms.PictureBox();
            this.pictureBox20 = new System.Windows.Forms.PictureBox();
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupboxStatusmessage = new System.Windows.Forms.GroupBox();
            this.textboxStatus = new System.Windows.Forms.RichTextBox();
            this.groupboxSessionprogress = new System.Windows.Forms.GroupBox();
            this.groupboxCans = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textboxCanscollected = new System.Windows.Forms.TextBox();
            this.textboxCansremaining = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.groupboxRewarddata = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.textboxRewardtotal = new System.Windows.Forms.TextBox();
            this.textboxRewardepisode = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textboxEpisodesprogress = new System.Windows.Forms.TextBox();
            this.textboxNprogress = new System.Windows.Forms.TextBox();
            this.textboxStepsprogress = new System.Windows.Forms.TextBox();
            this.groupboxCurrentposition = new System.Windows.Forms.GroupBox();
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
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textboxEprogress = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textboxYprogress = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox17 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupboxInitialsettings.SuspendLayout();
            this.groupboxRewards.SuspendLayout();
            this.groupboxQmatrix.SuspendLayout();
            this.groupboxQmatrixselect.SuspendLayout();
            this.groupboxQmatrixview.SuspendLayout();
            this.groupboxHistory.SuspendLayout();
            this.groupboxAlgorithmprogress.SuspendLayout();
            this.groupboxCountdown.SuspendLayout();
            this.groupboxConfiguration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupboxStatusmessage.SuspendLayout();
            this.groupboxSessionprogress.SuspendLayout();
            this.groupboxCans.SuspendLayout();
            this.groupboxRewarddata.SuspendLayout();
            this.groupboxCurrentposition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // groupboxInitialsettings
            // 
            this.groupboxInitialsettings.Controls.Add(this.label9);
            this.groupboxInitialsettings.Controls.Add(this.textboxInitialNumberofsteps);
            this.groupboxInitialsettings.Controls.Add(this.textboxInitialNinitial);
            this.groupboxInitialsettings.Controls.Add(this.label21);
            this.groupboxInitialsettings.Controls.Add(this.textboxInitialY);
            this.groupboxInitialsettings.Controls.Add(this.textboxInitialEpsilon);
            this.groupboxInitialsettings.Controls.Add(this.groupboxRewards);
            this.groupboxInitialsettings.Controls.Add(this.label11);
            this.groupboxInitialsettings.Controls.Add(this.label10);
            this.groupboxInitialsettings.Controls.Add(this.label8);
            this.groupboxInitialsettings.Controls.Add(this.textboxInitialNumberofepisodes);
            this.groupboxInitialsettings.Location = new System.Drawing.Point(1407, 13);
            this.groupboxInitialsettings.Name = "groupboxInitialsettings";
            this.groupboxInitialsettings.Size = new System.Drawing.Size(569, 145);
            this.groupboxInitialsettings.TabIndex = 10;
            this.groupboxInitialsettings.TabStop = false;
            this.groupboxInitialsettings.Text = "Initial Settings";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 43);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Steps per episode";
            // 
            // textboxInitialNumberofsteps
            // 
            this.textboxInitialNumberofsteps.Location = new System.Drawing.Point(122, 63);
            this.textboxInitialNumberofsteps.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialNumberofsteps.Name = "textboxInitialNumberofsteps";
            this.textboxInitialNumberofsteps.ReadOnly = true;
            this.textboxInitialNumberofsteps.Size = new System.Drawing.Size(157, 22);
            this.textboxInitialNumberofsteps.TabIndex = 15;
            // 
            // textboxInitialNinitial
            // 
            this.textboxInitialNinitial.Location = new System.Drawing.Point(123, 104);
            this.textboxInitialNinitial.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialNinitial.Name = "textboxInitialNinitial";
            this.textboxInitialNinitial.ReadOnly = true;
            this.textboxInitialNinitial.Size = new System.Drawing.Size(66, 22);
            this.textboxInitialNinitial.TabIndex = 19;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(31, 87);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 17);
            this.label21.TabIndex = 18;
            this.label21.Text = "Ɛ";
            // 
            // textboxInitialY
            // 
            this.textboxInitialY.Location = new System.Drawing.Point(210, 104);
            this.textboxInitialY.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialY.Name = "textboxInitialY";
            this.textboxInitialY.ReadOnly = true;
            this.textboxInitialY.Size = new System.Drawing.Size(69, 22);
            this.textboxInitialY.TabIndex = 13;
            // 
            // textboxInitialEpsilon
            // 
            this.textboxInitialEpsilon.Location = new System.Drawing.Point(33, 104);
            this.textboxInitialEpsilon.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialEpsilon.Name = "textboxInitialEpsilon";
            this.textboxInitialEpsilon.ReadOnly = true;
            this.textboxInitialEpsilon.Size = new System.Drawing.Size(70, 22);
            this.textboxInitialEpsilon.TabIndex = 17;
            // 
            // groupboxRewards
            // 
            this.groupboxRewards.Controls.Add(this.textboxInitialBeerreward);
            this.groupboxRewards.Controls.Add(this.label44);
            this.groupboxRewards.Controls.Add(this.textboxInitialEmptysquare);
            this.groupboxRewards.Controls.Add(this.textboxRewardssuccessmove);
            this.groupboxRewards.Controls.Add(this.label30);
            this.groupboxRewards.Controls.Add(this.label28);
            this.groupboxRewards.Controls.Add(this.textboxInitialWallpunishment);
            this.groupboxRewards.Controls.Add(this.label29);
            this.groupboxRewards.Location = new System.Drawing.Point(286, 20);
            this.groupboxRewards.Name = "groupboxRewards";
            this.groupboxRewards.Size = new System.Drawing.Size(276, 119);
            this.groupboxRewards.TabIndex = 59;
            this.groupboxRewards.TabStop = false;
            this.groupboxRewards.Text = "Rewards";
            // 
            // textboxInitialBeerreward
            // 
            this.textboxInitialBeerreward.Location = new System.Drawing.Point(15, 84);
            this.textboxInitialBeerreward.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialBeerreward.Name = "textboxInitialBeerreward";
            this.textboxInitialBeerreward.ReadOnly = true;
            this.textboxInitialBeerreward.Size = new System.Drawing.Size(110, 22);
            this.textboxInitialBeerreward.TabIndex = 25;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(11, 24);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(114, 17);
            this.label44.TabIndex = 26;
            this.label44.Text = "Successful move";
            // 
            // textboxInitialEmptysquare
            // 
            this.textboxInitialEmptysquare.Location = new System.Drawing.Point(148, 84);
            this.textboxInitialEmptysquare.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialEmptysquare.Name = "textboxInitialEmptysquare";
            this.textboxInitialEmptysquare.ReadOnly = true;
            this.textboxInitialEmptysquare.Size = new System.Drawing.Size(111, 22);
            this.textboxInitialEmptysquare.TabIndex = 23;
            // 
            // textboxRewardssuccessmove
            // 
            this.textboxRewardssuccessmove.Location = new System.Drawing.Point(14, 43);
            this.textboxRewardssuccessmove.Margin = new System.Windows.Forms.Padding(4);
            this.textboxRewardssuccessmove.Name = "textboxRewardssuccessmove";
            this.textboxRewardssuccessmove.ReadOnly = true;
            this.textboxRewardssuccessmove.Size = new System.Drawing.Size(111, 22);
            this.textboxRewardssuccessmove.TabIndex = 27;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(11, 67);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(38, 17);
            this.label30.TabIndex = 24;
            this.label30.Text = "Beer";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(149, 25);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(71, 17);
            this.label28.TabIndex = 20;
            this.label28.Text = "Hits a wall";
            // 
            // textboxInitialWallpunishment
            // 
            this.textboxInitialWallpunishment.Location = new System.Drawing.Point(148, 43);
            this.textboxInitialWallpunishment.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialWallpunishment.Name = "textboxInitialWallpunishment";
            this.textboxInitialWallpunishment.ReadOnly = true;
            this.textboxInitialWallpunishment.Size = new System.Drawing.Size(111, 22);
            this.textboxInitialWallpunishment.TabIndex = 21;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(145, 69);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(80, 17);
            this.label29.TabIndex = 22;
            this.label29.Text = "Empty grab";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(209, 85);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 17);
            this.label11.TabIndex = 12;
            this.label11.Text = "γ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Episodes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "η";
            // 
            // textboxInitialNumberofepisodes
            // 
            this.textboxInitialNumberofepisodes.Location = new System.Drawing.Point(34, 63);
            this.textboxInitialNumberofepisodes.Margin = new System.Windows.Forms.Padding(4);
            this.textboxInitialNumberofepisodes.Name = "textboxInitialNumberofepisodes";
            this.textboxInitialNumberofepisodes.ReadOnly = true;
            this.textboxInitialNumberofepisodes.Size = new System.Drawing.Size(69, 22);
            this.textboxInitialNumberofepisodes.TabIndex = 13;
            // 
            // buttonRestart
            // 
            this.buttonRestart.Enabled = false;
            this.buttonRestart.Location = new System.Drawing.Point(35, 137);
            this.buttonRestart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(210, 27);
            this.buttonRestart.TabIndex = 5;
            this.buttonRestart.Text = "Restart algorithm";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.reset_algorithm);
            // 
            // comboboxQmatrixselect
            // 
            this.comboboxQmatrixselect.FormattingEnabled = true;
            this.comboboxQmatrixselect.Items.AddRange(new object[] {
            "No board states have been added yet."});
            this.comboboxQmatrixselect.Location = new System.Drawing.Point(27, 21);
            this.comboboxQmatrixselect.Name = "comboboxQmatrixselect";
            this.comboboxQmatrixselect.Size = new System.Drawing.Size(518, 24);
            this.comboboxQmatrixselect.TabIndex = 0;
            this.comboboxQmatrixselect.Text = "Select a board state...";
            this.comboboxQmatrixselect.SelectedIndexChanged += new System.EventHandler(this.comboboxQmatrixselect_SelectedIndexChanged);
            // 
            // textboxQmatrixcurrent
            // 
            this.textboxQmatrixcurrent.Location = new System.Drawing.Point(375, 38);
            this.textboxQmatrixcurrent.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixcurrent.Name = "textboxQmatrixcurrent";
            this.textboxQmatrixcurrent.ReadOnly = true;
            this.textboxQmatrixcurrent.Size = new System.Drawing.Size(75, 22);
            this.textboxQmatrixcurrent.TabIndex = 21;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(370, 21);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 17);
            this.label17.TabIndex = 20;
            this.label17.Text = "Current";
            // 
            // textboxQmatrixup
            // 
            this.textboxQmatrixup.Location = new System.Drawing.Point(291, 38);
            this.textboxQmatrixup.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixup.Name = "textboxQmatrixup";
            this.textboxQmatrixup.ReadOnly = true;
            this.textboxQmatrixup.Size = new System.Drawing.Size(75, 22);
            this.textboxQmatrixup.TabIndex = 19;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(287, 19);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 17);
            this.label24.TabIndex = 18;
            this.label24.Text = "Up";
            // 
            // textboxQmatrixdown
            // 
            this.textboxQmatrixdown.Location = new System.Drawing.Point(203, 38);
            this.textboxQmatrixdown.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixdown.Name = "textboxQmatrixdown";
            this.textboxQmatrixdown.ReadOnly = true;
            this.textboxQmatrixdown.Size = new System.Drawing.Size(79, 22);
            this.textboxQmatrixdown.TabIndex = 15;
            // 
            // textboxQmatrixright
            // 
            this.textboxQmatrixright.Location = new System.Drawing.Point(115, 38);
            this.textboxQmatrixright.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixright.Name = "textboxQmatrixright";
            this.textboxQmatrixright.ReadOnly = true;
            this.textboxQmatrixright.Size = new System.Drawing.Size(79, 22);
            this.textboxQmatrixright.TabIndex = 17;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(108, 19);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(41, 17);
            this.label25.TabIndex = 16;
            this.label25.Text = "Right";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(197, 19);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(43, 17);
            this.label26.TabIndex = 14;
            this.label26.Text = "Down";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(21, 18);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(32, 17);
            this.label27.TabIndex = 12;
            this.label27.Text = "Left";
            // 
            // textboxQmatrixleft
            // 
            this.textboxQmatrixleft.Location = new System.Drawing.Point(27, 38);
            this.textboxQmatrixleft.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixleft.Name = "textboxQmatrixleft";
            this.textboxQmatrixleft.ReadOnly = true;
            this.textboxQmatrixleft.Size = new System.Drawing.Size(79, 22);
            this.textboxQmatrixleft.TabIndex = 13;
            // 
            // groupboxQmatrix
            // 
            this.groupboxQmatrix.Controls.Add(this.label6);
            this.groupboxQmatrix.Controls.Add(this.textboxQmatrixentries);
            this.groupboxQmatrix.Controls.Add(this.groupboxQmatrixselect);
            this.groupboxQmatrix.Controls.Add(this.groupboxQmatrixview);
            this.groupboxQmatrix.Enabled = false;
            this.groupboxQmatrix.Location = new System.Drawing.Point(1408, 165);
            this.groupboxQmatrix.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxQmatrix.Name = "groupboxQmatrix";
            this.groupboxQmatrix.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxQmatrix.Size = new System.Drawing.Size(568, 204);
            this.groupboxQmatrix.TabIndex = 12;
            this.groupboxQmatrix.TabStop = false;
            this.groupboxQmatrix.Text = "Q-Matrix";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(470, 146);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "Stored entries";
            // 
            // textboxQmatrixentries
            // 
            this.textboxQmatrixentries.Location = new System.Drawing.Point(473, 163);
            this.textboxQmatrixentries.Margin = new System.Windows.Forms.Padding(4);
            this.textboxQmatrixentries.Name = "textboxQmatrixentries";
            this.textboxQmatrixentries.ReadOnly = true;
            this.textboxQmatrixentries.Size = new System.Drawing.Size(79, 22);
            this.textboxQmatrixentries.TabIndex = 61;
            // 
            // groupboxQmatrixselect
            // 
            this.groupboxQmatrixselect.Controls.Add(this.label35);
            this.groupboxQmatrixselect.Controls.Add(this.label40);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxCurrentsquare);
            this.groupboxQmatrixselect.Controls.Add(this.label41);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxUp);
            this.groupboxQmatrixselect.Controls.Add(this.label42);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxDown);
            this.groupboxQmatrixselect.Controls.Add(this.label43);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxRight);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxLeft);
            this.groupboxQmatrixselect.Controls.Add(this.comboboxQmatrixselect);
            this.groupboxQmatrixselect.Location = new System.Drawing.Point(7, 18);
            this.groupboxQmatrixselect.Name = "groupboxQmatrixselect";
            this.groupboxQmatrixselect.Size = new System.Drawing.Size(554, 110);
            this.groupboxQmatrixselect.TabIndex = 59;
            this.groupboxQmatrixselect.TabStop = false;
            this.groupboxQmatrixselect.Text = "Select";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(24, 53);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(32, 17);
            this.label35.TabIndex = 22;
            this.label35.Text = "Left";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(290, 51);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(26, 17);
            this.label40.TabIndex = 25;
            this.label40.Text = "Up";
            // 
            // comboboxCurrentsquare
            // 
            this.comboboxCurrentsquare.FormattingEnabled = true;
            this.comboboxCurrentsquare.Location = new System.Drawing.Point(376, 69);
            this.comboboxCurrentsquare.Name = "comboboxCurrentsquare";
            this.comboboxCurrentsquare.Size = new System.Drawing.Size(75, 24);
            this.comboboxCurrentsquare.TabIndex = 5;
            this.comboboxCurrentsquare.SelectedIndexChanged += new System.EventHandler(this.qmatrix_small_dropdown_changed);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(200, 50);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(43, 17);
            this.label41.TabIndex = 23;
            this.label41.Text = "Down";
            // 
            // comboboxUp
            // 
            this.comboboxUp.FormattingEnabled = true;
            this.comboboxUp.Location = new System.Drawing.Point(291, 69);
            this.comboboxUp.Name = "comboboxUp";
            this.comboboxUp.Size = new System.Drawing.Size(79, 24);
            this.comboboxUp.TabIndex = 4;
            this.comboboxUp.SelectedIndexChanged += new System.EventHandler(this.qmatrix_small_dropdown_changed);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(111, 51);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 17);
            this.label42.TabIndex = 24;
            this.label42.Text = "Right";
            // 
            // comboboxDown
            // 
            this.comboboxDown.FormattingEnabled = true;
            this.comboboxDown.Location = new System.Drawing.Point(203, 69);
            this.comboboxDown.Name = "comboboxDown";
            this.comboboxDown.Size = new System.Drawing.Size(79, 24);
            this.comboboxDown.TabIndex = 3;
            this.comboboxDown.SelectedIndexChanged += new System.EventHandler(this.qmatrix_small_dropdown_changed);
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(372, 51);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(103, 17);
            this.label43.TabIndex = 26;
            this.label43.Text = "Current square";
            // 
            // comboboxRight
            // 
            this.comboboxRight.FormattingEnabled = true;
            this.comboboxRight.Location = new System.Drawing.Point(115, 70);
            this.comboboxRight.Name = "comboboxRight";
            this.comboboxRight.Size = new System.Drawing.Size(79, 24);
            this.comboboxRight.TabIndex = 2;
            this.comboboxRight.SelectedIndexChanged += new System.EventHandler(this.qmatrix_small_dropdown_changed);
            // 
            // comboboxLeft
            // 
            this.comboboxLeft.FormattingEnabled = true;
            this.comboboxLeft.Location = new System.Drawing.Point(27, 70);
            this.comboboxLeft.Name = "comboboxLeft";
            this.comboboxLeft.Size = new System.Drawing.Size(79, 24);
            this.comboboxLeft.TabIndex = 1;
            this.comboboxLeft.SelectedIndexChanged += new System.EventHandler(this.qmatrix_small_dropdown_changed);
            // 
            // groupboxQmatrixview
            // 
            this.groupboxQmatrixview.Controls.Add(this.label27);
            this.groupboxQmatrixview.Controls.Add(this.textboxQmatrixup);
            this.groupboxQmatrixview.Controls.Add(this.textboxQmatrixright);
            this.groupboxQmatrixview.Controls.Add(this.textboxQmatrixleft);
            this.groupboxQmatrixview.Controls.Add(this.textboxQmatrixcurrent);
            this.groupboxQmatrixview.Controls.Add(this.label24);
            this.groupboxQmatrixview.Controls.Add(this.label26);
            this.groupboxQmatrixview.Controls.Add(this.label25);
            this.groupboxQmatrixview.Controls.Add(this.label17);
            this.groupboxQmatrixview.Controls.Add(this.textboxQmatrixdown);
            this.groupboxQmatrixview.Location = new System.Drawing.Point(7, 125);
            this.groupboxQmatrixview.Name = "groupboxQmatrixview";
            this.groupboxQmatrixview.Size = new System.Drawing.Size(460, 71);
            this.groupboxQmatrixview.TabIndex = 59;
            this.groupboxQmatrixview.TabStop = false;
            this.groupboxQmatrixview.Text = "Q-matrix values";
            // 
            // comboboxHistoryepisode
            // 
            this.comboboxHistoryepisode.FormattingEnabled = true;
            this.comboboxHistoryepisode.Location = new System.Drawing.Point(35, 23);
            this.comboboxHistoryepisode.Name = "comboboxHistoryepisode";
            this.comboboxHistoryepisode.Size = new System.Drawing.Size(211, 24);
            this.comboboxHistoryepisode.TabIndex = 22;
            this.comboboxHistoryepisode.Text = "View prior episodes...";
            this.comboboxHistoryepisode.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxHistoryepisode.SelectedIndexChanged += new System.EventHandler(this.history_index_changed);
            this.comboboxHistoryepisode.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxHistoryepisode.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            // 
            // groupboxHistory
            // 
            this.groupboxHistory.Controls.Add(this.comboboxHistorystep);
            this.groupboxHistory.Controls.Add(this.comboboxHistoryepisode);
            this.groupboxHistory.Enabled = false;
            this.groupboxHistory.Location = new System.Drawing.Point(1146, 903);
            this.groupboxHistory.Name = "groupboxHistory";
            this.groupboxHistory.Size = new System.Drawing.Size(257, 97);
            this.groupboxHistory.TabIndex = 22;
            this.groupboxHistory.TabStop = false;
            this.groupboxHistory.Text = "History";
            // 
            // comboboxHistorystep
            // 
            this.comboboxHistorystep.Enabled = false;
            this.comboboxHistorystep.FormattingEnabled = true;
            this.comboboxHistorystep.Location = new System.Drawing.Point(35, 53);
            this.comboboxHistorystep.Name = "comboboxHistorystep";
            this.comboboxHistorystep.Size = new System.Drawing.Size(211, 24);
            this.comboboxHistorystep.TabIndex = 23;
            this.comboboxHistorystep.Text = "View prior steps...";
            this.comboboxHistorystep.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxHistorystep.SelectedIndexChanged += new System.EventHandler(this.comboboxHistorystep_SelectedIndexChanged);
            this.comboboxHistorystep.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxHistorystep.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            // 
            // groupboxAlgorithmprogress
            // 
            this.groupboxAlgorithmprogress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupboxAlgorithmprogress.Controls.Add(this.label46);
            this.groupboxAlgorithmprogress.Controls.Add(this.comboboxDelayms);
            this.groupboxAlgorithmprogress.Controls.Add(this.label16);
            this.groupboxAlgorithmprogress.Controls.Add(this.label15);
            this.groupboxAlgorithmprogress.Controls.Add(this.comboboxAdvanceepisodes);
            this.groupboxAlgorithmprogress.Controls.Add(this.comboboxAdvancesteps);
            this.groupboxAlgorithmprogress.Controls.Add(this.buttonRestart);
            this.groupboxAlgorithmprogress.Controls.Add(this.buttonAdvancestepsdropdown);
            this.groupboxAlgorithmprogress.Enabled = false;
            this.groupboxAlgorithmprogress.Location = new System.Drawing.Point(1146, 553);
            this.groupboxAlgorithmprogress.Name = "groupboxAlgorithmprogress";
            this.groupboxAlgorithmprogress.Size = new System.Drawing.Size(257, 189);
            this.groupboxAlgorithmprogress.TabIndex = 12;
            this.groupboxAlgorithmprogress.TabStop = false;
            this.groupboxAlgorithmprogress.Text = "Control Progress";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(26, 72);
            this.label46.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(120, 17);
            this.label46.TabIndex = 26;
            this.label46.Text = "ms delay per step";
            // 
            // comboboxDelayms
            // 
            this.comboboxDelayms.FormattingEnabled = true;
            this.comboboxDelayms.Items.AddRange(new object[] {
            "0",
            "5",
            "10",
            "15",
            "20",
            "25",
            "50"});
            this.comboboxDelayms.Location = new System.Drawing.Point(35, 92);
            this.comboboxDelayms.Name = "comboboxDelayms";
            this.comboboxDelayms.Size = new System.Drawing.Size(89, 24);
            this.comboboxDelayms.TabIndex = 26;
            this.comboboxDelayms.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxDelayms.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxDelayms.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxDelayms.Leave += new System.EventHandler(this.comboboxDelayms_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(152, 17);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "# of episodes";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(32, 17);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "# of steps";
            // 
            // comboboxAdvanceepisodes
            // 
            this.comboboxAdvanceepisodes.FormattingEnabled = true;
            this.comboboxAdvanceepisodes.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "25",
            "100"});
            this.comboboxAdvanceepisodes.Location = new System.Drawing.Point(155, 36);
            this.comboboxAdvanceepisodes.Name = "comboboxAdvanceepisodes";
            this.comboboxAdvanceepisodes.Size = new System.Drawing.Size(90, 24);
            this.comboboxAdvanceepisodes.TabIndex = 21;
            this.comboboxAdvanceepisodes.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxAdvanceepisodes.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxAdvanceepisodes.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxAdvanceepisodes.Leave += new System.EventHandler(this.comboboxAdvanceepisodes_Leave);
            // 
            // comboboxAdvancesteps
            // 
            this.comboboxAdvancesteps.FormattingEnabled = true;
            this.comboboxAdvancesteps.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "25",
            "100"});
            this.comboboxAdvancesteps.Location = new System.Drawing.Point(35, 35);
            this.comboboxAdvancesteps.Name = "comboboxAdvancesteps";
            this.comboboxAdvancesteps.Size = new System.Drawing.Size(89, 24);
            this.comboboxAdvancesteps.TabIndex = 19;
            this.comboboxAdvancesteps.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxAdvancesteps.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxAdvancesteps.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxAdvancesteps.Leave += new System.EventHandler(this.comboboxAdvancesteps_Leave);
            // 
            // buttonAdvancestepsdropdown
            // 
            this.buttonAdvancestepsdropdown.Location = new System.Drawing.Point(155, 90);
            this.buttonAdvancestepsdropdown.Name = "buttonAdvancestepsdropdown";
            this.buttonAdvancestepsdropdown.Size = new System.Drawing.Size(90, 27);
            this.buttonAdvancestepsdropdown.TabIndex = 20;
            this.buttonAdvancestepsdropdown.Text = "Step";
            this.buttonAdvancestepsdropdown.UseVisualStyleBackColor = true;
            this.buttonAdvancestepsdropdown.Click += new System.EventHandler(this.buttonAdvancestepsdropdown_Click);
            // 
            // groupboxCountdown
            // 
            this.groupboxCountdown.Controls.Add(this.buttonStop);
            this.groupboxCountdown.Controls.Add(this.label48);
            this.groupboxCountdown.Controls.Add(this.textboxProgresssteps);
            this.groupboxCountdown.Controls.Add(this.label47);
            this.groupboxCountdown.Controls.Add(this.textboxCountdown);
            this.groupboxCountdown.Enabled = false;
            this.groupboxCountdown.Location = new System.Drawing.Point(1146, 762);
            this.groupboxCountdown.Name = "groupboxCountdown";
            this.groupboxCountdown.Size = new System.Drawing.Size(257, 119);
            this.groupboxCountdown.TabIndex = 60;
            this.groupboxCountdown.TabStop = false;
            this.groupboxCountdown.Text = "In progress";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(35, 74);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(211, 27);
            this.buttonStop.TabIndex = 30;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(148, 18);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(44, 17);
            this.label48.TabIndex = 29;
            this.label48.Text = "Steps";
            // 
            // textboxProgresssteps
            // 
            this.textboxProgresssteps.Location = new System.Drawing.Point(155, 36);
            this.textboxProgresssteps.Name = "textboxProgresssteps";
            this.textboxProgresssteps.ReadOnly = true;
            this.textboxProgresssteps.Size = new System.Drawing.Size(91, 22);
            this.textboxProgresssteps.TabIndex = 28;
            this.textboxProgresssteps.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(32, 18);
            this.label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(39, 17);
            this.label47.TabIndex = 27;
            this.label47.Text = "Time";
            // 
            // textboxCountdown
            // 
            this.textboxCountdown.Location = new System.Drawing.Point(35, 35);
            this.textboxCountdown.Name = "textboxCountdown";
            this.textboxCountdown.ReadOnly = true;
            this.textboxCountdown.Size = new System.Drawing.Size(89, 22);
            this.textboxCountdown.TabIndex = 0;
            this.textboxCountdown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupboxConfiguration
            // 
            this.groupboxConfiguration.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.groupboxConfiguration.Controls.Add(this.groupBox1);
            this.groupboxConfiguration.Controls.Add(this.button10);
            this.groupboxConfiguration.Controls.Add(this.buttonStartAlgorithm);
            this.groupboxConfiguration.Controls.Add(this.label7);
            this.groupboxConfiguration.Controls.Add(this.label31);
            this.groupboxConfiguration.Controls.Add(this.comboboxEpisode);
            this.groupboxConfiguration.Controls.Add(this.label14);
            this.groupboxConfiguration.Controls.Add(this.comboboxN);
            this.groupboxConfiguration.Controls.Add(this.comboboxE);
            this.groupboxConfiguration.Controls.Add(this.label13);
            this.groupboxConfiguration.Controls.Add(this.label12);
            this.groupboxConfiguration.Controls.Add(this.comboboxSteps);
            this.groupboxConfiguration.Controls.Add(this.comboboxY);
            this.groupboxConfiguration.Controls.Add(this.pictureBox4);
            this.groupboxConfiguration.Location = new System.Drawing.Point(1146, 13);
            this.groupboxConfiguration.Name = "groupboxConfiguration";
            this.groupboxConfiguration.Size = new System.Drawing.Size(257, 534);
            this.groupboxConfiguration.TabIndex = 11;
            this.groupboxConfiguration.TabStop = false;
            this.groupboxConfiguration.Text = "Configuration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label45);
            this.groupBox1.Controls.Add(this.comboboxMovedwithoutwall);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.comboboxEmptysquare);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.comboboxBeer);
            this.groupBox1.Controls.Add(this.comboboxWallpunishment);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Location = new System.Drawing.Point(16, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 232);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rewards";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(16, 177);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(179, 17);
            this.label45.TabIndex = 69;
            this.label45.Text = "Moved without hitting a wall";
            // 
            // comboboxMovedwithoutwall
            // 
            this.comboboxMovedwithoutwall.FormattingEnabled = true;
            this.comboboxMovedwithoutwall.Items.AddRange(new object[] {
            "-20",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "20"});
            this.comboboxMovedwithoutwall.Location = new System.Drawing.Point(19, 195);
            this.comboboxMovedwithoutwall.Name = "comboboxMovedwithoutwall";
            this.comboboxMovedwithoutwall.Size = new System.Drawing.Size(202, 24);
            this.comboboxMovedwithoutwall.TabIndex = 17;
            this.comboboxMovedwithoutwall.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxMovedwithoutwall.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            this.comboboxMovedwithoutwall.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxMovedwithoutwall.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxMovedwithoutwall.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxMovedwithoutwall_KeyPress);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(16, 124);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(100, 17);
            this.label32.TabIndex = 64;
            this.label32.Text = "Ran into a wall";
            // 
            // comboboxEmptysquare
            // 
            this.comboboxEmptysquare.FormattingEnabled = true;
            this.comboboxEmptysquare.Items.AddRange(new object[] {
            "-20",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "20"});
            this.comboboxEmptysquare.Location = new System.Drawing.Point(19, 90);
            this.comboboxEmptysquare.Name = "comboboxEmptysquare";
            this.comboboxEmptysquare.Size = new System.Drawing.Size(202, 24);
            this.comboboxEmptysquare.TabIndex = 13;
            this.comboboxEmptysquare.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxEmptysquare.SelectedIndexChanged += new System.EventHandler(this.button6_Click);
            this.comboboxEmptysquare.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxEmptysquare.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxEmptysquare.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxEmptysquare_KeyPress);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(16, 71);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(163, 17);
            this.label34.TabIndex = 66;
            this.label34.Text = "Incorrectly grabbed beer";
            // 
            // comboboxBeer
            // 
            this.comboboxBeer.FormattingEnabled = true;
            this.comboboxBeer.Items.AddRange(new object[] {
            "-20",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "20"});
            this.comboboxBeer.Location = new System.Drawing.Point(19, 38);
            this.comboboxBeer.Name = "comboboxBeer";
            this.comboboxBeer.Size = new System.Drawing.Size(202, 24);
            this.comboboxBeer.TabIndex = 11;
            this.comboboxBeer.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxBeer.SelectedIndexChanged += new System.EventHandler(this.button8_Click);
            this.comboboxBeer.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxBeer.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxBeer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxBeer_KeyPress);
            // 
            // comboboxWallpunishment
            // 
            this.comboboxWallpunishment.FormattingEnabled = true;
            this.comboboxWallpunishment.Items.AddRange(new object[] {
            "-20",
            "-10",
            "-5",
            "0",
            "5",
            "10",
            "20"});
            this.comboboxWallpunishment.Location = new System.Drawing.Point(19, 143);
            this.comboboxWallpunishment.Name = "comboboxWallpunishment";
            this.comboboxWallpunishment.Size = new System.Drawing.Size(202, 24);
            this.comboboxWallpunishment.TabIndex = 15;
            this.comboboxWallpunishment.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxWallpunishment.SelectedIndexChanged += new System.EventHandler(this.button4_Click);
            this.comboboxWallpunishment.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxWallpunishment.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxWallpunishment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxWallpunishment_KeyPress);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(16, 18);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 17);
            this.label33.TabIndex = 65;
            this.label33.Text = "Collected beer";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(35, 476);
            this.button10.Margin = new System.Windows.Forms.Padding(4);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(201, 28);
            this.button10.TabIndex = 12;
            this.button10.Text = "Reset config";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // buttonStartAlgorithm
            // 
            this.buttonStartAlgorithm.Location = new System.Drawing.Point(35, 441);
            this.buttonStartAlgorithm.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStartAlgorithm.Name = "buttonStartAlgorithm";
            this.buttonStartAlgorithm.Size = new System.Drawing.Size(202, 28);
            this.buttonStartAlgorithm.TabIndex = 7;
            this.buttonStartAlgorithm.Text = "Start algorithm";
            this.buttonStartAlgorithm.UseVisualStyleBackColor = true;
            this.buttonStartAlgorithm.Click += new System.EventHandler(this.start_algorithm);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "# of episodes";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(178, 146);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 17);
            this.label31.TabIndex = 63;
            this.label31.Text = "Ɛ";
            // 
            // comboboxEpisode
            // 
            this.comboboxEpisode.FormattingEnabled = true;
            this.comboboxEpisode.Items.AddRange(new object[] {
            "1000",
            "2500",
            "5000",
            "10000",
            "50000"});
            this.comboboxEpisode.Location = new System.Drawing.Point(35, 63);
            this.comboboxEpisode.Name = "comboboxEpisode";
            this.comboboxEpisode.Size = new System.Drawing.Size(201, 24);
            this.comboboxEpisode.TabIndex = 1;
            this.comboboxEpisode.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxEpisode.SelectedIndexChanged += new System.EventHandler(this.set_episode_from_dropdown);
            this.comboboxEpisode.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxEpisode.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxEpisode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxEpisode_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 17);
            this.label14.TabIndex = 62;
            this.label14.Text = "γ";
            // 
            // comboboxN
            // 
            this.comboboxN.FormattingEnabled = true;
            this.comboboxN.Location = new System.Drawing.Point(108, 163);
            this.comboboxN.Name = "comboboxN";
            this.comboboxN.Size = new System.Drawing.Size(60, 24);
            this.comboboxN.TabIndex = 5;
            this.comboboxN.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxN.SelectedIndexChanged += new System.EventHandler(this.set_n_from_dropdown);
            this.comboboxN.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxN.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxN_KeyPress);
            // 
            // comboboxE
            // 
            this.comboboxE.FormattingEnabled = true;
            this.comboboxE.Location = new System.Drawing.Point(178, 163);
            this.comboboxE.Name = "comboboxE";
            this.comboboxE.Size = new System.Drawing.Size(58, 24);
            this.comboboxE.TabIndex = 9;
            this.comboboxE.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxE.SelectedIndexChanged += new System.EventHandler(this.button2_Click);
            this.comboboxE.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxE.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxE_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(106, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 17);
            this.label13.TabIndex = 61;
            this.label13.Text = "η";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 17);
            this.label12.TabIndex = 60;
            this.label12.Text = "# of steps per episode";
            // 
            // comboboxSteps
            // 
            this.comboboxSteps.FormattingEnabled = true;
            this.comboboxSteps.Items.AddRange(new object[] {
            "50",
            "100",
            "200",
            "400",
            "1000"});
            this.comboboxSteps.Location = new System.Drawing.Point(35, 114);
            this.comboboxSteps.Name = "comboboxSteps";
            this.comboboxSteps.Size = new System.Drawing.Size(201, 24);
            this.comboboxSteps.TabIndex = 3;
            this.comboboxSteps.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxSteps.SelectedIndexChanged += new System.EventHandler(this.set_steps_from_dropdown);
            this.comboboxSteps.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxSteps.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxSteps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxSteps_KeyPress);
            // 
            // comboboxY
            // 
            this.comboboxY.FormattingEnabled = true;
            this.comboboxY.Location = new System.Drawing.Point(35, 163);
            this.comboboxY.Name = "comboboxY";
            this.comboboxY.Size = new System.Drawing.Size(60, 24);
            this.comboboxY.TabIndex = 7;
            this.comboboxY.DropDown += new System.EventHandler(this.dropdown_opened);
            this.comboboxY.SelectedIndexChanged += new System.EventHandler(this.set_y_from_dropdown);
            this.comboboxY.DropDownClosed += new System.EventHandler(this.dropdown_closed);
            this.comboboxY.Click += new System.EventHandler(this.combobox_clicked_clear_text);
            this.comboboxY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboboxY_KeyPress);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(34, 102);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(29, 41);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 59;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(38, 192);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(25, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 58;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(38, 377);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(25, 30);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox12.TabIndex = 57;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(38, 282);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(25, 30);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox13.TabIndex = 56;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox24.Image")));
            this.pictureBox24.Location = new System.Drawing.Point(38, 472);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(25, 30);
            this.pictureBox24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox24.TabIndex = 55;
            this.pictureBox24.TabStop = false;
            // 
            // pictureBox26
            // 
            this.pictureBox26.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox26.Image")));
            this.pictureBox26.Location = new System.Drawing.Point(38, 652);
            this.pictureBox26.Name = "pictureBox26";
            this.pictureBox26.Size = new System.Drawing.Size(25, 30);
            this.pictureBox26.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox26.TabIndex = 53;
            this.pictureBox26.TabStop = false;
            // 
            // pictureBox27
            // 
            this.pictureBox27.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox27.Image")));
            this.pictureBox27.Location = new System.Drawing.Point(38, 557);
            this.pictureBox27.Name = "pictureBox27";
            this.pictureBox27.Size = new System.Drawing.Size(25, 30);
            this.pictureBox27.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox27.TabIndex = 52;
            this.pictureBox27.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(38, 832);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(25, 30);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox10.TabIndex = 47;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(38, 742);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(25, 30);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox11.TabIndex = 46;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox16.Image")));
            this.pictureBox16.Location = new System.Drawing.Point(818, 998);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(25, 30);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox16.TabIndex = 43;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBox18
            // 
            this.pictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox18.Image")));
            this.pictureBox18.Location = new System.Drawing.Point(618, 998);
            this.pictureBox18.Name = "pictureBox18";
            this.pictureBox18.Size = new System.Drawing.Size(25, 30);
            this.pictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox18.TabIndex = 41;
            this.pictureBox18.TabStop = false;
            // 
            // pictureBox19
            // 
            this.pictureBox19.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox19.Image")));
            this.pictureBox19.Location = new System.Drawing.Point(718, 998);
            this.pictureBox19.Name = "pictureBox19";
            this.pictureBox19.Size = new System.Drawing.Size(25, 30);
            this.pictureBox19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox19.TabIndex = 40;
            this.pictureBox19.TabStop = false;
            // 
            // pictureBox20
            // 
            this.pictureBox20.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox20.Image")));
            this.pictureBox20.Location = new System.Drawing.Point(418, 998);
            this.pictureBox20.Name = "pictureBox20";
            this.pictureBox20.Size = new System.Drawing.Size(25, 30);
            this.pictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox20.TabIndex = 39;
            this.pictureBox20.TabStop = false;
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox21.Image")));
            this.pictureBox21.Location = new System.Drawing.Point(518, 998);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(25, 30);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox21.TabIndex = 38;
            this.pictureBox21.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(218, 998);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(25, 30);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 31;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(318, 998);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(25, 30);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox9.TabIndex = 30;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(118, 998);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 25;
            this.pictureBox3.TabStop = false;
            // 
            // groupboxStatusmessage
            // 
            this.groupboxStatusmessage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupboxStatusmessage.BackgroundImage")));
            this.groupboxStatusmessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupboxStatusmessage.Controls.Add(this.textboxStatus);
            this.groupboxStatusmessage.Location = new System.Drawing.Point(1409, 605);
            this.groupboxStatusmessage.Name = "groupboxStatusmessage";
            this.groupboxStatusmessage.Size = new System.Drawing.Size(569, 374);
            this.groupboxStatusmessage.TabIndex = 23;
            this.groupboxStatusmessage.TabStop = false;
            this.groupboxStatusmessage.Text = "Status message";
            // 
            // textboxStatus
            // 
            this.textboxStatus.Location = new System.Drawing.Point(33, 24);
            this.textboxStatus.Name = "textboxStatus";
            this.textboxStatus.ReadOnly = true;
            this.textboxStatus.Size = new System.Drawing.Size(530, 317);
            this.textboxStatus.TabIndex = 0;
            this.textboxStatus.Text = "";
            // 
            // groupboxSessionprogress
            // 
            this.groupboxSessionprogress.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupboxSessionprogress.BackgroundImage")));
            this.groupboxSessionprogress.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupboxSessionprogress.Controls.Add(this.groupboxCans);
            this.groupboxSessionprogress.Controls.Add(this.groupboxRewarddata);
            this.groupboxSessionprogress.Controls.Add(this.label23);
            this.groupboxSessionprogress.Controls.Add(this.label18);
            this.groupboxSessionprogress.Controls.Add(this.textboxEpisodesprogress);
            this.groupboxSessionprogress.Controls.Add(this.textboxNprogress);
            this.groupboxSessionprogress.Controls.Add(this.textboxStepsprogress);
            this.groupboxSessionprogress.Controls.Add(this.groupboxCurrentposition);
            this.groupboxSessionprogress.Controls.Add(this.label19);
            this.groupboxSessionprogress.Controls.Add(this.label20);
            this.groupboxSessionprogress.Controls.Add(this.textboxEprogress);
            this.groupboxSessionprogress.Controls.Add(this.label22);
            this.groupboxSessionprogress.Controls.Add(this.textboxYprogress);
            this.groupboxSessionprogress.Enabled = false;
            this.groupboxSessionprogress.Location = new System.Drawing.Point(1409, 367);
            this.groupboxSessionprogress.Name = "groupboxSessionprogress";
            this.groupboxSessionprogress.Size = new System.Drawing.Size(569, 237);
            this.groupboxSessionprogress.TabIndex = 18;
            this.groupboxSessionprogress.TabStop = false;
            this.groupboxSessionprogress.Text = "Session progress";
            // 
            // groupboxCans
            // 
            this.groupboxCans.Controls.Add(this.label37);
            this.groupboxCans.Controls.Add(this.textboxCanscollected);
            this.groupboxCans.Controls.Add(this.textboxCansremaining);
            this.groupboxCans.Controls.Add(this.label36);
            this.groupboxCans.Location = new System.Drawing.Point(22, 66);
            this.groupboxCans.Name = "groupboxCans";
            this.groupboxCans.Size = new System.Drawing.Size(190, 76);
            this.groupboxCans.TabIndex = 59;
            this.groupboxCans.TabStop = false;
            this.groupboxCans.Text = "Can data this episode";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(99, 21);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(66, 17);
            this.label37.TabIndex = 29;
            this.label37.Text = "Collected";
            // 
            // textboxCanscollected
            // 
            this.textboxCanscollected.Location = new System.Drawing.Point(99, 39);
            this.textboxCanscollected.Margin = new System.Windows.Forms.Padding(4);
            this.textboxCanscollected.Name = "textboxCanscollected";
            this.textboxCanscollected.ReadOnly = true;
            this.textboxCanscollected.Size = new System.Drawing.Size(79, 22);
            this.textboxCanscollected.TabIndex = 28;
            // 
            // textboxCansremaining
            // 
            this.textboxCansremaining.Location = new System.Drawing.Point(11, 39);
            this.textboxCansremaining.Margin = new System.Windows.Forms.Padding(4);
            this.textboxCansremaining.Name = "textboxCansremaining";
            this.textboxCansremaining.ReadOnly = true;
            this.textboxCansremaining.Size = new System.Drawing.Size(79, 22);
            this.textboxCansremaining.TabIndex = 23;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(14, 21);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(75, 17);
            this.label36.TabIndex = 22;
            this.label36.Text = "Remaining";
            // 
            // groupboxRewarddata
            // 
            this.groupboxRewarddata.Controls.Add(this.label38);
            this.groupboxRewarddata.Controls.Add(this.textboxRewardtotal);
            this.groupboxRewarddata.Controls.Add(this.textboxRewardepisode);
            this.groupboxRewarddata.Controls.Add(this.label39);
            this.groupboxRewarddata.Location = new System.Drawing.Point(282, 66);
            this.groupboxRewarddata.Name = "groupboxRewarddata";
            this.groupboxRewarddata.Size = new System.Drawing.Size(184, 76);
            this.groupboxRewarddata.TabIndex = 60;
            this.groupboxRewarddata.TabStop = false;
            this.groupboxRewarddata.Text = "Reward data";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(100, 22);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(40, 17);
            this.label38.TabIndex = 29;
            this.label38.Text = "Total";
            // 
            // textboxRewardtotal
            // 
            this.textboxRewardtotal.Location = new System.Drawing.Point(100, 40);
            this.textboxRewardtotal.Margin = new System.Windows.Forms.Padding(4);
            this.textboxRewardtotal.Name = "textboxRewardtotal";
            this.textboxRewardtotal.ReadOnly = true;
            this.textboxRewardtotal.Size = new System.Drawing.Size(75, 22);
            this.textboxRewardtotal.TabIndex = 28;
            // 
            // textboxRewardepisode
            // 
            this.textboxRewardepisode.Location = new System.Drawing.Point(14, 40);
            this.textboxRewardepisode.Margin = new System.Windows.Forms.Padding(4);
            this.textboxRewardepisode.Name = "textboxRewardepisode";
            this.textboxRewardepisode.ReadOnly = true;
            this.textboxRewardepisode.Size = new System.Drawing.Size(76, 22);
            this.textboxRewardepisode.TabIndex = 23;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(10, 23);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 17);
            this.label39.TabIndex = 22;
            this.label39.Text = "This episode";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(209, 16);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(15, 17);
            this.label23.TabIndex = 20;
            this.label23.Text = "γ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(387, 18);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 17);
            this.label18.TabIndex = 12;
            this.label18.Text = "Episode #";
            // 
            // textboxEpisodesprogress
            // 
            this.textboxEpisodesprogress.Location = new System.Drawing.Point(383, 37);
            this.textboxEpisodesprogress.Margin = new System.Windows.Forms.Padding(4);
            this.textboxEpisodesprogress.Name = "textboxEpisodesprogress";
            this.textboxEpisodesprogress.ReadOnly = true;
            this.textboxEpisodesprogress.Size = new System.Drawing.Size(75, 22);
            this.textboxEpisodesprogress.TabIndex = 13;
            // 
            // textboxNprogress
            // 
            this.textboxNprogress.Location = new System.Drawing.Point(121, 37);
            this.textboxNprogress.Margin = new System.Windows.Forms.Padding(4);
            this.textboxNprogress.Name = "textboxNprogress";
            this.textboxNprogress.ReadOnly = true;
            this.textboxNprogress.Size = new System.Drawing.Size(75, 22);
            this.textboxNprogress.TabIndex = 21;
            // 
            // textboxStepsprogress
            // 
            this.textboxStepsprogress.Location = new System.Drawing.Point(298, 37);
            this.textboxStepsprogress.Margin = new System.Windows.Forms.Padding(4);
            this.textboxStepsprogress.Name = "textboxStepsprogress";
            this.textboxStepsprogress.ReadOnly = true;
            this.textboxStepsprogress.Size = new System.Drawing.Size(79, 22);
            this.textboxStepsprogress.TabIndex = 15;
            // 
            // groupboxCurrentposition
            // 
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
            this.groupboxCurrentposition.Location = new System.Drawing.Point(21, 143);
            this.groupboxCurrentposition.Margin = new System.Windows.Forms.Padding(4);
            this.groupboxCurrentposition.Name = "groupboxCurrentposition";
            this.groupboxCurrentposition.Padding = new System.Windows.Forms.Padding(4);
            this.groupboxCurrentposition.Size = new System.Drawing.Size(445, 85);
            this.groupboxCurrentposition.TabIndex = 6;
            this.groupboxCurrentposition.TabStop = false;
            this.groupboxCurrentposition.Text = "Current percepts";
            // 
            // textboxCurrentsquare
            // 
            this.textboxCurrentsquare.Location = new System.Drawing.Point(363, 43);
            this.textboxCurrentsquare.Margin = new System.Windows.Forms.Padding(4);
            this.textboxCurrentsquare.Name = "textboxCurrentsquare";
            this.textboxCurrentsquare.ReadOnly = true;
            this.textboxCurrentsquare.Size = new System.Drawing.Size(75, 22);
            this.textboxCurrentsquare.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Current";
            // 
            // textboxUp
            // 
            this.textboxUp.Location = new System.Drawing.Point(275, 43);
            this.textboxUp.Margin = new System.Windows.Forms.Padding(4);
            this.textboxUp.Name = "textboxUp";
            this.textboxUp.ReadOnly = true;
            this.textboxUp.Size = new System.Drawing.Size(80, 22);
            this.textboxUp.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Up";
            // 
            // textboxDown
            // 
            this.textboxDown.Location = new System.Drawing.Point(187, 43);
            this.textboxDown.Margin = new System.Windows.Forms.Padding(4);
            this.textboxDown.Name = "textboxDown";
            this.textboxDown.ReadOnly = true;
            this.textboxDown.Size = new System.Drawing.Size(80, 22);
            this.textboxDown.TabIndex = 3;
            // 
            // textboxRight
            // 
            this.textboxRight.Location = new System.Drawing.Point(99, 43);
            this.textboxRight.Margin = new System.Windows.Forms.Padding(4);
            this.textboxRight.Name = "textboxRight";
            this.textboxRight.ReadOnly = true;
            this.textboxRight.Size = new System.Drawing.Size(80, 22);
            this.textboxRight.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Right";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Down";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Left";
            // 
            // textboxLeft
            // 
            this.textboxLeft.Location = new System.Drawing.Point(11, 43);
            this.textboxLeft.Margin = new System.Windows.Forms.Padding(4);
            this.textboxLeft.Name = "textboxLeft";
            this.textboxLeft.ReadOnly = true;
            this.textboxLeft.Size = new System.Drawing.Size(80, 22);
            this.textboxLeft.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(36, 17);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 17);
            this.label19.TabIndex = 20;
            this.label19.Text = "Ɛ";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(296, 18);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(49, 17);
            this.label20.TabIndex = 14;
            this.label20.Text = "Step #";
            // 
            // textboxEprogress
            // 
            this.textboxEprogress.Location = new System.Drawing.Point(33, 37);
            this.textboxEprogress.Margin = new System.Windows.Forms.Padding(4);
            this.textboxEprogress.Name = "textboxEprogress";
            this.textboxEprogress.ReadOnly = true;
            this.textboxEprogress.Size = new System.Drawing.Size(79, 22);
            this.textboxEprogress.TabIndex = 17;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(121, 17);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(16, 17);
            this.label22.TabIndex = 20;
            this.label22.Text = "η";
            // 
            // textboxYprogress
            // 
            this.textboxYprogress.Location = new System.Drawing.Point(206, 37);
            this.textboxYprogress.Margin = new System.Windows.Forms.Padding(4);
            this.textboxYprogress.Name = "textboxYprogress";
            this.textboxYprogress.ReadOnly = true;
            this.textboxYprogress.Size = new System.Drawing.Size(79, 22);
            this.textboxYprogress.TabIndex = 13;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.BackgroundImage = global::ReinforcementLearning.Properties.Resources.fry_squinting_small;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox4.Location = new System.Drawing.Point(195, 13);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 52);
            this.pictureBox4.TabIndex = 61;
            this.pictureBox4.TabStop = false;
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
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(38, 932);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(25, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox17
            // 
            this.pictureBox17.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox17.Image")));
            this.pictureBox17.Location = new System.Drawing.Point(914, 998);
            this.pictureBox17.Name = "pictureBox17";
            this.pictureBox17.Size = new System.Drawing.Size(25, 30);
            this.pictureBox17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox17.TabIndex = 42;
            this.pictureBox17.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(997, 993);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(29, 41);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2040, 1055);
            this.Controls.Add(this.groupboxCountdown);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox12);
            this.Controls.Add(this.pictureBox13);
            this.Controls.Add(this.pictureBox24);
            this.Controls.Add(this.pictureBox26);
            this.Controls.Add(this.pictureBox27);
            this.Controls.Add(this.pictureBox10);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.pictureBox16);
            this.Controls.Add(this.pictureBox18);
            this.Controls.Add(this.pictureBox19);
            this.Controls.Add(this.pictureBox20);
            this.Controls.Add(this.pictureBox21);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupboxStatusmessage);
            this.Controls.Add(this.groupboxHistory);
            this.Controls.Add(this.groupboxQmatrix);
            this.Controls.Add(this.groupboxSessionprogress);
            this.Controls.Add(this.groupboxAlgorithmprogress);
            this.Controls.Add(this.groupboxConfiguration);
            this.Controls.Add(this.groupboxInitialsettings);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox17);
            this.Controls.Add(this.pictureBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.groupboxInitialsettings.ResumeLayout(false);
            this.groupboxInitialsettings.PerformLayout();
            this.groupboxRewards.ResumeLayout(false);
            this.groupboxRewards.PerformLayout();
            this.groupboxQmatrix.ResumeLayout(false);
            this.groupboxQmatrix.PerformLayout();
            this.groupboxQmatrixselect.ResumeLayout(false);
            this.groupboxQmatrixselect.PerformLayout();
            this.groupboxQmatrixview.ResumeLayout(false);
            this.groupboxQmatrixview.PerformLayout();
            this.groupboxHistory.ResumeLayout(false);
            this.groupboxAlgorithmprogress.ResumeLayout(false);
            this.groupboxAlgorithmprogress.PerformLayout();
            this.groupboxCountdown.ResumeLayout(false);
            this.groupboxCountdown.PerformLayout();
            this.groupboxConfiguration.ResumeLayout(false);
            this.groupboxConfiguration.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupboxStatusmessage.ResumeLayout(false);
            this.groupboxSessionprogress.ResumeLayout(false);
            this.groupboxSessionprogress.PerformLayout();
            this.groupboxCans.ResumeLayout(false);
            this.groupboxCans.PerformLayout();
            this.groupboxRewarddata.ResumeLayout(false);
            this.groupboxRewarddata.PerformLayout();
            this.groupboxCurrentposition.ResumeLayout(false);
            this.groupboxCurrentposition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PictureBox pictureBox1;
        private Button buttonRestart;
        private GroupBox groupboxCurrentposition;
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
        private ComboBox comboboxEpisode;
        private GroupBox groupboxInitialsettings;
        private TextBox textboxInitialY;
        private TextBox textboxInitialEpsilon;
        private Label label11;
        private Label label10;
        private Label label8;
        private TextBox textboxInitialNumberofepisodes;
        private TextBox textboxInitialNumberofsteps;
        private Label label9;
        private ComboBox comboboxSteps;
        private ComboBox comboboxN;
        private ComboBox comboboxY;
        private GroupBox groupboxConfiguration;
        private ComboBox comboboxAdvancesteps;
        private ComboBox comboboxAdvanceepisodes;
        private GroupBox groupboxAlgorithmprogress;
        private GroupBox groupboxSessionprogress;
        private TextBox textboxYprogress;
        private TextBox textboxEprogress;
        private Label label18;
        private TextBox textboxEpisodesprogress;
        private TextBox textboxStepsprogress;
        private Label label20;
        private TextBox textboxInitialNinitial;
        private Label label21;
        private Label label23;
        private TextBox textboxNprogress;
        private Label label19;
        private Label label22;
        private ComboBox comboboxQmatrixselect;
        private TextBox textboxQmatrixcurrent;
        private Label label17;
        private TextBox textboxQmatrixup;
        private Label label24;
        private TextBox textboxQmatrixdown;
        private TextBox textboxQmatrixright;
        private Label label25;
        private Label label26;
        private Label label27;
        private TextBox textboxQmatrixleft;
        private GroupBox groupboxQmatrix;
        private TextBox textboxInitialBeerreward;
        private Label label30;
        private Label label29;
        private TextBox textboxInitialEmptysquare;
        private TextBox textboxInitialWallpunishment;
        private Label label28;
        private ComboBox comboboxBeer;
        private ComboBox comboboxEmptysquare;
        private ComboBox comboboxWallpunishment;
        private ComboBox comboboxE;
        private ComboBox comboboxHistoryepisode;
        private GroupBox groupboxHistory;
        private ComboBox comboboxHistorystep;
        private GroupBox groupboxStatusmessage;
        private RichTextBox textboxStatus;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox5;
        private PictureBox pictureBox8;
        private PictureBox pictureBox9;
        private PictureBox pictureBox16;
        private PictureBox pictureBox17;
        private PictureBox pictureBox18;
        private PictureBox pictureBox19;
        private PictureBox pictureBox20;
        private PictureBox pictureBox21;
        private PictureBox pictureBox10;
        private PictureBox pictureBox11;
        private PictureBox pictureBox24;
        private PictureBox pictureBox26;
        private PictureBox pictureBox27;
        private PictureBox pictureBox12;
        private PictureBox pictureBox13;
        private PictureBox pictureBox6;
        private Label label36;
        private TextBox textboxCansremaining;
        private TextBox textboxCanscollected;
        private GroupBox groupboxCans;
        private Label label37;
        private GroupBox groupboxRewarddata;
        private Label label38;
        private TextBox textboxRewardtotal;
        private TextBox textboxRewardepisode;
        private Label label39;
        private GroupBox groupboxQmatrixview;
        private GroupBox groupboxQmatrixselect;
        private Label label35;
        private Label label40;
        private ComboBox comboboxCurrentsquare;
        private Label label41;
        private ComboBox comboboxUp;
        private Label label42;
        private ComboBox comboboxDown;
        private Label label43;
        private ComboBox comboboxRight;
        private ComboBox comboboxLeft;
        private Button button10;
        private GroupBox groupboxRewards;
        private Label label44;
        private TextBox textboxRewardssuccessmove;
        private Label label32;
        private Label label7;
        private Label label31;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label34;
        private Label label33;
        private GroupBox groupBox1;
        private Label label45;
        private ComboBox comboboxMovedwithoutwall;
        private Label label16;
        private Label label15;
        private Label label6;
        private TextBox textboxQmatrixentries;
        private Label label46;
        private ComboBox comboboxDelayms;
        private Button buttonAdvancestepsdropdown;
        private PictureBox pictureBox7;
        private GroupBox groupboxCountdown;
        private TextBox textboxCountdown;
        private Label label48;
        private TextBox textboxProgresssteps;
        private Label label47;
        private Button buttonStop;
        private PictureBox pictureBox4;
    }
}

