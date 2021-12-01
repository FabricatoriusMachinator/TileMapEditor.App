using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileMapEditor.App
{
    class SelectableTile : ObservableObject
    {
        public enum Terrain {
            Grass,
            Dirt,
            Cobble
        }

        public Terrain terrain{get; set;}

        private bool blue;
        public bool Blue
        {
            get { return blue; }
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged("Blue");
                }
            }
        }

        private bool red;
        public bool Red
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged("Red");
                }
            }
        }

        private bool green;
        public bool Green
        {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged("Green");
                }
            }
        }
    }
}
