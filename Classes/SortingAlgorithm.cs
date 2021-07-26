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

    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i) 
        {
            int key = arr[i];
            int j = i - 1;
 
            // Move elements of arr[0..i-1],
            // that are greater than key,
            // to one position ahead of
            // their current position
            while (j >= 0 && arr[j] > key) {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;

            // Sorting Finish
            if(i == n - 1)
            {
                // For Debugging
                ArrayValueGenerator.PrintArrayValueSorted("Insertion Sort");

                // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                MainScene.ProcessingSorting("Sorted", true, Control.CursorShape.Forbidden);

            }
        }
    }
    // public static async Task InsertionSort(int[] arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor, Color swappingColor){
    //     await Task.Run(()=>{
    //         int n = arr.Length;
    //         for (int i = 1; i < n; i++)
    //         {
    //             int key = arr[i];
    //             Vector2 keyScale = arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Scale;
    //             int j = i - 1;
                
    //             // Set First Sorted Color
    //             if(j == 0)
    //             {
    //                 arrayValueParent.GetChild<Sprite>(j).Modulate = sortedColor;
    //             }
                
    //             // GD.Print("Sorted: " + arr[j]);

    //             // Task.Delay(MainScene.sortingSpeed).Wait();
                
    //             // GD.Print(arr[j] + " Comparing " + key);

    //             // Set the Comparing Color
    //             // arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = comparingColor;
    //             // arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = comparingColor;

    //             // Task.Delay(MainScene.sortingSpeed).Wait();
    //             //  GD.Print(i);
    //             while (j >= 0 && arr[j] >= key) {
                   
    //                 // GD.Print(arr[j] + " Swaped " + arr[j + 1]);
    //                 arr[j + 1] = arr[j];
    //                 arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Scale = new Vector2(arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Scale.x, arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Scale.y);
    //                 j = j - 1;
                    
    //                 // Set the Swapping Color
    //                 // arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = swappingColor;
    //                 // arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = swappingColor;

    //                 // Task.Delay(MainScene.sortingSpeed).Wait();

    //                 // // Set the Global Position
    //                 // Vector2 tempGlobalPosition = arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition;

    //                 // arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition = arrayValueParent.GetChild<Sprite>(j + 2).GlobalPosition;
    //                 // arrayValueParent.GetChild<Sprite>(j + 2).GlobalPosition = tempGlobalPosition;

                    
                    

    //                 // Task.Delay(MainScene.sortingSpeed).Wait();

    //                 // Set the Default Color
    //                 // arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = defaulColor;
                    
    //                 // Change the Index Position in Parent
    //                 // arrayValueParent.MoveChild(arrayValueParent.GetChild(j + 2), j + 1);

    //                 // Set the Sorted Color
                    
    //                 // arrayValueParent.GetChild<Sprite>(j + 2).GetChild<Sprite>(0).Modulate = sortedColor;

                    
    //             }

    //             // Current Sorted Color
    //             if(arrayValueParent.GetChild<Sprite>(j + 1).Name.ToInt() == arr[j + 1]){
    //                 arrayValueParent.GetChild<Sprite>(j + 1).Modulate = sortedColor;
    //             }

    //             arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Scale = new Vector2(keyScale.x, keyScale.y);
    //             arr[j + 1] = key;
                
    //             // Sorting Finish
    //             if(i == n - 1){
    //                 GD.Print("End loop");
    //                 // For Debugging
    //                 ArrayValueGenerator.PrintArrayValueSorted("Insertion Sort: ");

    //                 // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
    //                         // MainScene.ProcessingSorting("Sorted", true);

    //             }
    //         }
    //     }
    //     );
        
    // }
}
