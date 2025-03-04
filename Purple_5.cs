using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_5
    {
        public struct Response
        {
            private string _animal;
            private string _CharacterTrait;
            private string _concept;

            public string Animal => _animal;
            public string CharacterTrait => _CharacterTrait;
            public string Concept => _concept;

            public Response(string ans1, string ans2, string ans3)
            {
                _animal = ans1;
                _CharacterTrait = ans2;
                _concept = ans3;
            }

            public int CountVotes(Response[] responses, int questionNumber)
            {
                int c = 0;
                if (questionNumber == 1)
                {
                    foreach (Response r in responses)
                    {
                        if (r._animal == _animal && _animal != null) c++;
                    }
                }
                if (questionNumber == 2)
                {
                    foreach (Response r in responses)
                    {
                        if (r._CharacterTrait == _CharacterTrait && _CharacterTrait != null) c++;
                    }
                }
                if (questionNumber == 3)
                {
                    foreach (Response r in responses)
                    {
                        if (r._concept == _concept && _concept != null) c++;
                    }
                }
                return c;
            }

            public void Print()
            {
                Console.WriteLine(Animal + " " + CharacterTrait + " " + Concept);
            }
        }

        public struct Research
        {
            private string _name;
            private Response[] _responses;

            public string Name => _name;
            public Response[] Responses => _responses;

            public Research(string name)
            {
                _name = name;
                _responses = new Response[0];
            }

            public void Add(string[] answers)
            {
                if (answers == null) return;
                var NewArray = new Response[_responses.Length + 1];
                Array.Copy(_responses, NewArray, _responses.Length);
                var Resp = new Response(answers[0], answers[1], answers[2]);
                NewArray[_responses.Length] = Resp;
                _responses = NewArray;
            }

            public string[] GetTopResponses(int question)
            {
                var NewArray = new Response[_responses.Length];
                Array.Copy(_responses, NewArray, _responses.Length);
                for (int k = 0; k < NewArray.Length; k++)
                {
                    for (int j = 0; j < NewArray.Length - k - 1; j++)
                    {
                        if (NewArray[j].CountVotes(NewArray, question) < NewArray[j + 1].CountVotes(NewArray, question))
                        {
                            var p = NewArray[j];
                            NewArray[j] = NewArray[j + 1];
                            NewArray[j + 1] = p;
                        }
                    }
                }

                string[] Arr = new string[5];
                int i = 0;
                foreach (Response r in NewArray)
                {
                    if (question == 1 && Arr.Count(a => a == r.Animal) == 0 && r.Animal != null) Arr[i++] = r.Animal;
                    if (question == 2 && Arr.Count(a => a == r.CharacterTrait) == 0 && r.CharacterTrait != null) Arr[i++] = r.CharacterTrait;
                    if (question == 3 && Arr.Count(a => a == r.Concept) == 0 && r.Concept != null) Arr[i++] = r.Concept;
                    if (i == 5) break;
                }
                return Arr;
            }

            public void Print()
            {
                foreach (Response r in _responses)
                {
                    r.Print();
                }
            }
        }
    }
}
