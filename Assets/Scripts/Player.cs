using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header("Jumping Related Fields")] [SerializeField]
    private float jumpForce;

    [Header("Attack Related Fields")] [SerializeField]
    private float attackAnimationTime;

    [SerializeField] private float attackCooldown;


    // private variables, these should not be exposed through the inspector.
    private Vector3 _originalScale;
    private Vector3 _originalPosition;
    private Rigidbody _rigidbody;
    private Health _health;

    // boolean indicating if the player is currently jumping.
    private bool _isJumping;

    // boolean indicating if the player is currently crouching.
    private bool _isCrouched;

    // boolean indicating if the player is currently attacking.
    private bool _isAttacking;

    // this is a running tally of how long has passed since the last attack.
    private float _elapsedTimeSinceLastAttack;


    // Callbacks. Other components can register events for these callbacks.

    public Action OnJump { get; set; }
    public Action OnLand { get; set; }

    public Action OnCrouch { get; set; }
    public Action OnStand { get; set; }

    public Action OnAttack { get; set; }
    public Action OnStopAttack { get; set; }

    private void Awake()
    {
        // cache reference to the Scale we were at when we started.
        _originalScale = transform.localScale;
        _originalPosition = transform.localPosition;
        _rigidbody = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();

        OnLand += () => _isJumping = false;
        OnJump += () => _isJumping = true;
        OnJump += StandUp;

        OnCrouch += () => _isCrouched = true;
        OnStand += () => _isCrouched = false;

        OnAttack += () => _isAttacking = true;
        OnStopAttack += () =>
        {
            _isAttacking = false;
            _elapsedTimeSinceLastAttack = 0;
        };


        _elapsedTimeSinceLastAttack = attackCooldown;
    }

    private void Start()
    {
        Assert.IsNotNull(_health);
        Assert.IsNotNull(_rigidbody);
    }


    private void Update()
    {
        // check player health
        _health = GetComponent<Health>();
        if (_health.CurrentHealth <= 0)
        {
            return;
        }

        if (HandleJumping())
        {
            return;
        }

        // handle cooldown on performing an attack.
        // Can only do an attack every "attackCooldown" seconds.
        _elapsedTimeSinceLastAttack += Time.deltaTime;
        if (_elapsedTimeSinceLastAttack >= attackCooldown)
        {
            StartCoroutine(HandleAttacking());
        }


        HandleScaling();
    }

    private void HandleScaling()
    {
        // can't scale when jumping!
        if (_isJumping)
        {
            return;
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (!_isCrouched)
            {
                Crouch();
            }
        }
        else
        {
            if (_isCrouched)
            {
                StandUp();
            }
        }
    }

    private bool HandleJumping()
    {
        if (!Input.GetKeyDown(KeyCode.W)) return false;
        if (!_isJumping)
        {
            Jump();
            return true;
        }

        return false;
    }

    private IEnumerator HandleAttacking()
    {
        if (Input.GetKey(KeyCode.D) && !_isAttacking)
        {
            OnAttack?.Invoke();
            yield return new WaitForSeconds(attackAnimationTime);
            OnStopAttack?.Invoke();
        }
    }

    private void Crouch()
    {
        // the crouched position should be lowered by half of the height to place it at the ground.
        // we can do this immediately rather than letting the physics take some time to fall to the ground.
        Vector3 crouchedPosition = _originalPosition;
        crouchedPosition.y = _originalPosition.y / 2;
        UpdateTransform(new Vector3(1, 0.5f, 1), crouchedPosition);
        OnCrouch?.Invoke();
    }

    private void StandUp()
    {
        UpdateTransform(_originalScale, _originalPosition);
        OnStand?.Invoke();
    }

    private void UpdateTransform(Vector3 scale, Vector3 position)
    {
        transform.localScale = scale;
        transform.position = position;
    }

    private void Jump()
    {
        if (_isJumping)
        {
            throw new Exception("Jump cannot be called if the player is already jumping!");
        }

        Debug.Log("Jumping!", gameObject);
        // any registered callbacks get called when jump is pressed.
        // we can play things like animations and sound effects this way.
        OnJump?.Invoke();
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (HandleCollisionWithGround(other))
        {
            // if we hit the ground, there is nothing else to do.
            return;
        }

        // TODO: handle collisions with other things.
    }

    // HandleCollisionWithGround returns true if the ground was hit, false if it wasn't.
    // Any callbacks registered with hitting the ground are executed if the ground was hit.
    private bool HandleCollisionWithGround(Collision other)
    {
        // if we're not jumping, it doesn't matter if we are touching the ground or not.
        if (!_isJumping)
        {
            return false;
        }

        Ground ground = other.gameObject.GetComponent<Ground>();
        // we just collided with the ground!
        if (ground != null)
        {
            // any registered callbacks happen. (Sound effects, animations etc.)
            OnLand?.Invoke();
            return true;
        }

        return false;
    }
}