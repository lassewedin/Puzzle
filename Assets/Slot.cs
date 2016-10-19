public class Slot {
    public BaseTransform baseTransform;

    public int index { get; private set; }

    

    public Slot(int index, BaseTransform baseTransform) {
        this.index = index;
        this.baseTransform = baseTransform;
    }

    public bool CanPlaceInWorld(Piece piece, int rotateX, int rotateY, World world) {


        
        return true;
    }

    public bool TryPlaceInWorld(Piece piece, int rotateX, int rotateY, World world) {
        if (CanPlaceInWorld(piece, rotateX, rotateY, world)) {
            PlaceInWorld(piece, rotateX, rotateY, world);
            return true;
        }
        return false;
    } 

    public void PlaceInWorld(Piece piece, int rotateY, int rotateX, World world) {

        int[,,] rotated = piece.GetShape(rotateY, rotateX);
        for (int z = 0; z < 2; z++) {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 6; x++) {
                    int[] worldPosition = baseTransform.GetWorldPosition(x, y, z);
                    world.Set(worldPosition[0], worldPosition[1], worldPosition[2], rotated[x, y, z]);
                }
            }
        }
    }
}

