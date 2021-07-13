using Godot;
using System;

public class ArrayValueGenerator
{
    public int[] value;
    // Return a Set of Random Integer Value in Array
    public int[] RandomArrayValue(int arraySize, int from, int to){
        value = new int[arraySize];

        int randomValue;
        Random rn = new Random();

        for(int i = 0; i < value.Length; i++){
            randomValue = rn.Next(from, to);
            value[i] = randomValue;
        }

        return value;

    }

    // For Debugging
    public void PrintArrayValue(){
        GD.Print("Array: " + string.Join(",", value));
    }

    public int GetLength(){
        return value.Length;
    }

}
