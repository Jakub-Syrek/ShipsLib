using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ShipsLib;

namespace WPFShips.Views
{
    public class CustomButton : Button
    {
        public int X { get; set; }
        public int Y { get; set; }
        public  TileValue TileValue { get; set; }

        public TileValue HiddenTileValue { get; set; }
    }
}
