using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GhostScript : MonoBehaviour
{
    public PlayerScript ps;

    public GameObject spawn;
    public GameObject[] targets = { };

    public int destPoint;

    public NavMeshAgent agent;

    public Animator anim;

    public bool dead;

    //Player status variables
    public Hunting huntingS;

    private StateMachine sm;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sm = gameObject.AddComponent<StateMachine>();
        anim = GetComponent<Animator>();

        // add new states here
        huntingS = new Hunting(this, sm);


        // initialise the statemachine with the default state
        sm.Init(huntingS);
    }

    // Update is called once per frame
    void Update()
    {
        sm.CurrentState.HandleInput();
        sm.CurrentState.LogicUpdate();
        //print(sm.CurrentState);
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5F)
        {
            GoToTarget();
        }
    }

    public void GoToTarget()
    {
        if (targets.Length == 0)
        {
            print("No targets");
            return;
        }

        agent.destination = targets[destPoint].transform.position;
        destPoint = (destPoint + 1) % targets.Length;
    }
}
