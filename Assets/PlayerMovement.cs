using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    public float playerSpeed = 2.0f;

    public GameObject hitter;
    float AttackCD;
    public float defAttackCD = 1f;

    private float gravityValue = -9.81f;
    public Animator animator;
    public float HitTimer = .5f;
    IEnumerator HitEffect;
    public GameObject gameOver;
    public GameObject[] hiders;
    public bool endGame = false;
    Vector3 curPos;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        curPos = transform.position;
        AttackCD = 0;

    }

    void Hit()
    {
        animator.SetTrigger("Hit");
        HitEffect = hitEff();
        StartCoroutine(HitEffect);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, curPos) > 3)
        {
            Debug.LogError(transform.position);
            transform.position = curPos;
            return;
        }
        else curPos = transform.position;

        if (endGame) return;

        if(transform.localPosition.y < -5f)
        {
            foreach (var item in hiders)
            {
                item.SetActive(false);
            }
            gameOver.SetActive(true);
            endGame = true;
            return;
        }
        AttackCD -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (AttackCD < 0)
            {
                Hit();
                AttackCD = defAttackCD;
            }
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        if (!groundedPlayer)
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }

    public IEnumerator hitEff()
    {
        yield return new WaitForSeconds(HitTimer);
        hitter.transform.gameObject.SetActive(true);
        yield return new WaitForSeconds(HitTimer);
        hitter.transform.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Buff"))
        {
         //   other.gameObject.GetComponent<CubesDontFall>().DoAction(gameObject);
        }
    }
}
