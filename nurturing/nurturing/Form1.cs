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
            status_label.Text = $"体力　: {hp}\n" + $"攻撃力: {atk}\n" + $"防御力: {def}";
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            string name = name_textBox.Text.Trim();
            string type = "";
            int level = 1, xp = 0, nextxp = 5;
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
                FormTraining trainingForm = new FormTraining(name, type, level, hp, atk, def, xp, nextxp);
                trainingForm.Show();
                this.Hide();
            }
        }

        private void statuload_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "ステータスファイルを選択してください";
                openFileDialog.Filter = "CSVファイル (*.csv)|*.csv";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        var lines = File.ReadAllLines(filePath);

                        if (lines.Length < 2)
                        {
                            MessageBox.Show("データが空です。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // 最後の行をパース
                        string[] values = lines[^1].Split(',');

                        string playerName = values[0];
                        string charType   = values[1];
                        int level         = int.Parse(values[2]);
                        int hp            = int.Parse(values[3]);
                        int atk           = int.Parse(values[4]);
                        int def           = int.Parse(values[5]);
                        int xp            = int.Parse(values[6]);
                        int nextxp        = int.Parse(values[7]);

                        // 拡張版コンストラクタを使って育成画面へ
                        FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp);
                        trainingForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("読み込み中にエラーが発生しました：\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
