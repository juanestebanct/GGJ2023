using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Transform _transform;
    private Rigidbody2D rb;

    [SerializeField] private float speed = 1f;
    
    [Header("Limits")]
    [SerializeField] private Transform northLimit;
    [SerializeField] private Transform center;
    [SerializeField] private Transform southLimit;
    [SerializeField] private Transform eastLimit;
    [SerializeField] private Transform westLimit;

    private Vector2 previousPosition;
    private float elapsedTime;
    private float verticalPosition;
    private float horizontalPosition = 0;
    

    private void Awake()
    {
        _transform = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(center.position.x, center.position.y);
        verticalPosition = _transform.position.y;
        horizontalPosition = _transform.position.x;
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        
    }

    private void Move()
    {
        previousPosition = _transform.position;

        float verticalMovement = Input.GetAxisRaw("Vertical");

        if ((int)verticalMovement == 1) verticalPosition = northLimit.position.y;
        else if ((int)verticalMovement == -1) verticalPosition = southLimit.position.y;

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (horizontalMovement == 0) horizontalPosition = center.position.x;
        else if ((int)horizontalMovement == 1) horizontalPosition = eastLimit.position.x;
        else if ((int)horizontalMovement == -1) horizontalPosition = westLimit.position.x;

        float xMovement = _transform.position.x;
        float yMovement = _transform.position.y;
        
        if ((int)previousPosition.x == (int)center.position.x || Input.GetAxis("Horizontal") == 0)
        {
            yMovement = Mathf.Lerp(previousPosition.y, verticalPosition, Time.deltaTime * speed);
        }
        if (previousPosition.y >= northLimit.position.y-0.1f || (int)previousPosition.y <= (int)southLimit.position.y+0.1f)
        {
            xMovement = Mathf.Lerp(previousPosition.x, horizontalPosition, Time.deltaTime * speed);
        }
        transform.position = new Vector2(xMovement,yMovement);
    }
    
    
}
