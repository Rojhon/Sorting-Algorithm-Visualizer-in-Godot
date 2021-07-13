using Godot;
using System;

public class MainScene : Node2D
{
    public HSlider arraySizeSlider; // Instance of HSlider Node
    public int arraySize; // Storing here the current value of arraySizeSlider

    public int[] currentArrayValue; // Storing here the current array integer value

    // Range of Random Number
    public int from;
    public int to;

    // Option Button
    public OptionButton optionButton;

    public int index = 0; // Option button index

    public PackedScene arrayValue;
    public Node arrayValueParent;

    public Timer timer;

    public override void _Ready()
    {
        arrayValue = GD.Load<PackedScene>("res://Scene/ArrayValue.tscn");
        arrayValueParent = this.GetNode<Node>("ArrayValueParent");

        arraySizeSlider = this.GetNode<HSlider>("Control/ArraySizeSlider");
        timer = GetNode<Timer>("Timer");

        arraySize = (int)arraySizeSlider.Value;
        from = (int)arraySizeSlider.MinValue;
        to = (int)arraySizeSlider.MaxValue + 1;

        currentArrayValue = ArrayValueGenerator.RandomArrayValue(arraySize, from, to); // Set the first array Integer value

        InstanceNode(arrayValue, new Vector2(100, 400), arrayValueParent, arraySize);

        ArrayValueGenerator.PrintArrayValue();  // For Debugging 

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
        timer.Start();

    }

    // Sort the current array value when pressed
    public void _on_Sort_pressed(){
        if(optionButton.GetItemText(index) == "Bubble Sort"){
            SortingAlgorithm.BubbleSort(currentArrayValue);
            ArrayValueGenerator.PrintArrayValue();
        }

        if(optionButton.GetItemText(index) == "Merge Sort"){
            GD.Print("Merge Sort");
        }
    }

    // Set Array size through slider
    public void _on_ArraySizeSlider_value_changed(int value){
        DeleteInstanceNode();
        timer.Start();

    }

    // Instance the Node in the Scene
    public void InstanceNode(PackedScene node, Vector2 location, Node parent, int size){
        if(arrayValueParent.GetChildCount() == 0){
            for(int i = 0; i < size; i++){
                Global.InstanceNode(node, location, parent);

            }
        }
        
    }

    // Deleting Old Array Value Instance Node
    public void DeleteInstanceNode(){
        for(int i = 0; i < arrayValueParent.GetChildCount(); i++){
            arrayValueParent.GetChild<Sprite>(i).QueueFree();
        }

    }

    // This timer is for Instancing the Node Array Value
    public void _on_Timer_timeout(){
        arraySize = (int)arraySizeSlider.Value;
        currentArrayValue = ArrayValueGenerator.RandomArrayValue(arraySize, from, to);

        InstanceNode(arrayValue, new Vector2(100, 400), arrayValueParent, arraySize);

        // ArrayValueGenerator.PrintArrayValue(); // For Debugging  

    }

}
