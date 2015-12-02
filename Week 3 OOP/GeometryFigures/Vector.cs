using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class Vector
    {
        private List<Point> coordinates;

        public Vector(List<Point> coordinates) 
        {
            this.coordinates = coordinates;
        }

        public Vector(Vector vector) 
        {
            this.coordinates = vector.coordinates;
        }

        public Point this[int index] 
        {
            get 
            {
                return this.coordinates.ElementAt(index);
            }
            set 
            {
                if (index >= this.coordinates.Count())
                {
                    this.coordinates.Add(value);
                }
                else 
                {
                    this.coordinates[index] = value;
                }
            }
        }

        //TODO: Vector Problem
    }
}
