namespace ShipsLib;

public class TileDimension
{
    public TileDimension(BoardVertical x, BoardHorizontal y)
    {
        Y = y;
        X = x;
    }
    public BoardVertical X { get; set; }
    public BoardHorizontal Y { get; set; }
}