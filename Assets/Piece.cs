public class Piece {
    public int index { get; private set; }
    private int[,,] shape = new int[6, 2, 2];

    private BaseTransform tX0Y0 = new BaseTransform();


    public Piece(int index, int[,,] shape) {
        this.index = index;
        this.shape = shape;

        CreateTransforms();
    }

    private void CreateTransforms() {
          
        tX0Y0.xAxisWorldX = 1; tX0Y0.yAxisWorldX = 0; tX0Y0.zAxisWorldX = 0; tX0Y0.origoWorldX = 0;
        tX0Y0.xAxisWorldY = 0; tX0Y0.yAxisWorldY = 1; tX0Y0.zAxisWorldY = 0; tX0Y0.origoWorldY = 0;
        tX0Y0.xAxisWorldZ = 0; tX0Y0.yAxisWorldZ = 0; tX0Y0.zAxisWorldZ = 1; tX0Y0.origoWorldZ = 0;

    }

    //1. rotateX: 0 ==> 0, 1 ==> 90, 2 ==> 180, 3 ==> 270
    //2. rotateY: 0 ==> 0, 1 ==> 180
    public int[,,] GetShape(int rotateX, int rotateY) {
        int[,,] rotated = new int[6, 2, 2];

        for (int z = 0; z < 2; z++) {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 6; x++) {
                    int[] rotatedPosition = tX0Y0.GetWorldPosition(x, y, z);
                    rotated[rotatedPosition[0], rotatedPosition[1], rotatedPosition[2]] = shape[x, y, z];
                    rotated[x, y, z] = shape[x, y, z];
                }
            }
        }

        return rotated;
    }

}

