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
        public List<SelectableTile> TerrainType { get; private set; }

        public enum Selection
        {
            One,
            Two,
            Three
        }

        public Selection selectedEnum = Selection.One;


        public Command<Tile> TileClickCommand { get; private set; }
        public Command<SelectableTile> TerrainClickCommand { get; private set; }

        public TileMap()
        {
            Tiles = new List<Tile>();
            TerrainType = new List<SelectableTile>();

            

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {

                        Tiles.Add(new Tile() { Row = r, Column = c, Red = true });

                }
            }

            for (int r=0; r< 3; r++)
            {
                TerrainType.Add(new SelectableTile() { terrain = SelectableTile.Terrain.Grass, Red = true });
                for (int c = 0; c < 2; c++)
                {
                    if (c % 2 == 0)
                        TerrainType.Add(new SelectableTile() { terrain = SelectableTile.Terrain.Dirt, Blue = true});
                    else 
                        TerrainType.Add(new SelectableTile() { terrain = SelectableTile.Terrain.Cobble, Green = true});
                    
                        
                }
            }

            TileClickCommand = new Command<Tile>(OnTileClick);
            TerrainClickCommand = new Command<SelectableTile>(OnTerrainClick);
        }

        private void OnTerrainClick(SelectableTile obj)
        {
            switch (obj.terrain)
            {
                case (SelectableTile.Terrain)0:
                    selectedEnum = Selection.One;
                    break;
                case (SelectableTile.Terrain)1:
                    selectedEnum = Selection.Two;
                    break;
                case (SelectableTile.Terrain)2:
                    selectedEnum = Selection.Three;
                    break;


            } 
        }

        private void OnTileClick(Tile tile)
        {
            if (selectedEnum == Selection.One) {
                tile.Red = true;
                tile.Blue = false;
                tile.Green = false;
            }
            else if(selectedEnum == Selection.Two)
            {
                tile.Red = false;
                tile.Blue = true;
                tile.Green = false;
            }
            else if(selectedEnum == Selection.Three)
            {
                tile.Red = false;
                tile.Blue = false;
                tile.Green = true;
            }

        }

    }
}

