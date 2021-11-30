using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject []hiders;
    public int _hp;
    private void Start()
    {
       // Animator = GetComponentInChildren<Animator>();
    }
    public void GetHit(int dmg)
    {
        _hp-= dmg;

        if (_hp <= 0)
        {
            GetComponent<PlayerMovement>().endGame = true;
            foreach (var item in hiders)
            {
                item.SetActive(false);
            }
            gameOver.SetActive(true);
        }
       // Animator.SetTrigger("Hit");

    }
    public void GetHp()
    {
        _hp++;
    }
    public int GetCurrnetHp() => _hp;
}
