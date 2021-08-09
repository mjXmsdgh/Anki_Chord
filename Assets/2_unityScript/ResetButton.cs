using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject Main;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        Main.GetComponent<main>().NextProblem();
    }
}
