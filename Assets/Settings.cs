using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public AudioSource Audio;
    public void VolumChange(float num)
    {
        Debug.Log(num);
        Audio.volume = num;
    }
}
