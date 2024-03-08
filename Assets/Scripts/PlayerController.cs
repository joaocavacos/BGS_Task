using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;

    private float hInput;
    private float vInput;
    private Vector2 movement;
    
    public float moveSpeed = 10f;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();     
        SetPlayerAnimation();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    private void GetInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void PlayerMove()
    {
        movement = new Vector2(hInput, vInput);
        _rb.velocity = movement.normalized * moveSpeed;
    }

    private void SetPlayerAnimation()
    {
        _animator.SetFloat("hInput", hInput);
        _animator.SetFloat("vInput", vInput);
        _animator.SetFloat("Speed", movement.sqrMagnitude);
                
        if (Mathf.Abs(hInput) >= 1 || Mathf.Abs(vInput) >= 1)
        {
            _animator.SetFloat("lastMoveX", vInput);
            _animator.SetFloat("lastMoveY", hInput);
        }
    }

}
