using UnityEngine;

public static class FunctionLibrary
{
    public static Vector2Int ToVector2Int(this Vector3 vector) => new Vector2Int(Mathf.RoundToInt(vector.x), Mathf.RoundToInt(vector.z));

    public static bool CheckDiagonalMove(this Piece piece, Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
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
                || board[targetPosition.x, targetPosition.y].PieceType != piece.PieceType;
    }

    public static bool CheckStraightMove(this Piece piece, Vector2Int startPosition, Vector2Int targetPosition, Piece[,] board)
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
                    || board[targetPosition.x, targetPosition.y].PieceType != piece.PieceType;
    }
}