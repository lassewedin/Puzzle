public class Slot {
    public BaseTransform baseTransform;

    public int index { get; private set; }

    

    public Slot(int index, BaseTransform baseTransform) {
        this.index = index;
        this.baseTransform = baseTransform;
    }

    public bool CanPlaceInWorld(Piece piece, int rotateY, int rotateX, World world) {
        int[,,] rotated = piece.GetShape(rotateY, rotateX);
        for (int z = 0; z < 2; z++) {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 6; x++) {
                    int[] worldPosition = baseTransform.GetWorldPosition(x, y, z);
                    bool worldCube = world.Get(worldPosition[0], worldPosition[1], worldPosition[2]) != -1;
                    bool pieceCube = rotated[x, y, z] != -1;
                    if (worldCube && pieceCube) {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public bool TryPlaceInWorld(Piece piece, int rotateY, int rotateX, World world) {
        if (CanPlaceInWorld(piece, rotateY, rotateX, world)) {
            ForcePlaceInWorld(piece, rotateY, rotateX, world, false);
            return true;
        }
        return false;
    } 

    public void ForcePlaceInWorld(Piece piece, int rotateY, int rotateX, World world, bool useErrorIndex) {
        int[,,] rotated = piece.GetShape(rotateY, rotateX);
        for (int z = 0; z < 2; z++) {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 6; x++) {
                    int[] worldPosition = baseTransform.GetWorldPosition(x, y, z);
                    if (rotated[x, y, z] != -1) {
                        
                        if (useErrorIndex) {
                            world.Set(worldPosition[0], worldPosition[1], worldPosition[2], rotated[x, y, z] == -1 ? -1 : rotated[x, y, z] + 6 );
                        }
                        else {
                            world.Set(worldPosition[0], worldPosition[1], worldPosition[2], rotated[x, y, z]);
                        }
                    }
                }
            }
        }
    }
}

