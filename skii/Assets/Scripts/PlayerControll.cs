using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private InputAction move;
    public bool reverseControl = false;
    [SerializeField] private bool grounded = true;
    [SerializeField] LayerMask groundMask;
    
    [SerializeField] private float rotSpeed = 30;
    private Rigidbody rb;
    [SerializeField] private float forwardForce = 50;
    [SerializeField] private Vector3 pushbackForce;
    [SerializeField] private bool disabledControl= false;
    [SerializeField] private float disableTime = 1;
    private float lastControlTime;

    private void Awake()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += takeDamage;
    }
    void takeDamage()
    {
        rb.AddForce(pushbackForce);
        disabledControl = true;
        lastControlTime = Time.timeSinceLevelLoad;
        Debug.Log("PLAYER GOT HURT");
    }
    void FixedUpdate()
    {
        if(Time.timeSinceLevelLoad > lastControlTime + disableTime)
            disabledControl = false;
        grounded = Physics.Linecast(transform.position,transform.position +Vector3.down, groundMask);
        Color lineCol = grounded ? Color.green : Color.red;
        Debug.DrawLine(transform.position,transform.position + Vector3.down, lineCol);

        if (grounded && !disabledControl)
        {
            Vector2 moveInput = move.ReadValue<Vector2>();
            if (reverseControl)
            {
                transform.Rotate(0, -moveInput.x * rotSpeed* Time.deltaTime, 0);
            }
            else
            {
                transform.Rotate(0, moveInput.x * rotSpeed* Time.deltaTime, 0);
            }
            float turnAngle = Math.Abs(180- transform.localEulerAngles.y);
            float speedMult = Mathf.Cos(turnAngle * Mathf.Deg2Rad);
            rb.AddForce(transform.forward * forwardForce * speedMult * Time.fixedDeltaTime);
        }
    }
}