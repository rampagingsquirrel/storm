using UnityEngine;
using System.Collections;

public class SpaceObject
{
    public int id;
    public string name;
    public Vector3 position;
}

public class Star : SpaceObject
{
}

public class Planet : SpaceObject
{
    public string planetType;
}

public class Nebula : SpaceObject
{
}

public class Asteroid : SpaceObject
{
}
