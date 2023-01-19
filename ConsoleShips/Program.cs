using ShipsLib;

namespace ConsoleShips;

class Program
{
    static void Main(string[] args)
    {
        var newBoard = new Board();
        //newBoard.SetTile(new TileDimension(BoardVertical.B, BoardHorizontal.A), TileValue.Battleship);
        //var neighbours = newBoard.GetNeighbours(new TileDimension(BoardVertical.J, BoardHorizontal.J));
        Console.WriteLine(newBoard.ToString());

        var c = newBoard.GetTilesArrArr();
    }
}



