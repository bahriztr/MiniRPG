using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Instance process
    public static Player instance;

    [Header("Move Info")]
    public float moveSpeed = 5;

    public float facingDir { get; private set; } = 1;
    private bool facingRight = true;

    [Header("Timer Info")]
    private float timer = 0.57f;

    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    #endregion


    private void Awake()
    {
        InstanceProcess();

        //Create the states
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Run");
    }

    private void Start()
    {
        //Components assign process
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //First state assign
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        //Update states
        stateMachine.currentState.Update();
        UpdateTimer();
        PlayerAttacks();
    }

    private void InstanceProcess()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }

    public void PlayerAttacks()
    {
        if (Input.GetMouseButtonDown(0) && TimerForAttack())
            anim.SetTrigger("Attack");
    }

    private bool TimerForAttack()
    {
        if (timer > 0.57f)
        {
            timer = 0f;
            return true;
        }

        return false;
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        //Character movement
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController(_xVelocity);
    }

    public void Flip()
    {
        //Character rotates
        facingDir *= 1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float _x)
    {
        //Character flips with inputs
        if (_x > 0 && !facingRight)
            Flip();
        else if(_x < 0 && facingRight)
            Flip();
    }
}
