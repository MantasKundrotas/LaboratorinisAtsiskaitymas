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








        struct Person
        {
            public string Name;
            public string Surname;
            public float median;
            public float average;
        }







        static void v1()
        {
            Random randGenerator = new Random();
            Console.WriteLine("Įveskite Studento vardą, pavardę, namų darbų ir egzamino rezultatą. Pavyzdys: Vardas Pavardė ND pazymiai EGZ įvertinimas");

            bool run = true;
            string input;
          
            List<Person> data = new List<Person>();
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
          
                    List<string> fullName = input.Split(' ').ToList();
     

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

                    data.Add( new Person(){Name=fullName[0], Surname=fullName[1], median= final_median, average= final_avg});
                  
                }

            }
            printData(data);
            



        }
        static void printData(List<Person> data)
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


        static void MENU()
        {

            bool run = true;


            while (run)
            {
            
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) uzd 1");
            Console.WriteLine("2) uzd 2");
            Console.WriteLine("TERMINATE Exit");


            string x = Console.ReadLine();
            if(x == "1")
            {
                uzd1();
            }
            else if(x == "2")
            {
                    uzd2();
            }
           else if (x == "TERMINATE")
                {
                    run = false;
                }
            else { uzd1(); }

            }
        }
        static void uzd1()
        {
            double x = -10;
            while (x < 100)
            {
                double y = Math.Pow(Math.Sin(x), 2) - Math.Pow(Math.Cos(x), -2);
                x = x + 0.25;
                Console.WriteLine("x={0} _ y={1}", x, y);
            }
        }
        static void uzd2()
        {
     
            var sb = new System.Text.StringBuilder();
            sb.Append("|-------------------------------------------------|\n");
            sb.Append("|NR.  |Name      |   B. Year|   B.Month|    B. Day|\n");

           
            for (int index = 0; index < 7; index++)
            {
                Console.WriteLine("Iveskite duomenis Pavyzdys: Vardas,Gimimo metai,Gimimo mėnesis, GImimo diena");
                string x = Console.ReadLine();
                List<string> arr = x.Split(',').ToList();
                
                sb.Append("|-------------------------------------------------|\n");
                sb.Append(String.Format("|{0, 5}|{1, -10}|{2, 10}|{3, 10}|{4, 10}|\n", index, arr[0], arr[1], arr[2], arr[3]));
            }
            sb.Append("|-------------------------------------------------|\n");
            Console.WriteLine(sb);


        }
    }
}
