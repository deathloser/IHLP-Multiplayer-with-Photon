using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour {
    
    [SerializeField] float damage = 2.0f;
    float lastAttackTime = 0;
    float attackCooldown = 0.5f;

    NavMeshAgent agent;
    GameObject target;

    Animator anim;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();

        //chase the player (target)
        target = GameObject.FindGameObjectWithTag("Player");

        //animate the zombie
        anim = GetComponent<Animator>();
    }

    private void Update() {
        float distance = Vector3.Distance(transform.position,target.transform.position);
        if(distance<2) {
            StopEnemy();
            Attack();
            
            
            //Debug.Log("Here is the damage");

        } else {
            anim.SetBool("isAttacking",false);

            GoToTarget();
        }
        
    }

    private void GoToTarget() {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
        anim.SetBool("isWalking", true);

    }

    private void StopEnemy() {
        agent.isStopped = true;
        anim.SetBool("isWalking",false);

    }

    private void Attack() {
        if (Time.time - lastAttackTime > attackCooldown) {
                lastAttackTime = Time.time;
                target.GetComponent<CharacterStats>().TakeDamage(damage);
                target.GetComponent<CharacterStats>().CheckHealth();
                anim.SetBool("isAttacking",true);
                

            } 

    }


    public void ReactToHit() {
        
        StartCoroutine(Die());
        
    }

    private IEnumerator Die() {
        anim.SetBool("isKilled",true);
        
        
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);

        //
        
    }





}
