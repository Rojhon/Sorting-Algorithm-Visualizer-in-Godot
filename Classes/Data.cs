using Godot;
using System;

public class Data
{
    public static String sortingAlgorithm;
    public static int arraySize;
    public static float sortingSpeed;

    public static object[] data = {sortingAlgorithm, arraySize, sortingSpeed};
    
    public static Godot.Collections.Dictionary<string, object> Save()
    {
        return new Godot.Collections.Dictionary<string, object>()
        {
            {
                 "data", data
            }
        };
    }

    public static void SaveGame()
    {
        var saveGame = new File();
        saveGame.Open("user://savegame.save", File.ModeFlags.Write);
        saveGame.StoreLine(JSON.Print(Save()));
        saveGame.Close();
    }

    public static void LoadGame()
    {
        var saveGame = new File();
        if(!saveGame.FileExists("user://savegame.save"))
        {
            GD.Print("Error");
            return;
        }

        saveGame.Open("user://savegame.save", File.ModeFlags.Read);

        var currentLine = new Godot.Collections.Dictionary<string, object>((Godot.Collections.Dictionary)JSON.Parse(saveGame.GetLine()).Result);

        data[0] = currentLine["data"];
        saveGame.Close();
    }

    
}
