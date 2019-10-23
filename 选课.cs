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
    public partial class 选课 : Form
    {
        string str;
        public 选课()
        {
            InitializeComponent();
            try
            {
                string strda = "  select distinct course.cno,cname,ctype,ctime,tname from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno";

                CreateSqlConn.con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(strda, CreateSqlConn.con);
                da.Fill(ds, "显示数据");
                CreateSqlConn.con.Close();
                dataGridView1.AutoGenerateColumns = true;//自动创建列
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;//单击单元格编辑
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 103;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        public 选课(string mystr)
        {
            InitializeComponent();
            str = mystr;
            try
            {
                string strda = "  select distinct course.cno,cname,ctype,ctime,tname from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno";

                CreateSqlConn.con.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(strda, CreateSqlConn.con);
                da.Fill(ds, "显示数据");
                CreateSqlConn.con.Close();
                dataGridView1.AutoGenerateColumns = true;//自动创建列
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;//单击单元格编辑
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
        static class CreateSqlConn
        {

            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

//        private void button1_Click(object sender, EventArgs e)//选课操作
//        {
          
//            //insert into score values('20171101','04','71','') 要插入的数据 values(sno,cno,tno)
//            //解决办法是先用表中的教师姓名执行查询得到tno
//            //dataGridView1.CurrentCell.Value  当前单元格的内容
//            //要获取当前选定行，名称叫"Name"的单元格，你可以这样
//            //dataGridView.SelectedRows[0].Cells["Name"].Value.ToString()
//            try
//            {
//                int c1;
//                string s1 = "select tno from teacher where tname='" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "'";
//                SqlCommand com0 = new SqlCommand(s1, CreateSqlConn.con);
//                CreateSqlConn.con.Open();
//                String gettno = com0.ExecuteScalar().ToString();

//                string s2 = "insert into score values('" + str + "','" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "','" + gettno + "','')";

//                SqlCommand com1 = new SqlCommand(s2, CreateSqlConn.con);

//                c1 = com1.ExecuteNonQuery();


//                if (c1 > 0)
//                    MessageBox.Show("选课成功！");
//                else
//                    MessageBox.Show("选课失败！");
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show("请先选择，再按此按钮！");
//            }

//            finally
//            {
//                CreateSqlConn.con.Close();
//            }
            
//        }

//        private void button2_Click(object sender, EventArgs e)//删除选课信息
//        {
//            try
//            {
//                string s = "delete from score  where cno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and sno='"+str+"'";
//                CreateSqlConn.con.Open();
//                SqlCommand com = new SqlCommand(s, CreateSqlConn.con);
//                if (com.ExecuteNonQuery() > 0)
//                    MessageBox.Show("删除成功！");
//                else
//                    MessageBox.Show("删除失败！");
//            }
//            catch(Exception ex)
//            {
//                MessageBox.Show("请先选择，再按此按钮！");
//            }
//            finally
//            {
//                CreateSqlConn.con.Close();
//            }
            
//        }

//        private void button3_Click(object sender, EventArgs e)//查询已选修
//        {
//            //select distinct course.cno,cname,ctype,ctime,tname,troom,ttime from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno 
////and course.cno  in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='2')--查询已选课程信息
//            CreateSqlConn.con.Open();
//            //string selstr = "select cname ,tname ,ctime  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno = '" + str + "'";
//            string selstr = "select distinct course.cno,cname,ctype,ctime,tname  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='"+str+"'";
//            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
//            DataSet ds = new DataSet();
//            ds.Clear();
//            da.Fill(ds);
//            if (ds.Tables[0].Rows.Count != 0)
//            {
//                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
//                dataGridView1.ColumnHeadersHeight = 25;
//                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
//                dataGridView1.RowHeadersWidth = 103;
//                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
//                this.dataGridView1.DataSource = ds.Tables[0];
//            }
//            else
//                dataGridView1.DataSource = null;
//            CreateSqlConn.con.Close();
//        }

//        private void button4_Click(object sender, EventArgs e)//查询未选修
//        {
//            //select distinct course.cno,cname,ctype,ctime,tname,troom,ttime from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno 
//            //and course.cno  in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='2')--查询已选课程信息
//            CreateSqlConn.con.Open();
//            //string selstr = "select cname ,tname ,ctime  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno = '" + str + "'";
//            string selstr = "select distinct course.cno,cname,ctype,ctime,tname from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno" +
//" and course.cno not in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='" + str + "')";
//            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
//            DataSet ds = new DataSet();
//            ds.Clear();
//            da.Fill(ds);
//            if (ds.Tables[0].Rows.Count != 0)
//            {
//                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
//                dataGridView1.ColumnHeadersHeight = 25;
//                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
//                dataGridView1.RowHeadersWidth = 103;
//                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
//                this.dataGridView1.DataSource = ds.Tables[0];
//            }
//            else
//                dataGridView1.DataSource = null;
//            CreateSqlConn.con.Close();
//        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //insert into score values('20171101','04','71','') 要插入的数据 values(sno,cno,tno)
            //解决办法是先用表中的教师姓名执行查询得到tno
            //dataGridView1.CurrentCell.Value  当前单元格的内容
            //要获取当前选定行，名称叫"Name"的单元格，你可以这样
            //dataGridView.SelectedRows[0].Cells["Name"].Value.ToString()
            try
            {
                int c1;
                string s1 = "select tno from teacher where tname='" + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + "'";
                SqlCommand com0 = new SqlCommand(s1, CreateSqlConn.con);
                CreateSqlConn.con.Open();
                String gettno = com0.ExecuteScalar().ToString();

                string s2 = "insert into score values('" + str + "','" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "','" + gettno + "','')";//sno,cno,tno

                SqlCommand com1 = new SqlCommand(s2, CreateSqlConn.con);

                c1 = com1.ExecuteNonQuery();


                if (c1 > 0)
                    MessageBox.Show("选课成功！");
                else
                    MessageBox.Show("选课失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先选择，再按此按钮！");
            }

            finally
            {
                CreateSqlConn.con.Close();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "delete from score  where cno='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and sno='" + str + "'";
                CreateSqlConn.con.Open();
                SqlCommand com = new SqlCommand(s, CreateSqlConn.con);
                if (com.ExecuteNonQuery() > 0)
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("请先选择，再按此按钮！");
            }
            finally
            {
                CreateSqlConn.con.Close();
            }

        }



        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //select distinct course.cno,cname,ctype,ctime,tname,troom,ttime from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno 
            //and course.cno  in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='2')--查询已选课程信息
            CreateSqlConn.con.Open();
            //string selstr = "select cname ,tname ,ctime  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno = '" + str + "'";
            string selstr = "select distinct course.cno,cname,ctype,ctime,tname  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='" + str + "'";
            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 30;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //select distinct course.cno,cname,ctype,ctime,tname,troom,ttime from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno 
            //and course.cno  in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='2')--查询已选课程信息
            CreateSqlConn.con.Open();
            //string selstr = "select cname ,tname ,ctime  from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno = '" + str + "'";
            string selstr = "select distinct course.cno,cname,ctype,ctime,tname from course,teacher,teach where course.cno=teach.cno and teach.tno=teacher.tno" +
" and course.cno not in (select course.cno from course,score,teacher where course.cno = score.cno and teacher.tno = score.tno and sno ='" + str + "')";
            SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 30;
                this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close();
        }
    }
}
