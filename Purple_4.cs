﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Lab_6.Purple_4;

namespace Lab_6
{
    public class Purple_4
    {
        public struct Sportsman
        {
            private string _name;
            private string _surname;
            private double _time;

            public string Name => _name;
            public string Surname => _surname;
            public double Time => _time;

            public Sportsman(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _time = 0;
            }

            public void Run(double time)
            {
                if (_time == 0) _time = time;
            }

            public void Print()
            {
                Console.WriteLine(Name + " " + Surname + " " + Time);
            }
        }

        public struct Group
        {
            private string _name;
            private Sportsman[] _sportsman;

            public string Name => _name;
            public Sportsman[] Sportsmen => _sportsman;

            public Group(string name)
            {
                _name = name;
                _sportsman = new Sportsman[0];
            }

            public Group(Group group)
            {
                _name = group._name;
                var NewArray = new Sportsman[group._sportsman.Length];
                Array.Copy(group._sportsman, NewArray, group._sportsman.Length);
                _sportsman = NewArray;
            }

            public void Add(Sportsman sportsman)
            {
                var NewArray = new Sportsman[_sportsman.Length + 1];
                Array.Copy(_sportsman, NewArray, _sportsman.Length);
                NewArray[_sportsman.Length] = sportsman;
                _sportsman = NewArray;
            }

            public void Add(Sportsman[] array)
            {
                if (array == null) return;
                foreach (var s in array)
                {
                    Add(s);
                }
            }

            public void Add(Group group)
            {
                Add(group._sportsman);
            }

            public void Sort()
            {
                if (_sportsman == null) return;
                for (int i = 0; i < _sportsman.Length; i++)
                {
                    for (int j = 0; j < _sportsman.Length - i - 1; j++)
                    {
                        if (_sportsman[j].Time > _sportsman[j + 1].Time)
                        {
                            var p = _sportsman[j];
                            _sportsman[j] = _sportsman[j + 1];
                            _sportsman[j + 1] = p;
                        }
                    }
                }
            }

            public static Group Merge(Group group1, Group group2)
            {
                Group gr = new Group("Финалисты");
                int i = 0, j = 0;
                while (i < group1._sportsman.Length && j < group2._sportsman.Length)
                {
                    if (group1._sportsman[i].Time <= group2._sportsman[j].Time)
                        gr.Add(group1._sportsman[i++]);
                    else
                        gr.Add(group2._sportsman[j++]);
                }
                while (i < group1._sportsman.Length)
                    gr.Add(group1._sportsman[i++]);
                while (j < group2._sportsman.Length)
                    gr.Add(group2._sportsman[j++]);
                return gr;
            }

            public void Print()
            {
                foreach (Sportsman s in _sportsman)
                {
                    s.Print();
                }
            }
        }
    }
}
