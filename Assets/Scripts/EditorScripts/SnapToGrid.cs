using UnityEngine;

namespace EditorScripts
{
    // [ExecuteInEditMode]
    public class SnapToGrid : MonoBehaviour
    {
        void Update() => transform.position = ClampToInt(transform.position);


        Vector3 ClampToInt(Vector3 pos)
        {
            return new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));
        }
    }
}