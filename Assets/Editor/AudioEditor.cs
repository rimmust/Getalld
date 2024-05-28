using System;
using System.Collections.Generic;
using System.Linq;
using Getalld.Data;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class AudioEditor : EditorWindow
    {
        private const string UssFileName = "AudioEditorUSS";

        private const string FilePrefix = "ITEM_";

        //declare the list 
        private List<AudioClip> SoundClips = new List<AudioClip>();

        //the assets file to modify 
        private SoundSettings _settings;

        //buttonr property
        private Button clickedButton;
        //obejct click
        private ObjectField linkedSound;

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
            var stylesheet = AssetDatabase.LoadAssetAtPath<StyleSheet>($"Assets/Editor/{UssFileName}.uss");
            rootVisualElement.styleSheets.Add(stylesheet);
            var leftContainer = CreateList();
            rootVisualElement.Add(leftContainer);

            var rightContainer = new VisualElement { name = "Sound-List" };
            rootVisualElement.Add(rightContainer);
            

            // Assets/Objects/MusicCollection.asset
            //find the setting file!
            _settings = AssetDatabase.LoadAssetAtPath<SoundSettings>("Assets/Objects/MusicCollection.asset");

            var background1 = CreateButton("background-1", "backgroundMusic1");
            rightContainer.Add(background1);


             var background2 = CreateButton("background-2","backgroundMusic2");
            rightContainer.Add(background2);
            
             var collectDiamond = CreateButton("collectDiamond","collectDiamond");
            rightContainer.Add(collectDiamond);
            
             var collision = CreateButton("collision","collision");
             rightContainer.Add(collision);
            
             var gameover = CreateButton("gameover","gameover");
             rightContainer.Add(gameover);
            
             var reducehalth = CreateButton("reducehalth","reducehalth");
             rightContainer.Add(reducehalth);
            
             var jump = CreateButton("jump","jump");
             rightContainer.Add(jump);
            
             var obstacle = CreateButton("obstacle","obstacle");
             rightContainer.Add(obstacle);
            
             var water = CreateButton("water","water");
            rightContainer.Add(water);
        }

        /// <summary>
        /// Will create the lsit that we eill use on the left side
        /// </summary>
        /// <returns></returns>
        private VisualElement CreateList()
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
            var middleContainer = new VisualElement { name = "AudioList" };

            //declare the list
            Func<VisualElement> makeItem = () => new Label();
            const int itemHeight = 20;

            Action<VisualElement, int> bindItem = (element, i) =>
                (element as Label).text = "Audio " + SoundClips[i].name;

            //the soundclcips
            var ListView = new ListView(SoundClips, itemHeight, makeItem, bindItem);

            ListView.selectionChanged += element =>
            {
                selectedSound = element.First() as AudioClip;
                //check that we ahve clicked on button
                if (clickedButton != null)
                {
                    //if we are changing a sound we cannot play it
                    linkedSound.value = selectedSound;
                    clickedButton.text = $"{clickedButton.name}: {selectedSound.name}";
                    clickedButton = null;
                    linkedSound = null;
                    return;
                }
                
                //selected ux vojt
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


            middleContainer.Add(topContainer);
            middleContainer.Add(ListView);

            //to see the contianre
            return middleContainer;



        }

        /// <summary>
        /// Thso function willcreate the butona dnw euse it insetad of creaeting button
        /// mnaullay
        /// </summary>
        /// <param name="buttonName"></param>
        /// <returns></returns>
        private VisualElement CreateButton(string buttonName, string propertyName)
        {
            var element = new VisualElement();
            
            var button = new Button
            {
                name = buttonName,
                text = buttonName
            };

            var ClipField = new ObjectField
            {
                objectType = typeof(AudioClip),
                allowSceneObjects = false,
                visible = false
            };
            
            var settings = new SerializedObject(_settings);
            ClipField.BindProperty(settings.FindProperty(propertyName));

            button.clicked += () =>
            {
                if (clickedButton == null)
                {
                    button.text = "Please choose the sound";
                    //tell window which button is clicked
                    clickedButton = button;
                    linkedSound = ClipField;
                }
             

                //the button needs to know whihc file sound we choose

            };
            
            element.Add(button);
            element.Add(ClipField);
            
            return element;
            
        }

        public static void PlayClip(AudioClip clip)
        {
            var go = new GameObject("TEMP_AUDIO");
            var audioSource = go.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip);

        }

        

    }
}