using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    GameObject stats;
    GameObject score;

    public GameObject[] HitEffects;
    public AudioSource AudioClip;
    int dmg = 1;
    bool increaed = false;
    bool increaed2 = false;
    bool increaed3 = false;
    private void Start()
    {
        stats = GameObject.FindGameObjectWithTag("Player");
        score = GameObject.FindGameObjectWithTag("Score");

    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag.Equals("Player"))
        {
            if (score.GetComponent<PlayerScore>().score > 1500 && !increaed)
            {
                increaed = true;
                dmg = 2;
            }
            if (score.GetComponent<PlayerScore>().score > 10000 && !increaed2)
            {
                increaed2 = true;
                dmg = 3;
            }   
            if (score.GetComponent<PlayerScore>().score > 100000 && !increaed3)
            {
                increaed3 = true;
                dmg = 4;
            }

            AudioClip.Play(0);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().ShakeIt();
            GameObject effect = Instantiate(HitEffects[Random.Range(0, HitEffects.Length)]);

            effect.transform.position = other.transform.position + new Vector3(0, .3f, 0);

            stats.GetComponent<Stats>().GetHit(dmg);
        }


    }
}
