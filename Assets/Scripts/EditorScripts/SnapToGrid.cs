using UnityEngine;

namespace EditorScripts
{
    public class SnapToGrid : EditorOnlyMonoBehaviour
    {
        protected override void DoUpdate()
        {
            transform.position = ClampToInt(transform.position);
        }

        Vector3 ClampToInt(Vector3 pos)
        {
            return new Vector3(Mathf.FloorToInt(pos.x), Mathf.FloorToInt(pos.y), Mathf.FloorToInt(pos.z));
        }
    }
}