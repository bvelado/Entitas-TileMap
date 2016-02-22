using System;
using System.Collections.Generic;

public class Hex {

    /// <summary>
    /// Column position
    /// </summary>
    public int _q;

    /// <summary>
    /// Row position
    /// </summary>
    public int _r;

    public static Hex[] directions =
    {
        new Hex(1, 0), new Hex(1, -1), new Hex(0, -1),
        new Hex(-1, 0), new Hex(-1, 1), new Hex(0, 1)
    };

    public Hex(int q, int r)
    {
        _q = q;
        _r = r;
    }

    public Cube ToCube()
    {
        return new Cube(_q, -(_q - _r), _r);
    }
    
    public List<Hex> GetNeighborsPositions()
    {
        List<Hex> neighborsPositions = new List<Hex>();
        foreach(Hex direction in directions)
        {
            neighborsPositions.Add(direction + this);
        }
        return neighborsPositions;
    }

    public static float GetDistance(Hex a, Hex b)
    {
        Cube ca = a.ToCube();
        Cube cb = b.ToCube();

        return Cube.GetDistance(ca, cb);
    }

    public static bool IsEqual(Hex a, Hex b)
    {
        if (a._q == b._q && a._r == b._r)
            return true;
        return false;
    }

    public static Hex operator +(Hex a, Hex b)
    {
        return new Hex(a._q + b._q, a._r + b._r);
    }

    public static Hex operator -(Hex a, Hex b)
    {
        return new Hex(a._q - b._q, a._r - b._r);
    }

    public override string ToString()
    {
        return "[" + _q + ";" + _r + "]";
    }
}
