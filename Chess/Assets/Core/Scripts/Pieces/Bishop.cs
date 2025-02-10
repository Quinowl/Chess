using UnityEngine;

public class Bishop : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        return false;
    }
}