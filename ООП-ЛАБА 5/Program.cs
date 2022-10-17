using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box
{
    private float length;
    private float width;
    private float height;
    public Box(float length, float width, float height)
    {
        this.length= length;
        this.width = width;
        this.height = height;
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
            float length = float.Parse(Console.ReadLine());
            float width = float.Parse(Console.ReadLine());
            float height = float.Parse(Console.ReadLine());
            var NewBox = new Box(length,width,height);
            Console.WriteLine("SurfaceArea - " + NewBox.SurfaceArea());
            Console.WriteLine("LateralSurfaceArea - " + NewBox.LateralSurfaceArea());
            Console.WriteLine("Volume - " + NewBox.Volume());
        }
    }
}
