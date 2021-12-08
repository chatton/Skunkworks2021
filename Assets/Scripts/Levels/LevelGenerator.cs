using UnityEngine;
using Random = UnityEngine.Random;

namespace Levels
{
    // LevelGenerator generates the actual level that should be used based on the level segments assigned
    // to it in the editor.
    public class LevelGenerator : MonoBehaviour
    {
        [SerializeField] private int NumberOfSegments = 5;
        [SerializeField] private LevelSegment[] LevelSegments;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private Transform level;

        // GenerateLevel creates random level segments from the provided array.
        private void GenerateLevel()
        {
            // start at the beginning of the level.
            Vector3 spawnPosition = Vector3.zero;
            Player player = Instantiate(playerPrefab);
            player.transform.position = spawnPosition + Vector3.up;


            for (int i = 0; i < NumberOfSegments; i++)
            {
                int randomIndex = Random.Range(0, LevelSegments.Length);
                LevelSegment createdSegment = Instantiate(LevelSegments[randomIndex], level.transform);
                createdSegment.transform.position = spawnPosition;
                // offset each segment by its size.
                spawnPosition.x += createdSegment.Size - 1;
            }
        }


        private void Start()
        {
            GenerateLevel();
        }
    }
}