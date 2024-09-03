namespace IncrementalLib
{
    public partial class Incremental
    {
        public static Incremental Pow(Incremental a, int b)
        {
            if (b == 0) return new Incremental(1);
            if (b == 1) return new Incremental(a);

            Incremental result = new Incremental(1);
            Incremental baseValue = new Incremental(a);

            while (b > 0)
            {
                if (b % 2 == 1)
                {
                    result *= baseValue;
                }

                baseValue *= baseValue;
                b /= 2;
            }

            result.Normalize();

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