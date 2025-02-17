using UnityEngine;

public class Queen : Piece
{
    public override bool IsValidMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int deltaX = targetPosition.x - startPosition.x;
        int deltaY = targetPosition.y - startPosition.y;

        if (startPosition.x == targetPosition.x || startPosition.y == targetPosition.y)
            return CheckStraightMove(startPosition, targetPosition, board);
        else if (Mathf.Abs(deltaX) == Mathf.Abs(deltaY))
            return CheckDiagonalMove(startPosition, targetPosition, board);

        return false;
    }

    private bool CheckStraightMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int stepX = targetPosition.x > startPosition.x ? 1 : (targetPosition.x < startPosition.x ? -1 : 0);
        int stepY = targetPosition.y > startPosition.y ? 1 : (targetPosition.y < startPosition.y ? -1 : 0);

        int x = startPosition.x + stepX;
        int y = startPosition.y + stepY;

        while (x != targetPosition.x || y != targetPosition.y)
        {
            if (board[x, y] != null) return false;
            x += stepX;
            y += stepY;
        }

        return board[targetPosition.x, targetPosition.y] == null
                    || board[targetPosition.x, targetPosition.y].PieceType != pieceType;
    }

    private bool CheckDiagonalMove(Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
    {
        int stepX = targetPosition.x > startPosition.x ? 1 : -1;
        int stepY = targetPosition.y > startPosition.y ? 1 : -1;

        int x = startPosition.x + stepX;
        int y = startPosition.y + stepY;

        while (x != targetPosition.x && y != targetPosition.y)
        {
            if (board[x, y] != null) return false;
            x += stepX;
            y += stepY;
        }

        return board[targetPosition.x, targetPosition.y] == null
                || board[targetPosition.x, targetPosition.y].PieceType != pieceType;
    }
}