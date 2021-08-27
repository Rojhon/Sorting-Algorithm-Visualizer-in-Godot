using Godot;
using System;

public class Control : Godot.Control
{
    public Button generateNewArray;
    public Button sortButton;

    public override void _Ready()
    {
        generateNewArray = GetNode<Button>("GenerateNewArray");
        generateNewArray.FocusMode = Control.FocusModeEnum.None;

        sortButton = GetNode<Button>("Sort");
        sortButton.FocusMode = Control.FocusModeEnum.None;

    }

}
