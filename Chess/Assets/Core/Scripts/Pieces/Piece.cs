using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    protected abstract List<Vector2Int> GetAvailableCells();
    protected abstract void MoveTo(Vector2Int nextPosition);
}