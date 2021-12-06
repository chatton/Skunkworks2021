using System.Collections;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A reference to the prefab of the special effect which is used as an attack animation.")]
    private GameObject sfxPrefab;

    [SerializeField]
    [Tooltip("The location the sfx prefab will be spawned.")]
    private GameObject spawnPosition;

    [SerializeField] 
    [Tooltip("The delay before the OnAttack callback is called and the sfx is spawned")]
    private float sfxDelay;
    
    [SerializeField] 
    [Tooltip("The time it takes for the sfx to be destroyed.")]
    private float sfxDelayAfter;

    private Player _player;

    private void Awake() => _player = GetComponent<Player>();

    private void Start() => _player.OnAttack += () => StartCoroutine(AttackRoutine());

    private IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(sfxDelay);
        GameObject go = Instantiate(sfxPrefab);
        go.transform.position = spawnPosition.transform.position;
        yield return new WaitForSeconds(sfxDelayAfter);
        Destroy(go);
    }
}