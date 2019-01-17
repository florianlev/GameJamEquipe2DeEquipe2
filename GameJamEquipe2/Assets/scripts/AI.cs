using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{

    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("isWalk", true);
        if (_navMeshAgent == null)
        {
            Debug.LogError("Le nav mesh n'est pas attacher a : " + gameObject.name);
        }
        else if(gameObject.tag != "client")
        {

            setDestination();
        }
    }

    public void setDestination()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }

}
