using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TileMapEditor.App
{
    class Tile : ObservableObject
    {
        public int Row { get; set; }

        public int Column { get; set; }

        private bool blue;
        public bool Blue
        {
            get { return blue; }
            set
            {
                if(blue != value)
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

        private bool clicked = false;
        public bool Clicked
        {
            get { return clicked; }
            set
            {
                if (clicked != value)
                {
                    clicked = value;
                    OnPropertyChanged("Clicked");
                }
            }
        }
    }
}
