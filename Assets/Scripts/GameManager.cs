using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //to access other script but only this class can arrnage it  read only 
    public static GameManager instance { get; private set; }

    [Tooltip("The associated text component.")] [SerializeField]
      private TextMeshProUGUI scoreTextUI;

    [SerializeField] private TextMeshProUGUI highscoreText;

    //start the game
    public static GameState State { get; private set; } = GameState.Welcome;

    //create  a new instance from Scores 
    private Score scoreData = new Score();

    //kopja tal scorData read only 
    public Score Data
    {
        get => scoreData;
    }

    [Header("Screens")]
    [SerializeField] private GameObject welUI;
    [SerializeField] private GameObject instUI;
    [SerializeField] private GameObject gameplayUI;
    [SerializeField] private GameObject govplayUI;
    private void Awake()
    {
        if (instance == null) //so that the game mangers if there is more than 1 they dont fight 
        {
            //here we show that as the game loads this is the instacne of this manager
            instance = this;
        }

        scoreData = SaveSData.Load();
        AddScore(0);
    }
    
    private void Start()
    {
        //show welcome screen
        ChangeStateofGame(GameState.Welcome);
    }

    private void OnDestroy()
   {
      
        SaveSData.Save(scoreData);
       
   }
    
    public void AddScore(int points = 1)
    {
        //change by 1
        scoreData.score += points;
        
        //play Sound
        //EventManager.Instance.PlaySfx("");


        //highscore
        if (scoreData.score > scoreData.highScore)
        {
            //change to the amount of the score
            scoreData.highScore = scoreData.score;
        }

        //update the text 
        scoreTextUI.text = scoreData.score.ToString();
        highscoreText.text = scoreData.highScore.ToString();
        
    }

    public void UpdatePlayerPosition(Vector3 pos)
    {
        scoreData.playerPosition = pos;
    }

    //healthbar

    public void UpdateHealth(int Health)
    {
        scoreData.currentHealth = Health;
   
        
        if (scoreData.currentHealth == 0)
        {
           ChangeStateofGame(GameState.EndGame);
           //play sound effect
           //EventManager.Instance.PlaySfx("");
           //stop music
           //EventManager.Instance.musicSource.Stop();
           
        }

    }

    
    public void ChangeStateofGame(GameState newState)
    {
        welUI?.SetActive(newState == GameState.Welcome);
        instUI?.SetActive(newState == GameState.Instuctions);
        gameplayUI?.SetActive(newState == GameState.Playing);
        govplayUI?.SetActive(newState == GameState.EndGame);
            
        
        State = newState;
      //  Debug.Log(State);
    }

    public void ChangeStatetoPlaying()
    {
        ChangeStateofGame(GameState.Playing);
    }
    public void ChangeStatetoWelcome()
    {
        ChangeStateofGame(GameState.Welcome);
    }
    public void ChangeStatetoInstructions()
    {
        ChangeStateofGame(GameState.Instuctions);
    }
    
    public void ChangeStatetoEnd()
    {

        
        ChangeStateofGame(GameState.EndGame);
       
        
    }

   
}