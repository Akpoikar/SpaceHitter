using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public float speed = 2f;
    public NavMeshAgent agent;

    float AttackCD;
    public float defAttackCD = 1f;
    IEnumerator HitEffect;
    Animator animator;
    public Animator hitAnimator;
    public GameObject hitter;
    public float HitTimer = .5f;

    private void Start()
    {
        AttackCD = 0;
       // animator = GetComponent<Animator>();
    }

    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target == null) return;
        agent.SetDestination(target.transform.position);

        if (Vector3.Distance(target.transform.position, transform.position) < 3f)
        {

            AttackCD -= Time.deltaTime;
            if (AttackCD < 0)
            {
                Hit();
                AttackCD = defAttackCD;
            }
        }
    }

    public void Hit()
    {
       // animator.SetTrigger("Hit");
        HitEffect = hitEff();
        StartCoroutine(HitEffect);
    }

    public IEnumerator hitEff()
    {
        hitAnimator.SetTrigger("Hit");
        GetComponentInChildren<TrailRenderer>().enabled = true;
        yield return new WaitForSeconds(.3f);
        hitter.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(.4f);
        GetComponentInChildren<TrailRenderer>().enabled = false;
        hitter.transform.gameObject.SetActive(false);
    }

}
