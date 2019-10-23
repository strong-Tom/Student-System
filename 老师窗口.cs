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
{//some
    //改改更健康
    public partial class 老师窗口 : Form
    {
        String str;
     
        public 老师窗口(String t)
        {
            InitializeComponent();
        
            dataGridView1.ReadOnly = true;
 
            //this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);//把他看成监听器就好
            str = t;
        }
        
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void 老师窗口_Load(object sender, EventArgs e)
        {

        }


        int flag;
 

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        


        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            toolStripProgressBar1.Maximum = 100;//设置最大长度值
            toolStripProgressBar1.Value = 0;//设置当前值
            toolStripProgressBar1.Step = 10;//设置没次增长多少
            for (int i = 0; i < 10; i++)//循环
            {
                System.Threading.Thread.Sleep(50);//暂停1秒
                toolStripProgressBar1.Value += toolStripProgressBar1.Step;//让进度条增加一次
            }
            string selstr1 = "select scode from student where sno ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr2 = "select scode from student where sname ='" + toolStripTextBox1.Text.Trim() + "'";
            SqlCommand myCom1 = new SqlCommand(selstr1, CreateSqlConn.con);
            SqlCommand myCom2 = new SqlCommand(selstr2, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            myCom1.ExecuteNonQuery();
            myCom2.ExecuteNonQuery();
            SqlDataAdapter da;
            DataSet ds;
            dataGridView1.Columns.Clear();
            if (null != myCom1.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode

                da = new SqlDataAdapter("select student.sno ,sname ,score ,cname,course.cno from student,score,course where student.sno = score.sno and" +
 " course.cno = score.cno and student.sno ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);

                //                string s = "select student.sno as 学号,sname as 学生姓名,score as 分数,cname as 课程名称 from student,score,course where student.sno=score.sno and" +
                //" course.cno=score.cno and student.sno IN (SELECT DISTINCT sno FROM score WHERE cno IN (SELECT cno FROM score WHERE tno = " + str + "))";
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 103;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 2) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 103;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }



            }
            if (null != myCom2.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode

                da = new SqlDataAdapter("select student.sno ,sname ,score ,cname  from student,score,course where student.sno=score.sno and" +
 " course.cno=score.cno and student.sno IN (SELECT DISTINCT sno FROM score WHERE cno IN (SELECT cno FROM score WHERE sname = '" + toolStripTextBox1.Text.Trim() + "'))", CreateSqlConn.con);

                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 103;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 2) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 103;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }

            }
            CreateSqlConn.con.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //select tno as 教师号,tname as 姓名,tsex as 性别,tage as 年龄,tposition as 职位,tphone as 电话号码,dname as 学院名 from teacher
            CreateSqlConn.con.Open();
            string selstr = "select tno as 教师号,tname as 姓名,tsex as 性别,tage as 年龄,tposition as 职位,tphone as 电话号码,dname as 学院名 from teacher where tno = '" + str + "'";
            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds, "student");
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 30;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 2) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size(20, 20);
                dataGridView1.DataSource = null;
            }

            CreateSqlConn.con.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //select cname as 课程名,tname as 授课老师,ctime as 上课学期 from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno = '" + mystr + "'";

            CreateSqlConn.con.Open();
            string selstr = "select cname as 课程名,ctime as 课时,ctype as 课程类型,course.cno as 课程号 from course,teach,teacher where course.cno = teach.cno and teacher.tno = teach.tno and teach.tno = '" + str + "'";
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
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            flag = 1;

            CreateSqlConn.con.Open();
            string s = "select student.sno ,sname ,score ,cname,course.cno  from student,score,course where student.sno = score.sno and course.cno = score.cno and tno ='" + str + "'";

            SqlDataAdapter da = new SqlDataAdapter(s, CreateSqlConn.con);

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
                dataGridView1.DataSource = null;
            SqlCommandBuilder b = new SqlCommandBuilder(da);
            da.Update(ds);
            CreateSqlConn.con.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            修改老师密码 change1 = new 修改老师密码(str);
            change1.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            老师增加学生信息 jia = new 老师增加学生信息();
            jia.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {

                int c1;
                CreateSqlConn.con.Open();
                string s1 = "delete from score where sno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and cno='" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "'";

                SqlCommand com1 = new SqlCommand(s1, CreateSqlConn.con);

                c1 = com1.ExecuteNonQuery();


                if (c1 > 0)
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作无效，请点击行首进行删除操作！");
            }
            finally
            {
                CreateSqlConn.con.Close();
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            // select sname,score from student,score,teacher where student.sno=score.sno and score.tno=teacher.tno and score<60 and score.tno=12345
            CreateSqlConn.con.Open();
            // string s = "select sname,score from student,score,teacher where student.sno=score.sno and score.tno=teacher.tno and score<60 and score.tno='"+str+"'";
            string s = "select student.sno ,sname ,score ,cname,course.cno  from student,score,course where student.sno = score.sno and course.cno = score.cno and score<60 and score.tno ='" + str + "'";

            SqlDataAdapter da = new SqlDataAdapter(s, CreateSqlConn.con);

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
                this.dataGridView1.Size = new Size(20, 20);
                dataGridView1.DataSource = null;
            }


            CreateSqlConn.con.Close();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                管理该课程信息 guan = new 管理该课程信息(str, this.dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                guan.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("请用鼠标点击要选择课程的行头再管理该课程！");
            }
        }
    }
}
