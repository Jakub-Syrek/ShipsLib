using System;
using System.Drawing;

namespace ShipsLib
{
    public class Board : IBoard
    {
        private List<Tile> _tiles = new List<Tile>();
        public Board()
        {
            foreach (BoardVertical rowName in Enum.GetValues(typeof(BoardVertical)))
            {
                foreach (BoardHorizontal columnName in Enum.GetValues(typeof(BoardHorizontal)))
                {
                    var myDimension = new TileDimension(rowName, columnName);
                    _tiles.Add(new Tile(myDimension, TileValue.Empty));
                }
            }
        }

        private (TileDimension, TileDimension) GenerateShipPlacement(int shipLength)
        {
            int currentX1 = -1;
            int currentY1 = -1;

            int currentX2 = -1;
            int currentY2 = -1;
            bool valid = false;

            while (!valid)
            {
                Random random = new Random();

                if (shipLength == 1)
                {
                    int x1 = random.Next(0, 9);
                    int y1 = random.Next(0, 9);
                    var tilesInRange2 = GetNeighboursRange(new TileDimension((BoardVertical)x1, (BoardHorizontal)y1));
                    if (tilesInRange2.Any(x => x.IsOccupied) == false)
                    {
                        currentX1 = x1;
                        currentY1 = y1;
                        currentX2 = x1;
                        currentY2 = y1;
                        valid = true;
                    }
                }
                else
                {
                    int vertical = random.Next(0, 3);

                    var tilesOnTheWay = new List<Tile>();
                    //vertical
                    if (vertical % 2 == 0)
                    {
                        int x1 = random.Next(0, 9);
                        int y1 = random.Next(0, 9);

                        int x2 = -1;
                        int y2 = y1;

                        if (x1 < 5)
                        {
                            x2 = x1 + shipLength;
                        }
                        else
                        {
                            x2 = x1 - shipLength;
                        }

                        for (int x = (x1 < x2 ? x1 : x2); x <= (x2 > x1 ? x2 : x1); x++)
                        {
                            var tileInRange2 = GetNeighbours(new TileDimension((BoardVertical)x, (BoardHorizontal)y1));
                            tilesOnTheWay.AddRange(tileInRange2);

                        }
                        if (tilesOnTheWay.Any(x => x.IsOccupied) == false)
                        {
                            currentX1 = x1;
                            currentY1 = y1;
                            currentX2 = x2;
                            currentY2 = y2;
                            valid = true;
                        }
                    }
                    //horizontal
                    else
                    {
                        int x1 = random.Next(0, 9);
                        int y1 = random.Next(0, 9);

                        int x2 = x1;
                        int y2 = y1;

                        if (y1 < 5)
                        {
                            y2 += shipLength;
                        }
                        else
                        {
                            y2 -= shipLength;
                        }

                        for (int y = (y1 < y2 ? y1 : y2); y < (y2 > y1 ? y2 : y1); y++)
                        {
                            var tileInRange2 = GetNeighboursRange(new TileDimension((BoardVertical)x1, (BoardHorizontal)y));
                            tilesOnTheWay.AddRange(tileInRange2);
                        }

                        if (tilesOnTheWay.Any(x => x.IsOccupied) == false)
                        {
                            currentX1 = x1;
                            currentY1 = y1;
                            currentX2 = x2;
                            currentY2 = y2;
                            valid = true;
                        }
                    }
                }




                

                
            }

            return (new TileDimension((BoardVertical) currentX1, (BoardHorizontal) currentY1),
                new TileDimension((BoardVertical) currentX2, (BoardHorizontal) currentY2));
        }

        private void PlaceShip((TileDimension, TileDimension) dimensions, TileValue value)
        {
            var x1 = (int)dimensions.Item1.X;
            var y1 = (int)dimensions.Item1.Y;
            var x2 = (int)dimensions.Item2.X;
            var y2 = (int)dimensions.Item2.Y;

            if (x1 == x2)
            {
                for (int y = (y1 < y2 ? y1 : y2); y < (y2 > y1 ? y2 : y1); y++)
                {
                    SetTile(new TileDimension((BoardVertical) x1, (BoardHorizontal) y), value);
                }
            }
            else
            {
                for (int x = (x1 < x2 ? x1 : x2); x <= (x2 > x1 ? x2 : x1); x++)
                {
                    SetTile(new TileDimension((BoardVertical)x, (BoardHorizontal)y1), value);
                }
            }
        }
        public void PopulateRandomly()
        {
            TileValue[] shipTypes = (TileValue[])Enum.GetValues(typeof(TileValue));
            

            var shipPerCategoryCounter = 1;
            for (int i = 0; i < 5; i++)
            {
                var currentShipType = shipTypes[i];
                for (int j = 0; j < shipPerCategoryCounter; j++)
                {
                    switch (currentShipType)
                    {
                        case TileValue.Battleship:
                            (TileDimension, TileDimension) dimens = GenerateShipPlacement(4);
                            PlaceShip(dimens, currentShipType);
                            break;
                        case TileValue.Carrier:
                            dimens = GenerateShipPlacement(3);
                            PlaceShip(dimens, currentShipType);
                            break;
                        case TileValue.Cruiser:
                            dimens = GenerateShipPlacement(2);
                            PlaceShip(dimens, currentShipType);
                            break;
                        case TileValue.Destroyer:
                            dimens = GenerateShipPlacement(1);
                            PlaceShip(dimens, currentShipType);
                            break;
                    }

                }
                shipPerCategoryCounter++;
            }
        }

        public Tile? GetTile(TileDimension dimension)
        {
            return _tiles.FirstOrDefault(x => x.Dimension.X == dimension.X && x.Dimension.Y == dimension.Y);
        }
        public TileValue? SetTile(TileDimension dimension, TileValue value)
        {
            _tiles.FirstOrDefault(x => x.Dimension.X == dimension.X && x.Dimension.Y == dimension.Y)!.Value = value;
            return _tiles.FirstOrDefault(x => x.Dimension.X == dimension.X && x.Dimension.Y == dimension.Y)!.Value;
        }
        public Tile[][] GetTilesArrArr()
        {
            var grouped = _tiles
                .GroupBy(x=>x.Dimension.X)
                .OrderBy(x=>x.Key)
                .ToList();

            var arr = new Tile[grouped.Count][];
            for (int i = 0; i < grouped.Count; i++)
            {
                arr[i] = grouped[i]
                    .OrderBy(x=>x.Dimension.Y)
                    .ToArray();
            }
            return arr;
        }
        public List<Tile> GetNeighbours(TileDimension dimension)
        {
            var arr = GetTilesArrArr();

            var myX = (int)dimension.X;
            var myY = (int)dimension.Y;


            var vals = new List<Tile>();
            for (int i = myX-1; i <= myX+1; i++)
            {
                if (i < 0 || i > 9)
                    continue;
                for (int j = myY-1; j <= myY+1; j++)
                {
                    if(j < 0 || j > 9)
                        continue;

                    Tile myTile;
                    
                    //if (i == myX && j == myY)
                        //continue;
                    
                    myTile = arr[i][j];
                    vals.Add(myTile);
                }
            }

            return vals;
        }
        public List<Tile> GetNeighboursRange(TileDimension dimension)
        {
            var arr = GetTilesArrArr();

            var myX = (int)dimension.X;
            var myY = (int)dimension.Y;


            var vals = new List<Tile>();
            for (int i = myX - 2; i <= myX + 2; i++)
            {
                if (i < 0 || i > 9)
                    continue;
                for (int j = myY - 2; j <= myY + 2; j++)
                {
                    if (j < 0 || j > 9)
                        continue;

                    Tile myTile;

                    //if (i == myX && j == myY)
                    //continue;

                    myTile = arr[i][j];
                    vals.Add(myTile);
                }
            }

            return vals;
        }
        public override string ToString()
        {
            string innerVal = "";
            
            foreach (Tile tile in _tiles)
            {
                innerVal += tile.Value + ",";
                if (tile.Dimension.Y == BoardHorizontal.H)
                {
                    innerVal += Environment.NewLine;
                }
            }
            return innerVal;
        }
    }
}