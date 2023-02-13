using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string type;

    public int level;
    public int cost;

    private Manager gameManager;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI costText;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gm = GameObject.FindGameObjectWithTag("Game Manager");
        if (gm != null)
        {
            gameManager = gm.GetComponent<Manager>();
        } else
        {
            Debug.LogError("Couldn't find game manager on Game Manager layer!");
        }

        gameManager.GetUpgradeInfo(type, ref level, ref cost);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateNumbers();
    }

    void UpdateNumbers()
    {
        levelText.text = "Lv. " + level;
        costText.text = cost.ToString();
        if (gameManager.bank.quench >= cost)
        {
            costText.color = Color.green;
        } else
        {
            costText.color = Color.red;
        }
        
    }

    public void Purchase()
    {
        if (gameManager.bank.quench >= cost)
        {
            gameManager.BuyUpgrade(type);

            gameManager.GetUpgradeInfo(type, ref level, ref cost);
        }
    }
}
