using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float attackRadius = 10f;
    public float rotSPeed = 7f;
    public float stoppingDis = 2f;

    Animator anim;
    Transform meta;
    NavMeshAgent agent;
    
    

    // Start is called before the first frame update
    void Start()
    {
        meta = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    { 
    

    float distance = Vector3.Distance(meta.position, transform.position);
     

      
        
        if (distance <= attackRadius)
        {
            anim.SetInteger("condition", 1);
            agent.SetDestination(meta.position);

            if (distance <= agent.stoppingDistance)
            {
                //napadni metu
                FaceTarget();
                anim.SetInteger("condition", 0);
            }
        } else if (distance > attackRadius)
        {
            agent.isStopped = true;
            agent.ResetPath();
            anim.SetInteger("condition", 0);
        }
        
    }
    void FaceTarget()
    {
        Vector3 direction = (meta.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotSPeed);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
