using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace TileMapEditor.App
{
    class TileMap : ObservableObject
    {

        public List<Tile> Tiles { get; private set; }

        public enum Color
        {
            Red,
            Green,
            Blue
        }

        public Color selectedEnum = Color.Red;


        public Command<Tile> TileClickCommand { get; private set; }

        public TileMap()
        {
            Tiles = new List<Tile>();

            

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (c % 3 == 0)
                    {
                        Tiles.Add(new Tile() { Row = r, Column = c, Green = true });
                    }
                    else if (c % 2 == 0)
                    {
                        Tiles.Add(new Tile() { Row = r, Column = c, Blue = true });
                    }
                    else
                    {
                        Tiles.Add(new Tile() { Row = r, Column = c, Red = true });
                    }
                }
            }

            TileClickCommand = new Command<Tile>(OnTileClick);
        }

        private void OnTileClick(Tile tile)
        {

            tile.Red = true;
            tile.Blue = false;
            tile.Green = false;
            
            


        }

    }
}

