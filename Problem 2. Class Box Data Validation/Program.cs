using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


public class Box
{
    private float length;
    private float width;
    private float height;
    public Box(float length, float width, float height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    private float Length
    {
        set { 
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative");
            }
            this.length = value;
        }
    }
    private float Width
    {
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative");
            }
            this.width = value;
        }
    }
    private float Height
    {
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative");
            }
            this.height = value;
        }
    }
    public float SurfaceArea()
    {
        return 2 * (this.length * this.width) + 2 * (this.length * this.height) + 2 * (this.width * this.height);
    }
    public float LateralSurfaceArea()
    {
        return 2 * (this.length * this.height) + 2 * (this.width * this.height);
    }
    public float Volume()
    {
        return this.length * this.width * this.height;
    }
}

namespace ООП_ЛАБА_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                float length = float.Parse(Console.ReadLine());
                float width = float.Parse(Console.ReadLine());
                float height = float.Parse(Console.ReadLine());
                var NewBox = new Box(length, width, height);
                Console.WriteLine("SurfaceArea - " + NewBox.SurfaceArea());
                Console.WriteLine("LateralSurfaceArea - " + NewBox.LateralSurfaceArea());
                Console.WriteLine("Volume - " + NewBox.Volume());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
