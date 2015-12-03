using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFigures
{
    public class Vector
    {
        private double[] coordinates;

        public Vector(double[] coordinates)
        {
            this.coordinates = coordinates;
        }

        public Vector(Vector vector)
        {
            this.coordinates = vector.coordinates;
        }

        public double this[int index]
        {
            get
            {
                return this.coordinates[index];
            }
            set
            {
                this.coordinates[index] = value;
            }
        }

        public int GetDimensionality 
        {
            get 
            { 
                return this.coordinates.Length; 
            }
        }
        
        public double GetLength()
        {
            double sum = 0;
            foreach (var coordinate in this.coordinates)
            {
                sum += Math.Pow(coordinate, 2);
            }
            return Math.Sqrt(sum);
        }

        public override string ToString()
        {
            return string.Format("Vector[{0}]", string.Join(", ", this.coordinates));
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 7;
                foreach (var coordinate in this.coordinates)
                {
                    hash = hash * 3 + coordinate.GetHashCode();
                }
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = obj as Vector;

                if (this.coordinates.Length != this.coordinates.Length)
                {
                    return false;
                }

                for (int i = 0; i < this.coordinates.Length; i++)
                {
                    if (this.coordinates[i] != this.coordinates[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            else 
            {
                return false;
            }
        }
       
        public static bool operator ==(Vector firstVector, Vector secondVector)
        {
            return firstVector.Equals(secondVector);
        }

        public static bool operator !=(Vector firstVector, Vector secondVector)
        {
            return !firstVector.Equals(secondVector);
        }

        public static Vector operator +(Vector firstVector, Vector secondVector)
        {
            if (firstVector.coordinates.Length != secondVector.coordinates.Length)
            {
                throw new ArgumentException("Vectors should have equals numbers of dimensions!");
            }

            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] + secondVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator -(Vector firstVector, Vector secondVector)
        {
            if (firstVector.coordinates.Length != secondVector.coordinates.Length) 
            {
                throw new ArgumentException("Vectors should have equals numbers of dimensions!");
            }

            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] - secondVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator *(Vector firstVector, Vector secondVector)
        {
            if (firstVector.coordinates.Length != secondVector.coordinates.Length) 
            {
                throw new ArgumentException("Vectors should have equals numbers of dimensions!");
            } 

            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] * secondVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator +(Vector firstVector, double scalar)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] + scalar;
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator +(double scalar, Vector firstVector)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = scalar + firstVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator -(Vector firstVector, double scalar)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] - scalar;
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator -(double scalar, Vector firstVector)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = scalar - firstVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator *(Vector firstVector, double scalar)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] * scalar;
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator *(double scalar, Vector firstVector)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = scalar * firstVector.coordinates[i];
            }
            return new Vector(newCoordintes);
        }

        public static Vector operator /(Vector firstVector, double scalar)
        {
            double[] newCoordintes = new double[firstVector.coordinates.Length];
            for (int i = 0; i < newCoordintes.Length; i++)
            {
                newCoordintes[i] = firstVector.coordinates[i] / scalar;
            }
            return new Vector(newCoordintes);
        }
    }
}
