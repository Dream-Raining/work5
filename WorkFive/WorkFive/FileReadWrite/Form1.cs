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
            //�ж��û��Ƿ���ȷ��ѡ�����ļ�
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //��ȡ�û�ѡ���ļ��ĺ�׺��
                string extension = Path.GetExtension(fileDialog.FileName);
                //��ȡ�û�ѡ����ļ�
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
            //�ж��û��Ƿ���ȷ��ѡ�����ļ�
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //��ȡ�û�ѡ���ļ��ĺ�׺��
                string extension = Path.GetExtension(fileDialog.FileName);
                //��ȡ�û�ѡ����ļ�
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
            //�����ļ�
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