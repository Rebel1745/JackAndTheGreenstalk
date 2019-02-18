using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public enum PLANT_STATE { SEEDLING, VEGITATIVE, FLOWERING, HARVESTABLE, PROBLEMATIC, DEAD };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Stats
    int ageInDays;

    public bool IsAutoflower;

    public float MinFloweringTime;
    public float MaxFloweringTime;
    float floweringTime;

    public float MinHeight;
    public float MaxHeight;
    float maxHeight;
    float currentHeight;

    public float MinGrowRate;
    public float MaxGrowRate;
    float maxGrowRate;
    //float currentGrowRate;

    public float MinYeild;
    public float MaxYeild;
    float maxYeild;

    // public Color[] PlantColours; //colours of different bits of the plant

    public float MinTHC;
    public float MaxTHC;
    float THCContent;

    public float MinCBD;
    public float MaxCBD;
    float CBDContent;

    public float MinpH;
    public float MaxpH;
    float pHLevel;

    public float MinTemp;
    public float MaxTemp;
    float idealTemp;

    public float MinHumidity;
    public float MaxHumidity;
    float idealHumidity;

    public float MinLight;
    public float MaxLight;

    public PLANT_STATE PlantState;
    // hardiness

    // Needs
    public float MinWaterConsumption;
    public float MaxWaterConsumption;
    float waterConsumption;

    public float MinNitrogenConsumption;
    public float MaxNitrogenConsumption;
    float nitrogenConsumption;

    public float MinPhosphorousConsumption;
    public float MaxPhosphorousConsumption;
    float phosphorousConstumption;

    public float MinPotassiumConsumption;
    public float MaxPotassiumConsumption;
    float potassiumConsumption;

    public void PlantSeed()
    {
        PlantState = PLANT_STATE.SEEDLING;

        maxHeight = Random.Range(MinHeight, MaxHeight);
        maxGrowRate = Random.Range(MinGrowRate, MaxGrowRate);
        floweringTime = Random.Range(MinFloweringTime, MaxFloweringTime);
        maxYeild = Random.Range(MinYeild, MaxYeild);
        THCContent = Random.Range(MinTHC, MaxTHC);
        CBDContent = Random.Range(MinCBD, MaxCBD);
        pHLevel = Random.Range(MinpH, MaxpH);
        idealTemp = Random.Range(MinTemp, MaxTemp);
        idealHumidity = Random.Range(MinHumidity, MaxHumidity);

        waterConsumption = Random.Range(MinWaterConsumption, MaxWaterConsumption);
        nitrogenConsumption = Random.Range(MinNitrogenConsumption, MaxNitrogenConsumption);
        phosphorousConstumption = Random.Range(MinPhosphorousConsumption, MaxPhosphorousConsumption);
        potassiumConsumption = Random.Range(MinPotassiumConsumption, MaxPotassiumConsumption);
    }

    // move the game along and calculate the new state of the plant
    public void AdvanceDay()
    {
        ageInDays++;

        currentHeight += currentGrowRate;
    }
}
