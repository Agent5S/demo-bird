using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerJump : MonoBehaviour
{
    public float jumpVelocity;
    private Rigidbody2D rb;

    private void FireStarted(InputAction.CallbackContext obj)
    {
        var velocity = rb.velocity;
        velocity.y = jumpVelocity;
        this.rb.velocity = velocity;
    }

    private void FireCanceled(InputAction.CallbackContext obj)
    {
        var velocity = rb.velocity;
        velocity.y = velocity.y > 0 ? 0 : velocity.y; 
        this.rb.velocity = velocity;
    }

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        var input = InputObject.@default;
        input.Player.Enable();
        input.Player.Fire.started += FireStarted;
        input.Player.Fire.canceled += FireCanceled;
    }

    private void OnDisable()
    {
        var input = InputObject.@default;
        input.Player.Disable();
        input.Player.Fire.started -= FireStarted;
        input.Player.Fire.canceled -= FireCanceled;
    }
}
