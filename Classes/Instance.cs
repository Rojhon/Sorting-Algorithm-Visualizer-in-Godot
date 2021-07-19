using Godot;

public class Instance
{
    public static Sprite InstanceNode(PackedScene node, Vector2 location, Node parent){
        Sprite nodeInstance = node.Instance() as Sprite;
        parent.AddChild(nodeInstance);
        nodeInstance.GlobalPosition = location;
        return nodeInstance;
    }
}
