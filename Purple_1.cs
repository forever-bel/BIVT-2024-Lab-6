﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    class Purple_1
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private double _TotalScore;

            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return default(double[]);
                    var NewArray = new double[_coefs.Length];
                    Array.Copy(_coefs, NewArray, _coefs.Length);
                    return NewArray;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return default(int[,]);
                    var NewMatrix = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    for (int i = 0; i < _marks.GetLength(0); i++)
                    {
                        for (int j = 0; j < _marks.GetLength(1); j++)
                        {
                            NewMatrix[i, j] = _marks[i, j];
                        }
                    }
                    return NewMatrix;
                }
            }
            public double TotalScore
            {
                get
                {
                    if (_TotalScore != 0) return _TotalScore;
                    if (_marks == null) return 0;
                    for (int i = 0; i < 4; i++)
                    {
                        var NewArray = new double[7];
                        for (int j = 0; j < 7; j++)
                        {
                            NewArray[j] = _marks[i, j];
                        }
                        Array.Sort(NewArray);
                        var points = NewArray.Sum() - NewArray[0] - NewArray[6];
                        points *= _coefs[i];
                        _TotalScore += points;
                    }
                    return _TotalScore;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _TotalScore = 0;
            }

            public void SetCriterias(double[] coefs)
            {
                for (int i = 0; i < 4; i++)
                {
                    _coefs[i] = coefs[i];
                }
            }

            public void Jump(int[] marks)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (_marks[i, 0] == 0)
                    {
                        for (int j = 0; j < 7; j++)
                        {
                            _marks[i, j] = marks[j];
                        }
                        break;
                    }
                }
            }

            public static void Sort(Participant[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].TotalScore < array[j + 1].TotalScore)
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
                Console.WriteLine(Name + " " + Surname + " " + TotalScore);
            }
        }
    }
}
