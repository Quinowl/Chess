using UnityEngine;

public class Queen : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int deltaX = targetPosition.x - startPosition.x;
        int deltaY = targetPosition.y - startPosition.y;

        if (startPosition.x == targetPosition.x || startPosition.y == targetPosition.y)
            return this.CheckStraightMove(startPosition, targetPosition, board);
        else if (Mathf.Abs(deltaX) == Mathf.Abs(deltaY))
            return this.CheckDiagonalMove(startPosition, targetPosition, board);

        return false;
    }
}