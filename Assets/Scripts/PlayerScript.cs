using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int health;
    public bool alive;

    public float speed;

    public Rigidbody rb;

    public Vector3 movement;

    //Player status
    public Moving movingS;
    public Idle idleS;

    //State Machine
    public StateMachine sm;

    void Start()
    {
        sm = gameObject.GetComponent<StateMachine>();

        movingS = new Moving(this, sm);
        idleS = new Idle(this, sm);

        sm.Init(idleS);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        sm.CurrentState.HandleInput();
        sm.CurrentState.LogicUpdate();

    }

    void FixedUpdate()
    {
        sm.CurrentState.PhysicsUpdate();

        if (movement != Vector3.zero)
        {
            transform.forward = movement;
        }
    }


    public void PlayerInput()
    {
        //Gets the horizontal input to be used for the 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
    }

    //If movement input, current = moving
    public void CheckForMoveInput()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            sm.ChangeState(movingS);
        }
    }

    //If no input then state = idle
    public void CheckForIdle()
    {
        if (!Input.anyKey)
        {
            if (rb.velocity.magnitude <= 0.2)
            {
                sm.ChangeState(idleS);
            }
        }
    }

    //Used by the Moving state to make the player move
    public void MovePLayer()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Ghost"))
        {
            SceneManager.LoadScene("Game Over");
        }

    }
}
