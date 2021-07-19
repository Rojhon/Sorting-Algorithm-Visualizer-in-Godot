using Godot;
using System;

public class Control : Godot.Control
{
    public Button generateNewArray;
    public Button sortButton;
    public CheckBox pauseSystem;

    public override void _Ready()
    {
        generateNewArray = GetNode<Button>("GenerateNewArray");
        generateNewArray.FocusMode = Control.FocusModeEnum.None;

        sortButton = GetNode<Button>("Sort");
        sortButton.FocusMode = Control.FocusModeEnum.None;
        pauseSystem = GetNode<CheckBox>("PauseSystem");
        
    }

    public void _on_ArraySizeOption_item_selected(int index){
        if(GetTree().Paused == true){
            GetTree().Paused = false;
            pauseSystem.Pressed = false;

            GD.Print("Option: Generate new Array While Pause");

        }

    }

    public void _on_GenerateNewArray_pressed(){
        if(GetTree().Paused == true){
            GetTree().Paused = false;
            pauseSystem.Pressed = false;

            GD.Print("Button: Generate new Array While Pause");

        }
        
    }

    public void _on_Sort_mouse_entered(){
        if(GetTree().Paused == true){
            sortButton.MouseDefaultCursorShape = Control.CursorShape.Forbidden;
            GD.Print("Control Script: Mouse Cursor Forbidden");
            
        }
        if(GetTree().Paused == false && sortButton.Disabled == false){
            sortButton.MouseDefaultCursorShape = Control.CursorShape.PointingHand;
            GD.Print("Control Script: Mouse Cursor Pointing Hand");
            
        }
    }

}
