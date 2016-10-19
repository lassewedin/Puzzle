public class Piece {
    public int index { get; private set; }
    private int[,,] shape = new int[6, 2, 2];

    private BaseTransform tY0X0 = new BaseTransform();
    private BaseTransform tY0X1 = new BaseTransform();
    private BaseTransform tY0X2 = new BaseTransform();
    private BaseTransform tY0X3 = new BaseTransform();
    private BaseTransform tY1X0 = new BaseTransform();
    private BaseTransform tY1X1 = new BaseTransform();
    private BaseTransform tY1X2 = new BaseTransform();
    private BaseTransform tY1X3 = new BaseTransform();

    public Piece(int index, int[,,] shape) {
        this.index = index;
        this.shape = shape;

        CreateTransforms();
    }

    private BaseTransform GetBaseTransform(int rotationY, int rotationX) {
        if (rotationY == 0) {
            if (rotationX == 0) {
                return tY0X0;
            } else if (rotationX == 1) {
                return tY0X1;
            } else if (rotationX == 2) {
                return tY0X2;
            } else if (rotationX == 3) {
                return tY0X3;
            }
        } else {
            if (rotationX == 0) {
                return tY1X0;
            } else if (rotationX == 1) {
                return tY1X1;
            } else if (rotationX == 2) {
                return tY1X2;
            } else if (rotationX == 3) {
                return tY1X3;
            }
        }
        return null;
    } 

    private void CreateTransforms() {
          
        tY0X0.xAxisWorldX = 1;  tY0X0.yAxisWorldX = 0;  tY0X0.zAxisWorldX = 0;  tY0X0.origoWorldX = 0;
        tY0X0.xAxisWorldY = 0;  tY0X0.yAxisWorldY = 1;  tY0X0.zAxisWorldY = 0;  tY0X0.origoWorldY = 0;
        tY0X0.xAxisWorldZ = 0;  tY0X0.yAxisWorldZ = 0;  tY0X0.zAxisWorldZ = 1;  tY0X0.origoWorldZ = 0;

        tY0X1.xAxisWorldX = 1;  tY0X1.yAxisWorldX = 0;  tY0X1.zAxisWorldX = 0;  tY0X1.origoWorldX = 0;
        tY0X1.xAxisWorldY = 0;  tY0X1.yAxisWorldY = 0;  tY0X1.zAxisWorldY = -1; tY0X1.origoWorldY = 1;
        tY0X1.xAxisWorldZ = 0;  tY0X1.yAxisWorldZ = 1;  tY0X1.zAxisWorldZ = 0;  tY0X1.origoWorldZ = 0;

        tY0X2.xAxisWorldX = 1;  tY0X2.yAxisWorldX = 0;  tY0X2.zAxisWorldX = 0;  tY0X2.origoWorldX = 0;
        tY0X2.xAxisWorldY = 0;  tY0X2.yAxisWorldY = -1; tY0X2.zAxisWorldY = 0;  tY0X2.origoWorldY = 1;
        tY0X2.xAxisWorldZ = 0;  tY0X2.yAxisWorldZ = 0;  tY0X2.zAxisWorldZ = -1; tY0X2.origoWorldZ = 1;
         
        tY0X3.xAxisWorldX = 1;  tY0X3.yAxisWorldX = 0;  tY0X3.zAxisWorldX = 0;  tY0X3.origoWorldX = 0;
        tY0X3.xAxisWorldY = 0;  tY0X3.yAxisWorldY = 0;  tY0X3.zAxisWorldY = 1;  tY0X3.origoWorldY = 0;
        tY0X3.xAxisWorldZ = 0;  tY0X3.yAxisWorldZ = -1; tY0X3.zAxisWorldZ = 0;  tY0X3.origoWorldZ = 1;

        //world/local y 180
        tY1X0.xAxisWorldX = -1; tY1X0.yAxisWorldX = 0;  tY1X0.zAxisWorldX = 0;  tY1X0.origoWorldX = 5;
        tY1X0.xAxisWorldY = 0;  tY1X0.yAxisWorldY = 1;  tY1X0.zAxisWorldY = 0;  tY1X0.origoWorldY = 0;
        tY1X0.xAxisWorldZ = 0;  tY1X0.yAxisWorldZ = 0;  tY1X0.zAxisWorldZ = -1; tY1X0.origoWorldZ = 1;

        //first world/localy 180 then world 90 
        tY1X1.xAxisWorldX = -1; tY1X1.yAxisWorldX = 0;  tY1X1.zAxisWorldX = 0;  tY1X1.origoWorldX = 5;
        tY1X1.xAxisWorldY = 0;  tY1X1.yAxisWorldY = 0;  tY1X1.zAxisWorldY = 1;  tY1X1.origoWorldY = 0;
        tY1X1.xAxisWorldZ = 0;  tY1X1.yAxisWorldZ = 1; tY1X1.zAxisWorldZ = 0;  tY1X1.origoWorldZ = 0;

        //first world/localy 180 then world 180 
        tY1X2.xAxisWorldX = -1; tY1X2.yAxisWorldX = 0;  tY1X2.zAxisWorldX = 0;  tY1X2.origoWorldX = 5;
        tY1X2.xAxisWorldY = 0;  tY1X2.yAxisWorldY = -1; tY1X2.zAxisWorldY = 0;  tY1X2.origoWorldY = 1;
        tY1X2.xAxisWorldZ = 0;  tY1X2.yAxisWorldZ = 0;  tY1X2.zAxisWorldZ = 1;  tY1X2.origoWorldZ = 0;

        //first world/localy 180 then world 270 
        tY1X3.xAxisWorldX = -1; tY1X3.yAxisWorldX = 0;  tY1X3.zAxisWorldX = 0;  tY1X3.origoWorldX = 5;
        tY1X3.xAxisWorldY = 0;  tY1X3.yAxisWorldY = 0;  tY1X3.zAxisWorldY = -1; tY1X3.origoWorldY = 1;
        tY1X3.xAxisWorldZ = 0;  tY1X3.yAxisWorldZ = -1; tY1X3.zAxisWorldZ = 0;  tY1X3.origoWorldZ = 1;
    }

    //1. rotate (world) Y: 0 ==> 0, 1 ==> 180
    //1. rotate  world X : 0 ==> 0, 1 ==> 90, 2 ==> 180, 3 ==> 270
    public int[,,] GetShape(int rotateY, int rotateX) {
        int[,,] rotated = new int[6, 2, 2];

        for (int z = 0; z < 2; z++) {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 6; x++) {
                    int[] rotatedPosition = GetBaseTransform(rotateY, rotateX).GetWorldPosition(x, y, z);
                    if (shape[x, y, z] == 0) {
                        rotated[rotatedPosition[0], rotatedPosition[1], rotatedPosition[2]] = -1;
                    } else {
                        rotated[rotatedPosition[0], rotatedPosition[1], rotatedPosition[2]] = index;
                    } 
                }
            }
        }

        return rotated;
    }

}

