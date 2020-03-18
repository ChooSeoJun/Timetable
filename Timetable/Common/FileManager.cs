using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Model;

namespace Timetable.Common
{
    public class FileManager
    {
        string filePath = "D:\\data.csv";

        public void checkFile()
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
            {
                FileStream stream = File.Create(filePath);
                stream.Close();
            }
                //string[] lines = File.ReadAllLines("D:\\data.txt");     
        }
        public void saveWorkData()
        {
            StreamWriter sw = new StreamWriter(filePath, false);

            foreach(Work item in App.workList.timetable)
            {
                string workInfo = item.Name + "," + item.StartDate + "," + item.StartTime + "," + item.Duration + "," + item.ColorHex;
                sw.WriteLine(workInfo);
            }
        }
        public void readWorkData()
        {
            StreamReader sr = new StreamReader(filePath, Encoding.GetEncoding("utf-8"));
            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                App.workList.timetable.Add(new Model.Work() {
                    Name=temp[0],
                    StartDate=DateTime.Parse(temp[1]),
                    StartTime=DateTime.Parse(temp[2]),
                    Duration= DateTime.Parse(temp[3]),
                    ColorHex =temp[4] });
            }
        }
        public void writeWorkData(Work work)
        {
            App.workList.timetable.Add(work);
        }
    }
}
