using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitialiseEnvironment();
        DisplayStats();
    }

    public bool IsOutdoors;

    public float MinTemperature;
    public float MaxTemperature;
    float temperature;
    public Text TemperatureText;

    public float MinHumidity;
    public float MaxHumidity;
    float humidity;
    public Text HumidityText;

    public float MinpH;
    public float MaxpH;
    float pHLevel;
    public Text pHLevelText;

    public float MinWaterContent;
    public float MaxWaterContent;
    float waterContent;
    public Text WaterContentText;

    public float MinWaterReplacementRate;
    public float MaxWaterReplacementRate;
    float waterReplacementRate;
    public Text WaterReplacementRateText;

    public float MinNitrogenContent;
    public float MaxNitrogenContent;
    float nitrogenContent;
    public Text NitrogenContentText;

    public float MinNitrogenReplacementRate;
    public float MaxNitrogenReplacementRate;
    float nitrogenReplacementRate;
    public Text NitrogenReplacementRateText;

    public float MinPhosphorusContent;
    public float MaxPhosphorusContent;
    float phosphorusContent;
    public Text PhosphorusContentText;

    public float MinPhosphorusReplacementRate;
    public float MaxPhosphorusReplacementRate;
    float phosphorusReplacementRate;
    public Text PhosphorusReplacementRateText;

    public float MinPotassiumContent;
    public float MaxPotassiumContent;
    float potassiumContent;
    public Text PotassiumContentText;

    public float MinPotassiumReplacementRate;
    public float MaxPotassiumReplacementRate;
    float potassiumReplacementRate;
    public Text PotassiumReplacementRateText;

    // weather?

    void InitialiseEnvironment()
    {
        temperature = Random.Range(MinTemperature, MaxTemperature);
        humidity = Random.Range(MinHumidity, MaxHumidity);
        pHLevel = Random.Range(MinpH, MaxpH);

        waterContent = Random.Range(MinWaterContent, MaxWaterContent);
        nitrogenContent = Random.Range(MinNitrogenContent, MaxNitrogenContent);
        phosphorusContent = Random.Range(MinPhosphorusContent, MaxPhosphorusContent);
        potassiumContent = Random.Range(MinPotassiumContent, MaxPotassiumContent);

        waterReplacementRate = Random.Range(MinWaterReplacementRate, MaxWaterReplacementRate);
        nitrogenReplacementRate = Random.Range(MinNitrogenReplacementRate, MaxNitrogenReplacementRate);
        phosphorusReplacementRate = Random.Range(MinPhosphorusReplacementRate, MaxPhosphorusReplacementRate);
        potassiumReplacementRate = Random.Range(MinPotassiumReplacementRate, MaxPotassiumReplacementRate);
    }

    public void DisplayStats()
    {
        TemperatureText.text = RoundToDP(temperature, 1f).ToString();
        HumidityText.text = RoundToDP(humidity, 0f).ToString();
        pHLevelText.text = RoundToDP(pHLevel, 1f).ToString();
        WaterContentText.text = RoundToDP(waterContent, 0f).ToString();
        WaterReplacementRateText.text = RoundToDP(waterReplacementRate, 2f).ToString();
        NitrogenContentText.text = RoundToDP(nitrogenContent, 2f).ToString();
        NitrogenReplacementRateText.text = RoundToDP(nitrogenReplacementRate, 0f).ToString();
        PhosphorusContentText.text = RoundToDP(phosphorusContent, 2f).ToString();
        PhosphorusReplacementRateText.text = RoundToDP(phosphorusReplacementRate, 0f).ToString();
        PotassiumReplacementRateText.text = RoundToDP(potassiumReplacementRate, 0f).ToString();
        PotassiumContentText.text = RoundToDP(potassiumContent, 2f).ToString();
    }

    float RoundToDP(float num, float dp)
    {

        float multiplier = Mathf.Pow(10, dp);

        return Mathf.Round(num * multiplier) / multiplier;
    }
}
