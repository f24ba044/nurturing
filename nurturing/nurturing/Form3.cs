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
            //敵をランダムで決める
            int enemyrandom = rnd.Next(3); 

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
                //敵ステータス
                this.enemyhp = rnd.Next(500, 1000) * level;
                this.enemyatk = rnd.Next(100, 400) * level;
                this.enemydef = rnd.Next(500, 1000) * level;
                enemyName = "サム";
                enemy_pictureBox.Image = Properties.Resources.サム;
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

            }
            else if (enemyrandom == 1)
            {
                //敵ステータス
                this.enemyhp = rnd.Next(1200, 2000) * level;
                this.enemyatk = rnd.Next(100, 300) * level;
                this.enemydef = rnd.Next(300, 1000) * level;
                enemyName = "フレイムスティーラー";
                enemy_pictureBox.Image = Properties.Resources.フレイムスティーラー;
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

            }
            else if (enemyrandom == 2)
            {
                //敵ステータス
                this.enemyhp = rnd.Next(2000, 4000) * level;
                this.enemyatk = rnd.Next(50, 100) * level;
                this.enemydef = rnd.Next(50, 100) * level;
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
            log_label.Text = "";

            // プレイヤー攻撃
            if (charType == "サム" || charType == "フレイムスティーラー")
            {
                await attack1();
            }
            else if (charType == "ボリュクス")
            {
                await attack2();
            }

            // 敵のHPが0以下なら勝利処理
            if (enemyhp <= 0)
            {
                MessageBox.Show($"{charType}は戦いに勝利した!", "勝利", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int gainedXp = level <= 30
                    ? (int)(8 * Math.Pow(1.15, level))
                    : (int)(600 * Math.Pow(1.25, level - 30));
                xp += gainedXp;

                var trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();
                return;
            }


            await enemyAttack();

            // 必殺技ターン処理
            ult--;
            if (ult <= 0)
            {
                ult_button.Enabled = true;
                status_label.Text = $"{charType}\nステータス\n体力：{basehp}\n攻撃力：{atk}\n防御力：{def}\ncc:{cc}\ncd:{cd}\nレベル:{level}\n経験値\n{xp}\nNext:{nextxp}\n必殺技使用可能!";
            }
            else
            {
                status_label.Text = $"{charType}\nステータス\n体力：{basehp}\n攻撃力：{atk}\n防御力：{def}\ncc:{cc}\ncd:{cd}\nレベル:{level}\n経験値\n{xp}\nNext:{nextxp}\n必殺技まで残り{ult}ターン";
            }

            attack_button.Enabled = true;

        }

        private async  Task attack1()
        {
            bool isCritical = rnd.Next(1, 101) <= cc;
            double criticalMultiplier = isCritical ? cd : 1.0;
            int baseDamage = atk - (enemydef / 5);
            baseDamage = Math.Max(baseDamage, 1);
            double variance = rnd.NextDouble() * 0.4 + 0.8;
            int player_damage = (int)(baseDamage * criticalMultiplier * variance);
            enemyhp -= player_damage;

            log_label.Text += $"{charType}の攻撃！\n";
            await Task.Delay(100);
            log_label.Text += $"{player_damage} ダメージ！\n";

            // 敵ステータス更新
            enemy_status_label.Text = $"{enemyName}\n体力：{enemyhp}\n攻撃力：{enemyatk}\n防御力：{enemydef}\n";
        }

        private async Task attack2()
        {
            bool isCritical = rnd.Next(1, 101) <= cc;
            double criticalMultiplier = isCritical ? cd : 1.0;
            double baseDamage = (hp * 0.8) - (enemydef / 5);
            baseDamage = Math.Max(baseDamage, 1);
            double variance = rnd.NextDouble() * 0.4 + 0.8;
            int player_damage = (int)(baseDamage * criticalMultiplier * variance);
            enemyhp -= player_damage;

            log_label.Text += $"{charType}の攻撃！\n";
            await Task.Delay(100);
            log_label.Text += $"{player_damage} ダメージ！\n";

            // 敵ステータス更新
            enemy_status_label.Text = $"{enemyName}\n体力：{enemyhp}\n攻撃力：{enemyatk}\n防御力：{enemydef}\n";
        }

        private async Task enemyAttack()
        {
            // 敵の攻撃処理
            await Task.Delay(200);

            int enemyBaseDamage = enemyatk - (def / 3);
            double enemyVariance = rnd.NextDouble() * 0.4 + 0.8;
            enemyBaseDamage = Math.Max(enemyBaseDamage, 1);
            int enemy_damage = (int)(enemyBaseDamage * enemyVariance);
            basehp -= enemy_damage;

            log_label.Text += $"{enemyName}の攻撃!\n";

            await Task.Delay(100);

            log_label.Text += $"{charType}は{enemy_damage}ダメージを受けた！\n";

            // プレイヤーのHPチェック
            if (basehp <= 0)
            {
                int gainedXp = level <= 30
                    ? (int)(4 * Math.Pow(1.15, level))
                    : (int)(300 * Math.Pow(1.25, level - 30));
                xp += gainedXp;

                MessageBox.Show($"{charType}は戦いに敗れた", "敗北", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp, cc, cd);
                trainingForm.Show();
                this.Hide();
                return;
            }
        }
        private async void ult_button_Click(object sender, EventArgs e)
        {
            log_label.Text = null;
            attack_button.Enabled = false;
            ult_button.Enabled = false;

            int[] damageArray;
            string[] log_playerdamage;

            ult = 2;

            log_label.Text += $"{charType}の必殺技!\n";

            if (charType == "サム")
            {
                bool isCritical = rnd.Next(1, 101) <= cc;
                double criticalMultiplier = isCritical ? cd : 1.0;
                int baseDamage = atk;
                baseDamage = Math.Max(baseDamage, 1);
                double variance = rnd.NextDouble() * 0.4 + 0.8;
                int player_damage = (int)(baseDamage * criticalMultiplier * variance);
                enemyhp -= player_damage;

                await Task.Delay(100);

                log_label.Text += $"{player_damage}ダメージ！\n";
                enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

                await Task.Delay(100);
                int heal = (int)(hp * 0.25); // サムの必殺技でHPを25%回復
                basehp += heal;
                log_label.Text += $"{charType}は{heal}回復した！\n";
                status_label.Text = $"{charType}\nステータス\n体力：{basehp}\n攻撃力：{atk}\n防御力：{def}\ncc:{cc}\ncd:{cd}\nレベル:{level}\n経験値\n{xp}\nNext:{nextxp}\n必殺技まで残り{ult}ターン";
            }
            else if (charType == "フレイムスティーラー")
            {
                damageArray = new int[6];
                log_playerdamage = new string[6];
                //プレイヤーダメージ
                for (int i = 0; i < 5; i++)
                {
                    bool isCritical = rnd.Next(1, 101) < cc;
                    double criticalMultiplier = isCritical ? cd : 1.0;
                    double baseDamage = atk - (enemydef / 5);
                    double variance = rnd.NextDouble() * 0.2 + 0.5;
                    baseDamage = Math.Max(baseDamage, 1);
                    int player_damage = (int)(baseDamage * criticalMultiplier * variance);

                    damageArray[i] = player_damage;
                    log_playerdamage[i] = player_damage.ToString();
                }
                // 最後の一撃
                bool isCriticalLast = rnd.Next(1, 101) < cc;
                double criticalMultiplierLast = isCriticalLast ? cd : 1.0;
                double baseDamageLast = atk;
                double varianceLast = rnd.NextDouble() * 0.8 + 1.6;
                baseDamageLast = Math.Max(baseDamageLast, 1);
                int player_damageLast = (int)(baseDamageLast * criticalMultiplierLast * varianceLast);
                damageArray[5] = player_damageLast;
                log_playerdamage[5] = player_damageLast.ToString();

                await Task.Delay(100);

                for (int i = 0; i < 6; i++)
                {
                    await Task.Delay(100);

                    enemyhp -= damageArray[i];
                    log_label.Text += $"{log_playerdamage[i]}ダメージ！\n";
                    enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";
                }
            }
            else if (charType == "ボリュクス")
            {
                damageArray = new int[6];
                log_playerdamage = new string[6];
                //プレイヤーダメージ
                for (int i = 0; i < 6; i++)
                {
                    bool isCritical = rnd.Next(1, 101) < cc;
                    double criticalMultiplier = isCritical ? cd : 1.0;
                    double baseDamage = (hp * 0.6) - (enemydef / 5);
                    double variance = rnd.NextDouble() * 0.4 + 0.8;
                    baseDamage = Math.Max(baseDamage, 1);
                    int player_damage = (int)(baseDamage * criticalMultiplier * variance);

                    damageArray[i] = player_damage;
                    log_playerdamage[i] = player_damage.ToString();
                }
                await Task.Delay(100);

                for (int i = 0; i < 6; i++)
                {
                    await Task.Delay(100);

                    enemyhp -= damageArray[i];
                    log_label.Text += $"{log_playerdamage[i]}ダメージ！\n";
                    enemy_status_label.Text = $"{enemyName}\n" + $"体力　：{enemyhp}\n" + $"攻撃力：{enemyatk}\n" + $"防御力：{enemydef}\n";

                }
                // ボリュクスの必殺技はHPを回復
                int heal = (int)(hp * 0.15); // ボリュクスの必殺技でHPを15%回復
                basehp += heal;
                log_label.Text += $"{charType}は{heal}回復した！\n";
                status_label.Text = $"{charType}\nステータス\n体力：{basehp}\n攻撃力：{atk}\n防御力：{def}\ncc:{cc}\ncd:{cd}\nレベル:{level}\n経験値\n{xp}\nNext:{nextxp}\n必殺技まで残り{ult}ターン";

            }

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
                    gainedXp = (int)(600 * Math.Pow(1.25, level - 30));
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

            await enemyAttack();

            if (basehp < 0)
            {
                int gainedXp;
                if (level <= 30)
                {
                    // テーブルが緩やかなため、小さめの倍率でレベルに応じて成長
                    gainedXp = (int)(4 * Math.Pow(1.15, level));
                }
                else
                {
                    // 急激に増えるテーブルに合わせて経験値も増加
                    gainedXp = (int)(300 * Math.Pow(1.25, level - 30));
                }


                // 獲得経験値を加算
                xp += gainedXp;

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
