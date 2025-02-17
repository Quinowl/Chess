using UnityEngine;

public class Bishop : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int deltaX = targetPosition.x - startPosition.x;
        int deltaY = targetPosition.y - startPosition.y;
        if (Mathf.Abs(deltaX) == Mathf.Abs(deltaY))
        {
            return this.CheckDiagonalMove(startPosition, targetPosition, board);
        }

        return false;
    }
}