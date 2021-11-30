using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _text;
    [SerializeField] public TextMeshProUGUI _Hightext;
    GameObject score;
 /*   void OnGUI()
    {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete"))
        {
            PlayerPrefs.DeleteAll();
        }
    }*/
    private void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score");
    }
    private void Update()
    {
        if (_text != null)
        {
            int playerScore = score.GetComponent<PlayerScore>().score;
            int highestScore = PlayerPrefs.GetInt("HighScore");

            if(playerScore > highestScore)
                PlayerPrefs.SetInt("HighScore", playerScore);

            _text.text = "score:" + playerScore.ToString();
            _Hightext.text = "highest:" + PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
    public void Restart()
    {
        Debug.Log("Restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
}
