## Context
An idea to create an object that can enforce the stage ordering.

## Requirements
1. The stage ordering can be defined flexibly.
1. Once the ordering is defined, it will be immutable, which means it can no longer change.

## Design Concepts
1. A builder class accepts the ordering of the stages.
1. The builder will create the object with ordering enforcement, and it will be immutable.

## Builder
```
    public class Ordering<T>
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

            return this._directions.IndexOf(from) < this._directions.IndexOf(to);
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

```