using UnityEngine;

public class PieceSelector : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"Hit: {hit.collider.name}");

                BasePiece piece = hit.collider.GetComponent<BasePiece>();
                if (piece != null && piece.IsWhite)
                {
                    ChessBoardPlacementHandler.Instance.ClearHighlights();

                    var moves = piece.GetLegalMoves(BoardManager.Instance.Board);
                    foreach (var move in moves)
                    {
                        BasePiece targetPiece = BoardManager.Instance.GetPieceAt(move.x, move.y);

                        bool isEnemy = targetPiece != null && targetPiece.IsWhite != piece.IsWhite;
                        ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
                    }
                }
            }
        }
    }
}
