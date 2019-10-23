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
    public partial class 管理员界面 : Form
    {
        public 管理员界面()
        {
            InitializeComponent();
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);//把他看成监听器就好
        }
        static class CreateSqlConn
        {

            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        int flag;
      
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string strcomm="select * from dept";
                string strcolumn = dataGridView1.Columns[e.ColumnIndex].HeaderText;//获取列标题
                string strrow = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();//获取焦点触发行的第一个值
                string value = dataGridView1.CurrentCell.Value.ToString();//获取当前点击的活动单元格的值
                
                switch(flag)
                {
                    case 1: strcomm = "update student set " + strcolumn + "='" + value + "' where sno = '" + strrow + "'"; 
                        break;
                    case 2: strcomm = "update teacher set " + strcolumn + "='" + value + "' where tno = '" + strrow + "'";
                        break;
                    case 3: strcomm = "update course set " + strcolumn + "='" + value + "' where cno = '" + strrow + "'";
                        break;
                }
                 
                //update FilTer set 列名 = value where id = 3
                CreateSqlConn.con.Open();
                SqlCommand comm = new SqlCommand(strcomm, CreateSqlConn.con);
                comm.ExecuteNonQuery();
                if (comm.ExecuteNonQuery() > 0)
                    MessageBox.Show("修改成功！");
                else
                    MessageBox.Show("修改失败！");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            finally
            {
                CreateSqlConn.con.Close();
            }
        }

        

        private void button5_Click(object sender, EventArgs e)//删除
        {
            int count, c1, c2, c3;
            CreateSqlConn.con.Open();
            string s1 = "delete from student where sno='" + dataGridView1.CurrentCell.Value + "'";
            string s2 = "delete from teacher where tno='" + dataGridView1.CurrentCell.Value + "'";
            string s3 = "delete from course where cno='" + dataGridView1.CurrentCell.Value + "'";
            SqlCommand com1 = new SqlCommand(s1, CreateSqlConn.con);
            SqlCommand com2 = new SqlCommand(s2, CreateSqlConn.con);
            SqlCommand com3 = new SqlCommand(s3, CreateSqlConn.con);
            c1 = com1.ExecuteNonQuery();
            c2 = com1.ExecuteNonQuery();
            c3 = com1.ExecuteNonQuery();
            count = c1 + c2 + c3;
            if (count > 0)
                MessageBox.Show("删除成功！");
            else
                MessageBox.Show("删除失败！");


            CreateSqlConn.con.Close();
        }

        private void button6_Click(object sender, EventArgs e)//增加学生信息
        {
            增加学生信息 plus = new 增加学生信息();
            plus.Show();
        }

        private void button7_Click(object sender, EventArgs e)//增加老师信息
        {
            增加老师信息 plus1 = new 增加老师信息();
            plus1.Show();
        }

        private void button8_Click(object sender, EventArgs e)//增加课程信息
        {
            增加课程信息 plus2 = new 增加课程信息();
            plus2.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            修改学生成绩 xiu = new 修改学生成绩();
            xiu.Show();
        }

      

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            flag = 1;
            try
            {
                string strda = "select * from student";

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            flag = 2;
            try
            {
                string strda = "select * from teacher";

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

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            flag = 3;
            try
            {
                string strda = "select * from course";

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

        private void toolStripButton4_Click(object sender, EventArgs e)
        {//toolStripTextBox1
            toolStripProgressBar1.Maximum = 100;//设置最大长度值
            toolStripProgressBar1.Value = 0;//设置当前值
            toolStripProgressBar1.Step = 10;//设置没次增长多少
            for (int i = 0; i < 10; i++)//循环
            {
            System.Threading.Thread.Sleep(50);//暂停1秒
            toolStripProgressBar1.Value += toolStripProgressBar1.Step;//让进度条增加一次
            }
            string selstr = "select scode from student where sno ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr1 = "select tcode from teacher where tno ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr2 = "select cno from course where cno ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr3 = "select scode from student where sname ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr4 = "select tcode from teacher where tname ='" + toolStripTextBox1.Text.Trim() + "'";
            string selstr5 = "select cno from course where cname ='" + toolStripTextBox1.Text.Trim() + "'";
            SqlCommand myCom = new SqlCommand(selstr, CreateSqlConn.con);//学号
            SqlCommand myCom1 = new SqlCommand(selstr1, CreateSqlConn.con);//教师号
            SqlCommand myCom2 = new SqlCommand(selstr2, CreateSqlConn.con);//课程号
            SqlCommand myCom3 = new SqlCommand(selstr3, CreateSqlConn.con);
            SqlCommand myCom4 = new SqlCommand(selstr4, CreateSqlConn.con);
            SqlCommand myCom5 = new SqlCommand(selstr5, CreateSqlConn.con);
            CreateSqlConn.con.Open();

            SqlDataAdapter da;
            DataSet ds;
            dataGridView1.Columns.Clear();
            if (null != myCom.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode
                flag = 1;//flag用于表示哪种表对应的修改状态
                da = new SqlDataAdapter("select sno ,sname ,ssex ,sage  ,cclass ,sphone ,dname ,scode  from student where sno ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);

                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }



            }
            if (null != myCom1.ExecuteScalar())
            {//Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 

                da = new SqlDataAdapter("select tno ,tname ,tsex ,tage,tposition ,tphone ,dname ,tcode  from teacher where tno ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);
                flag = 2;
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }

            }
            if (null != myCom2.ExecuteScalar())
            {//Course（CNo,CName,CType,CTime）;  

                da = new SqlDataAdapter("select cno ,cname ,ctype ,ctime  from course where cno ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);
                flag = 3;
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }

            }
            if (null != myCom3.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode

                da = new SqlDataAdapter("select sno ,sname ,ssex ,sage  ,cclass ,sphone ,dname ,scode  from student where sname ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);
                flag = 1;

                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }


            }
            if (null != myCom4.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode

                da = new SqlDataAdapter("select tno ,tname ,tsex ,tage ,tposition ,tphone ,dname ,tcode  from teacher where tname ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);
                flag = 2;
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }


            }
            if (null != myCom5.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
            {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                //,sname,ssex,sage,cclass,sphone,dname,scode

                da = new SqlDataAdapter("select cno ,cname ,ctype ,ctime  from course where cname ='" + toolStripTextBox1.Text.Trim() + "'", CreateSqlConn.con);
                flag = 3;
                ds = new DataSet();
                ds.Clear();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size((ds.Tables[0].Columns.Count + 1) * 103, (ds.Tables[0].Rows.Count + 1) * 25);
                    this.dataGridView1.DataSource = ds.Tables[0];
                }
                else
                {
                    dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                    dataGridView1.ColumnHeadersHeight = 25;
                    dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                    dataGridView1.RowHeadersWidth = 20;
                    this.dataGridView1.Size = new Size(20, 20);
                    dataGridView1.DataSource = null;
                }


            }
            if (null == myCom.ExecuteScalar() && null == myCom1.ExecuteScalar() && null == myCom2.ExecuteScalar() && null == myCom3.ExecuteScalar()
                && null == myCom4.ExecuteScalar() && null == myCom5.ExecuteScalar())
            {
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 25;
                dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
                dataGridView1.RowHeadersWidth = 20;
                this.dataGridView1.Size = new Size(20, 20);
                dataGridView1.DataSource = null;
                MessageBox.Show("查找失败，请检查输入是否有误！");


            }

            //}

            CreateSqlConn.con.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            增加学生信息 plus = new 增加学生信息();
            plus.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            增加老师信息 plus1 = new 增加老师信息();
            plus1.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            增加课程信息 plus2 = new 增加课程信息();
            plus2.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            int count, c1, c2, c3;
            try
            {
                CreateSqlConn.con.Open();
                string s1 = "delete from student where sno='" + dataGridView1.CurrentCell.Value + "'";
                string s2 = "delete from teacher where tno='" + dataGridView1.CurrentCell.Value + "'";
                string s3 = "delete from course where cno='" + dataGridView1.CurrentCell.Value + "'";
                SqlCommand com1 = new SqlCommand(s1, CreateSqlConn.con);
                SqlCommand com2 = new SqlCommand(s2, CreateSqlConn.con);
                SqlCommand com3 = new SqlCommand(s3, CreateSqlConn.con);
                c1 = com1.ExecuteNonQuery();
                c2 = com1.ExecuteNonQuery();
                c3 = com1.ExecuteNonQuery();
                count = c1 + c2 + c3;
                if (count > 0)
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除失败！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("请先选择要删除的选项!");
            }

            CreateSqlConn.con.Close();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            修改学生成绩 xiu = new 修改学生成绩();
            xiu.Show();
        }
    }
}
