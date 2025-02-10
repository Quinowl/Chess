using UnityEngine;

public class Pawn : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int direction = pieceColor == EPieceColor.White ? 1 : -1;

        if (targetPosition.x == startPosition.x && targetPosition.y == startPosition.y + direction && board[targetPosition.x, targetPosition.y] == null)
            return true;

        if (targetPosition.x == startPosition.x && targetPosition.y == startPosition.y + 2 * direction && board[targetPosition.x, targetPosition.y] == null && board[startPosition.x, startPosition.y + direction] == null)
        {
            if ((pieceColor == EPieceColor.White && startPosition.y == 1) || (pieceColor == EPieceColor.Black && startPosition.y == 6))
                return true;
        }

        if (Mathf.Abs(targetPosition.x - startPosition.x) == 1 && targetPosition.y == startPosition.y + direction && board[targetPosition.x, targetPosition.y] != null)
        {
            if (board[targetPosition.x, targetPosition.y].PieceType != pieceType)
                return true;
        }

        return false;
    }
}
