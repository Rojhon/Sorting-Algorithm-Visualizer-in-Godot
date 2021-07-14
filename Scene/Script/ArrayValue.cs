using Godot;
using System;

public class ArrayValue : Sprite
{
    public Node parent;
    public int index;
    public int selfValue;
    public Label intValue;
    
    public override void _Ready()
    {
        parent = GetParent<Node>();

        // Set this to the array value
        index = parent.GetChildCount() - 1; // Self index in the parent
        selfValue = ArrayValueGenerator.GetArrayValues()[index]; 

        // Display text value
        intValue = this.GetNode<Label>("IntValue");
        intValue.Text = selfValue.ToString();

    }

    public override void _Process(float delta)
    {
        
    }

}
