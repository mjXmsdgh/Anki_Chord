using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MyChord;
using MySearchKey;

public class main : MonoBehaviour
{
    private List<string> m_InputKeyList;

    private int m_ProblemNumber;

    public GameObject m_ChordManager;

    Dictionary<string, int> m_WrongNumber;

    public GameObject m_GUIManager;

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
        m_InputKeyList = new List<string>();
        m_ProblemNumber = 0;
        m_ChordManager.GetComponent<ChordManager>().init();
        m_WrongNumber = new Dictionary<string, int>();

        m_GUIManager.GetComponent<GUI_Manager>().init();

        m_WrongNumber.Add("C", 0);
        m_WrongNumber.Add("D", 0);
        m_WrongNumber.Add("E", 0);
        m_WrongNumber.Add("F", 0);
        m_WrongNumber.Add("G", 0);
        m_WrongNumber.Add("A", 0);
        m_WrongNumber.Add("B", 0);
    }

    private void clear()
    {
        // myKeyList
        m_InputKeyList.Clear();

        m_GUIManager.GetComponent<GUI_Manager>().clear();
    }

    private void change_problem_number()
    {
        m_ProblemNumber = (int)Random.Range(0, 7);
        //Application.Quit();
    }

    private void setup_problem()
    {
        Chord tempChord = m_ChordManager.GetComponent<ChordManager>().get_chord_object(m_ProblemNumber);
        m_GUIManager.GetComponent<GUI_Manager>().SetProblemLabel(tempChord.chord_name);
    }

    public void Notify(GameObject KeyObject, string inputKey)
    {
        // add key object
        m_GUIManager.GetComponent<GUI_Manager>().AddKeyObject(KeyObject);

        // add input key
        m_InputKeyList.Add(inputKey);

        // check number
        if (m_InputKeyList.Count != 3)
        {
            return;
        }

        // check
        search_key obj = new search_key();
        Chord tempChord = m_ChordManager.GetComponent<ChordManager>().get_chord_object(m_ProblemNumber);
        bool ans = obj.isCorrect(tempChord, m_InputKeyList);

        // update GUI
        m_GUIManager.GetComponent<GUI_Manager>().DisplayResult(ans);

        //string temp = "A 0\nB 0\n";
        //m_StaticLabel.GetComponent<Text>().text = temp;
    }
}
