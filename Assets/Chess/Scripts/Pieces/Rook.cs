using System.Collections.Generic;
using UnityEngine;

public class Rook : BasePiece
{
    public override List<Vector2Int> GetLegalMoves(BasePiece[,] board)
    {
        List<Vector2Int> legal = new List<Vector2Int>();

        Vector2Int[] directions = new Vector2Int[]
        {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        foreach (Vector2Int dir in directions)
        {
            int r = Row + dir.x;
            int c = Column + dir.y;

            while (BoardManager.Instance.IsInsideBoard(r, c))
            {
                BasePiece piece = board[r, c];
                if (piece == null)
                {
                    legal.Add(new Vector2Int(r, c));
                }
                else
                {
                    if (piece.IsWhite != IsWhite)
                        legal.Add(new Vector2Int(r, c));
                    break;
                }

                r += dir.x;
                c += dir.y;
            }
        }

        return legal;
    }
}
