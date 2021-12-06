using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        // our own fireball can't hit the player. Just ignore the collision.
        if (other.IsPlayer())
        {
            return;
        }
        
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();
        // the thing we hit is an obstacle! Let's destroy it.
        if (obstacle != null)
        {
            Destroy(obstacle.gameObject);
        }
    }
    
}