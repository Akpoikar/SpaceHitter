using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    bool pause = false;
    public Slider Slider;
    public void VolumChange(float num)
    {
        Debug.Log(num);
        GameObject.Find("MainMusic").GetComponent<AudioSource>().volume = num;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Resume();
            }
            else
            {
                Pauser();
            }
        }
    }

    public void Resume()
    {
        pause = false;
        Time.timeScale = 1;

        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }

    public void Pauser()
    {
        pause = true;
        Time.timeScale = 0;

        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
