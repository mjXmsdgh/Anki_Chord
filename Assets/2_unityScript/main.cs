using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyChord;
using MySearchKey;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextProblem();
        }
    }

    public void NextProblem()
    {
        clear();
        change_problem_number();
        setup_problem();
    }

    private void init()
    {
        inputKeyList = new List<string>();
        myObjectList = new List<GameObject>();
        problem_number = 0;
        myChordManager.GetComponent<ChordManager>().init();
        myProblemLabel.GetComponent<Text>().text = "";
        myResultLabel.GetComponent<Text>().text = "";
    }

    private void clear()
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

    private void change_problem_number()
    {
        problem_number = (int)Random.Range(0, 7);
        Debug.Log(problem_number);

        //Application.Quit();
    }

    private void setup_problem()
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
        search_key obj = new search_key();
        Chord tempChord = myChordManager.GetComponent<ChordManager>().get_chord_object(problem_number);
        bool ans = obj.isCorrect(tempChord, inputKeyList);

        // update GUI
        if (ans == true)
        {
            myResultLabel.GetComponent<Text>().text = "Correct";
        }
        else
        {
            myResultLabel.GetComponent<Text>().text = "Wrong";
        }
    }
}
