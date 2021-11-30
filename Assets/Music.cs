using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource Audio;
    public static bool first = true;
    private void Start()
    {
        if (!first)
            //if (GameObject.Find("MainMusic"))
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(Audio);
            first = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
