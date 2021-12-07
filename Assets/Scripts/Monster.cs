using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float deathTimer;


    // the player health
    private Health _playerHealth;
    private Animator _animator;
    private BoxCollider _collider;
    private Rigidbody _rigidbody;

    private static readonly int Die = Animator.StringToHash("Die");
    private static readonly int Attacking = Animator.StringToHash("Attacking");


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _collider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // get a reference to the player's health, any time the player runs into an obstacle they will take damage.
        _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
    }


    private void OnCollisionEnter(Collision other)
    {
        // only handle the case of a player walking into it.
        if (!other.IsPlayer())
        {
            return;
        }

        _animator.SetBool(Attacking, true);
        _playerHealth.TakeDamage(damage);
    }

    public void Kill()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _animator.SetTrigger(Die);
        // StartCoroutine(KillRoutine());
    }

    // private IEnumerator KillRoutine()
    // {
    // disable the collider so no collisions can happen again.

    // }
}