namespace nurturing
{
    partial class character_select
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
            Label title_label;
            name_textBox = new TextBox();
            status_label = new Label();
            pictureBox1 = new PictureBox();
            name_label = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            Sum_radioButton = new RadioButton();
            FlameReaver_radioButton = new RadioButton();
            Pollux_radioButton = new RadioButton();
            select_btn = new Button();
            label1 = new Label();
            character_label = new Label();
            statuload_button = new Button();
            title_label = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // title_label
            // 
            title_label.BackColor = Color.Transparent;
            title_label.Font = new Font("HGS創英角ﾎﾟｯﾌﾟ体", 30F, FontStyle.Regular, GraphicsUnit.Point, 128);
            title_label.ForeColor = Color.White;
            title_label.Location = new Point(12, 9);
            title_label.Name = "title_label";
            title_label.Size = new Size(776, 62);
            title_label.TabIndex = 0;
            title_label.Text = "壊滅スターレイル";
            title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // name_textBox
            // 
            name_textBox.Font = new Font("HGS創英角ﾎﾟｯﾌﾟ体", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            name_textBox.Location = new Point(12, 97);
            name_textBox.Name = "name_textBox";
            name_textBox.PlaceholderText = "名前を入力";
            name_textBox.Size = new Size(210, 22);
            name_textBox.TabIndex = 1;
            // 
            // status_label
            // 
            status_label.BackColor = Color.Transparent;
            status_label.Font = new Font("HGP創英角ﾎﾟｯﾌﾟ体", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            status_label.ForeColor = Color.White;
            status_label.Location = new Point(580, 71);
            status_label.Name = "status_label";
            status_label.Size = new Size(208, 58);
            status_label.TabIndex = 2;
            status_label.Text = "ステータス";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.サム;
            pictureBox1.Location = new Point(70, 150);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.BackColor = Color.Transparent;
            name_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 9F, FontStyle.Underline, GraphicsUnit.Point, 128);
            name_label.ForeColor = Color.Black;
            name_label.Location = new Point(12, 74);
            name_label.Name = "name_label";
            name_label.Size = new Size(87, 15);
            name_label.TabIndex = 4;
            name_label.Text = "プレイヤー";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.フレイムスティーラー;
            pictureBox2.Location = new Point(330, 150);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 200);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.ボリュクス;
            pictureBox3.Location = new Point(580, 150);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(150, 200);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // Sum_radioButton
            // 
            Sum_radioButton.BackColor = SystemColors.ControlText;
            Sum_radioButton.ForeColor = Color.White;
            Sum_radioButton.Location = new Point(70, 356);
            Sum_radioButton.Name = "Sum_radioButton";
            Sum_radioButton.Size = new Size(150, 26);
            Sum_radioButton.TabIndex = 8;
            Sum_radioButton.TabStop = true;
            Sum_radioButton.Text = "「星核ハンター」サム";
            Sum_radioButton.UseVisualStyleBackColor = false;
            Sum_radioButton.CheckedChanged += radioButton_CheckedChanged;
            // 
            // FlameReaver_radioButton
            // 
            FlameReaver_radioButton.BackColor = SystemColors.ControlText;
            FlameReaver_radioButton.ForeColor = Color.White;
            FlameReaver_radioButton.Location = new Point(330, 356);
            FlameReaver_radioButton.Name = "FlameReaver_radioButton";
            FlameReaver_radioButton.Size = new Size(150, 26);
            FlameReaver_radioButton.TabIndex = 9;
            FlameReaver_radioButton.TabStop = true;
            FlameReaver_radioButton.Text = "フレイムスティーラー";
            FlameReaver_radioButton.UseVisualStyleBackColor = false;
            FlameReaver_radioButton.CheckedChanged += radioButton_CheckedChanged;
            // 
            // Pollux_radioButton
            // 
            Pollux_radioButton.BackColor = SystemColors.ControlText;
            Pollux_radioButton.ForeColor = Color.White;
            Pollux_radioButton.Location = new Point(580, 356);
            Pollux_radioButton.Name = "Pollux_radioButton";
            Pollux_radioButton.Size = new Size(150, 26);
            Pollux_radioButton.TabIndex = 10;
            Pollux_radioButton.TabStop = true;
            Pollux_radioButton.Text = "ボリュクス";
            Pollux_radioButton.UseVisualStyleBackColor = false;
            Pollux_radioButton.CheckedChanged += radioButton_CheckedChanged;
            // 
            // select_btn
            // 
            select_btn.Location = new Point(330, 401);
            select_btn.Name = "select_btn";
            select_btn.Size = new Size(150, 37);
            select_btn.TabIndex = 11;
            select_btn.Text = "選択";
            select_btn.UseVisualStyleBackColor = true;
            select_btn.Click += select_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(344, 113);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 12;
            // 
            // character_label
            // 
            character_label.BackColor = Color.Transparent;
            character_label.Font = new Font("HGP創英角ﾎﾟｯﾌﾟ体", 9F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 128);
            character_label.ForeColor = Color.White;
            character_label.Location = new Point(330, 114);
            character_label.Name = "character_label";
            character_label.Size = new Size(150, 19);
            character_label.TabIndex = 13;
            character_label.Text = "キャラクター選択";
            character_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statuload_button
            // 
            statuload_button.Location = new Point(624, 6);
            statuload_button.Name = "statuload_button";
            statuload_button.Size = new Size(164, 62);
            statuload_button.TabIndex = 14;
            statuload_button.Text = "育成データをロードする";
            statuload_button.UseVisualStyleBackColor = true;
            statuload_button.Click += statuload_button_Click;
            // 
            // character_select
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.サーシス;
            ClientSize = new Size(800, 450);
            Controls.Add(statuload_button);
            Controls.Add(character_label);
            Controls.Add(label1);
            Controls.Add(select_btn);
            Controls.Add(Pollux_radioButton);
            Controls.Add(FlameReaver_radioButton);
            Controls.Add(Sum_radioButton);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(name_label);
            Controls.Add(pictureBox1);
            Controls.Add(status_label);
            Controls.Add(name_textBox);
            Controls.Add(title_label);
            Name = "character_select";
            Text = "character_select";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title_label;
        private TextBox name_textBox;
        private Label status_label;
        private PictureBox pictureBox1;
        private Label name_label;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private RadioButton Sum_radioButton;
        private RadioButton FlameReaver_radioButton;
        private RadioButton Pollux_radioButton;
        private Button select_btn;
        private Label label1;
        private Label character_label;
        private Button statuload_button;
    }
}
