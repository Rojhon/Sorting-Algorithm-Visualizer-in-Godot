using Godot;
using System;

public class MainScene : Node2D
{
    public int arraySize = 5; // Storing here the current value of arraySizeSlider

    public int[] currentArrayValue; // Storing here the current array integer value

    // Range of Random Number
    public int from = 5;
    public int to = 101;

    // Option Button
    public OptionButton sortingAlgoOption;
    public OptionButton arraySizeOption;

    public int index = 0; // Option button index

    public PackedScene arrayValue; // PackedScene of ArrayValue Node
    public Node arrayValueParent; // Storing here the ArrayValue Node

    public Timer timer; // The timer 

    public override void _Ready()
    {
        arrayValue = GD.Load<PackedScene>("res://Scene/ArrayValue.tscn"); // Instance the Array Value Scene
        arrayValueParent = this.GetNode<Node>("ArrayValueParent"); // Get the node ArrayValueParent in the scene

        // Adding item choices of Sorting Algorithm option button
        sortingAlgoOption = this.GetNode<OptionButton>("Control/SortingALgoOption");
        AddItem(); 

        // Adding item choices of Array Size Option and Set the array size
        arraySizeOption = this.GetNode<OptionButton>("Control/ArraySizeOption");
        AddSize();

        timer = GetNode<Timer>("Timer"); // Get the node Timer in the scene

        SetArrayValue();// Set the first array value

    }

    // Adding item choices in Sorting Algorithm option button
    public void AddItem(){
        sortingAlgoOption.AddItem("Bubble Sort");
        sortingAlgoOption.AddItem("Merge Sort");

    }

    // Set the index of active Sort Algorithm in option button when selected
    public void _on_SortingALgoOption_item_selected(int index){
        this.index = index;
        
    }

    // Adding item choices button in Array Size Option
    public void AddSize(){
        arraySizeOption.AddItem("5");
        arraySizeOption.AddItem("10");
        arraySizeOption.AddItem("25");
        arraySizeOption.AddItem("50");
        arraySizeOption.AddItem("75");
        arraySizeOption.AddItem("100");

    }

    // Display the new Array Value and Deleting the old Array Value
    public void _on_ArraySizeOption_item_selected(int index){
        DeleteInstanceNode();
        timer.Start();
    }

    // Set the array size
    public void SetSize(){
        arraySize = arraySizeOption.Text.ToString().ToInt();
    }

    // Generate a new Random Integer Value in Array and Deleting the old Array value when Pressed
    public void _on_GenerateNewArray_pressed(){
        DeleteInstanceNode();
        timer.Start();
    }

    // This timer is for Instancing the Node Array Value
    public void _on_Timer_timeout(){
        SetSize();
        SetArrayValue();
    }

    // Sort the current array value when pressed
    public void _on_Sort_pressed(){
        if(sortingAlgoOption.GetItemText(index) == "Bubble Sort"){
            SortingAlgorithm.BubbleSort(currentArrayValue);
            
            ArrayValueGenerator.PrintArrayValue(); // For Debugging
        }

        if(sortingAlgoOption.GetItemText(index) == "Merge Sort"){
            GD.Print("Merge Sort");
        }
    }

    // Instance the Node in the Scene
    public void InstanceNode(PackedScene node, Vector2 location, Node parent, int size, int gap){
        if(arrayValueParent.GetChildCount() == 0){
            for(int i = 0; i < size; i++){
                Global.InstanceNode(node, location, parent);
                location.x += gap;

            }
        }
        
    }

    // Set Respawn Point - This is Fix position 
    public Vector2 RespawnPoint(){
        Vector2 location = new Vector2(0, 520); // 482

        if(ArrayValueGenerator.GetLength() == 5){
            location.x = 308;
        }
        else if(ArrayValueGenerator.GetLength() == 10){
            location.x = 133;
        }
        else if(ArrayValueGenerator.GetLength() == 25){
            location.x = 43;
        }
        else{
            location.x = 33;

        }
        
        
        return location;
    }

    // Gap for displaying Array Value
    public int Gap(int arraySize){
        int gap = 0;
        if(arraySize == 5 || arraySize == 10){
            gap = 70;

        }
        else if(arraySize == 25){
            gap = 35;
        }

        else if(arraySize == 50){
            gap = 18;
        }
        else if(arraySize == 75){
            gap = 12;
        }
        else if(arraySize == 100){
            gap = 9;
        }
        return gap;
    }

    // Set and Display the array values in the scene
    public void SetArrayValue(){
        currentArrayValue = ArrayValueGenerator.RandomArrayValue(arraySize, from, to);

        InstanceNode(arrayValue, RespawnPoint(), arrayValueParent, arraySize, Gap(arraySize));

        // For Debugging  
        ArrayValueGenerator.PrintArrayValue(); 
        GD.Print("Array Size: " + ArrayValueGenerator.GetLength());

    }

    // Deleting Old Array Value Instance Node
    public void DeleteInstanceNode(){
        for(int i = 0; i < arrayValueParent.GetChildCount(); i++){
            arrayValueParent.GetChild<Sprite>(i).QueueFree();
        }

    }

}
