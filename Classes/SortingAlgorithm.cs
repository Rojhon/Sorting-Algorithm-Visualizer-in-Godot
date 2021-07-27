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
                        arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale = new Vector2(arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale.x, arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale.y);
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
                    // Set the Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = swappingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = swappingColor;

                    Task.Delay(MainScene.sortingSpeed).Wait();
                    
                    // Set the default Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;

                    // Set the scale
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale;
                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;

                    // Set Sorted Color
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
            for (int i = 1; i < n; i++) 
            {
                int key = arr[i];
                int j = i - 1;

                arrayValueParent.GetChild<Sprite>(j).Modulate = comparingColor;
                arrayValueParent.GetChild<Sprite>(j + 1).Modulate = comparingColor;

                Vector2 tempGLobalScale = arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).GlobalScale;

                Task.Delay(MainScene.sortingSpeed).Wait();

                if(arr[j] < key)
                {
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;
                }

                while (j >= 0 && arr[j] > key)
                {
                    // Set the Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = comparingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = comparingColor;

                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = swappingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = swappingColor;

                    Task.Delay(MainScene.sortingSpeed).Wait();
                    
                    // Set the default Color
                    arrayValueParent.GetChild<Sprite>(j).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;

                    // Set the scale
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).GlobalScale = arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale;
                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).GlobalScale = tempGLobalScale;
                    
                    arr[j + 1] = arr[j];
                    j = j - 1;

                    // Task.Delay(MainScene.sortingSpeed).Wait();
                }
            
                arrayValueParent.GetChild<Sprite>(j + 1).Modulate = defaulColor;
                
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
                    ArrayValueGenerator.PrintArrayValueSorted("Gnome Sort");

                    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                    MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);

                }
            }
        });
    }
   
}
