## Context
An idea to create an object that can enforce the stage ordering.

## Requirements
1. The stage ordering can be defined flexibly.
1. Once the ordering is defined, it will be immutable, which means it can no longer change.

## Design Concepts
1. A builder class accepts the ordering of the stages.
1. The builder will create the object with ordering enforcement, and it will be immutable.