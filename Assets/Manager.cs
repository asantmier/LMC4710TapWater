using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Bank bank;

    public float water;
    public float quench;
    public int clickPower = 1;
    public int quenchRatio = 10;

    [Header("Assists")]
    // How many assistants are owned
    public int up_AssistsLevel = 0;

    // Formula for cost is: cost = base * mult^level
    public float up_AssistsBase = 10;
    public float up_AssistsMult = 1.1f;

    // One Assistant fills this many cups every second
    public float up_AssistsBaseCPS = 0.25f;

    [Header("Purifiers")]
    public int up_PurifiersLevel = 0;
    public float up_PurifiersBase = 50;
    public float up_PurifiersMult = 1.15f;
    public float up_PurifiersBaseCPS = 0.5f;

    [Header("Fountains")]
    public int up_FountainsLevel = 0;
    public float up_FountainsBase = 100;
    public float up_FountainsMult = 1.2f;
    public float up_FountainsBaseCPS = 1.5f;

    [Header("Waterfalls")]
    public int up_WaterfallsLevel = 0;
    public float up_WaterfallsBase = 500;
    public float up_WaterfallsMult = 1.25f;
    public float up_WaterfallsBaseCPS = 5f;

    [Header("Drills")]
    public int up_DrillsLevel = 0;
    public float up_DrillsBase = 1000;
    public float up_DrillsMult = 1.3f;
    public float up_DrillsBaseCPS = 20f;

    [Header("Faucets")]
    public int up_FaucetsLevel = 0;
    public float up_FaucetsBase = 10000;
    public float up_FaucetsMult = 1.4f;
    public float up_FaucetsBaseCPS = 100f;

    [Header("Harvesters")]
    public int up_HarvestersLevel = 0;
    public float up_HarvestersBase = 50000;
    public float up_HarvestersMult = 1.45f;
    public float up_HarvestersBaseCPS = 1000f;

    [Header("Quantums")]
    public int up_QuantumsLevel = 0;
    public float up_QuantumsBase = 100000;
    public float up_QuantumsMult = 1.5f;
    public float up_QuantumsBaseCPS = 5000f;

    [Header("Water")]
    public int en_WaterLevel = 0;
    public float en_WaterBase = 50;
    public float en_WaterMult = 2f;

    [Header("People")]
    public int en_PeopleLevel = 0;
    public float en_PeopleBase = 100;
    public float en_PeopleMult = 2f;

    [Header("Stage")]
    public int stage = 0;
    public float stageBase = 500;
    public float stageMult = 8f;
    public float stageBoost = 4f;

    private void Start()
    {
        GameObject info = GameObject.FindGameObjectWithTag("Bank");
        if (info != null)
        {
            bank = info.GetComponent<Bank>();
        }
        else
        {
            Debug.LogError("Couldn't find an object tagged with Bank!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate earnings from automatic upgrades
        if (up_AssistsLevel > 0)
        {
            float earned = (up_AssistsBaseCPS * up_AssistsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_PurifiersLevel > 0)
        {
            float earned = (up_PurifiersBaseCPS * up_PurifiersLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_FountainsLevel > 0)
        {
            float earned = (up_FountainsBaseCPS * up_FountainsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_WaterfallsLevel > 0)
        {
            float earned = (up_WaterfallsBaseCPS * up_WaterfallsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_DrillsLevel > 0)
        {
            float earned = (up_DrillsBaseCPS * up_DrillsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_FaucetsLevel > 0)
        {
            float earned = (up_FaucetsBaseCPS * up_FaucetsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_HarvestersLevel > 0)
        {
            float earned = (up_FaucetsBaseCPS * up_HarvestersLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }
        if (up_QuantumsLevel > 0)
        {
            float earned = (up_QuantumsBaseCPS * up_QuantumsLevel) * Time.deltaTime;
            water += earned * Mathf.Pow(stageBoost, stage);
        }

        // Update bank counter
        bank.water = Mathf.FloorToInt(water);
        bank.quench = Mathf.FloorToInt(quench);
    }

    public void GetUpgradeInfo(string upgrade, ref int level, ref int cost)
    {
        switch (upgrade)
        {
            case "assists":
                level = up_AssistsLevel;
                cost = Mathf.FloorToInt(up_AssistsBase * Mathf.Pow(up_AssistsMult, up_AssistsLevel));
                break;
            case "purifiers":
                level = up_PurifiersLevel;
                cost = Mathf.FloorToInt(up_PurifiersBase * Mathf.Pow(up_PurifiersMult, up_PurifiersLevel));
                break;
            case "fountains":
                level = up_FountainsLevel;
                cost = Mathf.FloorToInt(up_FountainsBase * Mathf.Pow(up_FountainsMult, up_FountainsLevel));
                break;
            case "waterfalls":
                level = up_WaterfallsLevel;
                cost = Mathf.FloorToInt(up_WaterfallsBase * Mathf.Pow(up_WaterfallsMult, up_WaterfallsLevel));
                break;
            case "drills":
                level = up_DrillsLevel;
                cost = Mathf.FloorToInt(up_DrillsBase * Mathf.Pow(up_DrillsMult, up_DrillsLevel));
                break;
            case "faucets":
                level = up_FaucetsLevel;
                cost = Mathf.FloorToInt(up_FaucetsBase * Mathf.Pow(up_FaucetsMult, up_FaucetsLevel));
                break;
            case "harvesters":
                level = up_HarvestersLevel;
                cost = Mathf.FloorToInt(up_HarvestersBase * Mathf.Pow(up_HarvestersMult, up_HarvestersLevel));
                break;
            case "quantums":
                level = up_QuantumsLevel;
                cost = Mathf.FloorToInt(up_QuantumsBase * Mathf.Pow(up_QuantumsMult, up_QuantumsLevel));
                break;
            case "people":
                level = en_PeopleLevel;
                cost = Mathf.FloorToInt(en_PeopleBase * Mathf.Pow(en_PeopleMult, en_PeopleLevel));
                break;
            case "water":
                level = en_WaterLevel;
                cost = Mathf.FloorToInt(en_WaterBase * Mathf.Pow(en_WaterMult, en_WaterLevel));
                break;
            case "stage":
                level = stage;
                cost = Mathf.FloorToInt(stageBase * Mathf.Pow(stageMult, stage));
                break;
            default:
                Debug.LogError("Couldn't find upgrade to query with name " + upgrade);
                break;
        }
    }

    public void BuyUpgrade(string upgrade)
    {
        switch (upgrade)
        {
            case "assists":
                quench -= Mathf.FloorToInt(up_AssistsBase * Mathf.Pow(up_AssistsMult, up_AssistsLevel));
                up_AssistsLevel++;
                break;
            case "purifiers":
                quench -= Mathf.FloorToInt(up_PurifiersBase * Mathf.Pow(up_PurifiersMult, up_PurifiersLevel));
                up_PurifiersLevel++;
                break;
            case "fountains":
                quench -= Mathf.FloorToInt(up_FountainsBase * Mathf.Pow(up_FountainsMult, up_FountainsLevel));
                up_FountainsLevel++;
                break;
            case "waterfalls":
                quench -= Mathf.FloorToInt(up_WaterfallsBase * Mathf.Pow(up_WaterfallsMult, up_WaterfallsLevel));
                up_WaterfallsLevel++;
                break;
            case "drills":
                quench -= Mathf.FloorToInt(up_DrillsBase * Mathf.Pow(up_DrillsMult, up_DrillsLevel));
                up_DrillsLevel++;
                break;
            case "faucets":
                quench -= Mathf.FloorToInt(up_FaucetsBase * Mathf.Pow(up_FaucetsMult, up_FaucetsLevel));
                up_FaucetsLevel++;
                break;
            case "harvesters":
                quench -= Mathf.FloorToInt(up_HarvestersBase * Mathf.Pow(up_HarvestersMult, up_HarvestersLevel));
                up_HarvestersLevel++;
                break;
            case "quantums":
                quench -= Mathf.FloorToInt(up_QuantumsBase * Mathf.Pow(up_QuantumsMult, up_QuantumsLevel));
                up_QuantumsLevel++;
                break;
            case "people":
                water -= Mathf.FloorToInt(en_PeopleBase * Mathf.Pow(en_PeopleMult, en_PeopleLevel));
                en_PeopleLevel++;
                break;
            case "water":
                water -= Mathf.FloorToInt(en_WaterBase * Mathf.Pow(en_WaterMult, en_WaterLevel));
                en_WaterLevel++; 
                break;
            case "stage":
                water -= Mathf.FloorToInt(stageBase * Mathf.Pow(stageMult, stage));
                stage++;
                break;
            default:
                Debug.LogError("Couldn't find upgrade to buy with name " + upgrade);
                break;
        }

        // Update bank counter
        bank.water = Mathf.FloorToInt(water);
        bank.quench = Mathf.FloorToInt(quench);
    }

    public void Fill() {
        updateWater(clickPower * Mathf.FloorToInt(Mathf.Pow(2, en_WaterLevel)));
    }

    public void Quench() {
        if (water >= quenchRatio) {
            int waterToQuench = Mathf.FloorToInt(quenchRatio * Mathf.Pow(stageBoost, stage));
            int quenchFactor = Mathf.FloorToInt(water) / waterToQuench;
            int quenchToGain = Mathf.FloorToInt(Mathf.Pow(2, en_PeopleLevel) * Mathf.Pow(stageBoost, stage));
            updateQuench(quenchToGain * quenchFactor);
            updateWater(-(waterToQuench * quenchFactor));
        }
    }

    public void updateWater(int increment)
    {
        water += increment;
    }

    public void updateQuench(int increment)
    {
        quench += increment;
    }
}
