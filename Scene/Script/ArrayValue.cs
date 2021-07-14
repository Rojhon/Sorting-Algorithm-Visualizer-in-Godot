using Godot;
using System;

public class ArrayValue : Sprite
{
    public Node parent; // Parent Node -- Array Value Parent
    public int index; // Index for getting self ChildCount in Parent
    public int selfValue; // Storing here the data of his Array Value
    public Label intValue; // Label the data

    public Sprite valueSprite; // Value Sprite Node

    public override void _Ready()
    {
        parent = GetParent<Node>();

        // Set this to the array value
        index = parent.GetChildCount() - 1; // Self index in the parent
        selfValue = ArrayValueGenerator.GetArrayValues()[index]; 

        // Display text value
        intValue = this.GetNode<Label>("IntValue");
        intValue.Text = selfValue.ToString();

        // Value Sprite Node
        valueSprite = GetNode<Sprite>("ValueSprite");
        valueSprite.Scale = new Vector2(valueSprite.Scale.x, -selfValue * 4);

    }

}
