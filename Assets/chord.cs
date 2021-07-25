using System.Collections;
using System.Collections.Generic;
//using UnityEngine;


namespace myChord
{
    public class Chord
    {
        public string chord_name;

        public string first;
        public string third;
        public string fifth;

        public void init(string input_name,
                        string input_first,
                        string input_third,
                        string input_fifth)
        {
            chord_name = input_name;
            first = input_fifth;
            third = input_third;
            fifth = input_fifth;
        }
    }
}