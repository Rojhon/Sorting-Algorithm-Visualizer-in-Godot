using Godot;
using System;

public class MainScene : Node2D
{
    // Choices for types of sortingAlgoOption and it's index in the Option button
    public static OptionButton sortingAlgoOption;
    public int index = 0;

    // Choices for arraySize of arraySizeOption, and Storage of current array that generated
    public OptionButton arraySizeOption;
    public int arraySize;
    public int[] currentArrayValue;

    // Range of Random Number to be generated in Array
    public int from = 5;
    public int to = 101;

    // Sorting Speed Option ans it's speed value in Millisecond
    public OptionButton sortingSpeedOption;
    public static int sortingSpeed = 1;

    // Sort Button
    public static Button sortButton;

    // Variables for Respawn Object
    public PackedScene arrayValue; // PackedScene of ArrayValue Node
    public Node arrayValueParent; // Storing here the ArrayValue Node

    // The timer for sorting
    public Timer timer; 

    // Color
    public Color defaulColor = new Color( 1, 1, 1, 1 );
    public Color sortedColor = new Color(0, 1, 0, 1);
    public Color comparingColor = new Color( 0, 0, 1, 1 ) ;
    public Color swappingColor = new Color( 1, 0, 0, 1 );

    public override void _Ready(){
        // Adding item choices of Sorting Algorithm option button
        sortingAlgoOption = this.GetNode<OptionButton>("Control/SortingALgoOption");
        AddItem(); 

        // Adding item choices of Array Size Option and Set the array size
        arraySizeOption = this.GetNode<OptionButton>("Control/ArraySizeOption");
        AddSize();
        arraySize = arraySizeOption.GetItemText(arraySizeOption.Selected).ToInt();
        

        // Adding item choices in Sorting Speed Option
        sortingSpeedOption = this.GetNode<OptionButton>("Control/SortingSpeedOption");
        AddSortingSpeed();
        GD.Print("Sorting Speed: " + sortingSpeed);

        // Instance the Array Value Scene and Get the node ArrayValueParent in the scene
        arrayValue = GD.Load<PackedScene>("res://Scene/ArrayValue.tscn"); 
        arrayValueParent = this.GetNode<Node>("ArrayValueParent"); 

        // Sort button
        sortButton = GetNode<Button>("Control/Sort");

        // Get the node Timer in the scene
        timer = GetNode<Timer>("Timer"); 

        // Set the first array values
        SetArrayValue();
    }

    // Adding Choices "Type of Sorting Algorithm" in sortinAlgoOption button and Set the index of current sortAlgoOption in option button when selected
    public void AddItem(){
        sortingAlgoOption.AddItem("Bubble Sort");
        sortingAlgoOption.AddItem("Merge Sort");

    }

    public void _on_SortingALgoOption_item_selected(int index){
        this.index = index;
        
    }

    // Adding Choices "Array size" in arraySizeOption button, Set the array size, Display the new Array Value, and Deleting the old Array Value
    public void AddSize(){
        arraySizeOption.AddItem("5");
        arraySizeOption.AddItem("10");
        arraySizeOption.AddItem("25");
        arraySizeOption.AddItem("50");
        arraySizeOption.AddItem("75");
        arraySizeOption.AddItem("100");

    }

    public void SetSize(){
        arraySize = arraySizeOption.Text.ToString().ToInt();
    }

    public void _on_ArraySizeOption_item_selected(int index){
        ProcessingSorting("Sort", false);
        DeleteInstanceNode();
        timer.Start();
    }

    // Adding Choices "Sorting Speed" in sortingSpeedOption, and Set the Sorting Speed
    public void AddSortingSpeed(){
        sortingSpeedOption.AddItem("0.001");
        sortingSpeedOption.AddItem("0.01");
        sortingSpeedOption.AddItem("0.1");
        sortingSpeedOption.AddItem("1");
        sortingSpeedOption.AddItem("3");
        sortingSpeedOption.AddItem("5");
        
    }

    public void _on_SortingSpeedOption_item_selected(int index){
        float sortingSpeedChoices = sortingSpeedOption.Text.ToString().ToFloat() * 1000;
        sortingSpeed = (int)sortingSpeedChoices;
        GD.Print("Sorting Speed: " + sortingSpeed);

    }

    // Generate a new Random Integer Value in Array and Deleting the old Array value when Pressed
    public void _on_GenerateNewArray_pressed(){
        ProcessingSorting("Sort", false);
        DeleteInstanceNode();
        timer.Start();
    }

    // Sort the current stored array value when pressed
    public void _on_Sort_pressed(){
        ProcessingSorting("Sorting...", true);

        if(sortingAlgoOption.GetItemText(index) == "Bubble Sort"){
            SortingAlgorithm.BubbleSort(currentArrayValue, arrayValueParent, defaulColor, sortedColor, comparingColor, swappingColor);

        }

        else if(sortingAlgoOption.GetItemText(index) == "Merge Sort"){
            GD.Print("Merge Sort");
        }

    }

    // This timer is for Instancing the Node Array Value
    public void _on_Timer_timeout(){
        SetSize();
        SetArrayValue();
    }

    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
    public static void ProcessingSorting(string text, bool disabled){
        sortButton.Text = text;
        sortButton.Disabled = disabled;
        sortingAlgoOption.Disabled = disabled;
    }

    // Set Respawn Point - This is Fix position 
    public Vector2 RespawnPoint(){
        Vector2 location = new Vector2(0, 520);

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

    // Instance the Node in the Scene
    public void InstanceNode(PackedScene node, Vector2 location, Node parent, int size, int gap){
        if(arrayValueParent.GetChildCount() == 0){
            for(int i = 0; i < size; i++){
                Global.InstanceNode(node, location, parent);
                location.x += gap;

            }
        }
        
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
