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


    public Global global;
    public PackedScene arrayValue;
    public Node arrayValueParent;

    public override void _Ready()
    {

        global = new Global();
        arrayValue = GD.Load<PackedScene>("res://Scene/ArrayValue.tscn");
        arrayValueParent = GetNode<Node>("ArrayValueParent");

        arrayValueGenerator = new ArrayValueGenerator();
        arraySizeSlider = this.GetNode<HSlider>("Control/ArraySizeSlider");

        arraySize = (int)arraySizeSlider.Value;
        from = (int)arraySizeSlider.MinValue;
        to = (int)arraySizeSlider.MaxValue + 1;

        currentArrayValue = arrayValueGenerator.RandomArrayValue(arraySize, from, to); // Set the first array Integer value

        InstanceNode(arrayValue, new Vector2(100, 400), arrayValueParent, arraySize);

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
        DeleteInstanceNode();

        arraySize = (int)arraySizeSlider.Value;
        currentArrayValue = arrayValueGenerator.RandomArrayValue(arraySize, from, to);

        InstanceNode(arrayValue, new Vector2(100, 400), arrayValueParent, arraySize);

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

    public void InstanceNode(PackedScene node, Vector2 location, Node parent, int arraySize){
        if(arrayValueParent.GetChildCount() == 0){
            for(int i = 0; i < arraySize; i++){
            global.InstanceNode(node, location, parent);
        }
        }
        
    }

    public void DeleteInstanceNode(){
        for(int i = 0; i < arrayValueParent.GetChildCount(); i++){
            arrayValueParent.GetChild<Sprite>(i).QueueFree();
        }

    }

}
