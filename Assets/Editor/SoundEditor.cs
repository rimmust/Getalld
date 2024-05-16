using Getalld.Data;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(SoundSettings))]
public class SoundSettingsEditor : UnityEditor.Editor
{
    public override VisualElement CreateInspectorGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = new VisualElement();

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);

        // Background 1
        var background1 = CreateField("background1", "backgroundMusic1");
        var background2 = CreateField("background2", "backgroundMusic2");
        var diamondsound = CreateField("diamondsound", "collectDiamond");
        var collsions = CreateField("collsions", "collsion");
        var gameovers = CreateField("gameovers", "gameover");
        var reduceh = CreateField("reduceh", "reducehealth");
        var jumps = CreateField("jumps", "jump");
        var obstacles = CreateField("obstcales", "obstacle");
        var watersound = CreateField("watersound", "water");
        
        
        root.Add(background1);
        root.Add(background2);
        root.Add(diamondsound);
        root.Add(collsions);
        root.Add(gameovers);
        root.Add(reduceh);
        root.Add(jumps);
        root.Add(obstacles);
        root.Add(watersound);

        return root;
    }

    public ObjectField CreateField(string label, string bindingPath)
    {
        var field = new ObjectField { label = label };
        field.objectType = typeof(AudioClip);
        field.bindingPath = bindingPath;
            
        return field;
    }
}
