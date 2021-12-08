using UnityEngine;

namespace EditorScripts
{
    // this class should be extended if there is a script we want to only run in the editor and not when the game is running.
    [ExecuteInEditMode]
    public abstract class EditorOnlyMonoBehaviour : MonoBehaviour
    {
        protected abstract void DoUpdate();

        void Update()
        {
            if (Application.isEditor && !Application.isPlaying)
            {
                DoUpdate();
            }
        }
    }
}