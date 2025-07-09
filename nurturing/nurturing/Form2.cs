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
using System.Xml.Linq;

namespace nurturing
{
    public partial class FormTraining : Form
    {
        //レベル
        int level = 1;
        //経験値
        int xp;
        int nextxp;
        int basexp;
        //ステータス
        string playerName;
        string charType;
        int hp;
        int atk;
        int def;
        int cc;
        double cd;

        Random rnd = new Random();
        public FormTraining(string playerName, string charType, int level, int hp, int atk, int def, int xp, int nextxp,int cc,double cd)
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
            this.cc = cc;
            this.cd = cd;
            this.basexp = (int)(15 + level * 1.2);

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
            if (level >= 80)
            {
                xp_label.Text = $"レベル:{level}\n" + "レベル上限に達しました";
                xp_button.Enabled = false;
            }
            else
            {
                xp_label.Text = $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}";

            }
            critical_label.Text = $"cc：{cc}\n" + $"cd：{cd}";
        }

        private async void xp_button_Click(object sender, EventArgs e)
        {
            if (level >= 80)
            {
                MessageBox.Show("レベル上限に達しました", "上限", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xp_button.Enabled = false;

            xp += basexp;
            xp_label.Text = $"レベル:{level}\n経験値\n{xp}\nNext:{nextxp}";

            while (xp >= nextxp)
            {
                int r = rnd.Next(101); // 0-30hp, 31-50atk, 51-70def, 71-85cc, 86-100cd
                int r1 = rnd.Next(100, 2000); // ステータスのあがり幅

                await Task.Delay(300);

                if (r <= 30)
                {
                    hp += r1;
                }
                else if (r <= 50)
                {
                    atk += r1;
                }
                else if(r <= 70)
                {
                    def += r1;
                }
                else if (r <= 85)
                {
                    if (cc <= 100)
                    {
                        cc += 5;
                    }
                    else
                    {
                        cd += 0.1;
                        cd = Math.Floor(cd * 10) / 10;
                    }
                }
                else if (r <= 100)
                {
                    cd += 0.1;
                    cd = Math.Floor(cd * 10) / 10;
                }

                while (xp >= nextxp)
                {
                    xp -= nextxp;
                    level++;

                    if (level <= 30)
                    {
                        nextxp = (int)(10 * Math.Pow(1.2, level - 1));
                    }
                    else
                    {
                        double baseAtLevel30 = 10 * Math.Pow(1.2, 29);
                        nextxp = (int)(baseAtLevel30 * Math.Pow(1.28, level - 30));
                    }

                    basexp = (int)(15 + level * 1.2);

                }

                UpdateStatusLabel();
                xp_label.Text = $"レベル:{level}\n経験値\n{xp}\nNext:{nextxp}\nレベルアップ!!";
            }
            xp_button.Enabled = true;
        }


        private void UpdateStatusLabel()
        {
            status_label.Text = "ステータス\n" + $"体力　：{hp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}";
            critical_label.Text = $"cc：{cc}\n" + $"cd：{cd}";
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
                string header = "名前,職業,レベル,体力,攻撃力,防御力,現在XP,次のレベルまでのXP,クリティカル率,クリティカルダメージ";
                string csvLine = $"{playerName},{charType},{level},{hp},{atk},{def},{xp},{nextxp},{cc},{cd}";

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
            DialogResult result = MessageBox.Show(
            "バトルしますか？",
            "確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("バトルへ移行します", "バトル", MessageBoxButtons.OK, MessageBoxIcon.Information);
                From_Battle from_Battle = new From_Battle(playerName,charType,level,hp,atk,def,xp,nextxp,cc,cd);
                from_Battle.Show();
                this.Hide();
            }
        }
    }
}
