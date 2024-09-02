using UnityEngine;

namespace IncrementalLib
{
    public partial class Incremental
    {
        public static Incremental Pow(Incremental a, int b)
        {
            if (b == 0) return new Incremental(1);

            Incremental result = new Incremental(a);
            if (b == 1) return result;

            while (result.Exponent == 0 && b >= 2)
            {
                result *= a;
                b--;
            }

            if (b == 1) return result;

            result.Exponent *= b;
            result.Normalize();

            Debug.LogError(result);
            return result;
        }

        public static Incremental Pow(double a, int b)
        {
            return Pow(new Incremental(a), b);
        }

        public static Incremental Pow(int a, int b)
        {
            return Pow(new Incremental(a), b);
        }

        public static Incremental Pow(long a, int b)
        {
            return Pow(new Incremental(a), b);
        }

        public static Incremental Min(Incremental a, Incremental b)
        {
            return a < b ? a : b;
        }

        public static Incremental Max(Incremental a, Incremental b)
        {
            return a > b ? a : b;
        }


    }
}