public class BaseTransform {
    public int xAxisWorldX = 1; public int yAxisWorldX = 0; public int zAxisWorldX = 0; public int origoWorldX = 0;
    public int xAxisWorldY = 0; public int yAxisWorldY = 1; public int zAxisWorldY = 0; public int origoWorldY = 0;
    public int xAxisWorldZ = 0; public int yAxisWorldZ = 0; public int zAxisWorldZ = 1; public int origoWorldZ = 0;

    public int[] GetWorldPosition(int x, int y, int z) {
        int[] worldPosition = new int[3];
        int worldX = xAxisWorldX * x + yAxisWorldX * y + zAxisWorldX * z + origoWorldX;
        int worldY = xAxisWorldY * x + yAxisWorldY * y + zAxisWorldY * z + origoWorldY;
        int worldZ = xAxisWorldZ * x + yAxisWorldZ * y + zAxisWorldZ * z + origoWorldZ;
        worldPosition[0] = worldX;
        worldPosition[1] = worldY;
        worldPosition[2] = worldZ;
        return worldPosition;
    }
}

