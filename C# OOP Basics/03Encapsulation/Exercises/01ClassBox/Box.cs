using System;
using System.Collections.Generic;
using System.Text;

namespace _01ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length { get => length; set => length = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }

        public double CalculateLateralSurface()
        {
            double lateralSurface = 2 * (this.length * this.height) + 2 * (this.width * this.height);
            return lateralSurface;
        }

        public double CalculateSurface()
        {
            double surface = 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
            return surface;
        }

        public double CalculateVolume()
        {
            double volume = this.length * this.height * this.width;
            return volume;
        }
        
        public override string ToString()
        {
            return $"Surface Area - {this.CalculateSurface():f2}\nLateral Surface Area - {this.CalculateLateralSurface():f2}\n" +
                $"Volume - {this.CalculateVolume():f2}";
            
        }
    }
}
