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
    public partial class 已经废弃的管理员 : Form
    {
         int flag;
        public 已经废弃的管理员()
        {
            InitializeComponent();
        }
        public 已经废弃的管理员(String g)
        {
            InitializeComponent();
        }
        private void 管理员_Load(object sender, EventArgs e)
        {

        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBox1.Text == "增加学生信息")//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();      
                btnColumn1.HeaderText = "学号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "姓名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "性别";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "年龄";
                dataGridView1.Columns.Add(btnColumn4);
                DataGridViewTextBoxColumn btnColumn5 = new DataGridViewTextBoxColumn();
                btnColumn5.HeaderText = "班级";
                dataGridView1.Columns.Add(btnColumn5);
                DataGridViewTextBoxColumn btnColumn6 = new DataGridViewTextBoxColumn();
                btnColumn6.HeaderText = "电话号码";
                dataGridView1.Columns.Add(btnColumn6);
                DataGridViewTextBoxColumn btnColumn7 = new DataGridViewTextBoxColumn();
                btnColumn7.HeaderText = "学院";
                dataGridView1.Columns.Add(btnColumn7);
                DataGridViewTextBoxColumn btnColumn8 = new DataGridViewTextBoxColumn();
                btnColumn8.HeaderText = "登录密码";
                dataGridView1.Columns.Add(btnColumn8);
                flag = 1;
               
            }
            if (comboBox1.Text == "增加老师信息")//--Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 
            {//（教师号，姓名，性别，年龄，职称，电话，所属学院，登录初始密码）； 
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "教师号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "姓名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "性别";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "年龄";
                dataGridView1.Columns.Add(btnColumn4);
                DataGridViewTextBoxColumn btnColumn5 = new DataGridViewTextBoxColumn();
                btnColumn5.HeaderText = "职称";
                dataGridView1.Columns.Add(btnColumn5);
                DataGridViewTextBoxColumn btnColumn6 = new DataGridViewTextBoxColumn();
                btnColumn6.HeaderText = "电话号码";
                dataGridView1.Columns.Add(btnColumn6);
                DataGridViewTextBoxColumn btnColumn7 = new DataGridViewTextBoxColumn();
                btnColumn7.HeaderText = "学院";
                dataGridView1.Columns.Add(btnColumn7);
                DataGridViewTextBoxColumn btnColumn8 = new DataGridViewTextBoxColumn();
                btnColumn8.HeaderText = "登录密码";
                dataGridView1.Columns.Add(btnColumn8);
                flag = 11;

            }
            if (comboBox1.Text == "增加课程信息")//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
            {// 课程表（课程号，课程名，课程类型，课时）； Course（CNo,CName,CType,CTime）;  

                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "课程号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "课程名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "课程类型";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "课时";
                dataGridView1.Columns.Add(btnColumn4);
                flag = 12;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int r = 0;
            string selstr;
            SqlCommand cmd;
            switch (flag)//flag=1为第一个下拉框的第一个文本，flag=11,为第一个下拉框的第二个文本，flag=12位第三个。第二个下拉框为flag=2；
            {
                case 1:
                    //insert into student values('20172','fw','男','21','1','16516','计算机学院','31215')
                    
                    //string selstr = "insert into student values('2017ddddd','老子第4','男','21','1','16516','计算机学院','31215')";
                     selstr = "insert into student values('" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[3].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[5].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[7].Value.ToString()
                          +  "')";
             cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            if(cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("增加数据成功！");
                
            }
            else
            {

                MessageBox.Show("增加数据失败！");

            }
            CreateSqlConn.con.Close(); 
                   
                    break;
                case 11:
                    
                    //string selstr = "insert into student values('2017ddddd','老子第4','男','21','1','16516','计算机学院','31215')";
                     selstr = "insert into teacher values('" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[3].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[5].Value.ToString()
                         + "','" + this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[7].Value.ToString()
                          +  "')";
             cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            if(cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("增加数据成功！");
                
            }
            else
            {

                MessageBox.Show("增加数据失败！");

            }
            CreateSqlConn.con.Close(); 
                    break;
                case 12:

                     //课程表（课程号，课程名，课程类型，课时）； 
                     // Course（CNo,CName,CType,CTime）;  
                    selstr = "insert into course values('" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "','" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "','" + this.dataGridView1.Rows[r].Cells[3].Value.ToString()
                         + "')";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("增加数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("增加数据失败！");

                    }
                    CreateSqlConn.con.Close();
                    break;
                case 2:
                    selstr = "select sno as 学号,sname as 姓名,ssex as 性别,sage as 年龄 ,cclass as 班级,sphone 电话号码,dname as 学院名,scode as 登录密码 from student";
                      cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            cmd.ExecuteNonQuery();
                     SqlDataAdapter da = new SqlDataAdapter(selstr, CreateSqlConn.con);
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
                    //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
            if (ds.Tables[0].Rows.Count != 0)
            {
                this.dataGridView1.DataSource = ds.Tables[0];
            }
            else
                dataGridView1.DataSource = null;
            CreateSqlConn.con.Close(); 
                        break;
                case 21:// where tno ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);
                        selstr = "select tno as 教师号,tname as 姓名,tsex as 性别,tage as 年龄,tposition as 职位,tphone as 电话号码,dname as 学院名,tcode as 登录密码 from teacher";
                        cmd = new SqlCommand(selstr, CreateSqlConn.con);
                        CreateSqlConn.con.Open();
                        cmd.ExecuteNonQuery();
                         da = new SqlDataAdapter(selstr, CreateSqlConn.con);
                         ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        //dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();//清空数据
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            this.dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                            dataGridView1.DataSource = null;
                        CreateSqlConn.con.Close();
                        break;
                case 22:// where tno ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);
                        selstr = "select cno as 课程号,cname as 课程名,ctype as 类型,ctime as 课时 from course";
                        cmd = new SqlCommand(selstr, CreateSqlConn.con);
                        CreateSqlConn.con.Open();
                        cmd.ExecuteNonQuery();
                        da = new SqlDataAdapter(selstr, CreateSqlConn.con);
                        ds = new DataSet();
                        ds.Clear();
                        da.Fill(ds);
                        //dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();//清空数据
                        if (ds.Tables[0].Rows.Count != 0)
                        {
                            this.dataGridView1.DataSource = ds.Tables[0];
                        }
                        else
                            dataGridView1.DataSource = null;
                        CreateSqlConn.con.Close();
                        break;
           case 3:
                        
                        selstr = "delete from student where sno='"+this.dataGridView1.Rows[0].Cells[0].Value.ToString()+"'";
                     cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
            if(cmd.ExecuteNonQuery()>0)
            {
                MessageBox.Show("删除数据成功！");
                
            }
            else
            {

                MessageBox.Show("删除数据失败！");

            }
            CreateSqlConn.con.Close(); 
                    break;
           case 31:

                    selstr = "delete from teacher where tno='" + this.dataGridView1.Rows[0].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("删除数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("删除数据失败！");

                    }
                    CreateSqlConn.con.Close();
                    break;
           case 32:

                    selstr = "delete from course where cno='" + this.dataGridView1.Rows[0].Cells[0].Value.ToString() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("删除数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("删除数据失败！");

                    }
                    CreateSqlConn.con.Close();
                    break;

            }
            CreateSqlConn.con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "查找学生信息")
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据

                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "学号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "姓名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "性别";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "年龄";
                dataGridView1.Columns.Add(btnColumn4);
                DataGridViewTextBoxColumn btnColumn5 = new DataGridViewTextBoxColumn();
                btnColumn5.HeaderText = "班级";
                dataGridView1.Columns.Add(btnColumn5);
                DataGridViewTextBoxColumn btnColumn6 = new DataGridViewTextBoxColumn();
                btnColumn6.HeaderText = "电话号码";
                dataGridView1.Columns.Add(btnColumn6);
                DataGridViewTextBoxColumn btnColumn7 = new DataGridViewTextBoxColumn();
                btnColumn7.HeaderText = "学院";
                dataGridView1.Columns.Add(btnColumn7);
                DataGridViewTextBoxColumn btnColumn8 = new DataGridViewTextBoxColumn();
                btnColumn8.HeaderText = "登录密码";
                dataGridView1.Columns.Add(btnColumn8);
                flag = 2;
            
            }

            if (comboBox2.Text == "查找老师信息")
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
                //Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 
                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "教师号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "姓名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "性别";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "年龄";
                dataGridView1.Columns.Add(btnColumn4);
                DataGridViewTextBoxColumn btnColumn5 = new DataGridViewTextBoxColumn();
                btnColumn5.HeaderText = "职位";
                dataGridView1.Columns.Add(btnColumn5);
                DataGridViewTextBoxColumn btnColumn6 = new DataGridViewTextBoxColumn();
                btnColumn6.HeaderText = "电话号码";
                dataGridView1.Columns.Add(btnColumn6);
                DataGridViewTextBoxColumn btnColumn7 = new DataGridViewTextBoxColumn();
                btnColumn7.HeaderText = "学院";
                dataGridView1.Columns.Add(btnColumn7);
                DataGridViewTextBoxColumn btnColumn8 = new DataGridViewTextBoxColumn();
                btnColumn8.HeaderText = "登录密码";
                dataGridView1.Columns.Add(btnColumn8);
                flag = 21;

            }
            if (comboBox2.Text == "查找课程信息")
            {//Course（CNo,CName,CType,CTime）;  
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据
             
                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "课程号";
                dataGridView1.Columns.Add(btnColumn1);
                DataGridViewTextBoxColumn btnColumn2 = new DataGridViewTextBoxColumn();
                btnColumn2.HeaderText = "课程名";
                dataGridView1.Columns.Add(btnColumn2);
                DataGridViewTextBoxColumn btnColumn3 = new DataGridViewTextBoxColumn();
                btnColumn3.HeaderText = "课程类型";
                dataGridView1.Columns.Add(btnColumn3);
                DataGridViewTextBoxColumn btnColumn4 = new DataGridViewTextBoxColumn();
                btnColumn4.HeaderText = "课时";
                dataGridView1.Columns.Add(btnColumn4);
          
                flag = 22;

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "删除学生信息")
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据

                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "学号";
                dataGridView1.Columns.Add(btnColumn1);

                flag = 3;
            }
            if (comboBox3.Text == "删除老师信息")
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据

                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "教师号";
                dataGridView1.Columns.Add(btnColumn1);

                flag = 31;
            }
            if (comboBox3.Text == "删除课程信息")
            {
                //dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();//清空数据

                DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
                btnColumn1.HeaderText = "课程号";
                dataGridView1.Columns.Add(btnColumn1);

                flag = 32;
            }
            
        }

        //private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox4.Text == "修改学生信息")//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
        //    {
        //        //dataGridView1.Rows.Clear();
        //        dataGridView1.Columns.Clear();//清空数据
        //        DataGridViewTextBoxColumn btnColumn1 = new DataGridViewTextBoxColumn();
        //        btnColumn1.HeaderText = "学号";
        //        dataGridView1.Columns.Add(btnColumn1);           
        //        flag = 4;               
        //    }
            
        //}
        int alter;//定义一个变量随着查询的号码的不同类别而改变alter=1时是查询的学生信息，2是老师，3是课程
        private void button1_Click_1(object sender, EventArgs e)
        {

            
            string selstr = "select scode from student where sno ='" + textBox1.Text.Trim() + "'";
            string selstr1="select tcode from teacher where tno ='" + textBox1.Text.Trim() + "'";
             string selstr2="select cno from course where cno ='" + textBox1.Text.Trim() + "'";
             string selstr3 = "select scode from student where sname ='" + textBox1.Text.Trim() + "'";
             string selstr4 = "select tcode from teacher where tname ='" + textBox1.Text.Trim() + "'";
             string selstr5 = "select cno from course where cname ='" + textBox1.Text.Trim() + "'";
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
                      alter = 1;
                       da = new SqlDataAdapter("select sno as 学号,sname as 姓名,ssex as 性别,sage as 年龄 ,cclass as 班级,sphone 电话号码,dname as 学院名,scode as 登录密码 from student where sno ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);
                      
                       ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;


                  }
                  if(null != myCom1.ExecuteScalar())
                  {//Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 
                      alter = 2;
                      da = new SqlDataAdapter("select tno as 教师号,tname as 姓名,tsex as 性别,tage as 年龄,tposition as 职位,tphone as 电话号码,dname as 学院名,tcode as 登录密码 from teacher where tno ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);

                      ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;

                  }
                  if (null != myCom2.ExecuteScalar())
                  {//Course（CNo,CName,CType,CTime）;  
                      alter = 3;
                      da = new SqlDataAdapter("select cno as 课程号,cname as 课程名,ctype as 类型,ctime as 课时 from course where cno ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);

                      ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;

                  }
                  if (null != myCom3.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
                  {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                      //,sname,ssex,sage,cclass,sphone,dname,scode
                      alter = 4;
                      da = new SqlDataAdapter("select sno as 学号,sname as 姓名,ssex as 性别,sage as 年龄 ,cclass as 班级,sphone 电话号码,dname as 学院名,scode as 登录密码 from student where sname ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);

                      ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;


                  }
                  if (null != myCom4.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
                  {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                      //,sname,ssex,sage,cclass,sphone,dname,scode
                      alter = 5;
                      da = new SqlDataAdapter("select tno as 教师号,tname as 姓名,tsex as 性别,tage as 年龄,tposition as 职位,tphone as 电话号码,dname as 学院名,tcode as 登录密码 from teacher where tname ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);

                      ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;


                  }
                  if (null != myCom5.ExecuteScalar())//&& myCom.ExecuteScalar().ToString() == textBox1.Text.Trim()
                  {//Student（SNo,SName,SSex,SAge,CClass,SPhone,DName,SCode）; 
                      //,sname,ssex,sage,cclass,sphone,dname,scode
                      alter = 6;
                      da = new SqlDataAdapter("select cno as 课程号,cname as 课程名,ctype as 类型,ctime as 课时 from course where cname ='" + textBox1.Text.Trim() + "'", CreateSqlConn.con);

                      ds = new DataSet();
                      ds.Clear();
                      da.Fill(ds);

                      if (ds.Tables[0].Rows.Count != 0)
                      {
                          this.dataGridView1.DataSource = ds.Tables[0];
                      }
                      else
                          dataGridView1.DataSource = null;


                  }
                  if (null == myCom.ExecuteScalar() && null == myCom1.ExecuteScalar() && null == myCom2.ExecuteScalar() && null == myCom3.ExecuteScalar()
                      && null == myCom4.ExecuteScalar() && null == myCom5.ExecuteScalar())
                 {
                     MessageBox.Show("查找失败，请检查输入是否有误！");  


                    }

              //}
           
            CreateSqlConn.con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //insert into student values('20172','fw','男','21','1','16516','计算机学院','31215')
            int r = 0;
            //string selstr = "insert into student values('2017ddddd','老子第4','男','21','1','16516','计算机学院','31215')";
            string selstr;
            SqlCommand cmd;
            switch (alter)
            {
                case 1: //update student set sno='000',sname='hello',ssex='男',sage='23',cclass='1',sphone='22222',dname='计算机学院',scode='33326' where sno='1'
                    selstr = "update student set sno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',sname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',ssex='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',sage='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString() + "',cclass='" +
                        this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "',sphone='" + this.dataGridView1.Rows[r].Cells[5].Value.ToString() + "',dname='" +
                        this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "',scode='" + this.dataGridView1.Rows[r].Cells[7].Value.ToString() + "' where sno='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("修改数据成功！");

            }
            else
            {

                MessageBox.Show("修改数据失败！");

            }
            CreateSqlConn.con.Close();
                    
                    
                    break;
                case 2: //Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 
                    //update teacher set tno='',tname='',tsex='',tage='',tposition='',tphone='',dname='',tcode='' where tno=''
                    selstr = "update teacher set tno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',tname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',tsex='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',tage='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString() + "',tposition='" +
                        this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "',tphone='" + this.dataGridView1.Rows[r].Cells[5].Value.ToString() + "',dname='" +
                        this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "',tcode='" + this.dataGridView1.Rows[r].Cells[7].Value.ToString() + "' where tno='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("修改数据成功！");

            }
            else
            {

                MessageBox.Show("修改数据失败！");

            }
            CreateSqlConn.con.Close();
                        
                    break;
                case 3: //Course（CNo,CName,CType,CTime）;
                    selstr = "update course set cno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',cname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',ctype='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',ctime='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString() 
                        + "' where cno='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
            CreateSqlConn.con.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("修改数据成功！");

            }
            else
            {

                MessageBox.Show("修改数据失败！");

            }
            CreateSqlConn.con.Close();
                    
                    break;
                case 4: //update student set sno='000',sname='hello',ssex='男',sage='23',cclass='1',sphone='22222',dname='计算机学院',scode='33326' where sno='1'
                    selstr = "update student set sno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',sname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',ssex='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',sage='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString() + "',cclass='" +
                        this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "',sphone='" + this.dataGridView1.Rows[r].Cells[5].Value.ToString() + "',dname='" +
                        this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "',scode='" + this.dataGridView1.Rows[r].Cells[7].Value.ToString() + "' where sname='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("修改数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("修改数据失败！");

                    }
                    CreateSqlConn.con.Close();


                    break;
                case 5: //Teacher（TNo,TName,TSex,TAge,TPosition,TPhone,DName,TCode）; 
                    //update teacher set tno='',tname='',tsex='',tage='',tposition='',tphone='',dname='',tcode='' where tno=''
                    selstr = "update teacher set tno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',tname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',tsex='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',tage='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString() + "',tposition='" +
                        this.dataGridView1.Rows[r].Cells[4].Value.ToString() + "',tphone='" + this.dataGridView1.Rows[r].Cells[5].Value.ToString() + "',dname='" +
                        this.dataGridView1.Rows[r].Cells[6].Value.ToString() + "',tcode='" + this.dataGridView1.Rows[r].Cells[7].Value.ToString() + "' where tname='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("修改数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("修改数据失败！");

                    }
                    CreateSqlConn.con.Close();

                    break;
                case 6: //Course（CNo,CName,CType,CTime）;
                    selstr = "update course set cno='" + this.dataGridView1.Rows[r].Cells[0].Value.ToString() + "',cname='" + this.dataGridView1.Rows[r].Cells[1].Value.ToString()
                        + "',ctype='" + this.dataGridView1.Rows[r].Cells[2].Value.ToString() + "',ctime='" + this.dataGridView1.Rows[r].Cells[3].Value.ToString()
                        + "' where cname='" + textBox1.Text.Trim() + "'";
                    cmd = new SqlCommand(selstr, CreateSqlConn.con);
                    CreateSqlConn.con.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("修改数据成功！");

                    }
                    else
                    {

                        MessageBox.Show("修改数据失败！");

                    }
                    CreateSqlConn.con.Close();

                    break;

            }
           
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
