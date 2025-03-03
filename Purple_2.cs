using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    var NewArray = new int[_marks.Length];
                    Array.Copy(_marks, NewArray, _marks.Length);
                    return NewArray;
                }
            }
            public int Distance => _distance;
            public int Result
            {
                get
                {
                    if (_marks == null) return 0;
                    Array.Sort(_marks);
                    int res = 0;
                    for (int i = 1; i < 4; i++)
                    {
                        res += _marks[i];
                    }
                    res += 60 + 2 * (_distance - 120);
                    if (res < 0) return 0;
                    return res;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
            }

            public void Jump(int distance, int[] marks)
            {
                if (distance < 0 || marks == null) return;
                _distance = distance;
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }


            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].Result < array[j + 1].Result)
                        {
                            var p = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = p;
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(Name + " " + Surname + " " + Distance);
            }
        }
    }
}
