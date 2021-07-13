using Godot;
using System;

public class ArrayValueGenerator
{
    public static int[] value;
    Global global = new Global();

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
        GD.Print("Array: " + string.Join(",", GetArrayValues()));
    }

    public static int[] GetArrayValues(){
        return value;
    }

    // public void DisplayArray(){
    //     foreach(var arr in GetArrayValues()){
    //         ArrayValue.selfValue = arr;
    //     }
    // }

    public int GetLength(){
        return value.Length;
    }

}
