using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBuff : MonoBehaviour
{
    public float time = 3f;
    Animator FadeAnimator;
    private void Start()
    {
        FadeAnimator = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            IEnumerator tmpEnum = FadingBuff(time);
            StartCoroutine(tmpEnum);
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
        }
    }

    IEnumerator FadingBuff(float timer)
    {
        Debug.Log("GetFade");
        FadeAnimator.SetTrigger("Fade");
        for (int i = 0; i < timer; i++)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().ShakeIt();
            yield return new WaitForSeconds(1);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().ShakeIt();
        }
        FadeAnimator.SetTrigger("Unfade");
        Destroy(gameObject);
    }
}
