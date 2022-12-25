using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace chendhHW09
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<teacher> teachers = new List<teacher>();
        List<course> courses = new List<course>();
        List<student> students = new List<student>();
        List<Rcord> records = new List<Rcord>();

        student selectedstudent = null;
        teacher selectedteacher = null;
        course selectedcourse = null;
        Rcord selectedrecord = null;

        public MainWindow()
        {
            InitializeComponent();

            InitializeStudent();

            InitializeCourse();
        }

        private void InitializeCourse()
        {
            teacher teacher1 = new teacher() { TeacherName = "陳定宏" };
            // course course1a = new course(teacher1) { CourseName = "視窗程式設計", Type = "選修", OpeningClass = "資工二甲", Point=3 };
            // teacher1.teachingcourses.Add(course1a);
            teacher1.teachingcourses.Add(new course(teacher1) { CourseName = "視窗程式設計", Type = "選修", OpeningClass = "資工二甲", Point = 3 });
            teacher1.teachingcourses.Add(new course(teacher1) { CourseName = "視窗程式設計", Type = "選修", OpeningClass = "資工二乙", Point = 3 });
            teacher1.teachingcourses.Add(new course(teacher1) { CourseName = "視窗程式設計", Type = "必修", OpeningClass = "五專三甲", Point = 3 });
            teachers.Add(teacher1);

            teacher teacher2 = new teacher() { TeacherName = "陳福坤" };
            teacher2.teachingcourses.Add(new course(teacher2) { CourseName = "工程數學", Type = "必修", OpeningClass = "資工二甲", Point = 3 });
            teacher2.teachingcourses.Add(new course(teacher2) { CourseName = "物理", Type = "選修", OpeningClass = "資工二乙", Point = 3 });
            teacher2.teachingcourses.Add(new course(teacher2) { CourseName = "機率與統計", Type = "必修", OpeningClass = "五專三甲", Point = 3 });
            teachers.Add(teacher2);

            teacher teacher3 = new teacher() { TeacherName = "吳建中" };
            teacher3.teachingcourses.Add(new course(teacher3) { CourseName = "物件導向程式設計", Type = "必修", OpeningClass = "五專資工二甲", Point = 2 });
            teacher3.teachingcourses.Add(new course(teacher3) { CourseName = "物件導向程式設計實習", Type = "必修", OpeningClass = "五專資工二甲", Point = 2 });
            teacher3.teachingcourses.Add(new course(teacher3) { CourseName = "linux系統概論", Type = "選修", OpeningClass = "四技資工一甲等合開", Point = 3 });
            teachers.Add(teacher3);

            trvteacher.ItemsSource = teachers;

            foreach (teacher teacher in teachers)
            {
                foreach (course course in teacher.teachingcourses)
                {
                    courses.Add(course);
                }
            }
            lbcourses.ItemsSource = courses;
        }

        private void InitializeStudent()
        {
          
        student student1 = new student() { StudentID = "A1234567890", StudentName = "陳小明" };
        students.Add(student1);
        student student2 = new student() { StudentID = "A1234543210", StudentName = "王小美" };
        students.Add(student2);
        cmbstudent.ItemsSource = students;
            cmbstudent.SelectedIndex = 0;
        }

        private void cmbstudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedstudent = (student)cmbstudent.SelectedItem;
            statuslabel.Content = $"選取學生:{selectedstudent.StudentID} {selectedstudent.StudentName}"; 
        }

        private void trvteacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if(trvteacher.SelectedItem is course)
            {
                selectedcourse = trvteacher.SelectedItem as course;
                selectedteacher = selectedcourse.Tutor;
                statuslabel.Content = $"授課教師:{selectedteacher.TeacherName} / {selectedcourse.CourseName}";
            }
            else if (trvteacher.SelectedItem is teacher)
            {
                selectedteacher = trvteacher.SelectedItem as teacher;
                statuslabel.Content = $"{selectedteacher.TeacherName}總共開設{selectedteacher.teachingcourses.Count}門課程。";
            }
        }

        private void lbcourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedcourse = (course)lbcourses.SelectedItem;
            selectedteacher = selectedcourse.Tutor;
            statuslabel.Content = $"授課教師:{selectedteacher.TeacherName} / {selectedcourse.CourseName}";
        }

        private void registerbutton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedstudent != null &&  selectedcourse != null)
            {
                Rcord currentrecord = new Rcord()
                {
                    SelectedStudent = selectedstudent,
                    SelectedCourse = selectedcourse,
                    TeacherName = selectedcourse.Tutor.TeacherName
                };
                foreach (Rcord r in records)
                {
                    if (r.Equals(currentrecord))
                    {
                        MessageBox.Show($"{selectedstudent.StudentName}已經選過{selectedcourse.CourseName}了,請重新選擇未選擇之課程");
                        return;
                    }
                }
                    records.Add(currentrecord);
                    lvrecords.ItemsSource = records;
                    lvrecords.Items.Refresh();
            }
            else
            {
                MessageBox.Show("請選擇學生或課程", "資料不足");
            }
        }

        private void lvrecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedrecord = (Rcord)lvrecords.SelectedItem;
            if (selectedrecord != null)
            {
                statuslabel.Content = $"{selectedrecord.SelectedStudent.StudentName}選修{selectedrecord.SelectedCourse.CourseName}的選課紀錄";
            }
            
        }

        private void withdrawbutton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedrecord != null)
            {
                records.Remove(selectedrecord);
                lvrecords.ItemsSource = records;
                lvrecords.Items.Refresh();
            }
        }
    }
}
