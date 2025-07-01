using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace nurturing
{
    public partial class FormTraining : Form
    {
        //レベル
        int level = 1;
        //経験値
        int xp;
        int nextxp;
        int basexp = 1;
        //ステータス
        string playerName;
        string charType;
        int hp;
        int atk;
        int def;

        Random rnd = new Random();
        public FormTraining(string playerName, string charType, int level, int hp, int atk, int def, int xp, int nextxp)
        {
            InitializeComponent();
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.playerName = playerName;
            this.charType = charType;
            this.level = level;
            this.xp = xp;
            this.nextxp = nextxp;
            if (charType == "サム")
            {
                character_pictureBox.Image = Properties.Resources.サム;
            }
            else if (charType == "フレイムスティーラー")
            {
                character_pictureBox.Image = Properties.Resources.フレイムスティーラー;
            }
            else if (charType == "ボリュクス")
            {
                character_pictureBox.Image = Properties.Resources.ボリュクス;
            }

            name_label.Text = "名前\n" + playerName + "の" + charType;
            status_label.Text = "ステータス\n" + $"体力　：{hp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}\n";
            XP_label.Text = $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}";
            ;
        }

        private async void xp_button_Click(object sender, EventArgs e)
        {

            xp_button.Enabled = false;

            xp += basexp;
            XP_label.Text = $"レベル:{level}\n経験値\n{xp}\nNext:{nextxp}";

            while (xp >= nextxp)
            {
                int r = rnd.Next(3); // 0=hp, 1=atk, 2=def
                int r1 = rnd.Next(10, 101); // ステータスのあがり幅

                await Task.Delay(300);

                switch (r)
                {
                    case 0: hp += r1; break;
                    case 1: atk += r1; break;
                    case 2: def += r1; break;
                }

                level++;
                xp -= nextxp;
                nextxp = (int)(10 * Math.Pow(1.5, level - 1));
                basexp = 1 + (level / 4);

                UpdateStatusLabel();
                XP_label.Text = $"レベル:{level}\n経験値\n{xp}\nNext:{nextxp}\n" + "レベルアップ!!";
            }
            xp_button.Enabled = true;
        }


        private void UpdateStatusLabel()
        {
            status_label.Text =
                "ステータス\n" + $"体力　：{hp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}";
        }

        private void csv_button_Click(object sender, EventArgs e)
        {
            try
            {
                // ダウンロードフォルダに保存
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                // ファイル名に日付を入れる
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string fileName = $"status_{timestamp}.csv";
                string filePath = Path.Combine(downloadsPath, fileName);

                // CSV ヘッダーとデータ（指定の順番で）
                string header = "名前,職業,レベル,体力,攻撃力,防御力,現在XP,次のレベルまでのXP";
                string csvLine = $"{playerName},{charType},{level},{hp},{atk},{def},{xp},{nextxp}";

                // 書き込み
                File.WriteAllText(filePath, header + "\n" + csvLine);

                MessageBox.Show($"ステータスを保存しました！\n{fileName}", "保存完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存中にエラーが発生しました：\n" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void battle_button_Click(object sender, EventArgs e)
        {

        }
    }
}
