using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public static GamePlayManager instance;

    [SerializeField] private GameOverPanelView gameOverPanelView;
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private Text scoreText;


    private float minX = -6f, maxX = 6f, minY = -2.5f, maxY = 2.5f;

    Food newFood;
    private int score = 0;
    int prevFoodType ;
    int multilier = 1;

    public delegate void OnGameOver();
    public static OnGameOver onGameOverUpdate;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    private void OnEnable()
    {
        onGameOverUpdate += OnGameOverUpdate;

    }

    private void OnDisable()
    {
        onGameOverUpdate -= OnGameOverUpdate;
    }

    private void Start()
    {
        score = 0;
        GenerateRandomFood();
    }

    public void GenerateRandomFood()
    {

        Vector3 foodPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY , maxY));
        newFood = Instantiate(foodPrefab, foodPos, Quaternion.identity).GetComponent<Food>();

        newFood.SetFoodProperty();
    }
    

    public void UpdateScore()
    {
      //  Debug.Log("P : "+prevFoodType + "  C :: "+ newFood.FoodType);
        if(prevFoodType == newFood.FoodType)
        {
            multilier++;
        }
        else
        {
            multilier = 1;
            prevFoodType = newFood.FoodType;
        }
        score += (newFood.FoodPoint * multilier);
        scoreText.text = "SCORE : " + score;

       
    }

    void OnGameOverUpdate()
    {
        multilier = 1;
        gameOverPanelView.Render(score);

    }
}
