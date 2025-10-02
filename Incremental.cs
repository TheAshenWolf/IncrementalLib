using System;

namespace IncrementalLib
{
    /// <summary>
    /// Class representing a large number. Really large number.
    /// </summary>
    public partial class Incremental
    {
        /// <summary>
        /// Maximum exponent difference between two Incrementals to run actual calculations.
        /// </summary>
        private const int MAX_MAGNITUDE_DIFFERENCE = 15;

        /// <summary>
        /// Represents the display setting of the Incremental.
        /// Change this to change what the <see cref="ToString"/> method returns.
        /// </summary>
        public static DisplaySetting DefaultDisplaySetting = DisplaySetting.Abbreviation;


        /// <summary>
        /// Used for many calculations -> we are caching it here to avoid creating a new one every time.
        /// </summary>
        private const int TEN_CUBE = 1000;

        /// <summary>
        /// Holds the value of the Incremental.
        /// </summary>
        public double Value { get; private set; }

        /// <summary>
        /// Holds the exponent of the Incremental.
        /// </summary>
        public int Exponent { get; private set; }

        /// <summary>
        /// Returns true if the Incremental is negative.
        /// </summary>
        public bool Negative { get; private set; }

        /// <summary>
        /// Constructor accepting a double value and integer exponent.
        /// </summary>
        /// <param name="value">The value of the incremental</param>
        /// <param name="exponent">Exponent to use</param>
        public Incremental(double value, int exponent = 0)
        {
            Negative = value < 0;
            Value = Math.Abs(value);
            Exponent = exponent;

            Normalize();
        }

        /// <summary>
        /// Creates a new Incremental using the <see cref="LargeNumbers"/> enum.
        /// </summary>
        /// <param name="value">The value of the incremental</param>
        /// <param name="exponent">Exponent to use</param>
        public Incremental(double value, LargeNumbers exponent)
        {
            Negative = value < 0;
            Value = Math.Abs(value);
            Exponent = (int)exponent;

            Normalize();
        }

        /// <summary>
        /// Creates a new Incremental using the <see cref="NumberAbbrev"/> enum.
        /// </summary>
        /// <param name="value">The value of the incremental</param>
        /// <param name="exponent">Exponent to use</param>
        public Incremental(double value, NumberAbbrev exponent)
        {
            Negative = value < 0;
            Value = Math.Abs(value);
            Exponent = (int)exponent;

            Normalize();
        }

        /// <summary>
        /// Creates a new Incremental from another Incremental.
        /// (Makes a deep copy)
        /// </summary>
        /// <param name="other">The incremental to copy</param>
        public Incremental(Incremental other)
        {
            Value = other.Value;
            Exponent = other.Exponent;
            Negative = other.Negative;

            Normalize();
        }

        /// <summary>
        /// Creates a zero Incremental.
        /// </summary>
        public Incremental()
        {
            Value = 0;
            Exponent = 0;
            Negative = false;
        }

        /// <summary>
        /// Normalizes the incremental value to where the value is between 1 and 999.
        /// </summary>
        public void Normalize()
        {
            if (Value == 0)
            {
                Exponent = 0;
                Negative = false;
                return;
            }

            if (Value is > 0 and < 1 && Exponent > 0)
            {
                Value *= TEN_CUBE;
                Exponent -= 3;
            }
            else if (Value >= TEN_CUBE)
            {
                int overExp = (int)Math.Floor(Math.Log(Value, TEN_CUBE));
                if (overExp <= 0) return; // This should never happen, but just in case
                Value /= Math.Pow(TEN_CUBE, overExp);
                Exponent += overExp * 3;
            }
            else if (Value <= 0)
            {
                Value = Math.Abs(Value);
                Negative = !Negative;

                if (Value < 1)
                {
                    Value *= TEN_CUBE;
                    Exponent -= 3;
                }
            }
        }

        /// <summary>
        /// Unpacks the sign of the incremental and applies it onto the value
        /// </summary>
        public void Unpack()
        {
            if (Negative)
            {
                Negative = false;
                Value = -Value;
            }
        }

        /// <summary>
        /// Aligns two Incrementals together by increasing the exponent of the smaller one,
        /// reducing its value.
        /// </summary>
        public void Align(Incremental other)
        {
            // If other exponent is smaller than this one, we need to flip the operands in this method
            if (other.Exponent < Exponent)
            {
                other.Align(this);
                return;
            }

            int diff = other.Exponent - Exponent;
            if (diff > 0)
            {
                Value = diff <= MAX_MAGNITUDE_DIFFERENCE ? Value / Math.Pow(10, diff) : 0;
                Exponent = other.Exponent;
            }
        }


        /// <summary>
        /// Returns a formatted number into a more readable form.
        /// Uses <see cref="DefaultDisplaySetting"/> to determine the format.
        /// </summary>
        public override string ToString()
        {
            return ToString(DefaultDisplaySetting);
        }

        /// <summary>
        /// Returns a formatted number into a more readable form using the given <paramref name="setting"/>.
        /// </summary>
        public string ToString(DisplaySetting setting)
        {
            Incremental value = new Incremental(this);
            value.Normalize();

            string sign = value.Negative ? "-" : "";

            Unit unit;
            switch (setting)
            {
                case DisplaySetting.Abbreviation:
                    if (Constants.units.TryGetValue(value.Exponent, out unit))
                    {
                        return sign + value.Value.ToString("N1") + " " + unit.Abbrev;
                    }
                    return sign + value.Value.ToString("N1") + new Unit("e" + value.Exponent, "e" + value.Exponent);

                case DisplaySetting.FullName:
                    if (Constants.units.TryGetValue(value.Exponent, out unit))
                    {
                        return sign + value.Value.ToString("N1") + " " + unit.Full;
                    }
                    return sign + value.Value.ToString("N1") + new Unit("e" + value.Exponent, "e" + value.Exponent);

                case DisplaySetting.Scientific:
                default:
                    return sign + value.Value.ToString("N1") + new Unit("e" + value.Exponent, "e" + value.Exponent);
            }
        }
    }
}