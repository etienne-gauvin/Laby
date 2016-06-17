using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class Cube {

    [Serializable]
    public class Direction : Cube
    {
        private static Direction[] _directions = {
            new Direction(new Vector3(1, -1, 0), 0),
            new Direction(new Vector3(1, 0, -1), 1),
            new Direction(new Vector3(0, 1, -1), 2),
            new Direction(new Vector3(-1, 1, 0), 3),
            new Direction(new Vector3(-1, 0, 1), 4),
            new Direction(new Vector3(0, -1, 1), 5)
        };

        public readonly int d;

        private Direction(Vector3 vect, int d) : base(vect)
        {
            this.d = d;
        }

        public static Direction GetRandom()
        {
            return _directions[UnityEngine.Random.Range(0, _directions.Length)];
        }

        public static Direction Get(int d)
        {
            return _directions[d];
        }

        public static Direction GetOpposite(int d)
        {
            if (d + 3 >= _directions.Length)
            {
                return _directions[d - 3];
            }
            else
            {
                return _directions[d + 3];
            }
        }

        public Direction Opposite()
        {
            return GetOpposite(d);
        }

        public new Direction RotateLeft()
        {
            if (d - 1 < 0)
            {
                return _directions[_directions.Length - 1];
            }
            else
            {
                return _directions[d - 1];
            }
        }

        public new Direction RotateRight()
        {
            if (d + 1 >= _directions.Length)
            {
                return _directions[0];
            }
            else
            {
                return _directions[_directions.Length + 1];
            }
        }

        public static Direction[] GetAll()
        {
            return _directions;
        } 
    }
    
    public Vector3 position;

    public Cube(Vector3 position) {
        this.position = position;
    }

    public Cube(float x, float y, float z) {
        position = new Vector3(x, y, z);
    }

    public float x
    {
        get
        {
            return position.x;
        }

        set
        {
            position.z = value;
        }
    }

    public float y
    {
        get
        {
            return position.y;
        }

        set
        {
            position.z = value;
        }
    }

    public float z
    {
        get
        {
            return position.z;
        }

        set
        {
            position.z = value;
        }
    }

    public override String ToString() {
        return String.Format("{0}, {1}, {2}", position.x, position.y, position.z);
    }

    public override bool Equals(object obj) {
        Cube c = obj as Cube;
        return position.Equals(c.position);
    }

    public override int GetHashCode() {
        return position.GetHashCode();
    }

    public static Cube operator + (Cube c1, Cube c2) {
        return new Cube(c1.position + c2.position);
    }

    public static Cube operator - (Cube c1, Cube c2) {
        return new Cube(c1.position - c2.position);
    }

    public Cube RotateLeft() {
        return new Cube(-position[1], -position[2], -position[0]);
    }

    public Cube RotateRight() {
        return new Cube(-position[2], -position[0], -position[1]);
    }

    public float Length() {
        float len = 0.0f;
        for (int i = 0; i < 3; i++) {
            if (Math.Abs(position[i]) > len) {
                len = Math.Abs(position[i]);
            }
        }
        return len;
    }

    public Cube Round() {
        int[] r = new int[3];
        var sum = 0;

         r[0] = (int)Math.Round(position.x);
         r[1] = (int)Math.Round(position.y);
         r[2] = (int)Math.Round(position.z);

        for (int i=0; i < 3; i++) {
            sum += r[i];
        }

        if (sum != 0) {
            float[] e = new float[3];
            var worst_i = 0;

            for (int i = 0; i < 3; i++ ) {
                e[i] = Math.Abs(r[i] - position[i]);
                if (e[i] > e[worst_i]) {
                    worst_i = i;
                }
            }

            r[worst_i] = -sum + r[worst_i];
        }

        return new Cube(r[0], r[1], r[2]);
    }
}
