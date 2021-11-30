using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]  public TextMeshProUGUI  _text;
    public GameObject _player;

    void Update()
    {
        int currentHealth = _player.GetComponent<Stats>().GetCurrnetHp();

        _text.text = "HP: " + currentHealth;     
    }
}
