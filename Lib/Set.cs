using System;
using System.Linq;

namespace Lib
{
    public class Set<Value>
    {
        Value[] values = new Value[0];

        public int Length { get => values.Length; }

        public Value this[int i] { get => values[i]; }

        public void Add(Value value)
        {
            if (values.Contains(value)) return;

            var newValues = new Value[values.Length + 1];

            for (var i = 0; i < values.Length; i++)
                newValues[i] = values[i];

            newValues[^1] = value;

            values = newValues;
        }

        public void Sort(Func<Value, Value, Comparison> compare)
        {
            for (var i = 0; i < values.Length; i++)
            {
                for (var j = i + 1; j < values.Length; j++)
                {
                    var comparison = compare(values[i], values[j]);

                    if (comparison == Comparison.Greater)
                    {
                        var temp = values[i];

                        values[i] = values[j];
                        values[j] = temp;
                    }
                }
            }
        }
    }
}
