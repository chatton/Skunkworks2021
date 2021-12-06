using System.Collections;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] private GameObject sfxPrefab;
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private float sfxDelay;
    [SerializeField] private float sfxDelayAfter;
    private Player _player;
    
    private bool _sfxIsHappening;
    
    private void Awake() => _player = GetComponent<Player>();

    private void Start() => _player.OnAttack += OnAttack;


    private void OnAttack()
    {
        if (_sfxIsHappening)
        {
            return;
        }

        StartCoroutine(AttackRoutine());
    }
    

    private IEnumerator AttackRoutine()
    {
        _sfxIsHappening = true;
        yield return new WaitForSeconds(sfxDelay);
        GameObject go = Instantiate(sfxPrefab);
        go.transform.position = spawnPosition.transform.position;
        yield return new WaitForSeconds(sfxDelayAfter);
        Destroy(go);
        _sfxIsHappening = false;
    }

}