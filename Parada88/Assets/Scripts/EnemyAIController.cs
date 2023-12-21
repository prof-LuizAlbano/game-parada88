// ---------------------------------------------
// ---------------------------------------------
// Creation Date: 2023-12-12
// Author: Testes Parada88 
// Project Name: junio 
// Description: 
// 
// ---------------------------------------------
// ---------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    public enum EnemyState { Idle, Chase, Attack }
    [SerializeField] private EnemyState _enemyState;

    [Header ("Movement")]
    [SerializeField] private float _gravity = 20f;
    [SerializeField] private float _moveSpeed = 2f;

    [Header ("Attack")]
    [SerializeField] private int _attackPower = 15;
    [SerializeField] private float _attackDistance = 1f;
    [SerializeField] private float _attackRate = 0.5f;

    [Header ("References")]
    [Tooltip ("Must be a capsule collider")] [SerializeField] private CapsuleCollider _collider;

    [Header ("Distances")]
    [SerializeField] private float playerPosition;
    [SerializeField] private float enemyPosition;
    [SerializeField] private float radiousOfAction = 10f;

    private Transform _player;
    private Transform _currentTarget;
    private Vector3 _velocity;
    private float _yVelocity;
    private Health _currentAttackTarget;
    private float _nextAttack = -1f;

    CharacterController _controller;
    private Animator _animator;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemyState = EnemyState.Idle;
        _player = GameObject.FindGameObjectWithTag("Player").transform;

        if( _player == null) {
            Debug.LogError("Player not found");
        }
        else {
            _currentTarget = _player;
            //_enemyState = EnemyState.Chase;
        }

        if( _collider == null ) {
            Debug.LogError("No trigger collider detected on enemy " + gameObject.name );
        }
        else {
            _collider.radius = _attackDistance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( this.detect() ) {
            _enemyState = EnemyState.Chase;
        }
        else {
            _enemyState = EnemyState.Idle;
        }

        switch (_enemyState)
        {
            case EnemyState.Idle:
                _animator.SetFloat("Speed", 0 );
                break;

            case EnemyState.Chase:
                _animator.SetFloat("Speed", 1 );
                CalculateMovement();
                break;

            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        _enemyState = EnemyState.Idle;
    }

    public bool detect()
    {
        // Distance of the player to the enemy along the X and Y axes
        float Xdistance = _player.transform.position.x - transform.position.x;
        float Ydistance = _player.transform.position.y - transform.position.y;

        if( (Mathf.Pow(Xdistance,2) + Mathf.Pow(Ydistance,2)) < Mathf.Pow(2.15f,2) )
            return false;
    
        return (Mathf.Pow(Xdistance,2) + Mathf.Pow(Ydistance,2)) < Mathf.Pow(this.radiousOfAction,2);
    }

    private void CalculateMovement()
    {
        if( _controller.isGrounded )
        {
            Vector3 direction = _currentTarget.position - transform.position;
            direction.Normalize();
            direction.y = 0f;

            transform.localRotation = Quaternion.LookRotation(direction);
            _velocity = direction * _moveSpeed;
        }
        else {
            _yVelocity -= _gravity;
        }

        _velocity.y = _yVelocity;
        _controller.Move(_velocity * Time.deltaTime );
    }

    private void Attack()
    {
        if( Time.time > _nextAttack )
        {
            if( _currentAttackTarget != null )
            {
                _currentAttackTarget.Damage(_attackPower);
                //UIManager.Instance.ActivateSplatter();
                _nextAttack = Time.time + _attackRate;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Player") )
        {
            _currentAttackTarget = _player.GetComponent<Health>();

            if( _currentAttackTarget != null )
            {
                _enemyState = EnemyState.Attack;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if( other.CompareTag("Player") )
        {
            _currentAttackTarget = null;
            _enemyState = EnemyState.Chase;
        }
    }
}
