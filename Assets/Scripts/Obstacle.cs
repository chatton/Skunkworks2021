using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // only handle the case of a player walking into it.
        if (!other.IsPlayer())
        {
            return;
        }

        Debug.Log(other.gameObject);
        Destroy(other.gameObject);
    }
}
