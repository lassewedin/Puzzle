public class PieceSet {

    private static Piece[] piece = new Piece[6];

    private bool[] isAvailable = new bool[6];

    public PieceSet() {
        SetAllAvailable();
    }

    public PieceSet(PieceSet pieceSet) {
        for (int i = 0; i < 6; i++) {
           this.isAvailable[i] = pieceSet.IsAvailable(i);
        }
    }

    public void SetAllAvailable() {
        for (int i = 0; i < 6; i++) {
            isAvailable[i] = true;
        }
    }

    public void SetAvailable(int index, bool isAvailable) {
        this.isAvailable[index] = isAvailable;
    }

    public bool hasAvailable {
        get { 
            for (int i = 0; i < 6; i++) {
                if(isAvailable[i]) {
                    return true;
                }
            }
            return false;
        }
    } 

    public bool IsAvailable(int index) {
        return isAvailable[index];
    }

    public static Piece GetPiece(int index) {
        if (piece[0] == null) {
            PieceSet.CreatePieces();
        }

        return piece[index];
    }

    private static void CreatePieces() {
        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 1; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 1; shape[2, 1, 1] = 1; shape[3, 1, 1] = 1; shape[4, 1, 1] = 1; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 1; shape[3, 1, 0] = 1; shape[4, 1, 0] = 1; shape[5, 1, 0] = 1; //top, near

            piece[0] = new Piece(0, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 0; shape[2, 0, 0] = 0; shape[3, 0, 0] = 0; shape[4, 0, 0] = 0; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 1; shape[2, 1, 1] = 0; shape[3, 1, 1] = 1; shape[4, 1, 1] = 1; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 0; shape[2, 1, 0] = 0; shape[3, 1, 0] = 0; shape[4, 1, 0] = 0; shape[5, 1, 0] = 1; //top, near

            piece[1] = new Piece(1, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 1; shape[3, 0, 0] = 0; shape[4, 0, 0] = 0; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 1; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 1; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 1; shape[2, 1, 0] = 0; shape[3, 1, 0] = 0; shape[4, 1, 0] = 0; shape[5, 1, 0] = 1; //top, near

            piece[2] = new Piece(2, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 0; shape[3, 0, 0] = 0; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 1; shape[2, 1, 1] = 1; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 0; shape[2, 1, 0] = 0; shape[3, 1, 0] = 0; shape[4, 1, 0] = 0; shape[5, 1, 0] = 1; //top, near

            piece[3] = new Piece(3, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 0; shape[2, 0, 0] = 1; shape[3, 0, 0] = 0; shape[4, 0, 0] = 0; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 1; shape[2, 1, 1] = 1; shape[3, 1, 1] = 1; shape[4, 1, 1] = 1; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 0; shape[2, 1, 0] = 1; shape[3, 1, 0] = 0; shape[4, 1, 0] = 0; shape[5, 1, 0] = 1; //top, near

            piece[4] = new Piece(4, shape);
        }

        {
            int[,,] shape = new int[6, 2, 2];
            shape[0, 0, 1] = 1; shape[1, 0, 1] = 1; shape[2, 0, 1] = 1; shape[3, 0, 1] = 1; shape[4, 0, 1] = 1; shape[5, 0, 1] = 1; //bottom, far
            shape[0, 0, 0] = 1; shape[1, 0, 0] = 1; shape[2, 0, 0] = 0; shape[3, 0, 0] = 0; shape[4, 0, 0] = 1; shape[5, 0, 0] = 1; //bottom, near

            shape[0, 1, 1] = 1; shape[1, 1, 1] = 0; shape[2, 1, 1] = 0; shape[3, 1, 1] = 0; shape[4, 1, 1] = 0; shape[5, 1, 1] = 1; //top, far
            shape[0, 1, 0] = 1; shape[1, 1, 0] = 0; shape[2, 1, 0] = 0; shape[3, 1, 0] = 0; shape[4, 1, 0] = 0; shape[5, 1, 0] = 1; //top, near
            piece[5] = new Piece(5, shape);
        }
    }
    }

