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
    private AreaTrigger _areaTrigger;

    private static readonly int Die = Animator.StringToHash("Die");
    private static readonly int Attacking = Animator.StringToHash("Attacking");


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _areaTrigger = GetComponentInChildren<AreaTrigger>();
        _collider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        ;
    }

    private void Start()
    {
        // get a reference to the player's health, any time the player runs into an obstacle they will take damage.
        _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
        _areaTrigger.Callback += PlayerEnteredDeathBox;
    }


    private void PlayerEnteredDeathBox(Collider col)
    {
        if (!col.IsPlayer())
        {
            return;
        }

        _animator.SetBool(Attacking, true);
        _playerHealth.TakeDamage(damage);
    }

    // private void OnCollisionEnter(Collision other)
    // {
    //     // only handle the case of a player walking into it.
    //     if (!other.IsPlayer())
    //     {
    //         return;
    //     }
    //
    //     _animator.SetBool(Attacking, true);
    //     _playerHealth.TakeDamage(damage);
    // }

    public void Kill()
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        _areaTrigger.GetComponent<Collider>().enabled = false;
        _animator.SetTrigger(Die);
        // StartCoroutine(KillRoutine());
    }

    // private IEnumerator KillRoutine()
    // {
    // disable the collider so no collisions can happen again.

    // }
}