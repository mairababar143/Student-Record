using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAssignment2
{
    public partial class Form1 : Form
    {
        RadioButton[] rObj = new RadioButton[50];
        Student s;
        string name, depart, uni, studentID, attend;
        int sem,counter;
        double dcgpa;
        float cgpa;
        char[] attendance = new char[50];
        public Form1()
        {
            s = new Student();
            InitializeComponent();
            panelDisplay.Hide();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelDelStudent.Hide();
            panelViewAtt.Hide();
            panelTop3.Hide();
            panelMark.Hide();
            s.GetInfo();
            name = depart = uni = studentID = attend = " ";
            sem =counter= 0;
            dcgpa = 0;
            cgpa = 0;
            panelStart.Location = new Point(0, 27);
            panelStart.Size = new Size(1234, 645);
            pictureBoxStart.Location = new Point(0, 0);
            pictureBoxStart.Size = new Size(850, 400);
            panelDelStudent.Location = new Point(0, 50);
            panelDelStudent.Size = new Size(1234, 645);
            panelNewStud.Location = new Point(0, 50);
            panelNewStud.Size = new Size(1234, 645);
            panelSearchID.Location = new Point(0, 50);
            panelSearchID.Size = new Size(1234, 645);
            panelSearchName.Location = new Point(0, 50);
            panelSearchName.Size = new Size(1234, 645);
            panelTop3.Location = new Point(0, 50);
            panelTop3.Size = new Size(1234, 645);
            panelViewAtt.Location = new Point(0, 50);
            panelViewAtt.Size = new Size(1234, 645);
            panelMark.Location = new Point(0, 50);
            panelMark.Size = new Size(1234, 645);
            panelDisplay.Location = new Point(0, 50);
            panelDisplay.Size = new Size(1234, 645);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNewStud.Show();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelTop3.Hide();
            panelDelStudent.Hide();
            panelStart.Hide();
            panelViewAtt.Hide();
            panelMark.Hide();
            panelDisplay.Hide();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDelStudent.Show();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelTop3.Hide();
            panelStart.Hide();
            panelViewAtt.Hide();
            panelMark.Hide();
            panelDisplay.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void seachByIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNewStud.Hide();
            panelSearchID.Show();
            panelSearchName.Hide();
            panelTop3.Hide();
            panelDelStudent.Hide();
            panelStart.Hide();
            panelViewAtt.Hide();
            panelMark.Hide();
            panelDisplay.Hide();
            richTextBoxSearchID.Text = string.Empty;
        }

        private void searchbyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            panelSearchName.Show();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelTop3.Hide();
            panelDelStudent.Hide();
            panelStart.Hide();
            panelViewAtt.Hide();
            panelMark.Hide();
            panelDisplay.Hide();
            richTextBoxStudName.Text = string.Empty;
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
        }

        private void panelDelStud_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSearchName_Click(object sender, EventArgs e)
        {
            richTextBoxStudName.Text.DefaultIfEmpty();
            richTextBoxStudName.ReadOnly = true;
            richTextBoxStudName.BackColor = Color.White;
            string[] nameArray = new string[50];
            string name = textBoxStudentName.Text;
            nameArray = s.SearchName(name);
            richTextBoxStudName.Text = "ID\t\tStudent Name\t\tAttendance\t\tCGPA\t\tSemester\tDepartment\tUniversity\n\n";
            for (int i = 0; i < nameArray.Length; i++)
            {
                richTextBoxStudName.Text += nameArray[i];
            }
            textBoxStudentName.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            richTextBoxSearchID.Text.DefaultIfEmpty();
            richTextBoxSearchID.ReadOnly = true;
            richTextBoxSearchID.BackColor = Color.White;
            string searchId = "";
            string id = textBoxSearchID.Text;
            searchId = s.SearchID(id);
            richTextBoxSearchID.Text = "ID\t\tStudent Name\t\tAttendance\t\tCGPA\t\tSemester\tDepartment\tUniversity\n\n";
            richTextBoxSearchID.Text += searchId;
            textBoxSearchID.Text = string.Empty;
        }

        private void panelTop3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void top3StudentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            panelTop3.Show();
            panelViewAtt.Hide();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelStart.Hide();
            panelDelStudent.Hide();
            panelMark.Hide();
            panelDisplay.Hide();
            string[] data = new string[50];
            data = s.TopThree();
            richTextBoxTop3.Text.DefaultIfEmpty();
            richTextBoxTop3.ReadOnly = true;
            richTextBoxTop3.BackColor = Color.White;
            richTextBoxTop3.Text = "ID\t\tStudent Name\t\tAttendance\t\tCGPA\t\tSemester\tDepartment\tUniversity\n\n"; 
            for (int i = 0; i < 3; i++)
            {
                richTextBoxTop3.Text += data[i];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDeleteRecord_Click(object sender, EventArgs e)
        {
            int result = 0;
            string id = textBoxDeleteStudID.Text;
            result = s.DeleteStudent(id);
            if (result != 0)
            {
                MessageBox.Show("Data Deleted Successfully");
            }
            else
                MessageBox.Show("Invalid ID");
            textBoxDeleteStudID.Text = string.Empty;
        }

        private void panelStart_Paint(object sender, PaintEventArgs e)
        {
        }

        private void viewAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelTop3.Hide();
            panelViewAtt.Show();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelStart.Hide();
            panelDelStudent.Hide();
            panelDisplay.Hide();
            richTextBoxAttend.Text.DefaultIfEmpty();
            panelMark.Hide();
            richTextBoxAttend.ReadOnly = true;
            richTextBoxAttend.BackColor = Color.White;
            string[] data = new string[50];
            data = s.ViewAttendance();
            richTextBoxAttend.Text = "\tID\t\tStudent Name\t\tAttendance\n\n";
            for (int i = 0; i < data.Length; i++)
            {
                richTextBoxAttend.Text += data[i];
            }
        }

        private void markAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxTop3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxAttend_TextChanged(object sender, EventArgs e)
        {

        }

        private void markAttendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelDisplay.Hide();
            panelMark.Show();
            panelStart.Hide();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelDelStudent.Hide();
            panelTop3.Hide();
            panelViewAtt.Hide();
            counter = s.TotalStudents();
            //label11.Text = string.Empty;
            label10.Text = string.Empty;
            Console.WriteLine(counter);
            label10.Text += "\tID" + "\t\t" + "Student Name\n\n";
            string[] data = new string[50] ;
            label8.Text = string.Empty;
            data = s.StudInfo();
            for (int i = 0; i < data.Length; i++)
            {
                label8.Text += "\t"+data[i] + "\t\t" ;
                //richTextBoxMark.Text += data[i];
            }
            int locationCount = 0;
            for(int i = 0; i < counter*2 ; i++)
            { 
                GroupBox gObj = new GroupBox();
                gObj.Visible = true;
                gObj.Name = "GroupBoxMark"+i;
                gObj.Location= new Point(0,10+locationCount);
                gObj.Size = new Size(800,40);
                panelMark.Controls.Add(gObj);
                locationCount += 40;
                attendance[i] = 'P';
                rObj[i] = new RadioButton();
                rObj[i].Name = "RadioBoxMarkPresent" + i;
                rObj[i].Location =new Point (400,10);
                rObj[i].Size = new Size(70, 20);
                rObj[i].Text = "Present";
                rObj[i].Checked = true;
                gObj.Controls.Add(rObj[i]);
                i = i + 1;
                attendance[i] = 'A';
                rObj[i] = new RadioButton();
                rObj[i].Name = "RadioBoxMarkAbsent" + i;
                rObj[i].Location = new Point(500,10);
                rObj[i].Size = new Size(70, 20);
                rObj[i].Text = "Absent";
                gObj.Controls.Add(rObj[i]);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void panelMark_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void displayStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelDisplay.Show();
            panelMark.Hide();
            panelStart.Hide();
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelDelStudent.Hide();
            panelTop3.Hide();
            panelViewAtt.Hide();
            richTextBoxDisplay.Text.DefaultIfEmpty();
            richTextBoxDisplay.ReadOnly = true;
            richTextBoxDisplay.BackColor = Color.White;
            string[] data = new string[50];
            data = s.display();
            richTextBoxDisplay.Text = "ID\t\tStudent Name\t\tAttendance\t\tCGPA\t\tSemester\tDepartment\tUniversity\n\n";
            for(int i = 0; i < data.Length; i++)
            {
                richTextBoxDisplay.Text += data[i];
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            int count = 0;
            for(int i = 0; i < counter*2; i++)
            {
                if (i % 2 == 0)
                {
                    if (rObj[i].Checked)
                    {
                        attendance[count] = 'P';
                        count++;
                    }
                }
                else if (i % 2 != 0)
                {
                    if (rObj[i].Checked)
                    {
                        attendance[count] = 'A';
                        count++;
                    }
                }
                
            }
            s.MarkAttendance(attendance);
            MessageBox.Show("Attendance Marked");
        }

        private void top3StudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNewStud.Hide();
            panelSearchID.Hide();
            panelSearchName.Hide();
            panelTop3.Hide();
            panelDelStudent.Hide();
            panelMark.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxStudName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int result = 0;
            studentID = textBoxID.Text;
            name = textBoxName.Text;
            sem = Convert.ToInt32(textBoxSem.Text);
            dcgpa = Convert.ToDouble (textBoxCGPA.Text);
            cgpa = (float)dcgpa;
            attend = textBoxAtt.Text;
            depart = textBoxDepart.Text;
            uni = textBoxUni.Text;
            result = s.AddStudent(studentID, name, sem, cgpa, depart, uni, attend);
            if (result == 1)
            {
                MessageBox.Show("Data Added Successfully");
            }
            else
            {
                MessageBox.Show("Data Already Present");
            }
            textBoxName.Text = string.Empty;
            textBoxID.Text = string.Empty;
            textBoxSem.Text = string.Empty;
            textBoxCGPA.Text = string.Empty;
            textBoxAtt.Text = string.Empty;
            textBoxDepart.Text = string.Empty;
            textBoxUni.Text = string.Empty;


        }
    }
}
