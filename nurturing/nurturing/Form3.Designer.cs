namespace nurturing
{
    partial class From_Battle
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
            character_pictureBox = new PictureBox();
            enemy_pictureBox = new PictureBox();
            status_label = new Label();
            enemy_status_label = new Label();
            log_label = new Label();
            attack_button = new Button();
            run_button = new Button();
            ult_button = new Button();
            title_label = new Label();
            ((System.ComponentModel.ISupportInitialize)character_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)enemy_pictureBox).BeginInit();
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
            title_label.TabIndex = 2;
            title_label.Text = "壊滅スターレイル";
            title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character_pictureBox
            // 
            character_pictureBox.Location = new Point(198, 74);
            character_pictureBox.Name = "character_pictureBox";
            character_pictureBox.Size = new Size(120, 200);
            character_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            character_pictureBox.TabIndex = 4;
            character_pictureBox.TabStop = false;
            // 
            // enemy_pictureBox
            // 
            enemy_pictureBox.Location = new Point(482, 74);
            enemy_pictureBox.Name = "enemy_pictureBox";
            enemy_pictureBox.Size = new Size(120, 200);
            enemy_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            enemy_pictureBox.TabIndex = 5;
            enemy_pictureBox.TabStop = false;
            // 
            // status_label
            // 
            status_label.BackColor = Color.Transparent;
            status_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            status_label.ForeColor = Color.White;
            status_label.Location = new Point(12, 74);
            status_label.Name = "status_label";
            status_label.Size = new Size(180, 281);
            status_label.TabIndex = 14;
            // 
            // enemy_status_label
            // 
            enemy_status_label.BackColor = Color.Transparent;
            enemy_status_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            enemy_status_label.ForeColor = Color.White;
            enemy_status_label.Location = new Point(608, 74);
            enemy_status_label.Name = "enemy_status_label";
            enemy_status_label.Size = new Size(180, 281);
            enemy_status_label.TabIndex = 15;
            // 
            // log_label
            // 
            log_label.BackColor = Color.Transparent;
            log_label.Font = new Font("HG創英角ﾎﾟｯﾌﾟ体", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            log_label.ForeColor = Color.White;
            log_label.Location = new Point(324, 74);
            log_label.Name = "log_label";
            log_label.Size = new Size(152, 281);
            log_label.TabIndex = 16;
            // 
            // attack_button
            // 
            attack_button.Location = new Point(12, 368);
            attack_button.Name = "attack_button";
            attack_button.Size = new Size(150, 70);
            attack_button.TabIndex = 17;
            attack_button.Text = "攻撃";
            attack_button.UseVisualStyleBackColor = true;
            attack_button.Click += attack_button_Click;
            // 
            // run_button
            // 
            run_button.Location = new Point(324, 368);
            run_button.Name = "run_button";
            run_button.Size = new Size(150, 70);
            run_button.TabIndex = 18;
            run_button.Text = "逃げる";
            run_button.UseVisualStyleBackColor = true;
            run_button.Click += run_button_Click;
            // 
            // ult_button
            // 
            ult_button.Location = new Point(168, 368);
            ult_button.Name = "ult_button";
            ult_button.Size = new Size(150, 70);
            ult_button.TabIndex = 19;
            ult_button.Text = "必殺技";
            ult_button.UseVisualStyleBackColor = true;
            ult_button.Click += ult_button_Click;
            // 
            // From_Battle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(ult_button);
            Controls.Add(run_button);
            Controls.Add(attack_button);
            Controls.Add(log_label);
            Controls.Add(enemy_status_label);
            Controls.Add(status_label);
            Controls.Add(enemy_pictureBox);
            Controls.Add(character_pictureBox);
            Controls.Add(title_label);
            Name = "From_Battle";
            Text = "Battle";
            ((System.ComponentModel.ISupportInitialize)character_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)enemy_pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox character_pictureBox;
        private PictureBox enemy_pictureBox;
        private Label status_label;
        private Label enemy_status_label;
        private Label log_label;
        private Button attack_button;
        private Button run_button;
        private Button ult_button;
    }
}