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
                        if (r._animal == _animal && _animal != " ") c++;
                    }
                }
                if (questionNumber == 2)
                {
                    foreach (Response r in responses)
                    {
                        if (r._CharacterTrait == _CharacterTrait && _CharacterTrait != " ") c++;
                    }
                }
                if (questionNumber == 3)
                {
                    foreach (Response r in responses)
                    {
                        if (r._concept == _concept && _concept != " ") c++;
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
                for (int k = 0; k < _responses.Length; k++)
                {
                    for (int j = 0; j < _responses.Length - k - 1; j++)
                    {
                        if (_responses[j].CountVotes(_responses, question) < _responses[j + 1].CountVotes(_responses, question))
                        {
                            var p = _responses[j];
                            _responses[j] = _responses[j + 1];
                            _responses[j + 1] = p;
                        }
                    }
                }

                string[] Array = new string[5];
                if (question == 1) Array[0] = _responses[0].Animal;
                if (question == 2) Array[0] = _responses[0].CharacterTrait;
                if (question == 3) Array[0] = _responses[0].Concept;

                int i = 1;
                foreach (Response r in _responses)
                {
                    if (question == 1 && Array.Count(a => a == r.Animal) == 0) Array[i++] = r.Animal;
                    if (question == 2 && Array.Count(a => a == r.CharacterTrait) == 0) Array[i++] = r.CharacterTrait;
                    if (question == 3 && Array.Count(a => a == r.Concept) == 0) Array[i++] = r.Concept;
                    if (i == 5) break;
                }
                return Array;
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
