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

       
            v1();
            Console.ReadKey();
        }

    




        static void readTxt(ref List<Class1.Person> data, string filePath)
        {
         
            List<int> scores = new List<int>();

            float egz = 0.0f;
            float final_avg = 0.0f;
            float final_median = 0.0f;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    List<string> values = line.Split(' ').ToList();
                    if (values[2] == "ND1")
                    { continue; }
                    for (int i = 2; i < values.Count - 1; i++)
                    {

                        scores.Add(Int32.Parse(values[i]));
                    }
                    egz = float.Parse(values[values.Count - 1]);
                    final_avg = 0.3f * AVG(scores) + 0.7f * egz;
                    final_median = 0.3f * Median(scores) + 0.7f * egz; ;


                    data.Add(new Class1.Person() { Name = values[0], Surname = values[1], median = final_median, average = final_avg });
                    scores.Clear();
                    Console.WriteLine(line);
                }
            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine(e);
            }
           
        }

        static void v1()
        {
            Random randGenerator = new Random();
            string input;
            string filePath = "C:/Users/mantask/Desktop/LaboratorinisAtsiskaitymas/studentai.txt";
            List<Class1.Person> data = new List<Class1.Person>();

            Console.WriteLine("Nuskaityti duomenis is failo studentai.txt?, press y");
            if (Console.ReadLine() == "y")
            {
                readTxt(ref data, filePath);
            }


         
            Console.WriteLine("Įveskite Studento vardą, pavardę, namų darbų ir egzamino rezultatą. Pavyzdys: Vardas Pavardė ND pazymiai EGZ įvertinimas");

            bool run = true;
          
          
         
            while(run)
            {
                Console.WriteLine("Vardas Pavarde, spauskite q ir enter");
                input = Console.ReadLine();
                if (input == "q")
                {
                    run = false;
                }
                else
                {

                    List<string> fullName = new List<string>{ "None", "None" };

                    List<string> temp = input.Split(' ').ToList();
                    if (temp.Count == 2) { fullName = temp; }

                    Console.WriteLine("Įveskite mokinio pazymius 10 balų skalėje tokiu formatu: 5 3 10 9 0 1 10\n Jeigu norite, jog skaičiai būtų sugeneruoti atsitiktinai spauskite r");
                    input = Console.ReadLine();
                    List<int> scores = new List<int>();
                    float egz = 0.0f;
                    if (input == "r")
                    {
                        for(int i = 0; i < randGenerator.Next(5, 11); i++)
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

                    data.Add( new Class1.Person(){Name=fullName[0], Surname=fullName[1], median= final_median, average= final_avg});
                  
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
            for (int x = 0; x<82; x++) { ll += "-"; }
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

            foreach(float number in numbers)
            {
                avg += number;
            }
            avg = (float)avg / (float)numbers.Count;

            return avg;
        }


    }
}
