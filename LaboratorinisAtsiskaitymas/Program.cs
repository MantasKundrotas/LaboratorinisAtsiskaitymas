using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LaboratorinisAtsiskaitymas
{

    class Program
    {
        static void Main(string[] args)
        {

            //generateData();
            calculateInferance();
            v1();
            Console.ReadKey();
        }






        static void readTxt(ref List<Class1.Person> data, string filePath, Boolean newtype)
        {
            Console.WriteLine(filePath);
            List<int> scores = new List<int>();

            float egz = 0.0f;
            float final_avg = 0.0f;
            float final_median = 0.0f;
            string type = "";
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                for (int x = 0; x < lines.Length; x++)
                {
                    type = "galvociai";
                    List<string> values = lines[x].Split(' ').ToList();

                    if (values[2] == "ND1") { continue; }
                    //Console.WriteLine(lines.Length.ToString() + " " + values[2]);
                    for (int i = 2; i < values.Count - 1; i++)
                    {

                        scores.Add(Int32.Parse(values[i]));
                    }

                    egz = float.Parse(values[values.Count - 1]);
                    final_avg = 0.3f * AVG(scores) + 0.7f * egz;
                    final_median = 0.3f * Median(scores) + 0.7f * egz; ;

                    if (final_avg < 5) { type = "vargsciukai"; }


                    data.Add(new Class1.Person() { Name = values[0], Surname = values[1], median = final_median, average = final_avg, type = type });


                    scores.Clear();

                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e);
            }

        }

        static void calculateInferance()
        {
            List<string> filePaths = new List<string> { "studentai1.txt", "studentai2.txt", "studentai3.txt", "studentai4.txt", "studentai5.txt" };
            List<int> numSamples = new List<int> { 1000, 10000, 100000, 1000000, 10000000 };
            string fPath = "C:/Users/mantask/Desktop/LaboratorinisAtsiskaitymas/";



            for (int i = 0; i < 5; i++)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                List<Class1.Person> Pdata = new List<Class1.Person>(numSamples[i]);

                generateData(numSamples[i], fPath + filePaths[i]);
                readTxt(ref Pdata, fPath + filePaths[i], true);

                writeFile(ref Pdata);
                watch.Stop();
                Console.WriteLine(String.Format("Loop {0} Execution Time: {1} ms", i.ToString(), watch.ElapsedMilliseconds));
            }



        }
        static void writeFile(ref List<Class1.Person> Pdata)
        {
            string fPath1 = "C:/Users/mantask/Desktop/LaboratorinisAtsiskaitymas/vargsciukai.txt";
            string fPath2 = "C:/Users/mantask/Desktop/LaboratorinisAtsiskaitymas/galvociai.txt";
            string s;

            using (System.IO.StreamWriter varg = new System.IO.StreamWriter(fPath1))
            {
                using (System.IO.StreamWriter galv = new System.IO.StreamWriter(fPath2))
                {
                    for (int i = 0; i < Pdata.Count; i++)
                    {
                        s = String.Format("{0, -20}{1, -20}{2, -10:0.00}{3, 20:0.00}\n", "Pavarde" + i.ToString(), "Vardas" + i.ToString(), Pdata[i].median, Pdata[i].average);
                        if (Pdata[i].type == "galvociai")
                        {
                            galv.Write(s);
                        }
                        else { varg.Write(s); }
                    }
                }
            }
        }

        static void generateData(int num, string fileName)
        {
            Random randGenerator = new Random();

            string s;
            s = String.Format("{0} {1} {2} {3} {4} {5} {6} {7}\n", "Vardas", "Pavarde", "ND1", "ND2", "ND3", "ND4", "ND5", "Egzaminas");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                file.Write(s);

                for (int i = 0; i < num; i++)
                {

                    s = String.Format("{0} {1} {2} {3} {4} {5} {6} {7}\n", "Vardas" + i.ToString(), "Pavarde" + i.ToString(),
                randGenerator.Next(0, 11), randGenerator.Next(0, 11),
                randGenerator.Next(0, 11), randGenerator.Next(0, 11),
                randGenerator.Next(0, 11), randGenerator.Next(0, 11));
                    file.Write(s);
                }
            }
        }
        static void v1()
        {
            Random randGenerator = new Random();
            string input;
            string filePath = "C:/Users/mantask/Desktop/LaboratorinisAtsiskaitymas/studentai.txt";
            List<Class1.Person> data = new List<Class1.Person>();
            string type = "galvociai";
            Console.WriteLine("Nuskaityti duomenis is failo studentai.txt?, press y");
            if (Console.ReadLine() == "y")
            {
                readTxt(ref data, filePath, false);
            }



            Console.WriteLine("Įveskite Studento vardą, pavardę, namų darbų ir egzamino rezultatą. Pavyzdys: Vardas Pavardė ND pazymiai EGZ įvertinimas");

            bool run = true;



            while (run)
            {
                Console.WriteLine("Vardas Pavarde, spauskite q ir enter");
                input = Console.ReadLine();
                if (input == "q")
                {
                    run = false;
                }
                else
                {

                    List<string> fullName = new List<string> { "None", "None" };

                    List<string> temp = input.Split(' ').ToList();
                    if (temp.Count == 2) { fullName = temp; }

                    Console.WriteLine("Įveskite mokinio pazymius 10 balų skalėje tokiu formatu: 5 3 10 9 0 1 10\n Jeigu norite, jog skaičiai būtų sugeneruoti atsitiktinai spauskite r");
                    input = Console.ReadLine();
                    List<int> scores = new List<int>();
                    float egz = 0.0f;
                    if (input == "r")
                    {
                        for (int i = 0; i < randGenerator.Next(5, 11); i++)
                        {
                            scores.Add(randGenerator.Next(0, 11));
                        }
                        egz = (float)randGenerator.Next(0, 11);
                    }
                    else
                    {

                        if (!input.Any(x => !char.IsLetter(x))) { continue; }

                        List<string> numbers = input.Split(' ').ToList();

                        foreach (string number in numbers)
                        {
                            scores.Add(Math.Max(Math.Min(10, Int32.Parse(number)), 0));
                            Console.WriteLine("Įveskite mokinio egzamino rezultatą 10 skalėje\n Jeigu norite jog skaičius būtų sugeneruotas atsi");
                            egz = Math.Max(Math.Min(10.0f, float.Parse(Console.ReadLine())), 0.0f);
                        }
                    }

                    scores.Sort();


                    float final_avg = 0.3f * AVG(scores) + 0.7f * (float)egz;
                    float final_median = 0.3f * Median(scores) + 0.7f * (float)egz; ;
                    if (final_avg < 5) { type = "vargsciukai"; }
                    data.Add(new Class1.Person() { Name = fullName[0], Surname = fullName[1], median = final_median, average = final_avg, type = type });

                }

            }
            data = data.OrderBy(p => p.Name).ToList();
            printData(data);




        }
        static void printData(List<Class1.Person> data)
        {

            var sb = new System.Text.StringBuilder();

            sb.Append(String.Format("{0, -20}{1, -20}{2, -10}{3, 5}{4, 5}{5, 10}\n", "Pavardė", "Vardas", "Galutinis (Vid.)", "/", "", "Galutinis (Med.)"));
            string ll = "";
            for (int x = 0; x < 82; x++) { ll += "-"; }
            sb.Append(ll + "\n");

            for (int index = 0; index < data.Count; index++)
            {

                sb.Append(String.Format("{0, -20}{1, -20}{2, -10:0.00}{3, 20:0.00}\n", data[index].Surname, data[index].Name, data[index].median, data[index].average));
            }
            Console.WriteLine(sb);
        }


        static float Median(List<int> numbers)
        {
            float median = 0.0f;

            int idx = Math.Max(numbers.Count / 2 - 1, 0);

            if (idx % 2 == 0)
            {
                median = (float)numbers[idx];
            }
            else
            {
                median = (float)(numbers[idx] + numbers[idx + 1]) / 2.0f;
            }
            return median;
        }
        static float AVG(List<int> numbers)
        {
            float avg = 0;

            foreach (float number in numbers)
            {
                avg += number;
            }
            avg = (float)avg / (float)numbers.Count;

            return avg;
        }


    }
}
