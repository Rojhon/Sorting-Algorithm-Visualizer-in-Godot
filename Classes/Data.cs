using Godot;
using System;

public class Data
{
    public static int[] data = {0, 0, 0};
    
    public static Godot.Collections.Dictionary<string, int[]> Save()
    {
        return new Godot.Collections.Dictionary<string, int[]>()
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

        var currentLine = new Godot.Collections.Dictionary<string, int[]>((Godot.Collections.Dictionary)JSON.Parse(saveGame.GetLine()).Result);

        data = currentLine["data"];
        saveGame.Close();
    }

    
}
