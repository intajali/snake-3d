using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private Material _material;
    private int foodPoint;
    private int foodType;

    public int FoodPoint { get => foodPoint; }
    public int FoodType { get => foodType; }

    private void Awake()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }


    public void SetFoodProperty()
    {
       Color colorValue;
       FoodItem foodItem = GameAssets.instance.GetRandomFood();
        foodPoint = foodItem.points;
        foodType = foodItem.type;
        if(ColorUtility.TryParseHtmlString(foodItem.color , out colorValue)){
            _material.color = colorValue;
        }
       
    }

}
