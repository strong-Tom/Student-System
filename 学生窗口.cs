using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
namespace 用户登录
{
   

    public partial class 学生窗口 : Form
    {

        String mystr;
        public 学生窗口()
        {
            InitializeComponent();
        }
        public 学生窗口(String s)
        {
            InitializeComponent();
            mystr = s;
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
       

      
        private void 学生窗口_Load(object sender, EventArgs e)
        {

        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                float GPA, t = 0f;
                int i;
                float sum1 = 0, sum2 = 0;

                for (i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if ((int)dataGridView1.Rows[i].Cells[1].Value >= 95 && (int)dataGridView1.Rows[i].Cells[1].Value <= 100)
                        t = 5.0f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 94)
                        t = 4.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 93)
                        t = 4.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 92)
                        t = 4.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 91)
                        t = 4.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 90)
                        t = 4.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 89)
                        t = 4.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 88)
                        t = 4.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 87)
                        t = 4.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 86)
                        t = 4.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 85)
                        t = 4.0f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 84)
                        t = 3.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 83)
                        t = 3.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 82)
                        t = 3.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 81)
                        t = 3.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 80)
                        t = 3.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 79)
                        t = 3.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 78)
                        t = 3.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 77)
                        t = 3.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 76)
                        t = 3.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 75)
                        t = 3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 74)
                        t = 2.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 73)
                        t = 2.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 72)
                        t = 2.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 71)
                        t = 2.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 70)
                        t = 2.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 69)
                        t = 2.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 68)
                        t = 2.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 67)
                        t = 2.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 66)
                        t = 2.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 65)
                        t = 2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 64)
                        t = 1.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 63)
                        t = 1.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 62)
                        t = 1.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 61)
                        t = 1.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 60)
                        t = 1f;
                    if (int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) < 60)
                        t = 0f;
                    //price = long.Parse(reader["PRICE"].ToString());
                    sum1 = sum1 + float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * t;
                    sum2 = sum2 + float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                GPA = sum1 / sum2;
                MessageBox.Show("你的绩点为：" + GPA + "。");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CreateSqlConn.con.Open();
            string selstr = "select sno as 学号,sname as 姓名,ssex as 性别,sage as 年龄,cclass as 班级,sphone as 电话号码,dname as 学院名 from student where sno = '" + mystr + "'";
            //string selstr = "select sno,sname,ssex,sage,Cname,Sphone,Dname from student where sno = '" + mystr + "'";
            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();

            ds.Clear();
            da.Fill(ds, "student");
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            CreateSqlConn.con.Open();
            string selstr = "select cname ,score ,tname,credit  from course,score,teacher where course.cno = score.cno and score.tno=teacher.tno and sno = '" + mystr + "'";
            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {

                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size(25, 25);
                dataGridView1.DataSource = null;
            }

            CreateSqlConn.con.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            平均成绩 avg = new 平均成绩(mystr);
            avg.Show();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            选课 xuan = new 选课(mystr);
            xuan.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                float GPA, t = 0f;
                int i;
                float sum1 = 0, sum2 = 0;

                for (i = 0; i < dataGridView1.RowCount - 1; i++)
                {
                    if ((int)dataGridView1.Rows[i].Cells[1].Value >= 95 && (int)dataGridView1.Rows[i].Cells[1].Value <= 100)
                        t = 5.0f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 94)
                        t = 4.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 93)
                        t = 4.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 92)
                        t = 4.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 91)
                        t = 4.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 90)
                        t = 4.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 89)
                        t = 4.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 88)
                        t = 4.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 87)
                        t = 4.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 86)
                        t = 4.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 85)
                        t = 4.0f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 84)
                        t = 3.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 83)
                        t = 3.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 82)
                        t = 3.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 81)
                        t = 3.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 80)
                        t = 3.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 79)
                        t = 3.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 78)
                        t = 3.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 77)
                        t = 3.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 76)
                        t = 3.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 75)
                        t = 3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 74)
                        t = 2.9f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 73)
                        t = 2.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 72)
                        t = 2.7f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 71)
                        t = 2.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 70)
                        t = 2.5f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 69)
                        t = 2.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 68)
                        t = 2.3f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 67)
                        t = 2.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 66)
                        t = 2.1f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 65)
                        t = 2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 64)
                        t = 1.8f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 63)
                        t = 1.6f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 62)
                        t = 1.4f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 61)
                        t = 1.2f;
                    if ((int)dataGridView1.Rows[i].Cells[1].Value == 60)
                        t = 1f;
                    if (int.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) < 60)
                        t = 0f;
                    //price = long.Parse(reader["PRICE"].ToString());
                    sum1 = sum1 + float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * t;
                    sum2 = sum2 + float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                GPA = sum1 / sum2;
                if(dataGridView1.DataSource==null)
                    MessageBox.Show("请先进入成绩界面再查看绩点!");
                else
                MessageBox.Show("你的绩点为：" + GPA + "。");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先进入成绩界面再查看绩点!");
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            修改学生密码 change = new 修改学生密码(mystr);
            change.Show();
        }
    }
}
