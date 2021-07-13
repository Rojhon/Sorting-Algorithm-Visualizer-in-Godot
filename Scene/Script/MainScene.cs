using Godot;
using System;

public class MainScene : Node2D
{
    public ArrayValueGenerator arrayValueGenerator; // Instance of ArrayValueGenerator Class
    public HSlider arraySizeSlider; // Instance of HSlider Node
    public int arraySize; // Storing here the current value of arraySizeSlider

    public int[] currentArrayValue; // Storing here the current array integer value

    // Range of Random Number
    public int from;
    public int to;

    // Option Button
    public OptionButton optionButton;

    public int index = 0; // Option button index

    public override void _Ready()
    {
        arrayValueGenerator = new ArrayValueGenerator();
        arraySizeSlider = this.GetNode<HSlider>("Control/ArraySizeSlider");

        arraySize = (int)arraySizeSlider.Value;
        from = (int)arraySizeSlider.MinValue;
        to = (int)arraySizeSlider.MaxValue + 1;

        currentArrayValue = arrayValueGenerator.RandomArrayValue(arraySize, from, to); // Set the first array Integer value
        arrayValueGenerator.PrintArrayValue();  // For Debugging 

        optionButton = this.GetNode<OptionButton>("Control/OptionButton");
        AddItem(); // Adding the item of option button
        
    }

    // Add the item of option button
    public void AddItem(){
        optionButton.AddItem("Bubble Sort");
        optionButton.AddItem("Merge Sort");
    }

    // Set the index of active Sort Algorithm in option button when selected
    public void _on_OptionButton_item_selected(int index){
        this.index = index;
    }

    // Generate a new Random Integer Value in Array when Pressed
    public void _on_GenerateNewArray_pressed(){
        arraySize = (int)arraySizeSlider.Value;

        currentArrayValue = arrayValueGenerator.RandomArrayValue(arraySize, from, to);
        arrayValueGenerator.PrintArrayValue();  // For Debugging  
    }

    // Sort the current array value when pressed
    public void _on_Sort_pressed(){
        if(optionButton.GetItemText(index) == "Bubble Sort"){
            SortingAlgorithm.BubbleSort(currentArrayValue);
            arrayValueGenerator.PrintArrayValue();
        }

        if(optionButton.GetItemText(index) == "Merge Sort"){
            GD.Print("Merge Sort");
        }
    }

// Set Array size through slider
    public void _on_ArraySizeSlider_value_changed(int value){
        arraySize = (int)arraySizeSlider.Value;

        currentArrayValue = arrayValueGenerator.RandomArrayValue(arraySize, from, to);
        arrayValueGenerator.PrintArrayValue();   // For Debugging 

    }

}
