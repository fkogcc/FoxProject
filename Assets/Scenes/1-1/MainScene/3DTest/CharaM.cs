using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharaM : MonoBehaviour
{
    public float jumpSpeed = 10;
    public float groundDistance = 0.01f;
    bool isOnGround = false;// ’n–Ê‚É—§‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©

    Animator animator;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        isOnGround = CheckForGround();
    }

    bool CheckForGround()
    {
        Vector3 capsuleBottom = capsuleCollider.center + Vector3.down * capsuleCollider.height * 0.5f;
        Vector3 feetPosition = transform.TransformPoint(capsuleBottom);

        return false;
    }

    public void Move(Vector2 input)
    {
        
    }

    void OnMove(InputValue inputValue)
    {
        Move(inputValue.Get<Vector2>());
    }

    public void Jump(bool state)
    {
        if(state)
        {
            rb.velocity += Vector3.up * jumpSpeed;
        }
    }

    void OnJump(InputValue inputValue)
    {
        Jump(inputValue.isPressed);
    }
}
