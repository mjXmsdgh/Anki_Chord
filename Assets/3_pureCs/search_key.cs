using System.Collections;
using System.Collections.Generic;
using MyChord;

namespace MySearchKey
{
    public class search_key
    {
        public bool isCorrect(Chord reference_chord, List<string> KeyList)
        {
            for (int i = 0; i < 3; i++)
            {
                bool ans = findKey(reference_chord.key_name[i], KeyList);

                if (ans == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool findKey(string reference_key, List<string> KeyList)
        {
            for (int i = 4; i < 6; i++)
            {
                string target = reference_key + i.ToString();

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