using UnityEngine;

public class FireBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        // our own fireball can't hit the player. Just ignore the collision.
        if (other.IsPlayer())
        {
            return;
        }
    }
}