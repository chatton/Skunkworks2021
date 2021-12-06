using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1;

    // the player health
    private Health _playerHealth;

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

        _playerHealth.TakeDamage(damage);
        // the obstacle gets destroyed after the player runs into it.
        Destroy(gameObject);
    }
}