using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float amountToMoveToTheLeft;

    private Health _playerHealth;


    private Health PlayerHealth
    {
        get
        {
            if (_playerHealth != null)
            {
                return _playerHealth;
            }

            _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
            return _playerHealth;
        }
    }

    void Update()
    {
        // stop moving the level if the player died.
        if (PlayerHealth.IsDead)
        {
            return;
        }


        // move the current position to the left every frame.
        transform.Translate(Vector3.left * amountToMoveToTheLeft * Time.deltaTime);
    }
}