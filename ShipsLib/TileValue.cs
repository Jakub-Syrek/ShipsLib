using System.ComponentModel;

namespace ShipsLib;

public enum TileValue
{
    [Description("B")]
    Battleship,

    [Description("A")]
    Carrier,

    [Description("C")]
    Cruiser,

    [Description("D")]
    Destroyer,

    [Description("X")]
    Hit,

    [Description("M")]
    Miss,

    [Description("o")]
    Empty
}