using System.Xml.Linq;

namespace nurturing
{
    public partial class character_select : Form
    {
        public character_select()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Sum_radioButton.Checked)
            {
                SetStatus(3500, 4000, 2500);
            }
            else if (FlameReaver_radioButton.Checked)
            {
                SetStatus(3000, 3500, 3500);
            }
            else if (Pollux_radioButton.Checked)
            {
                SetStatus(8500, 500, 1000);
            }
        }

        private void SetStatus(int hp, int atk, int def)
        {
            status_label.Text = $"体力: {hp}\n" + $"攻撃力: {atk}\n" + $"防御力: {def}";
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            string name = name_textBox.Text.Trim();
            string type = "";
            int hp = 0, atk = 0, def = 0;

            if (Sum_radioButton.Checked)
            {
                type = "サム";
                hp = 3500; atk = 4000; def = 2500;
            }
            else if (FlameReaver_radioButton.Checked)
            {
                type = "フレイムスティーラー";
                hp = 3000; atk = 3500; def = 3500;
            }
            else if (Pollux_radioButton.Checked)
            {
                type = "ボリュクス";
                hp = 8500; atk = 500; def = 1000;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("プレイヤーネームとキャラの種類を選択してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"プレイヤー名: {name}\nキャラクター: {type}\nこの内容で確定しますか？",
                "確認",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("キャラクターが確定しました！", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormTraining trainingForm = new FormTraining(name, type, hp, atk, def);
                trainingForm.Show();
                this.Hide();
            }
        }
    }
}
