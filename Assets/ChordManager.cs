using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MyChord;

public class ChordManager : MonoBehaviour
{
    public List<Chord> myChordList;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void init()
    {
        string filename = "./ChordList.csv";

        myChordList = new List<Chord>();
        ReadData(filename);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Chord get_chord_object(int number)
    {
        return myChordList[number];
    }

    void ReadData(string filename)
    {
        try
        {
            StreamReader myReader = new StreamReader(filename);

            while (myReader.EndOfStream == false)
            {
                string test = myReader.ReadLine();
                string[] temp = test.Split(',');

                Chord obj = new Chord();
                obj.init(temp[0], temp[1], temp[2], temp[3]);

                myChordList.Add(obj);
            }

        }

        catch (DirectoryNotFoundException e)
        {
            Debug.Log("file not found");
            Debug.Log(e);
        }
    }
}
