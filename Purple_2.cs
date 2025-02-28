using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;
            private int _result;

            public string Name => _name;
            public string Surname => _surname;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return default(int[]);
                    var NewArray = new int[_marks.Length];
                    Array.Copy(_marks, NewArray, _marks.Length);
                    return NewArray;
                }
            }
            public int Distance => _distance;
            public double Result
            {
                get
                {
                    if (_result > 0) return _result;
                    if (_result < 0) return 0;
                    if (_marks == null) return 0;
                    var NewArray = new int[5];
                    Array.Copy(_marks, NewArray, _marks.Length);
                    Array.Sort(NewArray);
                    _result = NewArray.Sum() - NewArray[0] - NewArray[4];
                    _result += 60 + 2 * (_distance - 120);
                    if (_result < 0) return 0;
                    return _result;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                _result = 0;
            }

            public void Jump(int distance, int[] marks)
            {
                _distance = distance;
                for (int i = 0; i < 5; i++)
                {
                    _marks[i] = marks[i];
                }
            }


            public static void Sort(Participant[] array)
            {
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
                Console.WriteLine(Name + " " + Surname + " " + Result);
            }
        }
    }
}
