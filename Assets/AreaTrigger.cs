using System;
using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    public Action<Collider> Callback;

    private void OnTriggerEnter(Collider other)
    {
        Callback?.Invoke(other);
    }
}