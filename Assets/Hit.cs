using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject stats;
    public GameObject[] HitEffects;
    public AudioSource AudioClip;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Enemy"))
        {
            AudioClip.Play(0);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().ShakeIt();
            GameObject effect = Instantiate(HitEffects[Random.Range(0, HitEffects.Length)]);

            effect.transform.position = other.transform.position + new Vector3(0, .3f, 0);
            stats.GetComponent<PlayerScore>().AddScore();
            GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>().GetHp();
            Destroy(other.gameObject);
        }


    }
}
