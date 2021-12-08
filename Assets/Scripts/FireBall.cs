using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        // our own fireball can't hit the player. Just ignore the collision.
        if (other.IsPlayer())
        {
            Physics.IgnoreCollision(other.collider, GetComponent<Collider>());
            return;
        }
        
        Monster monster = other.gameObject.GetComponent<Monster>();
        // the thing we hit is an obstacle! Let's destroy it.
        if (monster != null)
        {
            monster.Kill();
        }
    }
    
}