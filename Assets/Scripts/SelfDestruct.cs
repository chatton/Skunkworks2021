
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
