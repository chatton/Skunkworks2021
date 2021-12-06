using UnityEngine;

public static class Util
{
    public const string PlayerTag = "Player";

    public static bool IsPlayer(this GameObject go)
    {
        return go.CompareTag(PlayerTag);
    }

    public static bool IsPlayer(this Collider col)
    {
        return col.gameObject.IsPlayer();
    }
    
    public static bool IsPlayer(this Collision col)
    {
        return col.gameObject.IsPlayer();
    }
}