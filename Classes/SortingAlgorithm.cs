using Godot;
using System;
using System.Threading.Tasks;

public class SortingAlgorithm
{
    // Bubble Sort
    public static async Task BubbleSort(int []arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor, Color swappingColor){
        await Task.Run(()=>{
            int n = arr.Length; // Array Length

            for (int i = 0; i < n - 1; i++){
                for (int j = 0; j < n - i - 1; j++){

                    // Set the Comparing Color
                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = comparingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = comparingColor;

                    // GD.Print(arr[j] + " Comparing " + arr[j + 1]);
                    Task.Delay(MainScene.sortingSpeed).Wait();

                    if (arr[j] > arr[j + 1]){
                        // Swapping the array value
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // Set the Swapping Color
                        arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = swappingColor;
                        arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = swappingColor;

                        Task.Delay(MainScene.sortingSpeed).Wait();

                        // Set the Global Position
                        Vector2 tempGlobalPosition = arrayValueParent.GetChild<Sprite>(j).GlobalPosition;
                        arrayValueParent.GetChild<Sprite>(j).GlobalPosition = arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition;
                        arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition = tempGlobalPosition;
                        
                        // Change the Index Position in Parent
                        arrayValueParent.MoveChild(arrayValueParent.GetChild(j + 1), j);

                        // GD.Print(temp + " Swapping " + arr[j]);
                    }

                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the Default Color
                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = defaulColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = defaulColor;

                    // Task.Delay(MainScene.sortingSpeed).Wait();

                    if(j == n - i - 2){
                        // GD.Print("Success Sorted: " + arr[j + 1]);

                        // Set the Sorted Color
                        arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = sortedColor;

                    }

                    if(i == n - 2){
                            // GD.Print("Success Sorted: " + arr[j]);

                            // Set the Sorted Color
                            arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = sortedColor;

                            // For Debugging
                            ArrayValueGenerator.PrintArrayValueSorted("Bubble Sort: "); 

                            // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                            MainScene.ProcessingSorting("Sorted", true);
                        }
                }

            }
        }
        );
            
    }

    // Insertion Sort
    public static async Task InsertionSort(int[] arr, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor, Color swappingColor){
        await Task.Run(()=>{
            int n = arr.Length;
            for (int i = 1; i < n; ++i) {
                int key = arr[i];
                int j = i - 1;
                
                // Set the Sorted Color
                arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = sortedColor;
                GD.Print("Sorted: " + arr[j]);

                Task.Delay(MainScene.sortingSpeed).Wait();
                
                // GD.Print(arr[j] + " Comparing " + key);

                // Set the Comparing Color
                arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = comparingColor;
                arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = comparingColor;

                Task.Delay(MainScene.sortingSpeed).Wait();

                while (j >= 0 && arr[j] > key) {
                    arr[j + 1] = arr[j];
                    j = j - 1;

                    // Set the Swapping Color
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = swappingColor;
                    arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = swappingColor;

                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the Global Position
                    Vector2 tempGlobalPosition = arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition;
                    // GD.Print(arr[j + 1] + " Swapping " + arr[j + 2]);

                    arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition = arrayValueParent.GetChild<Sprite>(j + 2).GlobalPosition;
                    arrayValueParent.GetChild<Sprite>(j + 2).GlobalPosition = tempGlobalPosition;

                    Task.Delay(MainScene.sortingSpeed).Wait();

                    // Set the Sorted Color
                    arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = sortedColor;

                    // Change the Index Position in Parent
                    arrayValueParent.MoveChild(arrayValueParent.GetChild(j + 2), j + 1);

                    // Set the Sorted Color
                    
                    arrayValueParent.GetChild<Sprite>(j + 2).GetChild<Sprite>(0).Modulate = sortedColor;

                    
                }
                arrayValueParent.GetChild<Sprite>(i).GetChild<Sprite>(0).Modulate = sortedColor;
                arr[j + 1] = key;

                if(i == n - 1){
                    // For Debugging
                    ArrayValueGenerator.PrintArrayValueSorted("Insertion Sort: ");

                    // Run when Array Sorting is Processing - Set the text of sortButton, Disable the sortButton, sortingAlgoOption
                            MainScene.ProcessingSorting("Sorted", true);

                }
            }
        }
        );
        
    }
}
