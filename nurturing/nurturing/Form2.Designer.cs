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
            title_label = new Label();
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
            // FormTraining
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(title_label);
            Name = "FormTraining";
            Text = "Training";
            ResumeLayout(false);
        }

        #endregion
    }
}