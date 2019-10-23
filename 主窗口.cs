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


   
    public partial class 主窗口 : Form
    {
        
        int sg;
        public 主窗口()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


             if (m_name.Text.Trim() == "")
            { label4.Text = "请输入用户名！";
     
           
           
            } 
           
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            switch(sg)
            {

                case 1:
                    if (m_name.Text.Trim() == "")   //m_name可能是文本框
                        label4.Text = "请输入用户名！";
                    else
                    {
                        CreateSqlConn.con.Open();
                        SqlCommand myCom = new SqlCommand("select scode from student where sno ='" + m_name.Text.Trim() + "'", CreateSqlConn.con);
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (null != myCom.ExecuteScalar() && m_password.Text.Trim() == myCom.ExecuteScalar().ToString())
                        {
                            CreateSqlConn.con.Close();
                            学生窗口 stu = new 学生窗口(m_name.Text.Trim());
                            stu.Show();
                            //this.Hide();
                        }
                        else
                        {
                            label5.Text = "请输入正确密码！";
                            CreateSqlConn.con.Close();
                        }
                    }
                    break;
               
                case 2:
                    if (m_name.Text.Trim() == "")
                        label4.Text = "请输入用户名！";
                    else
                    {
                        CreateSqlConn.con.Open();
                        SqlCommand myCom = new SqlCommand("select TCode from Teacher where Tno ='" + m_name.Text.Trim() + "'", CreateSqlConn.con);
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (null != myCom.ExecuteScalar() && m_password.Text.Trim() == myCom.ExecuteScalar().ToString())
                        {
                            CreateSqlConn.con.Close();
                           老师窗口 tea = new 老师窗口(m_name.Text.Trim());
                            tea.Show();
                            //this.Hide();
                        }
                        else
                        {
                            label5.Text = "请输入正确密码！";
                            CreateSqlConn.con.Close();
                        }
                    }
                    break;
                case 3:
                    if (m_name.Text.Trim() == "")
                        label4.Text = "请输入用户名！";
                     else if (m_name.Text.Trim() !="admin" )
                        label4.Text = "请输入正确的用户名！";
                    else
                    {
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (m_password.Text.Trim() != "000000")
                            label5.Text = "请输入正确的密码！";
                        else
                        {
                            管理员界面 admin = new 管理员界面();
                            admin.Show();
                        }


                    }
                  
                    break;
                    
              


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void 主窗口_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void m_password_MouseClick(object sender, MouseEventArgs e)
        {
            m_password.Text = "";
        }

        private void m_name_MouseClick(object sender, MouseEventArgs e)
        {
            m_name.Text = "";
            if (m_name.Text.Trim() == "")
                m_password.Text = "";
        }

      

        private void button2_Click_1(object sender, EventArgs e)
        {
            switch (sg)
            {

                case 1:
                    if (m_name.Text.Trim() == "")   //m_name可能是文本框
                        label4.Text = "请输入用户名！";
                    else
                    {
                        CreateSqlConn.con.Open();
                        SqlCommand myCom = new SqlCommand("select scode from student where sno ='" + m_name.Text.Trim() + "'", CreateSqlConn.con);
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (null != myCom.ExecuteScalar() && m_password.Text.Trim() == myCom.ExecuteScalar().ToString())
                        {
                            CreateSqlConn.con.Close();
                            学生窗口 stu = new 学生窗口(m_name.Text.Trim());
                            stu.Show();
                            //this.Hide();
                        }
                        else
                        {
                            label5.Text = "请输入正确密码！";
                            CreateSqlConn.con.Close();
                        }
                    }
                    break;

                case 2:
                    if (m_name.Text.Trim() == "")
                        label4.Text = "请输入用户名！";
                    else
                    {
                        CreateSqlConn.con.Open();
                        SqlCommand myCom = new SqlCommand("select TCode from Teacher where Tno ='" + m_name.Text.Trim() + "'", CreateSqlConn.con);
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (null != myCom.ExecuteScalar() && m_password.Text.Trim() == myCom.ExecuteScalar().ToString())
                        {
                            CreateSqlConn.con.Close();
                            老师窗口 tea = new 老师窗口(m_name.Text.Trim());
                            tea.Show();
                            //this.Hide();
                        }
                        else
                        {
                            label5.Text = "请输入正确密码！";
                            CreateSqlConn.con.Close();
                        }
                    }
                    break;
                case 3:
                    if (m_name.Text.Trim() == "")
                        label4.Text = "请输入用户名！";
                    else if (m_name.Text.Trim() != "admin")
                        label4.Text = "请输入正确的用户名！";
                    else
                    {
                        if (m_password.Text.Trim() == "")
                            label5.Text = "请输入密码！";
                        else if (m_password.Text.Trim() != "000000")
                            label5.Text = "请输入正确的密码！";
                        else
                        {
                            管理员界面 admin = new 管理员界面();
                            admin.Show();
                        }


                    }

                    break;




            }
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            sg = 2;
        }

        private void m_name_Click(object sender, EventArgs e)
        {
            m_name.Text = "";
        }

        private void m_name_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (m_name.Text.Trim() == "admin")
            {
                m_password.Text = "000000";
                pictureBox2.Image = Image.FromFile("C:\\Users\\zt\\Pictures\\施瓦辛格.jpg");
                
            }
                
            if (m_name.Text.Trim() == "20171101")
            {
                pictureBox2.Image = Image.FromFile("C:\\Users\\zt\\Pictures\\杰森斯坦森.jpg");
                m_password.Text = "666666";
            }
               
            if (m_name.Text.Trim() == "12345")
            {
                m_password.Text = "123456";
                pictureBox2.Image = Image.FromFile("C:\\Users\\zt\\Pictures\\史泰龙.jpg");
            }
               
            if (m_name.Text.Trim() == "20171001")
            {
                m_password.Text = "666666";
                pictureBox2.Image = Image.FromFile("C:\\Users\\zt\\Pictures\\张曦月.png");
            }
                
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            sg = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sg = 3;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
