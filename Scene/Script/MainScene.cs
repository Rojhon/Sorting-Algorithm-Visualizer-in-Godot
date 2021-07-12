using Godot;
using System;
using System.Linq;

public class MainScene : Node2D
{
    public HSlider arraySizeSlider;
    public override void _Ready()
    {
        arraySizeSlider = this.GetNode<HSlider>("Control/ArraySizeSlider");
        // GD.Print(string.Join(",", RandomArrayValue((int)arraySizeSlider.MinValue)));

        InitArray((int)arraySizeSlider.Value);

    }

// Return a Set of Random Integer Value in Array
    public int[] RandomArrayValue(int arraySize){
        int[] value = new int[arraySize];
        int[] newValue = new int[arraySize];

        int randomValue;
        Random rn = new Random();

        for(int i = 0; i < value.Length; i++){
            randomValue = rn.Next((int)arraySizeSlider.MinValue, (int)arraySizeSlider.MaxValue + 1);
            value[i] = randomValue;
            newValue = value.Distinct().ToArray();

        }

        return newValue;

    }

    private void InitArray(int arraySize){
        int[] arr = new int[arraySize];
        Random rnd = new Random();
        int temp;

        for(int i = 0; i < arr.Length; i++){
            temp = rnd.Next(arraySize + 1);
            while(IsDup(temp, arr)){
                temp = rnd.Next(arraySize + 1);

            }
            arr[i] = temp;
        }

        PrintArr(arr);
       
    }

    public void PrintArr(int[] arr){
         GD.Print(string.Join(", ", arr));

    }

    public bool IsDup(int temp, int[] arr){
        foreach(var item in arr){
            if(item == temp){
                return true;
            }
        }

        return false;
    }

    public void _on_ArraySizeSlider_value_changed(int value){
        // GD.Print(string.Join(",", RandomArrayValue(value)));
        InitArray((int)arraySizeSlider.Value);

    }

// Return a Set of Random Integer Value in Array when Pressed
    public void _on_GenerateNewArray_pressed(){
        // GD.Print(string.Join(",", RandomArrayValue((int)arraySizeSlider.Value)));
        InitArray((int)arraySizeSlider.Value);
    }

}
