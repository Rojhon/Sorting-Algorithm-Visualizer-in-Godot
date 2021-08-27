using Godot;
using System;

public class MainScene : Node2D
{
    // Choices for types of sortingAlgoOption and it's index in the Option button
    public static OptionButton sortingAlgoOption;

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
    float sortingSpeedChoices;

    // Sort Button
    public static Button sortButton;

    // Variables for Respawn Object
    public PackedScene arrayValue; // PackedScene of ArrayValue Node
    public Node arrayValueParent; // Storing here the ArrayValue Node

    // The timer for sorting
    public Timer timer; 

    // Sorting
    public static bool sorting = false;

    public override void _Ready()
    {
        Data.LoadGame();

        // Adding item choices of Sorting Algorithm option button
        sortingAlgoOption = this.GetNode<OptionButton>("Control/SortingALgoOption");
        sortingAlgoOption.FocusMode = Control.FocusModeEnum.None;
        AddItem(); 
        sortingAlgoOption.Select(Data.data[0]); // Set the active save Option in SortingAlgoOption

        // Adding item choices of Array Size Option and Set the array size
        arraySizeOption = this.GetNode<OptionButton>("Control/ArraySizeOption");
        arraySizeOption.FocusMode = Control.FocusModeEnum.None;
        AddSize();
        arraySizeOption.Select(Data.data[1]); // Set the active save Option Array SIze
        arraySize = arraySizeOption.GetItemText(arraySizeOption.Selected).ToInt();

        // Adding item choices in Sorting Speed Option
        sortingSpeedOption = this.GetNode<OptionButton>("Control/SortingSpeedOption");
        sortingSpeedOption.FocusMode = Control.FocusModeEnum.None;
        AddSortingSpeed();
        sortingSpeedOption.Select(Data.data[2]); // Set the active save Option Sorting Speed
        sortingSpeedChoices = sortingSpeedOption.Text.ToString().ToFloat() * 1000;
        sortingSpeed = (int)sortingSpeedChoices;

        // Instance the Array Value Scene and Get the node ArrayValueParent in the scene
        arrayValue = GD.Load<PackedScene>("res://Scene/ArrayValue.tscn"); 
        arrayValueParent = this.GetNode<Node>("ArrayValueParent"); 

        // Sort button
        sortButton = GetNode<Button>("Control/Sort");

        // Get the node Timer in the scene
        timer = GetNode<Timer>("Timer"); 

        // Set the first array values
        SetArrayValue();

        // Print Values in Console for debugging
        Debug();
        
    }

    // For Debugging
    public override void _PhysicsProcess(float delta)
    {
        if(Input.IsActionJustPressed("Debug")){
            Debug();

        }
    }

    public void Debug()
    {
        Console.Clear();
        GD.Print("Current Values...");
        GD.Print($"Active Algorithm: {sortingAlgoOption.Text}");
        ArrayValueGenerator.PrintArrayValue();
        GD.Print($"Array Length: {ArrayValueGenerator.GetLength()}");
        GD.Print($"Sorting Speed: {sortingSpeed} ms -> {(float)sortingSpeed/1000} sec");
        GD.Print("");
    }

    // Saving the Data
    public void SaveData(int dataIndex, int optionData)
    {
        Data.data[dataIndex] = optionData;
        Data.SaveGame();

    }

    // Adding Choices "Type of Sorting Algorithm" in sortinAlgoOption button and Set the index of current sortAlgoOption in option button when selected
    public void AddItem()
    {
        sortingAlgoOption.AddItem("Bubble Sort");
        sortingAlgoOption.AddItem("Insertion Sort");
        sortingAlgoOption.AddItem("Gnome Sort");
        sortingAlgoOption.AddItem("Selection Sort");

    }

    public void _on_SortingALgoOption_item_selected(int index)
    {
        SaveData(0, index);
        Debug();

    }

    // Adding Choices "Array size" in arraySizeOption button, Set the array size, Display the new Array Value, and Deleting the old Array Value
    public void AddSize()
    {
        arraySizeOption.AddItem("5");
        arraySizeOption.AddItem("10");
        arraySizeOption.AddItem("25");
        arraySizeOption.AddItem("50");
        arraySizeOption.AddItem("75");
        arraySizeOption.AddItem("100");

    }

    public void SetSize()
    {
        arraySize = arraySizeOption.Text.ToString().ToInt();
    }

    public void _on_ArraySizeOption_item_selected(int index)
    {
        SaveData(1, index);
        ProcessingSorting("Sort", false, Control.CursorShape.PointingHand);
        DeleteInstanceNode();
        timer.Start();

    }

    // Adding Choices "Sorting Speed" in sortingSpeedOption, and Set the Sorting Speed
    public void AddSortingSpeed()
    {
        sortingSpeedOption.AddItem("0.001");
        sortingSpeedOption.AddItem("0.01");
        sortingSpeedOption.AddItem("0.1");
        sortingSpeedOption.AddItem("1");
        sortingSpeedOption.AddItem("3");
        sortingSpeedOption.AddItem("5");
        
    }

    public void _on_SortingSpeedOption_item_selected(int index)
    {
        sortingSpeedChoices = sortingSpeedOption.Text.ToString().ToFloat() * 1000;
        sortingSpeed = (int)sortingSpeedChoices;

        SaveData(2, index);
        Debug();
    }

    // Generate a new Random Integer Value in Array and Deleting the old Array value when Pressed
    public void _on_GenerateNewArray_pressed()
    {
        ProcessingSorting("Sort", false, Control.CursorShape.PointingHand);
        DeleteInstanceNode();
        timer.Start();
    }

    // Sort the current stored array value when pressed
    public void _on_Sort_pressed()
    {
        sorting = true;
        GD.Print("Sorting...");
        ProcessingSorting("Sorting...", true, Control.CursorShape.Forbidden);

        if(sortingAlgoOption.GetItemText(sortingAlgoOption.Selected) == "Bubble Sort")
        {
            SortingAlgorithm.BubbleSort(currentArrayValue, arrayValueParent, Colors.defaulColor, Colors.sortedColor, Colors.comparingColor, Colors.swappingColor);

        }

        else if(sortingAlgoOption.GetItemText(sortingAlgoOption.Selected) == "Insertion Sort")
        {
            SortingAlgorithm.InsertionSort(currentArrayValue, arrayValueParent, Colors.defaulColor, Colors.sortedColor, Colors.swappingColor);
            // SortingAlgorithm.InsertionSort(currentArrayValue, arrayValueParent, Colors.defaulColor, Colors.sortedColor, Colors.comparingColor, Colors.swappingColor);

        }
        else if(sortingAlgoOption.GetItemText(sortingAlgoOption.Selected) == "Gnome Sort")
        {
            SortingAlgorithm.GnomeSort(currentArrayValue, arrayValueParent, Colors.defaulColor, Colors.sortedColor, Colors.comparingColor, Colors.swappingColor);

        }

        else if(sortingAlgoOption.GetItemText(sortingAlgoOption.Selected) == "Selection Sort")
        {
            SortingAlgorithm.SelectionSort(currentArrayValue, arrayValueParent, Colors.defaulColor, Colors.sortedColor, Colors.comparingColor, Colors.swappingColor);

        }

    }

    // This timer is for Instancing the Node Array Value
    public void _on_Timer_timeout()
    {
        SetSize();
        SetArrayValue();
        Debug();
    }

    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
    public static void ProcessingSorting(string text, bool disabled, Control.CursorShape cursor)
    {
        sortButton.Text = text;
        sortButton.Disabled = disabled;
        sortButton.MouseDefaultCursorShape = cursor;

        sortingAlgoOption.Disabled = disabled;
        sortingAlgoOption.MouseDefaultCursorShape = cursor;

    }

    // Set Respawn Point - This is Fix position 
    public Vector2 RespawnPoint()
    {
        Vector2 location = new Vector2(0, 520);

        if(ArrayValueGenerator.GetLength() == 5)
        {
            location.x = 308;
        }
        else if(ArrayValueGenerator.GetLength() == 10)
        {
            location.x = 133;
        }
        else if(ArrayValueGenerator.GetLength() == 25)
        {
            location.x = 43;
        }
        else
        {
            location.x = 33;

        }
        
        return location;
    }

    // Gap for displaying Array Value
    public int Gap(int arraySize)
    {
        int gap = 0;
        if(arraySize == 5 || arraySize == 10)
        {
            gap = 70;

        }
        else if(arraySize == 25)
        {
            gap = 35;
        }

        else if(arraySize == 50)
        {
            gap = 18;
        }
        else if(arraySize == 75)
        {
            gap = 12;
        }
        else if(arraySize == 100)
        {
            gap = 9;
        }
        return gap;
    }

    // Instance the Node in the Scene
    public void InstanceNode(PackedScene node, Vector2 location, Node parent, int size, int gap)
    {
        if(arrayValueParent.GetChildCount() == 0)
        {
            for(int i = 0; i < size; i++)
            {
                Instance.InstanceNode(node, location, parent);
                location.x += gap;

            }
        }
        
    }

    // Set and Display the array values in the scene
    public void SetArrayValue()
    {
        currentArrayValue = ArrayValueGenerator.RandomArrayValue(arraySize, from, to);

        InstanceNode(arrayValue, RespawnPoint(), arrayValueParent, arraySize, Gap(arraySize));

    }

    // Deleting Old Array Value Instance Node
    public void DeleteInstanceNode()
    {
        for(int i = 0; i < arrayValueParent.GetChildCount(); i++)
        {
            arrayValueParent.GetChild<Sprite>(i).QueueFree();
        }

    }

}
