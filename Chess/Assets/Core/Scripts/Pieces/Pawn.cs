using UnityEngine;

public class Pawn : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        return false;
    }
}
