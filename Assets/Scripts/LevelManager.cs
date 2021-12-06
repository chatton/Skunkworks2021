using UnityEngine;
using UnityEngine.SceneManagement;

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