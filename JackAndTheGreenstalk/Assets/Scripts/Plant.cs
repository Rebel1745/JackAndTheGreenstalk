using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    public enum PLANT_STATE { SEEDLING, VEGITATIVE, FLOWERING, HARVESTABLE, PROBLEMATIC, DEAD };
    // Start is called before the first frame update
    void Start()
    {
        PlantSeed();
        DisplayStats();
    }

    List<GameObject> plantSegments = new List<GameObject>();
    public GameObject[] PlantSegmentPrefab;
    public GameObject RootPrefab;

    public List<GameObject> GrowthPoints = new List<GameObject>();

    // Stats
    int ageInDays;
    public Text AgeInDaysText;

    public bool IsAutoflower;

    public float MinFloweringDay;
    public float MaxFloweringDay;
    float floweringDay;
    public Text FloweringDayText;

    public float MinHeight;
    public float MaxHeight;
    float maxHeight;
    float currentHeight;
    public Text CurrentHeightText;

    public float MinGrowRate;
    public float MaxGrowRate;
    float maxGrowRate;
    public float CurrentGrowRate;
    public Text CurrentGrowRateText;

    public float MinYield;
    public float MaxYield;
    float maxYield;
    public Text MaxYieldText;

    // public Color[] PlantColours; //colours of different bits of the plant

    public float MinTHC;
    public float MaxTHC;
    float THCContent;
    public Text THCContentText;

    public float MinCBD;
    public float MaxCBD;
    float CBDContent;
    public Text CBDContentText;

    public float MinpH;
    public float MaxpH;
    float idealpHLevel;
    public Text IdealpHText;
    //float currentpHLevel;

    public float MinTemp;
    public float MaxTemp;
    float idealTemp;
    public Text IdealTempText;
    //float currentTemp;

    public float MinHumidity;
    public float MaxHumidity;
    float idealHumidity;
    public Text IdealHumidityText;
    //float currentHumidity;

    public float MinLight;
    public float MaxLight;
    //float currentLight;

    public PLANT_STATE PlantState;
    public Text PlantStateText;
    // hardiness

    // Needs
    public float MinWaterConsumption;
    public float MaxWaterConsumption;
    float waterConsumption;
    public Text WaterConsumptionText;
    float currentWaterLevel = 100f;
    public Text WaterLevelText;

    public float MinNitrogenConsumption;
    public float MaxNitrogenConsumption;
    float nitrogenConsumption;
    public Text NitrogenConsumptionText;
    float currentNitrogenLevel = 100f;
    public Text NitrogenLevelText;

    public float MinPhosphorusConsumption;
    public float MaxPhosphorusConsumption;
    float phosphorusConsumption;
    public Text PhosphorusConsumptionText;
    float currentPhosphorusLevel = 100f;
    public Text PhosphorusLevelText;

    public float MinPotassiumConsumption;
    public float MaxPotassiumConsumption;
    float potassiumConsumption;
    public Text PotassiumConsumptionText;
    float currentPotassiumLevel = 100f;
    public Text PotassiumLevelText;

    public void PlantSeed()
    {
        PlantState = PLANT_STATE.SEEDLING;

        maxHeight = Random.Range(MinHeight, MaxHeight);
        maxGrowRate = Random.Range(MinGrowRate, MaxGrowRate);
        floweringDay = Random.Range(MinFloweringDay, MaxFloweringDay);
        maxYield = Random.Range(MinYield, MaxYield);
        THCContent = Random.Range(MinTHC, MaxTHC);
        CBDContent = Random.Range(MinCBD, MaxCBD);
        idealpHLevel = Random.Range(MinpH, MaxpH);
        idealTemp = Random.Range(MinTemp, MaxTemp);
        idealHumidity = Random.Range(MinHumidity, MaxHumidity);

        waterConsumption = Random.Range(MinWaterConsumption, MaxWaterConsumption);
        nitrogenConsumption = Random.Range(MinNitrogenConsumption, MaxNitrogenConsumption);
        phosphorusConsumption = Random.Range(MinPhosphorusConsumption, MaxPhosphorusConsumption);
        potassiumConsumption = Random.Range(MinPotassiumConsumption, MaxPotassiumConsumption);

        CurrentGrowRate = maxGrowRate;

        GameObject go = Instantiate(RootPrefab, transform.position, transform.rotation, transform);
        GrowthPoints.Add(go);
        go.GetComponent<GrowthPoint>().parent = go.transform;
    }
    
    // move the game along and calculate the new state of the plant
    public void AdvanceDay()
    {
        ageInDays++;

        currentHeight += CurrentGrowRate;
        currentWaterLevel -= waterConsumption;
        currentNitrogenLevel -= nitrogenConsumption;
        currentPhosphorusLevel -= phosphorusConsumption;
        currentPotassiumLevel -= potassiumConsumption;


        //int randPlant = Random.Range(0, PlantSegmentPrefab.Length);

        //plantSegments.Add(PlantSegmentPrefab[randPlant]);

        //DisplayPlant();

        GrowPlant();
    }

    void GrowPlant()
    {
        foreach(GameObject g in GrowthPoints)
        {
            StartCoroutine(g.GetComponent<GrowthPoint>().Grow());
        }
    }

    void DisplayPlant()
    {
        GameObject prevGo = null;
        Vector3 spawnPos = transform.position;
        Quaternion spawnRot = transform.rotation;

        //remove current plant segments
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach(GameObject g in plantSegments)
        {
            if(prevGo != null)
            {
                spawnPos = prevGo.transform.Find("ConnectPoint").transform.position;
                spawnRot = prevGo.transform.Find("ConnectPoint").transform.rotation;
            }           

            prevGo = Instantiate(g.gameObject, spawnPos, spawnRot, this.transform); ;
        }
    }

    public void DisplayStats()
    {
        AgeInDaysText.text = ageInDays.ToString();
        FloweringDayText.text = RoundToDP(floweringDay, 0f).ToString();
        CurrentHeightText.text = RoundToDP(currentHeight, 2f).ToString();
        CurrentGrowRateText.text = RoundToDP(CurrentGrowRate, 2f).ToString();
        MaxYieldText.text = RoundToDP(maxYield, 0f).ToString();
        THCContentText.text = RoundToDP(THCContent, 1f).ToString();
        CBDContentText.text = RoundToDP(CBDContent, 1f).ToString();
        IdealpHText.text = RoundToDP(idealpHLevel, 2f).ToString();
        IdealTempText.text = RoundToDP(idealTemp, 1f).ToString();
        IdealHumidityText.text = RoundToDP(idealHumidity, 0f).ToString();
        PlantStateText.text = PlantState.ToString();
        WaterLevelText.text = RoundToDP(currentWaterLevel, 0f).ToString();
        WaterConsumptionText.text = RoundToDP(waterConsumption, 2f).ToString();
        NitrogenLevelText.text = RoundToDP(currentNitrogenLevel, 0f).ToString();
        NitrogenConsumptionText.text = RoundToDP(nitrogenConsumption, 2f).ToString();
        PhosphorusLevelText.text = RoundToDP(currentPhosphorusLevel, 0f).ToString();
        PhosphorusConsumptionText.text = RoundToDP(phosphorusConsumption, 2f).ToString();
        PotassiumLevelText.text = RoundToDP(currentPotassiumLevel, 0f).ToString();
        PotassiumConsumptionText.text = RoundToDP(potassiumConsumption, 2f).ToString();

    }

    float RoundToDP(float num, float dp)
    {

        float multiplier = Mathf.Pow(10, dp);

        return Mathf.Round(num * multiplier) / multiplier;
    }
}
