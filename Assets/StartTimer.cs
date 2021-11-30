using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StartTimer : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    public float _time;

    IEnumerator enumerator;
    public GameObject player;
    public GameObject Enemy;
    public GameObject Stats;
    public GameObject Hp;
    private void Start()
    {
        player.SetActive(false);
        Enemy.SetActive(false);
        Stats.SetActive(false);
        Hp.SetActive(false);
        enumerator = work();
        StartCoroutine(enumerator);
    }

    public void Starter()
    {
        
    }

    void Update()
    {
        _time -= Time.deltaTime; 
        if(_time <= 0)
        {
         //   gameObject.SetActive(false);
        }
    }

    IEnumerator work()
    {
        yield return new WaitForSeconds(1f);
        _text.text = "GET READY";
        yield return new WaitForSeconds(1f);
        _text.text = "START";
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
        player.SetActive(true);
        Enemy.SetActive(true);
        Stats.SetActive(true);
        Hp.SetActive(true);
    }

}
