﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_3
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _marks;
            private int[] _places;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    var NewArray = new double[_marks.Length];
                    Array.Copy(_marks, NewArray, _marks.Length);
                    return NewArray;
                }
            }
            public int[] Places
            {
                get
                {
                    if (_places == null) return null;
                    var NewArray = new int[_places.Length];
                    Array.Copy(_places, NewArray, _places.Length);
                    return NewArray;
                }
            }
            public int Score
            {
                get
                {
                    if (_places == null) return 0;
                    return Places.Sum();
                }
            }
            private int TopPlace
            {
                get
                {
                    if (_places == null) return 0;
                    return _places.Min();
                }
            }
            private double TotalMark
            {
                get
                {
                    if (_marks == null) return 0;
                    return _marks.Sum();
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new double[7];
                _places = new int[7];
            }

            public void Evaluate(double result)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (_marks[i] == 0)
                    {
                        _marks[i] = result;
                        break;
                    }
                }
            }

            public static void SetPlaces(Participant[] participants)
            {
                if (participants == null) return;
                for (int i = 0; i < 7; i++)
                {
                    for (int k = 0; k < participants.Length; k++)
                    {
                        for (int j = 0; j < participants.Length - 1 - k; j++)
                        {
                            if (participants[j]._marks[i] < participants[j + 1]._marks[i])
                            {
                                var p = participants[j];
                                participants[j] = participants[j + 1];
                                participants[j + 1] = p;
                            }
                        }
                    }
                    for (int k = 0; k < participants.Length; k++)
                    {
                        participants[k]._places[i] = k + 1;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int k = 0; k < array.Length; k++)
                {
                    for (int j = 0; j < array.Length - 1 - k; j++)
                    {
                        if (array[j].Score > array[j + 1].Score)
                        {
                            var p = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = p;
                        }
                        else if (array[j].Score == array[j + 1].Score)
                        {
                            if (array[j].TopPlace > array[j + 1].TopPlace)
                            {
                                var p = array[j];
                                array[j] = array[j + 1];
                                array[j + 1] = p;
                            }
                            else if (array[j].TopPlace == array[j + 1].TopPlace)
                            {
                                if (array[j].TotalMark < array[j + 1].TotalMark)
                                {
                                    var p = array[j];
                                    array[j] = array[j + 1];
                                    array[j + 1] = p;
                                }
                            }
                        }
                    }
                }
            }

            public void Print()
            {
                Console.WriteLine(Name + " " + Surname + " " + Score + " " + TopPlace + " " + TotalMark);
            }
        }
    }
}
