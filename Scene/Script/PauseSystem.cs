using Godot;
using System;

public class PauseSystem : CheckBox
{
    public void _on_PauseSystem_pressed(){
        if(this.Pressed == true){
            GetTree().Paused = true;
            GD.Print("Pause");

        }

        if(this.Pressed == false){
            GetTree().Paused = false;
            GD.Print("UnPause");
        }
        
    }


}
