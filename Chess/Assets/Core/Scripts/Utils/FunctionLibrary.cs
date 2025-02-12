using UnityEngine;

public static class FunctionLibrary
{
    public static Vector2Int ToVector2Int(this Vector3 vector) => new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));
}