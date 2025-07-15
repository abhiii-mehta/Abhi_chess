Chess - Possible Moves Highlighter
----------------------------------

This Unity project highlights all legal moves for a selected chess piece on a standard 8x8 board. It focuses on object-oriented design, clean code, and clarity — not full chess gameplay.

----------------------------------
Assessment Goals
----------------------------------
- Show all legal moves for a selected white chess piece.
- Green = possible move.
- Red = enemy capture possible.
- No movement logic, turn system, or check/checkmate.
- Focus is on modular, readable, and maintainable code.

----------------------------------
Project Structure
----------------------------------

Scripts:
- BasePiece.cs
  Abstract class for all chess pieces.

- Pawn.cs, Knight.cs, Rook.cs, Bishop.cs, Queen.cs, King.cs
  Implement legal movement logic for each type.

- BoardManager.cs
  Stores all pieces in an 8x8 grid and provides lookup.

- ChessBoardPlacementHandler.cs
  Places pieces on board and handles visual highlighting.

- PieceSelector.cs
  Handles mouse clicks and triggers legal move highlights.

- ChessPlayerPlacementHandler.cs
  Sets each piece's row/column on start.

----------------------------------
Highlighting System
----------------------------------
- All 64 tiles contain an inactive child GameObject (a circle sprite).
- Highlights are white by default and invisible at start.
- When a piece is clicked:
  - Green circles show legal move positions.
  - Red (50–70% transparent) circles show attackable enemies.

----------------------------------
Usage
----------------------------------
- Add any white piece to the scene.
- Set its Row, Column, and mark it as IsWhite = true in Inspector.
- Press Play and click the piece to see legal moves highlighted.
- No actual movement will happen — only visual hints.

----------------------------------
Unity Version
----------------------------------
- Unity 2020.3.40f1 (as required)

----------------------------------
Optional Extensions
----------------------------------
(Not implemented — can be added in the future)
- Piece movement
- Turn-based system
- AI opponent
- Game rules (check, checkmate, etc.)

----------------------------------
Author
----------------------------------
Abhinandan Mehta  
Submission for Unity Game Developer Internship test - IDZ Digital Private Limited