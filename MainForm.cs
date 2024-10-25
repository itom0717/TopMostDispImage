using System.Windows.Forms;

namespace TopMostDispImage
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクター
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
            //ダミー座標をセット
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
                //コマンドライン引数を取得
                string[] cmds = System.Environment.GetCommandLineArgs();



#if DEBUG
                //TEST
                cmds = new string[8];
                //モニタ番号
                cmds[1] = (4).ToString();

                //X座標
                cmds[2] = (0).ToString();

                //Y座標
                cmds[3] = (256).ToString();

                //幅
                cmds[4] = (768).ToString();

                //高さ
                cmds[5] = (768).ToString();

                //透過指定 : 0=透過しない,1=黒色を透過させる
                cmds[6] = (1).ToString();

                //画像ファイル名
                cmds[7] = "AH64Frame.png";
#endif
                if (cmds.Length < 8)
                {
                    throw new Exception($"引数が足りません。");
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
                    throw new Exception($"モニタ番号が取得できません。[{monitorText}]");
                }

                if (!int.TryParse(xOffsetText, out xOffset) || xOffset < 0)
                {
                    throw new Exception($"X座標が取得できません。[{xOffsetText}]");
                }

                if (!int.TryParse(yOffsetText, out yOffset) || yOffset < 0)
                {
                    throw new Exception($"Y座標が取得できません。[{yOffsetText}]");
                }
                if (!int.TryParse(widthText, out width) || width <= 0)
                {
                    throw new Exception($"幅が取得できません。[{widthText}]");
                }
                if (!int.TryParse(heightText, out height) || height <= 0)
                {
                    throw new Exception($"高さが取得できません。[{heightText}]");
                }
                if (!int.TryParse(transparencyText, out transparency) || (transparency != 0 && transparency != 1))
                {
                    throw new Exception($"透過指定が取得できません。[{transparencyText}]");
                }
                string? appPath = Path.GetDirectoryName(Application.ExecutablePath);
                if (appPath == null)
                {
                    throw new Exception($"画像ファイルが見つかりません。\n[{imgPath}]");
                }
                imgPath = Path.Combine(appPath, "image", imgPath);
                if (!File.Exists(imgPath))
                {
                    throw new Exception($"画像ファイルが見つかりません。\n[{imgPath}]");
                }

                //モニタ指定
                var ScreenList = Screen.AllScreens;
                if (ScreenList.Length < monitor)
                {
                    throw new Exception($"モニタ番号のモニタが見つかりません[{monitor}]");
                }
                Screen s = ScreenList[monitor - 1];

                this.Location = s.Bounds.Location;

                //サイズ変更
                this.Width = width;
                this.Height = height;
                this.Top += yOffset;
                this.Left += xOffset;

                //画像を表示
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
