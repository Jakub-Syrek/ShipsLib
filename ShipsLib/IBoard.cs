namespace ShipsLib;

interface IBoard
{
    public Tile? GetTile(TileDimension dimension);
    public TileValue? SetTile(TileDimension dimension, TileValue value);
    public Tile[][] GetTilesArrArr();
    public List<Tile> GetNeighbours(TileDimension dimension);
}