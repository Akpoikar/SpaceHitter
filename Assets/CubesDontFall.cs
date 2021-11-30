using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesDontFall : MonoBehaviour
{
    public float time = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Player"))
        {
            if (other.gameObject.GetComponentInChildren<PlayerInterraction>().WantToDie == false)
                return;
            IEnumerator tmpEnum = DontFallBuff(time, other.gameObject);
            StartCoroutine(tmpEnum);
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
        }
    }

    IEnumerator DontFallBuff(float time, GameObject playerObject)
    {

        playerObject.GetComponentInChildren<PlayerInterraction>().WantToDie = false;
        yield return new WaitForSeconds(time);
        playerObject.GetComponentInChildren<PlayerInterraction>().WantToDie = true;
        Destroy(gameObject);
    }
}
