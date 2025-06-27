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
            status_label.Text = $"�̗�: {hp}\n" + $"�U����: {atk}\n" + $"�h���: {def}";
        }

        private void select_btn_Click(object sender, EventArgs e)
        {
            string name = name_textBox.Text.Trim();
            string type = "";
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
                FormTraining trainingForm = new FormTraining(name, type, hp, atk, def);
                trainingForm.Show();
                this.Hide();
            }
        }
    }
}
