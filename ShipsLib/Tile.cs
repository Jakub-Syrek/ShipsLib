namespace ShipsLib;

public class Tile
{
    public Tile(TileDimension dimension, TileValue value)
    {
        Dimension = dimension;
        Value = value;
    }

    public TileValue Value { get; set; }
    public TileDimension Dimension { get; set; }
    public string Description
    {
        get
        {
            return EnumExtensionMethods.GetEnumDescription(Value);
        }
    }
    public bool IsOccupied
    {
        get
        {
            return Value == TileValue.Battleship
                   || Value == TileValue.Destroyer
                   || Value == TileValue.Cruiser
                   || Value == TileValue.Carrier;
        }
    }
}