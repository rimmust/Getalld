using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class AudioEditor : EditorWindow
    {
        private const string UssFileName = "ItemEditorUSS";
        private const string FilePrefix = "ITEM_";
        //declare the list 
        private List<AudioClip> SoundClips = new List<AudioClip>();

        //declare the var
        private AudioClip selectedSound;

        [MenuItem("Game/Audio")]
        private static void ShowWindow()
        {
            var window = GetWindow<AudioEditor>();
            window.titleContent = new GUIContent("TITLE");
            window.Show();
        }

        private void OnEnable()
        {
            // load all audio
            SoundClips = new(Resources.LoadAll<AudioClip>("Sound"));
        }

        private void CreateGUI()
        {
            //top continer
            var topContainer = new VisualElement();
            //label
            var title = new Label { text = "Audio Manager" };
            //button
            var playButton = new Button { text = "Play" };
            playButton.clicked += () => PlayClip(selectedSound);
            
            var soundPlaying = new Label { text = "Mp3" };
            
            
            //add elements in the container
            topContainer.Add(title);
            topContainer.Add(playButton);
            topContainer.Add(soundPlaying);

            
            
            //middle continer
            var middleContainer = new VisualElement();
            
            //declare the list
            Func<VisualElement> makeItem = () => new Label();
            const int itemHeight = 20;

            Action<VisualElement, int> bindItem = (element, i) => (element as Label).text = "Audio " + SoundClips[i].name;
            
            //the soundclcips
            var ListView = new ListView(SoundClips, itemHeight, makeItem,bindItem);

            ListView.selectionChanged += element =>
            {
                selectedSound = element.First() as AudioClip;
                if (selectedSound != null)
                {
                    //change to play sound
                    playButton.text = $"play {selectedSound.name}";
                }
                else
                {

                    playButton.text = $"play";
                }
            };
            

            middleContainer.Add(ListView);
            
            // var Sound1 = new Button { text = "Sound1" };
            // var Sound2 = new Button { text = "Sound2" };
            // var Sound3 = new Button { text = "Sound3" };
            // var Sound4 = new Button { text = "Sound4" };
            // var Sound5 = new Button { text = "Sound5" };
            // var Sound6 = new Button { text = "Sound6" };
            //
            //
            // //add elements in the container
            // middleContainer.Add(Sound1);
            // middleContainer.Add(Sound2);
            // middleContainer.Add(Sound3);
            // middleContainer.Add(Sound4);
            // middleContainer.Add(Sound5);
            // middleContainer.Add(Sound6);
            
            //to see the contianre
            rootVisualElement.Add(topContainer);
            rootVisualElement.Add(middleContainer);
            
            
            
        }

        public static void PlayClip(AudioClip clip)
        {
            var go = new GameObject("TEMP_AUDIO");
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip);
            
        }

    }
}