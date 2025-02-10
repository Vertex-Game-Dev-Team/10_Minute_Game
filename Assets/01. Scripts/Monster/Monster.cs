using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Monster : MonoBehaviour
{
    private Transform playerTransform;
    private Animator animator;
    private Collider attackCollider;
    private Collider sensingCollider;

    private bool isMove;
    private float attackWaitTime = 0.5f;
    private int hp;
    private int maxHp = 100;

    protected readonly int hashAttack = Animator.StringToHash("Attack");
    protected readonly int hashDamaged = Animator.StringToHash("Damaged");
    protected readonly int hashDeath = Animator.StringToHash("Death");
    protected readonly int hashMove = Animator.StringToHash("Move");

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        if(playerTransform != null && isMove)
        {
            if(Vector3.Distance(playerTransform.position, transform.position) < 5)
            {
                isMove = false;
                animator.SetBool(hashMove, false);
                StartCoroutine(Co_Attack());
            }
        }
    }

    private IEnumerator Co_Attack()
    {
        animator.SetTrigger(hashAttack);
        yield return null;

        float animationTime = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(attackWaitTime);

        attackCollider.enabled = true;
        yield return new WaitForSeconds(0.01f);
        attackCollider.enabled = false;

        yield return new WaitForSeconds(animationTime - attackWaitTime - 0.01f);
        isMove = true;
        animator.SetBool(hashMove, true);
    }

    public void Damaged(int damage)
    {
        hp -= damage;

        if(hp < 0)
        {
            playerTransform = null;
            isMove = false;
            animator.SetBool(hashDeath, true);
            Destroy(this.gameObject, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerTransform == null)
        {
            playerTransform = other.transform;
            sensingCollider.enabled = false;

            isMove = true;
            animator.SetBool(hashMove, true);
        }
    }
}
