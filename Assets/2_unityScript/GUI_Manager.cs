using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Manager : MonoBehaviour
{
    private List<GameObject> m_KeyObjectList;

    public GameObject m_ProblemLabel;

    public GameObject m_StaticLabel;

    public GameObject m_CorrectImage;

    public GameObject m_WrongImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void init()
    {
        m_KeyObjectList = new List<GameObject>();
        m_ProblemLabel.GetComponent<Text>().text = "";
        m_StaticLabel.GetComponent<Text>().text = "";
        m_CorrectImage.SetActive(false);
        m_WrongImage.SetActive(false);
    }


    public void clear()
    {
        // myObjectList;
        for (int i = 0; i < m_KeyObjectList.Count; i++)
        {
            m_KeyObjectList[i].GetComponent<key_script>().restore_color();
        }
        m_KeyObjectList.Clear();

        // m_ProblemLabel
        m_ProblemLabel.GetComponent<Text>().text = "";

        // m_StaticLabel
        //m_StaticLabel.GetComponent<Text>().text = "";

        m_CorrectImage.SetActive(false);
        m_WrongImage.SetActive(false);
    }

    public void AddKeyObject(GameObject inputObject)
    {
        m_KeyObjectList.Add(inputObject);
    }

    public void SetProblemLabel(string inputText)
    {
        m_ProblemLabel.GetComponent<Text>().text = inputText;
    }

    public void DisplayResult(bool answer)
    {
        if(answer==true)
        {
            m_CorrectImage.SetActive(true);
        }
        else
        {
            m_WrongImage.SetActive(true);
        }
    }

    public void SetStaticLabel(string input_sting)
    {
        m_StaticLabel.GetComponent<Text>().text=input_sting;
    }
}
