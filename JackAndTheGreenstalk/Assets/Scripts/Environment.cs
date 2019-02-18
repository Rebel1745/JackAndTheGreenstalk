using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitialiseEnvironment();
    }

    public bool IsOutdoors;

    public float MinTemperature;
    public float MaxTemperature;
    float temperature;

    public float MinHumidity;
    public float MaxHumidity;
    float humidity;

    public float MinpH;
    public float MaxpH;
    float pHLevel;

    public float MinNitrogenContent;
    public float MaxNitrogenContent;
    float nitrogenContent;

    public float MinNitrogenReplacementRate;
    public float MaxNitrogenReplacementRate;
    float nitrogenReplacementRate;

    public float MinPhosphorousContent;
    public float MaxPhosphorousContent;
    float phosphorousConstumption;

    public float MinPhosphorousReplacementRate;
    public float MaxPhosphorousReplacementRate;
    float phosphorousReplacementRate;

    public float MinPotassiumContent;
    public float MaxPotassiumContent;
    float potassiumContent;

    public float MinPotassiumReplacementRate;
    public float MaxPotassiumReplacementRate;
    float potassiumReplacementRate;

    // weather?

    void InitialiseEnvironment()
    {
        temperature = Random.Range(MinTemperature, MaxTemperature);
        humidity = Random.Range(MinHumidity, MaxHumidity);
        pHLevel = Random.Range(MinpH, MaxpH);

        nitrogenContent = Random.Range(MinNitrogenContent, MaxNitrogenContent);
        phosphorousConstumption = Random.Range(MinPhosphorousContent, MaxPhosphorousContent);
        potassiumContent = Random.Range(MinPotassiumContent, MaxPotassiumContent);

        nitrogenReplacementRate = Random.Range(MinNitrogenReplacementRate, MaxNitrogenReplacementRate);
        phosphorousConstumption = Random.Range(MinPhosphorousReplacementRate, MaxPhosphorousReplacementRate);
        potassiumReplacementRate = Random.Range(MinPotassiumReplacementRate, MaxPotassiumReplacementRate);
    }
}
