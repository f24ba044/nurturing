namespace nurturing
{
    partial class FormTraining
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
            Label title_label;
            csv_button = new Button();
            character_pictureBox = new PictureBox();
            name_label = new Label();
            xp_button = new Button();
            status_label = new Label();
            xp_label = new Label();
            battle_button = new Button();
            critical_label = new Label();
            title_label = new Label();
            ((System.ComponentModel.ISupportInitialize)character_pictureBox).BeginInit();
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
            title_label.TabIndex = 1;
            title_label.Text = "壊滅スターレイル";
            title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // csv_button
            // 
            csv_button.Location = new Point(624, 9);
            csv_button.Name = "csv_button";
            csv_button.Size = new Size(164, 62);
            csv_button.TabIndex = 2;
            csv_button.Text = "育成内容出力";
            csv_button.UseVisualStyleBackColor = true;
            csv_button.Click += csv_button_Click;
            // 
            // character_pictureBox
            // 
            character_pictureBox.Location = new Point(400, 90);
            character_pictureBox.Name = "character_pictureBox";
            character_pictureBox.Size = new Size(220, 300);
            character_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            character_pictureBox.TabIndex = 3;
            character_pictureBox.TabStop = false;
            // 
            // name_label
            // 
            name_label.BackColor = Color.Transparent;
            name_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            name_label.ForeColor = Color.White;
            name_label.Location = new Point(32, 84);
            name_label.Name = "name_label";
            name_label.Size = new Size(362, 56);
            name_label.TabIndex = 4;
            // 
            // xp_button
            // 
            xp_button.Location = new Point(34, 375);
            xp_button.Name = "xp_button";
            xp_button.Size = new Size(150, 70);
            xp_button.TabIndex = 12;
            xp_button.Text = "餌をあげる";
            xp_button.UseVisualStyleBackColor = true;
            xp_button.Click += xp_button_Click;
            // 
            // status_label
            // 
            status_label.BackColor = Color.Transparent;
            status_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            status_label.ForeColor = Color.White;
            status_label.Location = new Point(32, 151);
            status_label.Name = "status_label";
            status_label.Size = new Size(180, 90);
            status_label.TabIndex = 13;
            // 
            // xp_label
            // 
            xp_label.BackColor = Color.Transparent;
            xp_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            xp_label.ForeColor = Color.White;
            xp_label.Location = new Point(32, 241);
            xp_label.Name = "xp_label";
            xp_label.Size = new Size(180, 131);
            xp_label.TabIndex = 14;
            // 
            // battle_button
            // 
            battle_button.Location = new Point(638, 368);
            battle_button.Name = "battle_button";
            battle_button.Size = new Size(150, 70);
            battle_button.TabIndex = 15;
            battle_button.Text = "バトル";
            battle_button.UseVisualStyleBackColor = true;
            battle_button.Click += battle_button_Click;
            // 
            // critical_label
            // 
            critical_label.BackColor = Color.Transparent;
            critical_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            critical_label.ForeColor = Color.White;
            critical_label.Location = new Point(218, 151);
            critical_label.Name = "critical_label";
            critical_label.Size = new Size(180, 90);
            critical_label.TabIndex = 16;
            // 
            // FormTraining
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.背景;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(critical_label);
            Controls.Add(battle_button);
            Controls.Add(xp_label);
            Controls.Add(status_label);
            Controls.Add(xp_button);
            Controls.Add(name_label);
            Controls.Add(character_pictureBox);
            Controls.Add(csv_button);
            Controls.Add(title_label);
            Name = "FormTraining";
            Text = "Training";
            ((System.ComponentModel.ISupportInitialize)character_pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button csv_button;
        private PictureBox character_pictureBox;
        private Label name_label;
        private Button xp_button;
        private Label status_label;
        private Label xp_label;
        private Button battle_button;
        private Label critical_label;
    }
}