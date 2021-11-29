using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.App
{
    class Map : ObservableObject
    {
        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    height = value * 64;
                    OnPropertyChanged("Height");
                }
            }
        }

        private int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value*64;
                    OnPropertyChanged("Width");
                }
            }
        }
    }
}
