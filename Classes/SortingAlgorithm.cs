using Godot;
using System;
using System.Threading.Tasks;

public class SortingAlgorithm
{
    // Bubble Sort
    public static async Task BubbleSort(int []arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor, Color swappingColor)
    {
        await Task.Run(()=>
        {
            int n = arr.Length; // Array Length

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {

                    // Set the Comparing Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = comparingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = comparingColor;

                    // GD.Print(arr[j] + " Comparing " + arr[j + 1]);
                    Task.Delay(MainScene.sortingSpeed).Wait();

                    if (arr[j] > arr[j + 1])
                    {
                        // Swapping the array value
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // Set the Swapping Color
                        arrayValueParent.GetChild<Sprite>(j).Modulate = swappingColor;
                        arrayValueParent.GetChild<Sprite>(j + 1).Modulate = swappingColor;

                        Task.Delay(MainScene.sortingSpeed).Wait();

                        // Set Size
                        Vector2 tempGLobalScale = arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale;
                        arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale;
                        arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;

                        // GD.Print(temp + " Swapping " + arr[j]);
                    }

                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the Default Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;

                    if(j == n - i - 2)
                    {
                        // GD.Print("Success Sorted: " + arr[j + 1]);
                        // Set the Sorted Color
                        arrayValueParent.GetChild<Sprite>(j + 1).Modulate = sortedColor;

                    }

                    if(i == n - 2)
                    {
                            // GD.Print("Success Sorted: " + arr[j]);

                            // Set the Sorted Color
                            arrayValueParent.GetChild<Sprite>(j).Modulate = sortedColor;

                            // For Debugging
                            ArrayValueGenerator.PrintArrayValueSorted("Bubble Sort"); 

                            // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                            MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);
                    }
                }

            }
        }
        );
            
    }

    // Insertion Sort
    public static async Task InsertionSort(int[] arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color swappingColor)
    {
        await Task.Run(()=>
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++) 
            {
                int key = arr[i];
                int j = i - 1;

                // Set the Color
                if(i == 1){
                    arrayValueParent.GetChild<Sprite>(j).Modulate = sortedColor;
                }

                Vector2 tempGLobalScale = arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).GlobalScale;

                Task.Delay(MainScene.sortingSpeed).Wait();

                arrayValueParent.GetChild<Sprite>(i).Modulate = swappingColor;

                Task.Delay(MainScene.sortingSpeed).Wait();
    
                while (j >= 0 && arr[j] > key)
                {
                    // Set the swapping color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = swappingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = swappingColor;

                    Task.Delay(MainScene.sortingSpeed).Wait();
                    
                    // Set the default Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;

                    // Set the scale
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale;
                    // arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;

                    // Set the Sorted Color
                    if(i < n - 1)
                    {
                        arrayValueParent.GetChild<Sprite>(i).Modulate = sortedColor;
                    }
                    

                    arr[j + 1] = arr[j];
                    j = j - 1;
                    
                    if(j >= 0){
                        arrayValueParent.GetChild<Sprite>(j).Modulate = swappingColor;

                    }
                    
                    Task.Delay(MainScene.sortingSpeed).Wait();
                }
                if(j >= 0){
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;

                }
                arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;
                if(i < n - 1)
                {
                    arrayValueParent.GetChild<Sprite>(i).Modulate = sortedColor;
                }
                
                arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;
                arr[j + 1] = key;

                // Sorting Finish
                if(i == n - 1)
                {
                    for (int f = 0; f < n; f++)
                    {
                        arrayValueParent.GetChild<Sprite>(f).Modulate = swappingColor;
                        Task.Delay(MainScene.sortingSpeed).Wait();
                        arrayValueParent.GetChild<Sprite>(f).Modulate = sortedColor;

                    }
                    // For Debugging
                    ArrayValueGenerator.PrintArrayValueSorted("Insertion Sort");

                    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                    MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);

                }
            }
        });
    }

    // Gnome Sort
    public static async Task GnomeSort(int[] arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor,Color swappingColor)
    {
        await Task.Run(()=>
        {
            int n = arr.Length;
            int index = 0;
 
            while (index < n)
            {
                if (index == 0)
                    index++;

                // GD.Print(arr[index - 1] + " Comparing " + arr[index]);
                arrayValueParent.GetChild<Sprite>(index).Modulate = comparingColor;
                arrayValueParent.GetChild<Sprite>(index - 1).Modulate = comparingColor;
                Task.Delay(MainScene.sortingSpeed).Wait();

                if (arr[index] >= arr[index - 1])
                {
                    // Set the default color
                    arrayValueParent.GetChild<Sprite>(index).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(index - 1).Modulate = defaulColor;
                    Task.Delay(MainScene.sortingSpeed).Wait();
                    index++;
                }
                    
                else {
                    int temp = 0;
                    temp = arr[index];

                    Vector2 tempGLobalScale = arrayValueParent.GetChild<Sprite>(index).GetChild<Sprite>(0).GlobalScale;

                    // GD.Print(arr[index] + " Swapping " + arr[index - 1]);
                    arrayValueParent.GetChild<Sprite>(index).Modulate = swappingColor;
                    arrayValueParent.GetChild<Sprite>(index - 1).Modulate = swappingColor;
                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the scale
                    arrayValueParent.GetChild<Sprite>(index).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(index - 1).GetChild<Sprite>(0).GlobalScale;
                    arrayValueParent.GetChild<Sprite>(index - 1).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;

                    // Set the default color
                    Task.Delay(MainScene.sortingSpeed).Wait();
                    arrayValueParent.GetChild<Sprite>(index).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(index - 1).Modulate = defaulColor;

                    arr[index] = arr[index - 1];
                    arr[index - 1] = temp;
                    index--;
                }
            }

            for (int i = 0; i < n; i++)
            {
                // Set the sorted color
                arrayValueParent.GetChild<Sprite>(i).Modulate = sortedColor;
                Task.Delay(MainScene.sortingSpeed).Wait();
            }
            // For Debugging
            ArrayValueGenerator.PrintArrayValueSorted("Gnome Sort");

            // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
            MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);
        });
    }
   
   // Selection Sort
   public static async Task SelectionSort(int []arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor,Color swappingColor)
    {
        await Task.Run(()=>
        {
            int n = arr.Length;
    
            // One by one move boundary of unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array
                int min_index = i;
                for (int j = i + 1; j < n; j++)
                {
                    // GD.Print(arr[j] + " Comparing " + arr[min_index]);
                    arrayValueParent.GetChild<Sprite>(j).Modulate = comparingColor;
                    arrayValueParent.GetChild<Sprite>(min_index).Modulate = comparingColor;
                    Task.Delay(MainScene.sortingSpeed).Wait();
                    
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;

                    if (arr[j] < arr[min_index])
                    {
                        arrayValueParent.GetChild<Sprite>(min_index).Modulate = defaulColor;
                        min_index = j;
                        // GD.Print("Current Min: " + arr[min_index]);
                        arrayValueParent.GetChild<Sprite>(min_index).Modulate = comparingColor;
                    }
                    
                }
    
                // Swap the found minimum element with the first
                // element
                // GD.Print(arr[min_index] + " Swapping " + arr[i]);

                arrayValueParent.GetChild<Sprite>(min_index).Modulate = swappingColor;
                arrayValueParent.GetChild<Sprite>(i).Modulate = swappingColor;

                Task.Delay(MainScene.sortingSpeed).Wait();

                Vector2 tempGLobalScale = arrayValueParent.GetChild<Sprite>(min_index).GetChild<Sprite>(0).GlobalScale;
                arrayValueParent.GetChild<Sprite>(min_index).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).GlobalScale;
                arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;

                Task.Delay(MainScene.sortingSpeed).Wait();
                arrayValueParent.GetChild<Sprite>(min_index).Modulate = defaulColor;
                arrayValueParent.GetChild<Sprite>(i).Modulate = defaulColor;

                int temp = arr[min_index];
                arr[min_index] = arr[i];
                arr[i] = temp;

                Task.Delay(MainScene.sortingSpeed).Wait();

                // GD.Print("Sorted: " + arr[i]);
                arrayValueParent.GetChild<Sprite>(i).Modulate = sortedColor;

                // Sorting Finish
                if(i == n - 2)
                {
                    arrayValueParent.GetChild<Sprite>(n - 1).Modulate = sortedColor;
                    // For Debugging
                    ArrayValueGenerator.PrintArrayValueSorted("Selection Sort"); 

                    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                    MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);
                }
            }
	
        });
        
    }
}
