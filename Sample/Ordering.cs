using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    internal class Ordering<T>
    {
        private readonly List<T> _directions;

        private Ordering(List<T> directions)
        {
            this._directions = directions;
        }

        public bool IsOK(T from, T to)
        {
            if (this._directions.IndexOf(from) < 0 || this._directions.IndexOf(to) < 0)
            {
                return false;
            }

            return this._directions.IndexOf(from) + 1 == this._directions.IndexOf(to);
        }

        public class Builder
        {
            private readonly List<T> _directions = new List<T>();

            public Builder AndThen(T direction)
            {
                _directions.Add(direction);
                return this;
            }

            public Ordering<T> Build() { return new Ordering<T>(this._directions); }
        }
    }
}
