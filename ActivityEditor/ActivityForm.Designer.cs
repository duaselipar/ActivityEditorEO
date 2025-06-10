namespace ActivityEditor
{
    partial class ActivityForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActivityForm));
            tabControl1 = new TabControl();
            tbcfg = new TabPage();
            groupBox3 = new GroupBox();
            linkLabel2 = new LinkLabel();
            linkLabel1 = new LinkLabel();
            label56 = new Label();
            Note = new GroupBox();
            label55 = new Label();
            button1 = new Button();
            groupBox2 = new GroupBox();
            btnpe = new Button();
            btnacn = new Button();
            txtpe = new TextBox();
            txtacn = new TextBox();
            label7 = new Label();
            label6 = new Label();
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtdb = new TextBox();
            txtpass = new TextBox();
            txtuser = new TextBox();
            txtport = new TextBox();
            txthost = new TextBox();
            tbmain = new TabPage();
            btnsv = new Button();
            txtts = new TextBox();
            label54 = new Label();
            tab = new TabControl();
            tabpe = new TabPage();
            txtpeuld = new TextBox();
            rtxtped3 = new RichTextBox();
            txtpedt3 = new TextBox();
            rtxtped2 = new RichTextBox();
            txtpedt2 = new TextBox();
            rtxtped1 = new RichTextBox();
            txtpedt1 = new TextBox();
            txtper = new TextBox();
            txtpert = new TextBox();
            txtpeactivityname = new TextBox();
            txtpescript = new TextBox();
            txtpeweb = new TextBox();
            txtpestatus = new TextBox();
            label21 = new Label();
            label19 = new Label();
            label20 = new Label();
            label17 = new Label();
            label18 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            tabacn = new TabPage();
            txtacntt = new TextBox();
            txtacnmet = new TextBox();
            label53 = new Label();
            label52 = new Label();
            label51 = new Label();
            txtacnd = new TextBox();
            txtacnhn = new TextBox();
            label50 = new Label();
            label49 = new Label();
            label48 = new Label();
            label47 = new Label();
            label46 = new Label();
            txtacntd = new TextBox();
            txtacnits = new TextBox();
            txtacnbb = new TextBox();
            txtacnci = new TextBox();
            label45 = new Label();
            label44 = new Label();
            label43 = new Label();
            label42 = new Label();
            label41 = new Label();
            label40 = new Label();
            label39 = new Label();
            label38 = new Label();
            label37 = new Label();
            label36 = new Label();
            label35 = new Label();
            label34 = new Label();
            label33 = new Label();
            label32 = new Label();
            label31 = new Label();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            txtacnfp = new TextBox();
            txtacnvb = new TextBox();
            txtacntstrht = new TextBox();
            txtacntstr = new TextBox();
            txtacntal = new TextBox();
            txtacnar = new TextBox();
            txtacnt = new TextBox();
            txtacnmn = new TextBox();
            txtacnmb = new TextBox();
            txtacnb = new TextBox();
            txtacnmi = new TextBox();
            txtacnm = new TextBox();
            txtacnai = new TextBox();
            txtacnat = new TextBox();
            txtacnpi = new TextBox();
            txtacnlt = new TextBox();
            txtacnct = new TextBox();
            txtacnet = new TextBox();
            txtacnbt = new TextBox();
            txtacnw = new TextBox();
            txtacned = new TextBox();
            txtacnbd = new TextBox();
            txtacni = new TextBox();
            txtacnp = new TextBox();
            label8 = new Label();
            dgvEvents = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            groupBoxDetails = new GroupBox();
            txtSearch = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            tabControl1.SuspendLayout();
            tbcfg.SuspendLayout();
            groupBox3.SuspendLayout();
            Note.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tbmain.SuspendLayout();
            tab.SuspendLayout();
            tabpe.SuspendLayout();
            tabacn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbcfg);
            tabControl1.Controls.Add(tbmain);
            tabControl1.Location = new Point(2, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(983, 805);
            tabControl1.TabIndex = 0;
            // 
            // tbcfg
            // 
            tbcfg.Controls.Add(groupBox3);
            tbcfg.Controls.Add(Note);
            tbcfg.Controls.Add(button1);
            tbcfg.Controls.Add(groupBox2);
            tbcfg.Controls.Add(groupBox1);
            tbcfg.Location = new Point(4, 24);
            tbcfg.Name = "tbcfg";
            tbcfg.Padding = new Padding(3);
            tbcfg.Size = new Size(975, 777);
            tbcfg.TabIndex = 0;
            tbcfg.Text = "Configuration";
            tbcfg.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(linkLabel2);
            groupBox3.Controls.Add(linkLabel1);
            groupBox3.Controls.Add(label56);
            groupBox3.Location = new Point(6, 413);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(963, 160);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "About";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(368, 119);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(63, 15);
            linkLabel2.TabIndex = 2;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "DuaSelipar";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(293, 104);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(74, 15);
            linkLabel1.TabIndex = 1;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Source Code";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label56
            // 
            label56.AutoSize = true;
            label56.Location = new Point(29, 29);
            label56.Name = "label56";
            label56.Size = new Size(627, 120);
            label56.TabIndex = 0;
            label56.Text = resources.GetString("label56.Text");
            // 
            // Note
            // 
            Note.Controls.Add(label55);
            Note.Location = new Point(6, 251);
            Note.Name = "Note";
            Note.Size = new Size(963, 70);
            Note.TabIndex = 3;
            Note.TabStop = false;
            Note.Text = "Note";
            // 
            // label55
            // 
            label55.AutoSize = true;
            label55.Location = new Point(25, 31);
            label55.Name = "label55";
            label55.Size = new Size(817, 15);
            label55.TabIndex = 0;
            label55.Text = "To modify the task name or reward details, please edit them in taskitem.dat. Changes made here will not update the names or rewards shown in the client.\r\n";
            // 
            // button1
            // 
            button1.Location = new Point(6, 327);
            button1.Name = "button1";
            button1.Size = new Size(963, 80);
            button1.TabIndex = 2;
            button1.Text = "Load And Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnpe);
            groupBox2.Controls.Add(btnacn);
            groupBox2.Controls.Add(txtpe);
            groupBox2.Controls.Add(txtacn);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new Point(6, 120);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(963, 125);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "File Config";
            // 
            // btnpe
            // 
            btnpe.Location = new Point(797, 69);
            btnpe.Name = "btnpe";
            btnpe.Size = new Size(75, 23);
            btnpe.TabIndex = 5;
            btnpe.Text = "Select";
            btnpe.UseVisualStyleBackColor = true;
            btnpe.Click += btnpe_Click;
            // 
            // btnacn
            // 
            btnacn.Location = new Point(797, 35);
            btnacn.Name = "btnacn";
            btnacn.Size = new Size(75, 23);
            btnacn.TabIndex = 4;
            btnacn.Text = "Select";
            btnacn.UseVisualStyleBackColor = true;
            btnacn.Click += btnacn_Click;
            // 
            // txtpe
            // 
            txtpe.Location = new Point(198, 70);
            txtpe.Name = "txtpe";
            txtpe.Size = new Size(584, 23);
            txtpe.TabIndex = 3;
            // 
            // txtacn
            // 
            txtacn.Location = new Point(198, 36);
            txtacn.Name = "txtacn";
            txtacn.Size = new Size(584, 23);
            txtacn.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(77, 73);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 1;
            label7.Text = "Playexplain.ini Path :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 39);
            label6.Name = "label6";
            label6.Size = new Size(167, 15);
            label6.TabIndex = 0;
            label6.Text = "ActivityCalendarNew.ini Path :";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtdb);
            groupBox1.Controls.Add(txtpass);
            groupBox1.Controls.Add(txtuser);
            groupBox1.Controls.Add(txtport);
            groupBox1.Controls.Add(txthost);
            groupBox1.Location = new Point(6, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(963, 108);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "MySQL Connection";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(594, 34);
            label5.Name = "label5";
            label5.Size = new Size(61, 15);
            label5.TabIndex = 9;
            label5.Text = "Database :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(303, 64);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 8;
            label4.Text = "Password :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 31);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 7;
            label3.Text = "User :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 64);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 6;
            label2.Text = "Port :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 36);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 5;
            label1.Text = "Hostname :";
            // 
            // txtdb
            // 
            txtdb.Location = new Point(661, 30);
            txtdb.Name = "txtdb";
            txtdb.Size = new Size(174, 23);
            txtdb.TabIndex = 4;
            // 
            // txtpass
            // 
            txtpass.Location = new Point(372, 61);
            txtpass.Name = "txtpass";
            txtpass.Size = new Size(174, 23);
            txtpass.TabIndex = 3;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(372, 31);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(174, 23);
            txtuser.TabIndex = 2;
            // 
            // txtport
            // 
            txtport.Location = new Point(94, 60);
            txtport.Name = "txtport";
            txtport.Size = new Size(174, 23);
            txtport.TabIndex = 1;
            // 
            // txthost
            // 
            txthost.Location = new Point(94, 31);
            txthost.Name = "txthost";
            txthost.Size = new Size(174, 23);
            txthost.TabIndex = 0;
            // 
            // tbmain
            // 
            tbmain.Controls.Add(btnsv);
            tbmain.Controls.Add(txtts);
            tbmain.Controls.Add(label54);
            tbmain.Controls.Add(tab);
            tbmain.Controls.Add(label8);
            tbmain.Controls.Add(dgvEvents);
            tbmain.Controls.Add(groupBoxDetails);
            tbmain.Controls.Add(txtSearch);
            tbmain.Location = new Point(4, 24);
            tbmain.Name = "tbmain";
            tbmain.Padding = new Padding(3);
            tbmain.Size = new Size(975, 777);
            tbmain.TabIndex = 1;
            tbmain.Text = "File Setting";
            tbmain.UseVisualStyleBackColor = true;
            // 
            // btnsv
            // 
            btnsv.Location = new Point(812, 693);
            btnsv.Name = "btnsv";
            btnsv.Size = new Size(153, 23);
            btnsv.TabIndex = 7;
            btnsv.Text = "Save All Settings";
            btnsv.UseVisualStyleBackColor = true;
            btnsv.Click += btnsv_Click;
            // 
            // txtts
            // 
            txtts.Location = new Point(532, 694);
            txtts.Name = "txtts";
            txtts.Size = new Size(274, 23);
            txtts.TabIndex = 6;
            // 
            // label54
            // 
            label54.AutoSize = true;
            label54.Location = new Point(403, 697);
            label54.Name = "label54";
            label54.Size = new Size(121, 15);
            label54.TabIndex = 5;
            label54.Text = "Action Trigger Script :";
            // 
            // tab
            // 
            tab.Controls.Add(tabpe);
            tab.Controls.Add(tabacn);
            tab.Location = new Point(399, 10);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(570, 669);
            tab.TabIndex = 4;
            // 
            // tabpe
            // 
            tabpe.Controls.Add(txtpeuld);
            tabpe.Controls.Add(rtxtped3);
            tabpe.Controls.Add(txtpedt3);
            tabpe.Controls.Add(rtxtped2);
            tabpe.Controls.Add(txtpedt2);
            tabpe.Controls.Add(rtxtped1);
            tabpe.Controls.Add(txtpedt1);
            tabpe.Controls.Add(txtper);
            tabpe.Controls.Add(txtpert);
            tabpe.Controls.Add(txtpeactivityname);
            tabpe.Controls.Add(txtpescript);
            tabpe.Controls.Add(txtpeweb);
            tabpe.Controls.Add(txtpestatus);
            tabpe.Controls.Add(label21);
            tabpe.Controls.Add(label19);
            tabpe.Controls.Add(label20);
            tabpe.Controls.Add(label17);
            tabpe.Controls.Add(label18);
            tabpe.Controls.Add(label16);
            tabpe.Controls.Add(label15);
            tabpe.Controls.Add(label14);
            tabpe.Controls.Add(label13);
            tabpe.Controls.Add(label12);
            tabpe.Controls.Add(label11);
            tabpe.Controls.Add(label10);
            tabpe.Controls.Add(label9);
            tabpe.Location = new Point(4, 24);
            tabpe.Name = "tabpe";
            tabpe.Padding = new Padding(3);
            tabpe.Size = new Size(562, 641);
            tabpe.TabIndex = 0;
            tabpe.Text = "PlayExplain.ini";
            tabpe.UseVisualStyleBackColor = true;
            // 
            // txtpeuld
            // 
            txtpeuld.Location = new Point(143, 599);
            txtpeuld.Name = "txtpeuld";
            txtpeuld.Size = new Size(391, 23);
            txtpeuld.TabIndex = 25;
            // 
            // rtxtped3
            // 
            rtxtped3.Location = new Point(143, 497);
            rtxtped3.Name = "rtxtped3";
            rtxtped3.Size = new Size(391, 96);
            rtxtped3.TabIndex = 24;
            rtxtped3.Text = "";
            // 
            // txtpedt3
            // 
            txtpedt3.Location = new Point(143, 468);
            txtpedt3.Name = "txtpedt3";
            txtpedt3.Size = new Size(391, 23);
            txtpedt3.TabIndex = 23;
            // 
            // rtxtped2
            // 
            rtxtped2.Location = new Point(143, 366);
            rtxtped2.Name = "rtxtped2";
            rtxtped2.Size = new Size(391, 96);
            rtxtped2.TabIndex = 22;
            rtxtped2.Text = "";
            // 
            // txtpedt2
            // 
            txtpedt2.Location = new Point(143, 337);
            txtpedt2.Name = "txtpedt2";
            txtpedt2.Size = new Size(391, 23);
            txtpedt2.TabIndex = 21;
            // 
            // rtxtped1
            // 
            rtxtped1.Location = new Point(143, 235);
            rtxtped1.Name = "rtxtped1";
            rtxtped1.Size = new Size(391, 96);
            rtxtped1.TabIndex = 20;
            rtxtped1.Text = "";
            // 
            // txtpedt1
            // 
            txtpedt1.Location = new Point(143, 203);
            txtpedt1.Name = "txtpedt1";
            txtpedt1.Size = new Size(391, 23);
            txtpedt1.TabIndex = 19;
            // 
            // txtper
            // 
            txtper.Location = new Point(143, 170);
            txtper.Name = "txtper";
            txtper.Size = new Size(391, 23);
            txtper.TabIndex = 18;
            // 
            // txtpert
            // 
            txtpert.Location = new Point(143, 139);
            txtpert.Name = "txtpert";
            txtpert.Size = new Size(391, 23);
            txtpert.TabIndex = 17;
            // 
            // txtpeactivityname
            // 
            txtpeactivityname.Location = new Point(143, 108);
            txtpeactivityname.Name = "txtpeactivityname";
            txtpeactivityname.Size = new Size(391, 23);
            txtpeactivityname.TabIndex = 16;
            // 
            // txtpescript
            // 
            txtpescript.Location = new Point(143, 79);
            txtpescript.Name = "txtpescript";
            txtpescript.Size = new Size(391, 23);
            txtpescript.TabIndex = 15;
            // 
            // txtpeweb
            // 
            txtpeweb.Location = new Point(143, 48);
            txtpeweb.Name = "txtpeweb";
            txtpeweb.Size = new Size(391, 23);
            txtpeweb.TabIndex = 14;
            // 
            // txtpestatus
            // 
            txtpestatus.Location = new Point(143, 19);
            txtpestatus.Name = "txtpestatus";
            txtpestatus.Size = new Size(391, 23);
            txtpestatus.TabIndex = 13;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(11, 602);
            label21.Name = "label21";
            label21.Size = new Size(126, 15);
            label21.TabIndex = 12;
            label21.Text = "Use Local Description :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(51, 500);
            label19.Name = "label19";
            label19.Size = new Size(82, 15);
            label19.TabIndex = 11;
            label19.Text = "Description 3 :";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(29, 471);
            label20.Name = "label20";
            label20.Size = new Size(108, 15);
            label20.TabIndex = 10;
            label20.Text = "Description Title 3 :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(49, 369);
            label17.Name = "label17";
            label17.Size = new Size(82, 15);
            label17.TabIndex = 9;
            label17.Text = "Description 2 :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(25, 340);
            label18.Name = "label18";
            label18.Size = new Size(108, 15);
            label18.TabIndex = 8;
            label18.Text = "Description Title 2 :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(51, 238);
            label16.Name = "label16";
            label16.Size = new Size(82, 15);
            label16.TabIndex = 7;
            label16.Text = "Description 1 :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(25, 206);
            label15.Name = "label15";
            label15.Size = new Size(108, 15);
            label15.TabIndex = 6;
            label15.Text = "Description Title 1 :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(81, 173);
            label14.Name = "label14";
            label14.Size = new Size(52, 15);
            label14.TabIndex = 5;
            label14.Text = "Reward :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(55, 142);
            label13.Name = "label13";
            label13.Size = new Size(78, 15);
            label13.TabIndex = 4;
            label13.Text = "Reward Title :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(45, 111);
            label12.Name = "label12";
            label12.Size = new Size(88, 15);
            label12.TabIndex = 3;
            label12.Text = "Activity Name :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(88, 82);
            label11.Name = "label11";
            label11.Size = new Size(43, 15);
            label11.TabIndex = 2;
            label11.Text = "Script :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(76, 51);
            label10.Name = "label10";
            label10.Size = new Size(55, 15);
            label10.TabIndex = 1;
            label10.Text = "Website :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(88, 22);
            label9.Name = "label9";
            label9.Size = new Size(45, 15);
            label9.TabIndex = 0;
            label9.Text = "Status :";
            // 
            // tabacn
            // 
            tabacn.Controls.Add(txtacntt);
            tabacn.Controls.Add(txtacnmet);
            tabacn.Controls.Add(label53);
            tabacn.Controls.Add(label52);
            tabacn.Controls.Add(label51);
            tabacn.Controls.Add(txtacnd);
            tabacn.Controls.Add(txtacnhn);
            tabacn.Controls.Add(label50);
            tabacn.Controls.Add(label49);
            tabacn.Controls.Add(label48);
            tabacn.Controls.Add(label47);
            tabacn.Controls.Add(label46);
            tabacn.Controls.Add(txtacntd);
            tabacn.Controls.Add(txtacnits);
            tabacn.Controls.Add(txtacnbb);
            tabacn.Controls.Add(txtacnci);
            tabacn.Controls.Add(label45);
            tabacn.Controls.Add(label44);
            tabacn.Controls.Add(label43);
            tabacn.Controls.Add(label42);
            tabacn.Controls.Add(label41);
            tabacn.Controls.Add(label40);
            tabacn.Controls.Add(label39);
            tabacn.Controls.Add(label38);
            tabacn.Controls.Add(label37);
            tabacn.Controls.Add(label36);
            tabacn.Controls.Add(label35);
            tabacn.Controls.Add(label34);
            tabacn.Controls.Add(label33);
            tabacn.Controls.Add(label32);
            tabacn.Controls.Add(label31);
            tabacn.Controls.Add(label30);
            tabacn.Controls.Add(label29);
            tabacn.Controls.Add(label28);
            tabacn.Controls.Add(label27);
            tabacn.Controls.Add(label26);
            tabacn.Controls.Add(label25);
            tabacn.Controls.Add(label24);
            tabacn.Controls.Add(label23);
            tabacn.Controls.Add(label22);
            tabacn.Controls.Add(txtacnfp);
            tabacn.Controls.Add(txtacnvb);
            tabacn.Controls.Add(txtacntstrht);
            tabacn.Controls.Add(txtacntstr);
            tabacn.Controls.Add(txtacntal);
            tabacn.Controls.Add(txtacnar);
            tabacn.Controls.Add(txtacnt);
            tabacn.Controls.Add(txtacnmn);
            tabacn.Controls.Add(txtacnmb);
            tabacn.Controls.Add(txtacnb);
            tabacn.Controls.Add(txtacnmi);
            tabacn.Controls.Add(txtacnm);
            tabacn.Controls.Add(txtacnai);
            tabacn.Controls.Add(txtacnat);
            tabacn.Controls.Add(txtacnpi);
            tabacn.Controls.Add(txtacnlt);
            tabacn.Controls.Add(txtacnct);
            tabacn.Controls.Add(txtacnet);
            tabacn.Controls.Add(txtacnbt);
            tabacn.Controls.Add(txtacnw);
            tabacn.Controls.Add(txtacned);
            tabacn.Controls.Add(txtacnbd);
            tabacn.Controls.Add(txtacni);
            tabacn.Controls.Add(txtacnp);
            tabacn.Location = new Point(4, 24);
            tabacn.Name = "tabacn";
            tabacn.Padding = new Padding(3);
            tabacn.Size = new Size(562, 641);
            tabacn.TabIndex = 1;
            tabacn.Text = "ActivityCalendarNew.ini";
            tabacn.UseVisualStyleBackColor = true;
            // 
            // txtacntt
            // 
            txtacntt.Location = new Point(390, 431);
            txtacntt.Name = "txtacntt";
            txtacntt.Size = new Size(140, 23);
            txtacntt.TabIndex = 63;
            // 
            // txtacnmet
            // 
            txtacnmet.Location = new Point(390, 402);
            txtacnmet.Name = "txtacnmet";
            txtacnmet.Size = new Size(140, 23);
            txtacnmet.TabIndex = 62;
            // 
            // label53
            // 
            label53.AutoSize = true;
            label53.Location = new Point(325, 434);
            label53.Name = "label53";
            label53.Size = new Size(57, 15);
            label53.TabIndex = 61;
            label53.Text = "TipTime :";
            // 
            // label52
            // 
            label52.AutoSize = true;
            label52.Location = new Point(295, 407);
            label52.Name = "label52";
            label52.Size = new Size(89, 15);
            label52.TabIndex = 60;
            label52.Text = "MaxEnterTime :";
            // 
            // label51
            // 
            label51.AutoSize = true;
            label51.Location = new Point(344, 378);
            label51.Name = "label51";
            label51.Size = new Size(38, 15);
            label51.TabIndex = 59;
            label51.Text = "Desc :";
            // 
            // txtacnd
            // 
            txtacnd.Location = new Point(390, 373);
            txtacnd.Name = "txtacnd";
            txtacnd.Size = new Size(140, 23);
            txtacnd.TabIndex = 58;
            // 
            // txtacnhn
            // 
            txtacnhn.Location = new Point(388, 344);
            txtacnhn.Name = "txtacnhn";
            txtacnhn.Size = new Size(142, 23);
            txtacnhn.TabIndex = 57;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Location = new Point(304, 349);
            label50.Name = "label50";
            label50.Size = new Size(78, 15);
            label50.TabIndex = 56;
            label50.Text = "HideNormal :";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Location = new Point(309, 318);
            label49.Name = "label49";
            label49.Size = new Size(73, 15);
            label49.TabIndex = 55;
            label49.Text = "TimeDelete :";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Location = new Point(283, 291);
            label48.Name = "label48";
            label48.Size = new Size(101, 15);
            label48.TabIndex = 54;
            label48.Text = "InterfaceToShow :";
            // 
            // label47
            // 
            label47.AutoSize = true;
            label47.Location = new Point(319, 262);
            label47.Name = "label47";
            label47.Size = new Size(65, 15);
            label47.TabIndex = 53;
            label47.Text = "BubbleBG :";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Location = new Point(328, 231);
            label46.Name = "label46";
            label46.Size = new Size(56, 15);
            label46.TabIndex = 52;
            label46.Text = "CheckIn :";
            // 
            // txtacntd
            // 
            txtacntd.Location = new Point(390, 315);
            txtacntd.Name = "txtacntd";
            txtacntd.Size = new Size(142, 23);
            txtacntd.TabIndex = 51;
            // 
            // txtacnits
            // 
            txtacnits.Location = new Point(390, 286);
            txtacnits.Name = "txtacnits";
            txtacnits.Size = new Size(142, 23);
            txtacnits.TabIndex = 50;
            // 
            // txtacnbb
            // 
            txtacnbb.Location = new Point(390, 257);
            txtacnbb.Name = "txtacnbb";
            txtacnbb.Size = new Size(142, 23);
            txtacnbb.TabIndex = 49;
            // 
            // txtacnci
            // 
            txtacnci.Location = new Point(390, 228);
            txtacnci.Name = "txtacnci";
            txtacnci.Size = new Size(142, 23);
            txtacnci.TabIndex = 48;
            // 
            // label45
            // 
            label45.AutoSize = true;
            label45.Location = new Point(304, 199);
            label45.Name = "label45";
            label45.Size = new Size(80, 15);
            label45.TabIndex = 47;
            label45.Text = "ForcePriority :";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Location = new Point(319, 170);
            label44.Name = "label44";
            label44.Size = new Size(65, 15);
            label44.TabIndex = 46;
            label44.Text = "VersionBit :";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Location = new Point(312, 141);
            label43.Name = "label43";
            label43.Size = new Size(70, 15);
            label43.TabIndex = 45;
            label43.Text = "TimeStr_ht :";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Location = new Point(328, 112);
            label42.Name = "label42";
            label42.Size = new Size(54, 15);
            label42.TabIndex = 44;
            label42.Text = "TimeStr :";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Location = new Point(296, 83);
            label41.Name = "label41";
            label41.Size = new Size(88, 15);
            label41.TabIndex = 43;
            label41.Text = "TaskActyLabel :";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(302, 54);
            label40.Name = "label40";
            label40.Size = new Size(82, 15);
            label40.TabIndex = 42;
            label40.Text = "Auto_remind :";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Location = new Point(80, 547);
            label39.Name = "label39";
            label39.Size = new Size(40, 15);
            label39.TabIndex = 41;
            label39.Text = "Time :";
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(72, 518);
            label38.Name = "label38";
            label38.Size = new Size(49, 15);
            label38.TabIndex = 40;
            label38.Text = "Month :";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Location = new Point(26, 489);
            label37.Name = "label37";
            label37.Size = new Size(94, 15);
            label37.TabIndex = 39;
            label37.Text = "MonthlyButton :";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(70, 460);
            label36.Name = "label36";
            label36.Size = new Size(50, 15);
            label36.TabIndex = 38;
            label36.Text = "Banner :";
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Location = new Point(39, 431);
            label35.Name = "label35";
            label35.Size = new Size(81, 15);
            label35.TabIndex = 37;
            label35.Text = "MonthlyIcon :";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Location = new Point(62, 402);
            label34.Name = "label34";
            label34.Size = new Size(58, 15);
            label34.TabIndex = 36;
            label34.Text = "Monthly :";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(45, 373);
            label33.Name = "label33";
            label33.Size = new Size(76, 15);
            label33.TabIndex = 35;
            label33.Text = "ActivityIcon :";
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(45, 344);
            label32.Name = "label32";
            label32.Size = new Size(78, 15);
            label32.TabIndex = 34;
            label32.Text = "ActivityType :";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(62, 315);
            label31.Name = "label31";
            label31.Size = new Size(61, 15);
            label31.TabIndex = 33;
            label31.Text = "PictureID :";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Location = new Point(51, 286);
            label30.Name = "label30";
            label30.Size = new Size(72, 15);
            label30.TabIndex = 32;
            label30.Text = "LimitTimes :";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(26, 257);
            label29.Name = "label29";
            label29.Size = new Size(97, 15);
            label29.TabIndex = 31;
            label29.Text = "CompleteTimes :";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(63, 228);
            label28.Name = "label28";
            label28.Size = new Size(60, 15);
            label28.TabIndex = 30;
            label28.Text = "EndTime :";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(53, 199);
            label27.Name = "label27";
            label27.Size = new Size(70, 15);
            label27.TabIndex = 29;
            label27.Text = "BeginTime :";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(81, 170);
            label26.Name = "label26";
            label26.Size = new Size(42, 15);
            label26.TabIndex = 28;
            label26.Text = "Week :";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(66, 141);
            label25.Name = "label25";
            label25.Size = new Size(57, 15);
            label25.TabIndex = 27;
            label25.Text = "EndDate :";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(56, 112);
            label24.Name = "label24";
            label24.Size = new Size(67, 15);
            label24.TabIndex = 26;
            label24.Text = "BeginDate :";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(57, 83);
            label23.Name = "label23";
            label23.Size = new Size(66, 15);
            label23.TabIndex = 25;
            label23.Text = "Important :";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(72, 54);
            label22.Name = "label22";
            label22.Size = new Size(51, 15);
            label22.TabIndex = 24;
            label22.Text = "Priority :";
            // 
            // txtacnfp
            // 
            txtacnfp.Location = new Point(390, 196);
            txtacnfp.Name = "txtacnfp";
            txtacnfp.Size = new Size(142, 23);
            txtacnfp.TabIndex = 23;
            // 
            // txtacnvb
            // 
            txtacnvb.Location = new Point(390, 167);
            txtacnvb.Name = "txtacnvb";
            txtacnvb.Size = new Size(142, 23);
            txtacnvb.TabIndex = 22;
            // 
            // txtacntstrht
            // 
            txtacntstrht.Location = new Point(390, 138);
            txtacntstrht.Name = "txtacntstrht";
            txtacntstrht.Size = new Size(142, 23);
            txtacntstrht.TabIndex = 21;
            // 
            // txtacntstr
            // 
            txtacntstr.Location = new Point(390, 109);
            txtacntstr.Name = "txtacntstr";
            txtacntstr.Size = new Size(142, 23);
            txtacntstr.TabIndex = 20;
            // 
            // txtacntal
            // 
            txtacntal.Location = new Point(390, 80);
            txtacntal.Name = "txtacntal";
            txtacntal.Size = new Size(142, 23);
            txtacntal.TabIndex = 19;
            // 
            // txtacnar
            // 
            txtacnar.Location = new Point(390, 51);
            txtacnar.Name = "txtacnar";
            txtacnar.Size = new Size(142, 23);
            txtacnar.TabIndex = 18;
            // 
            // txtacnt
            // 
            txtacnt.Location = new Point(129, 544);
            txtacnt.Name = "txtacnt";
            txtacnt.Size = new Size(142, 23);
            txtacnt.TabIndex = 17;
            // 
            // txtacnmn
            // 
            txtacnmn.Location = new Point(129, 515);
            txtacnmn.Name = "txtacnmn";
            txtacnmn.Size = new Size(142, 23);
            txtacnmn.TabIndex = 16;
            // 
            // txtacnmb
            // 
            txtacnmb.Location = new Point(129, 486);
            txtacnmb.Name = "txtacnmb";
            txtacnmb.Size = new Size(142, 23);
            txtacnmb.TabIndex = 15;
            // 
            // txtacnb
            // 
            txtacnb.Location = new Point(129, 457);
            txtacnb.Name = "txtacnb";
            txtacnb.Size = new Size(142, 23);
            txtacnb.TabIndex = 14;
            // 
            // txtacnmi
            // 
            txtacnmi.Location = new Point(129, 428);
            txtacnmi.Name = "txtacnmi";
            txtacnmi.Size = new Size(142, 23);
            txtacnmi.TabIndex = 13;
            // 
            // txtacnm
            // 
            txtacnm.Location = new Point(129, 399);
            txtacnm.Name = "txtacnm";
            txtacnm.Size = new Size(142, 23);
            txtacnm.TabIndex = 12;
            // 
            // txtacnai
            // 
            txtacnai.Location = new Point(129, 370);
            txtacnai.Name = "txtacnai";
            txtacnai.Size = new Size(142, 23);
            txtacnai.TabIndex = 11;
            // 
            // txtacnat
            // 
            txtacnat.Location = new Point(129, 341);
            txtacnat.Name = "txtacnat";
            txtacnat.Size = new Size(142, 23);
            txtacnat.TabIndex = 10;
            // 
            // txtacnpi
            // 
            txtacnpi.Location = new Point(129, 312);
            txtacnpi.Name = "txtacnpi";
            txtacnpi.Size = new Size(142, 23);
            txtacnpi.TabIndex = 9;
            // 
            // txtacnlt
            // 
            txtacnlt.Location = new Point(129, 283);
            txtacnlt.Name = "txtacnlt";
            txtacnlt.Size = new Size(142, 23);
            txtacnlt.TabIndex = 8;
            // 
            // txtacnct
            // 
            txtacnct.Location = new Point(129, 254);
            txtacnct.Name = "txtacnct";
            txtacnct.Size = new Size(142, 23);
            txtacnct.TabIndex = 7;
            // 
            // txtacnet
            // 
            txtacnet.Location = new Point(129, 225);
            txtacnet.Name = "txtacnet";
            txtacnet.Size = new Size(142, 23);
            txtacnet.TabIndex = 6;
            // 
            // txtacnbt
            // 
            txtacnbt.Location = new Point(129, 196);
            txtacnbt.Name = "txtacnbt";
            txtacnbt.Size = new Size(142, 23);
            txtacnbt.TabIndex = 5;
            // 
            // txtacnw
            // 
            txtacnw.Location = new Point(129, 167);
            txtacnw.Name = "txtacnw";
            txtacnw.Size = new Size(142, 23);
            txtacnw.TabIndex = 4;
            // 
            // txtacned
            // 
            txtacned.Location = new Point(129, 138);
            txtacned.Name = "txtacned";
            txtacned.Size = new Size(142, 23);
            txtacned.TabIndex = 3;
            // 
            // txtacnbd
            // 
            txtacnbd.Location = new Point(129, 109);
            txtacnbd.Name = "txtacnbd";
            txtacnbd.Size = new Size(142, 23);
            txtacnbd.TabIndex = 2;
            // 
            // txtacni
            // 
            txtacni.Location = new Point(129, 80);
            txtacni.Name = "txtacni";
            txtacni.Size = new Size(142, 23);
            txtacni.TabIndex = 1;
            // 
            // txtacnp
            // 
            txtacnp.Location = new Point(129, 51);
            txtacnp.Name = "txtacnp";
            txtacnp.Size = new Size(142, 23);
            txtacnp.TabIndex = 0;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(10, 744);
            label8.Name = "label8";
            label8.Size = new Size(48, 15);
            label8.TabIndex = 3;
            label8.Text = "Search :";
            // 
            // dgvEvents
            // 
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dgvEvents.Location = new Point(10, 10);
            dgvEvents.MultiSelect = false;
            dgvEvents.Name = "dgvEvents";
            dgvEvents.ReadOnly = true;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.Size = new Size(370, 721);
            dgvEvents.TabIndex = 0;
            dgvEvents.CellContentClick += dgvEvents_CellContentClick;
            dgvEvents.SelectionChanged += dgvEvents_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Event ID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Task Name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Trigger Scripts";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // groupBoxDetails
            // 
            groupBoxDetails.Location = new Point(0, 0);
            groupBoxDetails.Name = "groupBoxDetails";
            groupBoxDetails.Size = new Size(200, 100);
            groupBoxDetails.TabIndex = 1;
            groupBoxDetails.TabStop = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(64, 741);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(316, 23);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // ActivityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 817);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "ActivityForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Activity Editor By DuaSelipar";
            tabControl1.ResumeLayout(false);
            tbcfg.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            Note.ResumeLayout(false);
            Note.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbmain.ResumeLayout(false);
            tbmain.PerformLayout();
            tab.ResumeLayout(false);
            tabpe.ResumeLayout(false);
            tabpe.PerformLayout();
            tabacn.ResumeLayout(false);
            tabacn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbcfg;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TabPage tbmain;
        private Button button1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtdb;
        private TextBox txtpass;
        private TextBox txtuser;
        private TextBox txtport;
        private TextBox txthost;
        private TextBox txtpe;
        private TextBox txtacn;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnpe;
        private Button btnacn;

        private DataGridView dgvEvents;
        private GroupBox groupBoxDetails;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Label label8;
        private TextBox txtSearch;
        private TabControl tab;
        private TabPage tabpe;
        private TabPage tabacn;
        private Label label9;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label15;
        private Label label14;
        private RichTextBox rtxtped1;
        private TextBox txtpedt1;
        private TextBox txtper;
        private TextBox txtpert;
        private TextBox txtpeactivityname;
        private TextBox txtpescript;
        private TextBox txtpeweb;
        private TextBox txtpestatus;
        private Label label21;
        private Label label19;
        private Label label20;
        private Label label17;
        private Label label18;
        private Label label16;
        private RichTextBox rtxtped2;
        private TextBox txtpedt2;
        private TextBox txtpeuld;
        private RichTextBox rtxtped3;
        private TextBox txtpedt3;
        private TextBox txtacnlt;
        private TextBox txtacnct;
        private TextBox txtacnet;
        private TextBox txtacnbt;
        private TextBox txtacnw;
        private TextBox txtacned;
        private TextBox txtacnbd;
        private TextBox txtacni;
        private TextBox txtacnp;
        private TextBox txtacntal;
        private TextBox txtacnar;
        private TextBox txtacnt;
        private TextBox txtacnmn;
        private TextBox txtacnmb;
        private TextBox txtacnb;
        private TextBox txtacnmi;
        private TextBox txtacnm;
        private TextBox txtacnai;
        private TextBox txtacnat;
        private TextBox txtacnpi;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private TextBox txtacnfp;
        private TextBox txtacnvb;
        private TextBox txtacntstrht;
        private TextBox txtacntstr;
        private Label label40;
        private Label label39;
        private Label label38;
        private Label label37;
        private Label label36;
        private Label label35;
        private Label label34;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label44;
        private Label label43;
        private Label label42;
        private Label label41;
        private Label label45;
        private Label label49;
        private Label label48;
        private Label label47;
        private Label label46;
        private TextBox txtacntd;
        private TextBox txtacnits;
        private TextBox txtacnbb;
        private TextBox txtacnci;
        private TextBox txtacntt;
        private TextBox txtacnmet;
        private Label label53;
        private Label label52;
        private Label label51;
        private TextBox txtacnd;
        private TextBox txtacnhn;
        private Label label50;
        private TextBox txtts;
        private Label label54;
        private Button btnsv;
        private GroupBox Note;
        private Label label55;
        private GroupBox groupBox3;
        private Label label56;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}
