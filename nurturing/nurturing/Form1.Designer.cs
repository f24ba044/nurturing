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
            title_label = new Label();
            textBox1 = new TextBox();
            status_label = new Label();
            pictureBox1 = new PictureBox();
            name_label = new Label();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            select_btn = new Button();
            label1 = new Label();
            character_label = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // title_label
            // 
            title_label.Font = new Font("游ゴシック Light", 30F);
            title_label.Location = new Point(12, 9);
            title_label.Name = "title_label";
            title_label.Size = new Size(776, 62);
            title_label.TabIndex = 0;
            title_label.Text = "育成アプリ";
            title_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("游ゴシック Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            textBox1.Location = new Point(12, 97);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(210, 32);
            textBox1.TabIndex = 1;
            // 
            // status_label
            // 
            status_label.Font = new Font("游ゴシック Light", 9F);
            status_label.Location = new Point(482, 71);
            status_label.Name = "status_label";
            status_label.Size = new Size(306, 58);
            status_label.TabIndex = 2;
            status_label.Text = "ステータス";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(70, 150);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 200);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Font = new Font("游ゴシック Light", 9F);
            name_label.Location = new Point(12, 74);
            name_label.Name = "name_label";
            name_label.Size = new Size(39, 19);
            name_label.TabIndex = 4;
            name_label.Text = "名前";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(330, 150);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(150, 200);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(580, 150);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(150, 200);
            pictureBox3.TabIndex = 6;
            pictureBox3.TabStop = false;
            // 
            // radioButton1
            // 
            radioButton1.Location = new Point(70, 356);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(150, 26);
            radioButton1.TabIndex = 8;
            radioButton1.TabStop = true;
            radioButton1.Text = "radioButton1";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.Location = new Point(330, 356);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(150, 26);
            radioButton2.TabIndex = 9;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            radioButton3.Location = new Point(580, 356);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(150, 26);
            radioButton3.TabIndex = 10;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // select_btn
            // 
            select_btn.Location = new Point(330, 401);
            select_btn.Name = "select_btn";
            select_btn.Size = new Size(150, 37);
            select_btn.TabIndex = 11;
            select_btn.Text = "選択";
            select_btn.UseVisualStyleBackColor = true;
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
            character_label.Font = new Font("游ゴシック Light", 9F);
            character_label.Location = new Point(330, 114);
            character_label.Name = "character_label";
            character_label.Size = new Size(150, 19);
            character_label.TabIndex = 13;
            character_label.Text = "キャラクター選択";
            character_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // character_select
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(character_label);
            Controls.Add(label1);
            Controls.Add(select_btn);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(name_label);
            Controls.Add(pictureBox1);
            Controls.Add(status_label);
            Controls.Add(textBox1);
            Controls.Add(title_label);
            Name = "character_select";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title_label;
        private TextBox textBox1;
        private Label status_label;
        private PictureBox pictureBox1;
        private Label name_label;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Button select_btn;
        private Label label1;
        private Label character_label;
    }
}
