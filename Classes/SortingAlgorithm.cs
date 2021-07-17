using Godot;
using System;
using System.Threading.Tasks;

public class SortingAlgorithm
{

    public static async Task BubbleSort(int []arr, int arraySize, int sortingSpeed, Node arrayValueParent, Color defaulColor,Color sortedColor, Color comparingColor, Color swappingColor){
        await Task.Run(()=>{
            int f = 0;

            int n = arr.Length;
            for (int i = 0; i < n - 1; i++){
                for (int j = 0; j < n - i - 1; j++){

                    // Comparing Color
                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = comparingColor;
                    arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = comparingColor;

                    // GD.Print(arr[j] + " Comparing " + arr[j + 1]);
                    Task.Delay(sortingSpeed).Wait();

                    if (arr[j] > arr[j + 1]){
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        // Swapping Color
                        arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = swappingColor;
                        arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = swappingColor;

                        Task.Delay(sortingSpeed).Wait();

                        Vector2 tempGlobalPosition = arrayValueParent.GetChild<Sprite>(j).GlobalPosition;
                        arrayValueParent.GetChild<Sprite>(j).GlobalPosition = arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition;
                        arrayValueParent.GetChild<Sprite>(j + 1).GlobalPosition = tempGlobalPosition;

                        arrayValueParent.MoveChild(arrayValueParent.GetChild(j + 1), j);


                        // Set Scale
                        // arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Scale = new Vector2(arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Scale.x, -arr[j] * 4);
                        // arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Scale= new Vector2(arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Scale.x, -temp * 4);

                        // GD.Print(temp + " Swapping " + arr[j]);
                    }

                    arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = defaulColor;

                    if(j == n - i - 2){
                        // GD.Print("Success Sorted: " + arr[j + 1]);
                        arrayValueParent.GetChild<Sprite>(j + 1).GetChild<Sprite>(0).Modulate = sortedColor;
                        f++;

                        if(f == arraySize - 1){
                            // GD.Print("Success Sorted: " + arr[j]);
                            arrayValueParent.GetChild<Sprite>(j).GetChild<Sprite>(0).Modulate = sortedColor;

                        }

                    }
                }

            }
        }
        );
            
    }
}
