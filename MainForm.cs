using System.Windows.Forms;

namespace TopMostDispImage
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// �R���X�g���N�^�[
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// MainForm_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //�_�~�[���W���Z�b�g
            this.Top = 0;
            this.Left = 0;
            this.Width = 0;
            this.Height = 0;
        }

        /// <summary>
        /// MainForm_Shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                //�R�}���h���C���������擾
                string[] cmds = System.Environment.GetCommandLineArgs();



#if DEBUG
                //TEST
                cmds = new string[8];
                //���j�^�ԍ�
                cmds[1] = (4).ToString();

                //X���W
                cmds[2] = (0).ToString();

                //Y���W
                cmds[3] = (256).ToString();

                //��
                cmds[4] = (768).ToString();

                //����
                cmds[5] = (768).ToString();

                //���ߎw�� : 0=���߂��Ȃ�,1=���F�𓧉߂�����
                cmds[6] = (1).ToString();

                //�摜�t�@�C����
                cmds[7] = "AH64Frame.png";
#endif
                if (cmds.Length < 8)
                {
                    throw new Exception($"����������܂���B");
                }

                string monitorText = cmds[1];
                string xOffsetText = cmds[2];
                string yOffsetText = cmds[3];
                string widthText = cmds[4];
                string heightText = cmds[5];
                string transparencyText = cmds[6];
                string imgPath = cmds[7];

                int monitor;
                int xOffset;
                int yOffset;
                int width;
                int height;
                int transparency;


                if (!int.TryParse(monitorText, out monitor) || monitor <= 0)
                {
                    throw new Exception($"���j�^�ԍ����擾�ł��܂���B[{monitorText}]");
                }

                if (!int.TryParse(xOffsetText, out xOffset) || xOffset < 0)
                {
                    throw new Exception($"X���W���擾�ł��܂���B[{xOffsetText}]");
                }

                if (!int.TryParse(yOffsetText, out yOffset) || yOffset < 0)
                {
                    throw new Exception($"Y���W���擾�ł��܂���B[{yOffsetText}]");
                }
                if (!int.TryParse(widthText, out width) || width <= 0)
                {
                    throw new Exception($"�����擾�ł��܂���B[{widthText}]");
                }
                if (!int.TryParse(heightText, out height) || height <= 0)
                {
                    throw new Exception($"�������擾�ł��܂���B[{heightText}]");
                }
                if (!int.TryParse(transparencyText, out transparency) || (transparency != 0 && transparency != 1))
                {
                    throw new Exception($"���ߎw�肪�擾�ł��܂���B[{transparencyText}]");
                }
                string? appPath = Path.GetDirectoryName(Application.ExecutablePath);
                if (appPath == null)
                {
                    throw new Exception($"�摜�t�@�C����������܂���B\n[{imgPath}]");
                }
                imgPath = Path.Combine(appPath, "image", imgPath);
                if (!File.Exists(imgPath))
                {
                    throw new Exception($"�摜�t�@�C����������܂���B\n[{imgPath}]");
                }

                //���j�^�w��
                var ScreenList = Screen.AllScreens;
                if (ScreenList.Length < monitor)
                {
                    throw new Exception($"���j�^�ԍ��̃��j�^��������܂���[{monitor}]");
                }
                Screen s = ScreenList[monitor - 1];

                this.Location = s.Bounds.Location;

                //�T�C�Y�ύX
                this.Width = width;
                this.Height = height;
                this.Top += yOffset;
                this.Left += xOffset;

                //�摜��\��
                ImagePictureBox.Top = 0;
                ImagePictureBox.Left = 0;
                ImagePictureBox.Width = this.Width;
                ImagePictureBox.Height = this.Height;

                if(transparency == 1)
                {
                    this.TransparencyKey = Color.Black;
                }

                ImagePictureBox.Image = Image.FromFile(imgPath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        /// <summary>
        /// MainForm_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ImagePictureBox_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
