using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    // LevelManager is in charge of triggering certain events based on the state of the game. 
    public class LevelManager : MonoBehaviour
    {
        
        
        private Health playerHealth;

        private void Awake()
        {
            playerHealth = FindObjectOfType<Player>().GetComponent<Health>();
        }

        private void Start()
        {
            playerHealth.OnDeath += _ => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}