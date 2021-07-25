using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key_script : MonoBehaviour
{
    private AudioSource my_audioSource;

    public GameObject Observer;

    private Color myColor;

    // Start is called before the first frame update
    void Start()
    {
        // get audioSource
        my_audioSource = gameObject.GetComponent<AudioSource>();

        // save color
        myColor = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void restore_color()
    {
        GetComponent<Image>().color = myColor;
    }

    public void OnClick()
    {
        // change color
        GetComponent<Image>().color = Color.red;

        // play sound
        my_audioSource.PlayOneShot(my_audioSource.clip);

        // notify
        Observer.GetComponent<main>().Notify(gameObject, name);
    }
}
