using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    public GameObject _textObject;

    public void Notify(string text)
    {
        Debug.Log("Harder");
        IEnumerator enumerator = NotificationRoutine(text);
        StartCoroutine(enumerator);
    }
    
    IEnumerator NotificationRoutine(string text)
    {
        _textObject.SetActive(true);
        _text.text = text;
        yield return new WaitForSeconds(1);
        _textObject.SetActive(false);
}
}
