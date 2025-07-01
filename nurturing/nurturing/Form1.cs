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
            status_label.Text = $"�̗́@: {hp}\n" + $"�U����: {atk}\n" + $"�h���: {def}";
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            string name = name_textBox.Text.Trim();
            string type = "";
            int level = 1, xp = 0, nextxp = 5;
            int hp = 0, atk = 0, def = 0;

            if (Sum_radioButton.Checked)
            {
                type = "�T��";
                hp = 3500; atk = 4000; def = 2500;
            }
            else if (FlameReaver_radioButton.Checked)
            {
                type = "�t���C���X�e�B�[���[";
                hp = 3000; atk = 3500; def = 3500;
            }
            else if (Pollux_radioButton.Checked)
            {
                type = "�{�����N�X";
                hp = 8500; atk = 500; def = 1000;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type))
            {
                MessageBox.Show("�v���C���[�l�[���ƃL�����̎�ނ�I�����Ă��������B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"�v���C���[��: {name}\n�L�����N�^�[: {type}\n���̓��e�Ŋm�肵�܂����H",
                "�m�F",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("�L�����N�^�[���m�肵�܂����I", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormTraining trainingForm = new FormTraining(name, type, level, hp, atk, def, xp, nextxp);
                trainingForm.Show();
                this.Hide();
            }
        }

        private void statuload_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "�X�e�[�^�X�t�@�C����I�����Ă�������";
                openFileDialog.Filter = "CSV�t�@�C�� (*.csv)|*.csv";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        var lines = File.ReadAllLines(filePath);

                        if (lines.Length < 2)
                        {
                            MessageBox.Show("�f�[�^����ł��B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // �Ō�̍s���p�[�X
                        string[] values = lines[^1].Split(',');

                        string playerName = values[0];
                        string charType   = values[1];
                        int level         = int.Parse(values[2]);
                        int hp            = int.Parse(values[3]);
                        int atk           = int.Parse(values[4]);
                        int def           = int.Parse(values[5]);
                        int xp            = int.Parse(values[6]);
                        int nextxp        = int.Parse(values[7]);

                        // �g���ŃR���X�g���N�^���g���Ĉ琬��ʂ�
                        FormTraining trainingForm = new FormTraining(playerName, charType, level, hp, atk, def, xp, nextxp);
                        trainingForm.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("�ǂݍ��ݒ��ɃG���[���������܂����F\n" + ex.Message, "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
