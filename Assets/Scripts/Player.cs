
using UnityEngine;


public class Player : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("yolo");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Scale();
        }
    }
    private void Scale()
    {
        transform.localScale = new Vector3(1, 0.5f, 1);
    }
}
