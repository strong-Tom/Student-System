# studentsystem
这是个学生成绩管理系统，与SQL server连接实现对数据库的增删查改功能

以下是SQL server中建立数据库的过程：



/*创建学生成绩管理数据库
create database 学生成绩管理
on
(name='学生成绩管理_data',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\学生成绩管理.mdf',
	size=10mb,
	maxsize=100mb,
	filegrowth=10%)
	log on
	(name='学生成绩管理_log',
	filename='C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\学生成绩管理.ldf',
	size=5mb,
	maxsize=10mb,
	filegrowth=1%
	)
	*/

	/*创建老师表
	create table teacher
	(
	tno char(5),
	tname varchar(10) not null,
	tsex char(2)not null,
	tage char(2),
	tposition varchar(10),
	tphone varchar(10),
	dname varchar(20)not null,
	tcode varchar(20)not null,
	constraint teacher_pk primary key(tno),
	constraint teacher_tsex check(tsex in('男','女')),
	constraint teacher_tage check(tage>=23 and tage<=65),
	constraint teacher_dname_fk foreign key(dname) references  dept(dname) on delete cascade,
	)
	*/
	/*创建学院信息表
	create  table dept
	(
	dname varchar(20) not null,
	dphone varchar(10),
	constraint dept_dname primary key(dname)
	)
	*/
	/*创建学生表
	create table student
	(
	sno char(20),
	sname varchar(10),
	ssex char(2)not null,
	sage char(2),
	cclass char(2),
	sphone varchar(10),
	dname varchar(20) not null,
	scode varchar(20)not null,
	constraint student_pk primary key(sno),
	constraint student_ssex check(ssex in('男','女')),
	constraint student_sage check(sage>=10 and sage<=65),
	constraint student_dname_fk foreign key(dname) references  dept(dname) on delete cascade

	)
	*/
	/*创建课程表
	create table course
	(
	cno char(10),
	cname varchar(10),
	ctype varchar(10),
	ctime  char(2),
	constraint course_pk primary key(cno),
    )
	*/
	/*创建班级表
	create table class
	(
	cname varchar(10),
	dname varchar(20)not null,
	cunm char(2),
	constraint class_pk primary key(cname,dname)	 
	)
	*/
	/*创建教师授课表
	create table teach
	(
	tno char(5),
	 cno char(10),
	 troom char(2),
	 ttime char(2),
	 constraint teach_pk primary key(tno,cno),
	 constraint teach_tno_fk foreign key(tno) references  teacher(tno) on delete cascade,
	 constraint teach_cno_fk foreign key(cno) references course(cno) on delete cascade
	)
	*/
	创建学生选课表
	create table score
	(
	sno char(20),
	cno char(10),
	tno char(5),
	score char(2),
	constraint score_pk primary key(sno,cno),
	constraint score_sno_fk foreign key(sno) references student(sno) on delete cascade,
	
	 constraint score_cno_fk foreign key(cno) references course(cno) on delete cascade
	)
