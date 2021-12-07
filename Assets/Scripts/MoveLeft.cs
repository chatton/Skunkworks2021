using System;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    
    [SerializeField] private float amountToMoveToTheLeft;

    private Health _playerHealth;
    
    private void Start()
    {
        _playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
    }

    void Update()
    {
        // stop moving the level if the player died.
        if (_playerHealth.IsDead)
        {
            return;
        }

        Vector3 currentPosition = transform.position;
        
        // move the current position to the left every frame.
        transform.position =
            new Vector3(currentPosition.x - amountToMoveToTheLeft * Time.deltaTime, currentPosition.y, currentPosition.z);
    }
}
