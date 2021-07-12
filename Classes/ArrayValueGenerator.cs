using Godot;
using System;

public class ArrayValueGenerator
{
    public static int[] value;
    // Return a Set of Random Integer Value in Array
    public static int[] RandomArrayValue(int arraySize, int from, int to){
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
    public static void PrintArrayValue(){
        GD.Print(string.Join(",", value));
    }

    public static int GetLength(){
        return value.Length;
    }

}
