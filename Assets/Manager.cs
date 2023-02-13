using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Bank bank;

    public float water;
    public float quench;

    // How many assistants are owned
    public int up_AssistsLevel = 0;

    // Formula for cost is: cost = base * mult^level
    public float up_AssistsBase = 10;
    public float up_AssistsMult = 1.1f;

    // One Assistant fills this many cups every second
    public float up_AssistsBaseCPS = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate earnings from automatic upgrades
        if (up_AssistsLevel > 0)
        {
            float earned = (up_AssistsBaseCPS * up_AssistsLevel) * Time.deltaTime;
            water += earned;
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
            default:
                Debug.LogError("Couldn't find upgrade to buy with name " + upgrade);
                break;
        }

        // Update bank counter
        bank.water = Mathf.FloorToInt(water);
        bank.quench = Mathf.FloorToInt(quench);
    }
}
