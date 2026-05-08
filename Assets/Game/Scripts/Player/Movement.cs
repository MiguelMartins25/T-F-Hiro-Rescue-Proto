using System;
using System.Numerics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 0;
    private bool facingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    
    private UnityEngine.Vector2 movement;

    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        movement.x += input * accel * Time.deltaTime;
        transform.Translate(movement);
    }
}
