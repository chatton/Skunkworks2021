using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    
    [SerializeField] private float amountToMoveToTheLeft;
    void Update()
    {
        Vector3 currentPosition = transform.position;
        
        // move the current position to the left every frame.
        transform.position =
            new Vector3(currentPosition.x - amountToMoveToTheLeft * Time.deltaTime, currentPosition.y, currentPosition.z);
    }
}