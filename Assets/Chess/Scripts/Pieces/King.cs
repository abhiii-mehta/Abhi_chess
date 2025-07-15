using System.Collections.Generic;
using UnityEngine;

public class King : BasePiece
{
    public override List<Vector2Int> GetLegalMoves(BasePiece[,] board)
    {
        List<Vector2Int> legal = new List<Vector2Int>();

        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                if (dr == 0 && dc == 0) continue;

                int r = Row + dr;
                int c = Column + dc;

                if (!BoardManager.Instance.IsInsideBoard(r, c)) continue;

                BasePiece piece = board[r, c];
                if (piece == null || piece.IsWhite != IsWhite)
                {
                    legal.Add(new Vector2Int(r, c));
                }
            }
        }

        return legal;
    }
}
