
using UnityEngine;


public class SelfDestruct : MonoBehaviour
{

    private void Start() {
        Debug.Log("yolo");
    }    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }
}
