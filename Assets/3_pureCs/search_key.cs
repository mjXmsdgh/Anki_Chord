using System.Collections;
using System.Collections.Generic;
using MyChord;

namespace MySearchKey
{
    public class search_key
    {
        public bool isCorrect(Chord input_chord, List<string> KeyList)
        {
            for (int i = 0; i < 3; i++)
            {
                bool ans = findKey(input_chord.key_name[i], KeyList);

                if (ans == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool findKey(string input_key, List<string> KeyList)
        {
            for (int i = 4; i < 6; i++)
            {
                string target = input_key + i.ToString();

                int ans = KeyList.IndexOf(target);

                if (ans != -1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}