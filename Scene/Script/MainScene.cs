using Godot;
using System;

public class MainScene : Node2D
{
    public HSlider arraySizeSlider;
    public int arraySize;

    // Range of Random Number
    public int from;
    public int to;

    public override void _Ready()
    {
        arraySizeSlider = this.GetNode<HSlider>("Control/ArraySizeSlider");

        arraySize = (int)arraySizeSlider.Value;
        from = (int)arraySizeSlider.MinValue;
        to = (int)arraySizeSlider.MaxValue + 1;

        ArrayValueGenerator.RandomArrayValue(arraySize, from, to);
        ArrayValueGenerator.PrintArrayValue();     
    }

// Set Array size through slider
    public void _on_ArraySizeSlider_value_changed(int value){
        arraySize = (int)arraySizeSlider.Value;

        ArrayValueGenerator.RandomArrayValue(arraySize, from, to);
        ArrayValueGenerator.PrintArrayValue();   

    }

// Return a Set of Random Integer Value in Array when Pressed
    public void _on_GenerateNewArray_pressed(){
        arraySize = (int)arraySizeSlider.Value;

        ArrayValueGenerator.RandomArrayValue(arraySize, from, to);
        ArrayValueGenerator.PrintArrayValue();   
    }

 

}
