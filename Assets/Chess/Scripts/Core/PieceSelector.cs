using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                BasePiece piece = hit.collider.GetComponent<BasePiece>();
                if (piece != null && piece.IsWhite)
                {
                    ChessBoardPlacementHandler.Instance.ClearHighlights();

                    var moves = piece.GetLegalMoves(BoardManager.Instance.Board);
                    foreach (var move in moves)
                    {
                        BasePiece targetPiece = BoardManager.Instance.GetPieceAt(move.x, move.y);
                        if (targetPiece != null && !targetPiece.IsWhite)
                        {
                            ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
                        }
                        else if (targetPiece == null)
                        {
                            ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
                        }
                    }
                }
            }
        }
    }
}
