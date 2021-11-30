using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Leveling : MonoBehaviour
{
    public Material _matToControl;
    public GameObject preview;

    // Update is called once per frame
    void Update()
    {

        Color color = preview.GetComponent<Image>().material.GetColor("_Color1");

        _matToControl.EnableKeyword("_EMISSION");
        _matToControl.SetColor("_EmissiveColor",
            color * 7f);
        _matToControl.color = color;
        
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
