using Godot;
using System;

public class ArrayValue : Sprite
{
    public int selfValue;
    public int index;
  
    public override void _Ready()
    {
        index = GetParent<Node>().GetChildCount() - 1;
        selfValue = ArrayValueGenerator.GetArrayValues()[index];
        GD.Print(selfValue);
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
