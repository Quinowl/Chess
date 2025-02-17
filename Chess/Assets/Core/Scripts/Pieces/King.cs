using UnityEngine;

public class King : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int deltaX = Mathf.Abs(targetPosition.x - startPosition.x);
        int deltaY = Mathf.Abs(targetPosition.y - startPosition.y);

        if (deltaX <= 1 && deltaY <= 1)
            return board[targetPosition.x, targetPosition.y] == null || board[targetPosition.x, targetPosition.y].PieceType != pieceType;

        return false;
    }
}