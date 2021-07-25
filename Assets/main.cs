using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using myChord;

public class main : MonoBehaviour
{
    private List<string> inputKeyList;

    private List<GameObject> myObjectList;

    private int problem_number;

    public GameObject myChordManager;

    //---------- GUI  -----------
    public GameObject myProblemLabel;

    public GameObject myResultLabel;

    //-------------------------------------------------
    //-------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        init();
        setup_problem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void init()
    {
        inputKeyList = new List<string>();
        myObjectList = new List<GameObject>();
        problem_number = 0;
        myChordManager.GetComponent<ChordManager>().init();
        myProblemLabel.GetComponent<Text>().text = "";
        myResultLabel.GetComponent<Text>().text = "";
    }

    public void clear()
    {
        // myKeyList
        inputKeyList.Clear();

        // myObjectList;
        for (int i = 0; i < myObjectList.Count; i++)
        {
            myObjectList[i].GetComponent<key_script>().restore_color();
        }
        myObjectList.Clear();

        // myProblemLabel
        myProblemLabel.GetComponent<Text>().text = "";

        // myResultLabel
        myResultLabel.GetComponent<Text>().text = "";
    }

    public void change_problem_number()
    {
        problem_number = problem_number + 1;
    }

    public void setup_problem()
    {
        Chord tempChord = myChordManager.GetComponent<ChordManager>().get_chord_object(problem_number);
        myProblemLabel.GetComponent<Text>().text = tempChord.chord_name;
    }

    public void Notify(GameObject KeyObject, string inputKey)
    {
        // add key object
        myObjectList.Add(KeyObject);

        // add input key
        inputKeyList.Add(inputKey);

        // check number
        if (inputKeyList.Count != 3)
        {
            return;
        }

        // check
        bool ans = isCorrect();

        // update GUI
        if (ans == true)
        {
            myResultLabel.GetComponent<Text>().text = "Correct";
        }
        else
        {
            myResultLabel.GetComponent<Text>().text = "Wring";
        }
    }

    private bool isCorrect()
    {
        List<int> answerList = new List<int>();

        Chord tempChord = myChordManager.GetComponent<ChordManager>().get_chord_object(problem_number);

        bool ans1 = findKey(tempChord.first);
        bool ans2 = findKey(tempChord.third);
        bool ans3 = findKey(tempChord.fifth);

        if ((ans1 == true) && (ans2 == true) && (ans3 == true))
        {
            return true;
        }

        return false;
    }

    private bool findKey(string input_key)
    {
        for (int i = 4; i < 6; i++)
        {
            string target = input_key + i.ToString();

            int ans = inputKeyList.IndexOf(target);

            if (ans != -1)
            {
                return true;
            }
        }
        return false;
    }
}
