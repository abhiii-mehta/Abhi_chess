using System.Collections.Generic;
using UnityEngine;

public class Pawn : BasePiece
{
    public override List<Vector2Int> GetLegalMoves(BasePiece[,] board)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        int direction = IsWhite ? 1 : -1;
        int startRow = IsWhite ? 1 : 6;
        int nextRow = Row + direction;

        if (BoardManager.Instance.IsInsideBoard(nextRow, Column) && board[nextRow, Column] == null)
        {
            moves.Add(new Vector2Int(nextRow, Column));

            if (Row == startRow && board[nextRow + direction, Column] == null)
            {
                moves.Add(new Vector2Int(nextRow + direction, Column));
            }
        }

        for (int dc = -1; dc <= 1; dc += 2)
        {
            int newCol = Column + dc;
            if (BoardManager.Instance.IsInsideBoard(nextRow, newCol))
            {
                BasePiece target = board[nextRow, newCol];
                if (target != null && target.IsWhite != IsWhite)
                {
                    moves.Add(new Vector2Int(nextRow, newCol));
                }
            }
        }

        return moves;
    }
}
