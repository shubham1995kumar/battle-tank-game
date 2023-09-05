// TankModel.cs
using UnityEngine;

public class TankModel
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    public Material color { get; private set; }

    public TankModel(float _movementSpeed, float _rotationSpeed, Material _color)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        color = _color;
    }
}
