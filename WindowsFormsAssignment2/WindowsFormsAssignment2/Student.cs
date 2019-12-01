using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAssignment2
{
    class Student
    {
        List<Student> listObj;
        string name, depart, uni, studentID, attend;
        int sem,students;
        float cgpa;
        double dcgpa;
        public Student()
        {
            listObj = new List<Student>();
            studentID =  depart = attend =  name =uni = " ";
            sem = students = 0;
            cgpa = 0;
        }
        public void GetInfo()
        {
            string line = " ";
            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\Desktop\Student.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(students);
                students++;
                studentID = line;
                name = file.ReadLine();
                attend = file.ReadLine();
                dcgpa = Convert.ToDouble(file.ReadLine());
                cgpa = (float)dcgpa;
                sem = Convert.ToInt32(file.ReadLine());
                depart = file.ReadLine();
                uni = file.ReadLine();

                listObj.Add(new Student() { studentID = this.studentID, name = this.name, sem = this.sem, cgpa = this.cgpa, depart = this.depart, uni = this.uni, attend = this.attend });
                
            }
            file.Close();

        }
        public string[] display()
        {
            string[] data = new string[50];
            for(int i = 0; i < listObj.Count; i++)
            {
                data[i] += listObj[i].studentID + "\t\t" + listObj[i].name + "\t\t\t" + listObj[i].attend + "\t\t" + listObj[i].cgpa + "\t\t" + listObj[i].sem + "\t\t" + listObj[i].depart + "\t\t" + listObj[i].uni + "\n";
            }
            return data;
        }
        public int ValidID(string id)
        {
            int Valid = 0, indexCount = 0;
            for (int i = 0; i < listObj.Count(); i++)
            {
                if (listObj[i].studentID == id)
                {
                    indexCount = i;
                    Valid++;
                }
            }
            if (Valid > 0)
                return indexCount;
            else
                return -1;

        }
        public int AddStudent(string Mid, string Mname, int Msem, float Mcgpa, string Mdepart, string Muni, string Mattend)
        {
            int Valid = ValidID(Mid), count = 0;
            if (Valid == -1)
            {
                listObj.Add(new Student() { studentID = Mid, name = Mname, sem = Msem, cgpa = Mcgpa, depart = Mdepart, uni = Muni, attend = Mattend });
                using (StreamWriter write = new StreamWriter(@"D:\Desktop\Student.txt", true))
                {
                    write.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}", Mid, Mname, Mattend, Mcgpa, Msem, Mdepart, Muni);
                    students++;
                }
                count = 1;
            }
            else
                count = 0;
            return count;
        }
        public int TotalStudents()
        {
            //Console.WriteLine(students);
            return students;
        }
        public int DeleteStudent(string id)
        {
            int indexCount = 0, fileindexCount = -1, count = 0;
            indexCount = ValidID(id);
            if (indexCount != -1)
            {
                listObj.RemoveAt(indexCount);
                string[] lines = File.ReadAllLines(@"D:\Desktop\Student.txt");
                List<string> deleteList = new List<string>(lines);
                File.Delete(@"D:\Desktop\Student.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i] == id)
                    {
                        fileindexCount = i;
                        count = 1;
                        break;
                    }
                }
                deleteList.RemoveRange(fileindexCount, 7);

                using (StreamWriter write = File.AppendText(@"D:\Desktop\Student.txt"))
                {
                    foreach (string el in deleteList)
                    {
                        write.WriteLine(el);
                    }
                }
            }
            else
                count = 0;
            return count;
        }
        public string[] SearchName(string name)
        {
            string[] data = new string[50];
            int valid = 0, length = 0;
            int indexCount = 0; ;
            length = name.Length;
            Console.WriteLine(listObj.Count());
            for (int i = 0; i < listObj.Count(); i++)
            {
                string NameFromList = listObj[i].name.Substring(0, length);
                if (name==NameFromList)
                {
                    valid++;
                    indexCount = i;
                    data[i] += listObj[indexCount].studentID + "\t\t" + listObj[indexCount].name + "\t\t\t" + listObj[indexCount].attend + "\t\t" + listObj[indexCount].cgpa + "\t\t" + listObj[indexCount].sem + "\t\t" + listObj[indexCount].depart + "\t\t" + listObj[indexCount].uni + "\n";
                }
            }
            if (valid > 0)
            {
                return data;
            }
            else
            {
                data[0] = "\n\n\t\t\t\t\t\tData not Found";
                return data;
            }
            
        }
        public string SearchID(string id)
        {
            string data = "";
            int indexCount = ValidID(id);
            if (indexCount != -1) 
            {
                data = listObj[indexCount].studentID + "\t\t" + listObj[indexCount].name + "\t\t\t" + listObj[indexCount].attend + "\t\t" + listObj[indexCount].cgpa + "\t\t" + listObj[indexCount].sem + "\t\t" + listObj[indexCount].depart + "\t\t" + listObj[indexCount].uni + "\n";
            }
            else
            {
                data = "\n\n\t\t\t\t\tData Not Found";
            }
            return data;
        }
        public void MarkAttendance(Char[] arr)
        {
            int index = 2;
            string[] attArray = File.ReadAllLines(@"D:\Desktop\Student.txt");
            for (int i = 0; i < listObj.Count; i++)
            {
                char att = ' ';
                Console.Write("{0}\t{1}\t\tAttendance: ", listObj[i].studentID, listObj[i].name);
                att = Convert.ToChar(arr[i]);

                if (att == 'P' || att == 'p')
                {
                    listObj[i].attend = "Present";
                    attArray[index] = "P";

                }
                else if (att == 'A' || att == 'a')
                {
                    listObj[i].attend = "Absent";
                    attArray[index] = "A";

                }
                else
                    Console.WriteLine("Invalid Input");
                index += 7;
            }
            File.WriteAllLines(@"D:\Desktop\Student.txt", attArray);
        }
        public string[] ViewAttendance()
        {
            string[] data = new string[50];
            for (int i = 0; i < listObj.Count; i++)
            {
                data[i] += "\t" + listObj[i].studentID + "\t\t" + listObj[i].name + "\t\t" + listObj[i].attend.PadRight(10) + "\n";
            }
            
            return data;
        }
        public string[] StudInfo()
        {
            string[] data = new string[50];
            for (int i = 0; i < listObj.Count; i++)
            {
                data[i] += "\t" + listObj[i].studentID + "\t\t\t\t" + listObj[i].name + "\n\n";
            }

            return data;
        }
        public string[] TopThree()
        {
            string[] data = new string[50];
            listObj.Sort((x, y) => y.cgpa.CompareTo(x.cgpa));
            for (int i = 0; i < 3; i++)
            {
                data[i] += listObj[i].studentID + "\t\t" + listObj[i].name + "\t\t\t" + listObj[i].attend + "\t\t" + listObj[i].cgpa + "\t\t" + listObj[i].sem + "\t\t" + listObj[i].depart + "\t\t" + listObj[i].uni + "\n";
            }
            return data;
        }
    }
}
