using System.Collections;
using System.Collections.Generic;
//using UnityEngine;


namespace MyChord
{
    public class Chord
    {
        public string chord_name;

        public List<string> key_name;

        public void init(string input_name,
                        string input_first,
                        string input_third,
                        string input_fifth)
        {
            if (key_name != null)
            {
                key_name.Clear();
            }
            key_name = new List<string>();

            chord_name = input_name;

            key_name.Add(input_first);
            key_name.Add(input_third);
            key_name.Add(input_fifth);
        }

    }
}