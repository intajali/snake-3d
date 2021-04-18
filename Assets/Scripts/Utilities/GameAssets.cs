using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class FoodItem
{
    public int type { get; set; }
    public int points { get; set; }
    public string color { get; set; }
}

public class FoodList
{
    public List<FoodItem> Foods { get; set; }
}

/// <summary>
/// Reading All game assets 
/// </summary>
public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    private FoodList foodList;

    void Awake()
    {
        if (instance == null)
            instance = this;


        // Load Foods.json from Resources.

        TextAsset textAsset = Resources.Load<TextAsset>("Foods");

        foodList = JsonConvert.DeserializeObject<FoodList>(textAsset.ToString());  // Deserialize json sting to object.
    }


    public FoodItem GetRandomFood()
    {
        return foodList.Foods[Random.Range(0, foodList.Foods.Count)];
    }

    
}
