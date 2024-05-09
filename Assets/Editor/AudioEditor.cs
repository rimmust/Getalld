using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class AudioEditor : EditorWindow
    {
        private const string UssFileName = "ItemEditorUSS";
        private const string FilePrefix = "ITEM_";

        [MenuItem("Game/Audio")]
        private static void ShowWindow()
        {
            var window = GetWindow<AudioEditor>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }
        
        private void CreateGUI()
        {
            //top continer
            var topContainer = new VisualElement();
            //label
            var title = new Label { text = "Audio Manager" };
            //button
            var playButton = new Button { text = "Play" };
            
            var soundPlaying = new Label { text = "Mp3" };
            
            
            //add elements in the container
            topContainer.Add(title);
            topContainer.Add(playButton);
            topContainer.Add(soundPlaying);

            //to see the contianre
            rootVisualElement.Add(topContainer);
            
            //middle continer
            var middleContainer = new VisualElement();
            
            //declare the list
            const int itemCount = 7;
            var items = new List<string>(itemCount);
            
            var Sound1 = new Button { text = "Sound1" };
            var Sound2 = new Button { text = "Sound2" };
            var Sound3 = new Button { text = "Sound3" };
            var Sound4 = new Button { text = "Sound4" };
            var Sound5 = new Button { text = "Sound5" };
            var Sound6 = new Button { text = "Sound6" };
            
            
            //add elements in the container
            middleContainer.Add(Sound1);
            middleContainer.Add(Sound2);
            middleContainer.Add(Sound3);
            middleContainer.Add(Sound4);
            middleContainer.Add(Sound5);
            middleContainer.Add(Sound6);
            
            //to see the contianre
            rootVisualElement.Add(middleContainer);
            
            
            
        }
        
        

    }
}