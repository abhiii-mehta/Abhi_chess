using System.Collections.Generic;
using UnityEngine;

public class Knight : BasePiece
{
    private static readonly Vector2Int[] Moves = new Vector2Int[]
    {
        new Vector2Int(2, 1), new Vector2Int(1, 2), new Vector2Int(-1, 2), new Vector2Int(-2, 1),
        new Vector2Int(-2, -1), new Vector2Int(-1, -2), new Vector2Int(1, -2), new Vector2Int(2, -1)
    };

    public override List<Vector2Int> GetLegalMoves(BasePiece[,] board)
    {
        List<Vector2Int> legal = new List<Vector2Int>();

        foreach (Vector2Int move in Moves)
        {
            int r = Row + move.x;
            int c = Column + move.y;

            if (!BoardManager.Instance.IsInsideBoard(r, c)) continue;

            BasePiece piece = board[r, c];
            if (piece == null || piece.IsWhite != IsWhite)
                legal.Add(new Vector2Int(r, c));
        }

        return legal;
    }
}
