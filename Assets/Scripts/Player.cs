using System;
using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float attackAnimationTime;

    // private variables, these should not be exposed through the inspector.
    private Vector3 _originalScale;
    private Vector3 _originalPosition;
    private Rigidbody _rigidbody;
    private bool _isJumping;
    private bool _isCrouched;


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

        OnLand += () => _isJumping = false;
        OnJump += () => _isJumping = true;
        OnJump += StandUp;

        OnCrouch += () => _isCrouched = true;
        OnStand += () => _isCrouched = false;
    }


    private void Update()
    {
        if (HandleJumping())
        {
            return;
        }

        StartCoroutine(HandleAttacking());

        HandleScaling();
    }

    private void HandleScaling()
    {
        // can't scale when jumping!
        if (_isJumping)
        {
            return;
        }

        if (Input.GetKey(KeyCode.DownArrow))
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
        if (!Input.GetKeyDown(KeyCode.Space)) return false;
        if (!_isJumping)
        {
            Jump();
            return true;
        }

        return false;
    }

    private IEnumerator HandleAttacking()
    {
        if (Input.GetKey(KeyCode.W))
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