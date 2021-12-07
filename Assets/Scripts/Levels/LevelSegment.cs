using UnityEngine;

namespace Levels
{
    
    // a LevelSegment represents a portion of the level.
    // These can be shuffled and used to generate levels.
    public class LevelSegment : MonoBehaviour
    {
        // the size of a level segment is just the child count.
        // we assume every cube is a 1x1x1 cube.
        public int Size => transform.childCount;
    }
}