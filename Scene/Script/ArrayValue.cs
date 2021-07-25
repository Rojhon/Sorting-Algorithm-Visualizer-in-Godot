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

        // Set This Name
        this.Name = selfValue.ToString(); 

        // Value Sprite Node - Set the Scale
        valueSprite = GetNode<Sprite>("ValueSprite");

        if(ArrayValueGenerator.GetLength() == 5 || ArrayValueGenerator.GetLength() == 10)
        {
            valueSprite.Scale = new Vector2(valueSprite.Scale.x, -selfValue * 4);

        }else if(ArrayValueGenerator.GetLength() == 25)
        {
            valueSprite.Scale = new Vector2(30, -selfValue * 4);

        }
        else if(ArrayValueGenerator.GetLength() == 50)
        {
            valueSprite.Scale = new Vector2(15, -selfValue * 4);

        }
        else if(ArrayValueGenerator.GetLength() == 75)
        {
            valueSprite.Scale = new Vector2(10, -selfValue * 4);

        }
        else if(ArrayValueGenerator.GetLength() == 100)
        {
            valueSprite.Scale = new Vector2(5, -selfValue * 4);

        }

        // Show Hide the Label
        if(ArrayValueGenerator.GetLength() <= 10)
        {
            intValue.Show();
        }
        else
        {
            intValue.Hide();
        }


    }

}
