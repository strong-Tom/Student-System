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
    public partial class 平均成绩 : Form
    {
        String avgstr;
        public 平均成绩()
        {
            InitializeComponent();
        }
        static class CreateSqlConn
        {
            public static string ConnectionString = "Data Source=.;Initial Catalog= 学生成绩管理;Integrated Security=SSPI";
            //连接数据库字段，作为非系统管理员
            public static SqlConnection con = new SqlConnection(ConnectionString);  //创建一个连接对象
        }
        public 平均成绩(String a)
        {
           
             InitializeComponent();
            avgstr = a;
            CreateSqlConn.con.Open();
            SqlCommand aveCom = new SqlCommand("select avg(score)  from score where sno ='" +avgstr + "'", CreateSqlConn.con);
           // SqlDataReader avedr = aveCom.ExecuteReader(CommandBehavior.CloseConnection);
            object ave = aveCom.ExecuteScalar();;
           // double(ave) 
            label1.Text =ave.ToString();
            CreateSqlConn.con.Close();
        }
        

        private void 平均成绩_Load(object sender, EventArgs e)
        {

        }
    }
}
