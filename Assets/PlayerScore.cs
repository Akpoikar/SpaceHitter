using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    
    float _timeToDisplay = 1;
    public int score = 0;
    bool increaed = false;
    bool increaed2 = false;
    bool increaed3 = false;
    public GameObject player;
    public GameObject Notification;
    public int TimeScore = 10;
    public int ScoreToAddForEnemy = 100;
    void Update()
    {
        if (player.GetComponentInParent<PlayerMovement>().endGame == true)
            return;
        _timeToDisplay -= Time.deltaTime;
        if (_timeToDisplay < 0)
        {
            score += TimeScore;
            _timeToDisplay = 1f;
        }
        
        _text.text = score.ToString();

        if(score > 1500 && increaed == false)
        {
            TimeScore = 100;
            ScoreToAddForEnemy = 500;
            Notification.GetComponent<Notification>().Notify("Difficulty increased");
            increaed = true;
            player.GetComponent<PlayerInterraction>().IncreaseDiff();
        }
        else if(score > 10000 && increaed2 == false)
        {
            TimeScore = 1000;
            ScoreToAddForEnemy = 5000;
            Notification.GetComponent<Notification>().Notify("Difficulty increased");
            increaed2 = true;
            player.GetComponent<PlayerInterraction>().IncreaseDiff();
        } 
        else if(score > 100000 && increaed3 == false)
        {
            TimeScore = 10000;
            ScoreToAddForEnemy = 50000;
            Notification.GetComponent<Notification>().Notify("Difficulty increased");
            increaed3 = true;
            player.GetComponent<PlayerInterraction>().IncreaseDiff();
        }
    }


    public void AddScore()
    {
        score += ScoreToAddForEnemy;
    }
}
