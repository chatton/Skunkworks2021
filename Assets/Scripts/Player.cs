
using System;
using UnityEngine;


public class Player : MonoBehaviour
{

    private Vector3 _originalScale;
    private void Awake()
    {
        // cache reference to the Scale we were at when we started.
        _originalScale = transform.localScale;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Scale();
        }
        else
        {
            ResetSize();
        }
    }
    private void Scale()
    {
        SetLocalScale(new Vector3(1, 0.5f, 1));
    }

    private void ResetSize()
    {
        SetLocalScale(_originalScale);
    }

    private void SetLocalScale(Vector3 scale)
    {
        transform.localScale = scale;
    }
}
