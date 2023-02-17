using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Transform _transform;
    
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Transform[] _vfxPositions;
    [SerializeField] private float speed = 1f;
    
    [Header("Limits")]
    [SerializeField] private Transform _center;
    [SerializeField] private Transform _northLimit;
    [SerializeField] private Transform _southLimit;
    [SerializeField] private Transform _eastLimit;
    [SerializeField] private Transform _westLimit;
    [SerializeField] private Animator _animator;
    
    private int _particleIndex;
    private Vector2 _previousPosition;
    private float _elapsedTime;
    private float _verticalPosition;
    private float _horizontalPosition = 0;

    [SerializeField] private AudioSource playerDash;

    public bool CanShoot;

    private void Awake()
    {
        _transform = gameObject.transform;
        transform.position = _center.position;
        _verticalPosition = _transform.position.y;
        _horizontalPosition = _transform.position.x;
        CanShoot = false;
    }

    private void Update()
    {
        Move();
        Shoot();
    }

    private void Shoot()
    {
        if (CanShoot)
        {
            if (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.K))
            {
                _particleSystems[_particleIndex].Play();
                AudioManager.Instance.Player_Shoot();
                if (_transform.position.x != 0)
                {
                    _animator.SetTrigger("Attack");
                    StartCoroutine(ShootAnimation());
                }
            }
        }
    }

    private IEnumerator ShootAnimation()
    {
        _animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(0.2f);
        _animator.SetBool("IsAttacking", false);
    }

    private void Move()
    {
        _previousPosition = _transform.position;

        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) playerDash.Play();
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) playerDash.Play();
        
        if ((int)verticalMovement == 1) _verticalPosition = _northLimit.position.y;
        else if ((int)verticalMovement == -1) _verticalPosition = _southLimit.position.y;

        _animator.SetFloat("H_Mov", Input.GetAxis("Horizontal"));
        _animator.SetFloat("V_Mov", Input.GetAxis("Vertical"));

        if (horizontalMovement == 0) _horizontalPosition = _center.position.x;
        
        if ((int)horizontalMovement == 1)
        {
            _particleSystems[0].transform.position = _vfxPositions[0].position;
            _particleIndex = 0;
            _horizontalPosition = _eastLimit.position.x;
        }
        else if ((int)horizontalMovement == -1)
        {
            _particleSystems[1].transform.position = _vfxPositions[1].position;
            _particleIndex = 1;
            _horizontalPosition = _westLimit.position.x;
        }

        float xMovement = _transform.position.x;
        float yMovement = _transform.position.y;
        
        // if ((int) _previousPosition.x == (int) _center.position.x || Input.GetAxis("Horizontal") == 0)
        // {
        //     yMovement = Mathf.Lerp(_previousPosition.y, _verticalPosition, Time.deltaTime * speed);
        // }
        
        yMovement = Mathf.Lerp(_previousPosition.y, _verticalPosition, Time.deltaTime * speed);
        
        xMovement = Mathf.Lerp(_previousPosition.x, _horizontalPosition, Time.deltaTime * speed);
        
        // if (_previousPosition.y >= _northLimit.position.y - 0.1f || (int)_previousPosition.y <= (int)_southLimit.position.y + 0.1f)
        // {
        //     xMovement = Mathf.Lerp(_previousPosition.x, _horizontalPosition, Time.deltaTime * speed);
        // }
        
        transform.position = new Vector2(xMovement,yMovement);
    }
    
    
}
