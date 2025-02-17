using UnityEngine;

public class Rook : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        if (startPosition.x == targetPosition.x || startPosition.y == targetPosition.y)
            return this.CheckStraightMove(startPosition, targetPosition, board);

        return false;
    }
}