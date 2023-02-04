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
    

    private void Awake()
    {
        _transform = gameObject.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        previousPosition = _transform.position;
        Vector2 movement = Vector2.zero;
        
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float verticalPosition = 0;
        
        if (verticalMovement == 0) verticalPosition = center.position.y;
        else if (verticalMovement == 1) verticalPosition = northLimit.position.y;
        else if (verticalMovement == -1) verticalPosition = southLimit.position.y;

        movement = new Vector2(_transform.position.x, );
        
        float horizontalMovement = Input.GetAxisRaw("Vertical");
        float horizontalPosition = 0;
        if (horizontalMovement == 0)
        {
            movement = new Vector2(Mathf.Lerp(previousPosition.x, center.position.x, Time.deltaTime * speed), _transform.position.y);
        }
        else if (horizontalMovement == 1)
        {
            movement = new Vector2(Mathf.Lerp(previousPosition.x, eastLimit.position.x, Time.deltaTime * speed), _transform.position.y);
        }
        else if (horizontalMovement == -1)
        {
            
        }
        movement = new Vector2(, 
            );

        float xMovement = Mathf.Lerp(previousPosition.x, westLimit.position.x, Time.deltaTime * speed);
        float yMovement = Mathf.Lerp(previousPosition.y, verticalPosition, Time.deltaTime * speed);
        transform.position = movement;
    }
    
}
