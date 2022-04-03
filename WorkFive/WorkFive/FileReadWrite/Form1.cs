namespace FileReadWrite
{
    public partial class Form1 : Form
    {
        FileInfo fileInfo_First;
        FileInfo fileInfo_Second;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //获取用户选择的文件
                fileInfo_First = new FileInfo(fileDialog.FileName);
                this.textBox1.Text = fileInfo_First.FullName;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            //判断用户是否正确的选择了文件
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //获取用户选择文件的后缀名
                string extension = Path.GetExtension(fileDialog.FileName);
                //获取用户选择的文件
                fileInfo_Second = new FileInfo(fileDialog.FileName);
                this.textBox2.Text = fileInfo_Second.FullName;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fil = Environment.CurrentDirectory + @"\Data";
            string finalFile = Environment.CurrentDirectory + @"\Data\final.txt";
            //创建文件
            Directory.CreateDirectory(fil);
            FileStream fileStream = new FileStream(finalFile, FileMode.Append, FileAccess.Write);

            StreamReader reader1 = null;
            StreamReader reader2 = null;
            StreamWriter writer = null;

            try
            {
                FileStream fin_1 = new FileStream(fileInfo_First.FullName, FileMode.Open, FileAccess.Read);
                FileStream fin_2 = new FileStream(fileInfo_Second.FullName, FileMode.Open, FileAccess.Read);
                reader1 = new StreamReader(fin_1,System.Text.Encoding.Default);
                reader2 = new StreamReader(fin_2,System.Text.Encoding.Default);
                writer = new StreamWriter(fileStream,System.Text.Encoding.Default);
                int linNum = 0;
                string s = string.Empty;
                while((s = reader1.ReadLine()) != null)
                {
                    linNum++;
                    writer.WriteLine(linNum + ":\t" + s);
                }
                //linNum = 0;
                while((s = reader2.ReadLine()) != null)
                {
                    linNum++;
                    writer.WriteLine(linNum + ":\t" + s);
                }
            }catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if(reader1 != null) reader1.Close();
                if(reader2 != null) reader2.Close();
                if(writer != null) writer.Close();
            }

        }
    }
}