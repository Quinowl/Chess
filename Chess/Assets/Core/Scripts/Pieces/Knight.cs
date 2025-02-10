using UnityEngine;

public class Knight : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        return false;
    }
}