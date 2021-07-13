using Godot;
using System;

public class ArrayValue : Sprite
{
    public int selfValue;
    public int index;
  
    public override void _Ready()
    {
        index = GetParent<Node>().GetChildCount() - 1;
        selfValue = ArrayValueGenerator.GetArrayValues()[index]; // Set this to the array value
    }

}
