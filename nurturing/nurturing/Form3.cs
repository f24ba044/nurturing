using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace nurturing
{
    public partial class From_Battle : Form
    {
        //レベル
        int level;
        //経験値
        int xp;
        int nextxp;
        //味方ステータス
        string playerName;
        string charType;
        int hp;
        int atk;
        int def;
        int basehp;
        int cc;
        double cd;
        int ult = 2;
        //敵ステータス
        string enemyName;
        int enemyhp;
        int enemyatk;
        int enemydef;

        Random rnd = new Random();

        public From_Battle(string playerName, string charType, int level, int hp, int atk, int def, int xp, int nextxp, int cc, double cd)
        {
            InitializeComponent();
            //味方ステータス
            this.playerName = playerName;
            this.charType = charType;
            this.level = level;
            this.xp = xp;
            this.nextxp = nextxp;
            this.hp = hp;
            this.atk = atk;
            this.def = def;
            this.basehp = hp;
            this.cc = cc;
            this.cd = cd;
            //敵ステータス
            this.enemyhp = rnd.Next(1000, 2000) * level;
            this.enemyatk = rnd.Next(100, 300) * level;
            this.enemydef = rnd.Next(100, 500) * level;
            int enemyrandom = rnd.Next(3); //敵をランダムで決める

            //味方
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

            //敵
            if (enemyrandom == 0)
            {
                enemyName = "サム";
                enemy_pictureBox.Image = Properties.Resources.サム;
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

            }
            else if (enemyrandom == 1)
            {
                enemyName = "フレイムスティーラー";
                enemy_pictureBox.Image = Properties.Resources.フレイムスティーラー;
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

            }
            else if (enemyrandom == 2)
            {
                enemyName = "ボリュクス";
                enemy_pictureBox.Image = Properties.Resources.ボリュクス;
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

            }

            status_label.Text = $"{charType}\n" + "ステータス\n" + $"体力　：{hp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}\n" + $"cc:{cc}\n" + $"cd{cd}\n" + $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}\n" + $"必殺技まで残り{ult}ターン";
            ult_button.Enabled = false;
        }

        private void run_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "この戦いから逃げますか？",
            "確認",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"{playerName}は戦いから逃走した", "逃走", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();
            }
        }

        private async void attack_button_Click(object sender, EventArgs e)
        {
            attack_button.Enabled = false;
            ult_button.Enabled = false;
            log_label.Text = null;
            //プレイヤーダメージ
            bool isCritical = rnd.Next(1, 101) < cc;
            double criticalMultiplier = isCritical ? cd : 1.0;
            int baseDamage = atk - (enemydef / 5);
            double variance = rnd.NextDouble() * 0.4 + 0.8;
            baseDamage = Math.Max(baseDamage, 1);
            int player_damage = (int)(baseDamage * criticalMultiplier * variance);
            string log_playerdamage = player_damage.ToString();

            //敵ダメージ
            int enemyBaseDamage = enemyatk - (def / 5);
            double enemyVariance = rnd.NextDouble() * 0.4 + 0.8;
            enemyBaseDamage = Math.Max(enemyBaseDamage, 1);
            int enemy_damage = (int)(enemyBaseDamage * enemyVariance);
            string log_enemydamage = enemy_damage.ToString();

            log_label.Text += $"{charType}の攻撃!\n";

            await Task.Delay(100);

            string v1 = $"{log_playerdamage}ダメージ!\n";
            log_label.Text += v1;
            enemyhp -= player_damage;
            enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";


            if (enemyhp < 0)
            {
                MessageBox.Show($"{charType}は戦いに勝利した!", "winer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int gainedXp;

                if (level <= 30)
                {
                    // テーブルが緩やかなため、小さめの倍率でレベルに応じて成長
                    gainedXp = (int)(8 * Math.Pow(1.15, level));
                }
                else
                {
                    // 急激に増えるテーブルに合わせて経験値も増加
                    gainedXp = (int)(300 * Math.Pow(1.25, level - 30));
                }

                // 獲得経験値を加算
                xp += gainedXp;

                FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();

                return;
            }

            await Task.Delay(100);

            log_label.Text += $"{enemyName}の攻撃!\n";
            string v2 = $"{charType}は{log_enemydamage}受けた!\n";
            log_label.Text += v2;
            basehp -= enemy_damage;
            ult--;
            if (ult == 0)
            {
                ult_button.Enabled = true;
                ult++;
                status_label.Text = $"{charType}\n" + "ステータス\n" + $"体力　：{basehp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}\n" + $"cc:{cc}\n" + $"cd{cd}\n" + $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}\n" + $"必殺技使用可能!";

            }
            else
            {
                status_label.Text = $"{charType}\n" + "ステータス\n" + $"体力　：{basehp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}\n" + $"cc:{cc}\n" + $"cd{cd}\n" + $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}\n" + $"必殺技まで残り{ult}ターン";

            }
            if (basehp < 0)
            {
                MessageBox.Show($"{charType}は戦いに敗れた", "lose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();
            }

            await Task.Delay(500);
            attack_button.Enabled = true;
        }

        private async void ult_button_Click(object sender, EventArgs e)
        {
            log_label.Text = null;
            attack_button.Enabled = false;
            ult_button.Enabled = false;

            int[] damageArray = new int[3];
            string[] log_playerdamage = new string[3];

            //プレイヤーダメージ
            for (int i = 0; i < 3; i++)
            {
                bool isCritical = rnd.Next(1, 101) < cc;
                double criticalMultiplier = isCritical ? cd : 1.0;
                int baseDamage = atk - (enemydef / 5);
                double variance = rnd.NextDouble() * 0.4 + 0.8;
                baseDamage = Math.Max(baseDamage, 1);
                int player_damage = (int)(baseDamage * criticalMultiplier * variance);

                damageArray[i] = player_damage;
                log_playerdamage[i] = player_damage.ToString();
            }

            //敵ダメージ
            int enemyBaseDamage = enemyatk - (def / 5);
            double enemyVariance = rnd.NextDouble() * 0.4 + 0.8;
            enemyBaseDamage = Math.Max(enemyBaseDamage, 1);
            int enemy_damage = (int)(enemyBaseDamage * enemyVariance);
            string log_enemydamage = enemy_damage.ToString();

            log_label.Text += $"{charType}の必殺技!\n";

            await Task.Delay(100);
            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(100);
                enemyhp -= damageArray[i];
                log_label.Text += $"{log_playerdamage[i]}ダメージ！\n";
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";
            }
            ult = 2;

            if (enemyhp < 0)
            {
                MessageBox.Show($"{charType}は戦いに勝利した!", "winer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                int gainedXp;

                if (level <= 30)
                {
                    // テーブルが緩やかなため、小さめの倍率でレベルに応じて成長
                    gainedXp = (int)(8 * Math.Pow(1.15, level));
                }
                else
                {
                    // 急激に増えるテーブルに合わせて経験値も増加
                    gainedXp = (int)(300 * Math.Pow(1.25, level - 30));
                }

                // 獲得経験値を加算
                xp += gainedXp;

                FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();

                await Task.Delay(500);
                attack_button.Enabled = true;
                return;
            }

            await Task.Delay(300);
            log_label.Text = null;
            log_label.Text += $"{enemyName}の攻撃!\n";
            string v4 = $"{charType}は{log_enemydamage}受けた!\n";
            log_label.Text += v4;
            basehp -= enemy_damage;
            status_label.Text = $"{charType}\n" + "ステータス\n" + $"体力　：{basehp}\n" + $"攻撃力：{atk}\n" + $"防御力：{def}\n" + $"cc:{cc}\n" + $"cd{cd}\n" + $"レベル:{level}\n" + "経験値\n" + $"{xp}\n" + $"Next:{nextxp}";

            if (basehp < 0)
            {
                MessageBox.Show($"{charType}は戦いに敗れた", "lose", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();
            }

            await Task.Delay(500);
            attack_button.Enabled = true;
        }
    }
}
