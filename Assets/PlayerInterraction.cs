using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterraction : MonoBehaviour
{
    public float timer = 10f;
    public float StartFadeSpeed = 2f;
    private IEnumerator coroutine;
    public bool WantToDie = true;
    public GameObject FallEffect;
    public GameObject RaiseEffect;
    public int maxIntercation = 1;

    public void IncreaseDiff()
    {
        maxIntercation++;
    }

    void OnTriggerEnter(Collider other)
    {
        if (WantToDie == false) return;
            if (!other.transform.tag.Equals("Ground")) return;


        if (!other.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName
            ("New State")) return;

//        Debug.Log("Remember" + other.transform.name);
        coroutine = Interact(timer, other.transform.gameObject, maxIntercation);

        StartCoroutine(coroutine);
    }

    private IEnumerator Interact(float waitTime,GameObject gameObject, int maxInter)
    {
        if (maxInter == 0)
            yield break;
        Animator animator = gameObject.GetComponent<Animator>();
        // gameObject.GetComponent<Renderer>().material.color = Color.red;
        animator.SetTrigger("Color");
         yield return new WaitForSeconds(2.5f);

        animator.SetTrigger("Small");
        #region Effect
        /*var ob1 = Instantiate(FallEffect);
            ob1.transform.position = gameObject.transform.position + new Vector3(0,1,0);
            Destroy(ob1, 1.5f);*/
        #endregion
        yield return new WaitForSeconds(waitTime);
        animator.ResetTrigger("Small");

        animator.SetTrigger("Big");
        #region RiseEffect
       /* var obj = Instantiate(RaiseEffect);
            obj.transform.position = gameObject.transform.position;
            Destroy(obj, 1.5f);*/
        #endregion
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(waitTime);
        animator.ResetTrigger("Big");

        StartCoroutine(Interact(waitTime, gameObject, maxInter - 1));
    }

}
