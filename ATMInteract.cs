using System.Collections.Generic;
using UnityEngine;

public class ATMInteract : Interactable
{
    private MoneyManager moneyManager;
    private static Dictionary<string, bool> atmInteractions = new Dictionary<string, bool>();

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the MoneyManager is on the same GameObject
        moneyManager = FindObjectOfType<MoneyManager>();

        // Initialize interaction states for ATMs if not already done
        if (!atmInteractions.ContainsKey(gameObject.name))
        {
            atmInteractions[gameObject.name] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Debug.Log("Interacting with " + gameObject.name);

        if (atmInteractions[gameObject.name])
        {
            Debug.Log("ATM already interacted with.");
            return;  // If already interacted, do nothing
        }

        if (moneyManager != null)
        {
            float randomMoney = Random.Range(2000000f, 5000000f);
            moneyManager.AddMoney(randomMoney);
            Debug.Log("Added $" + randomMoney + " to money.");
        }

        atmInteractions[gameObject.name] = true;  // Mark this ATM as interacted
    }

    // Static method to reset the atmInteractions dictionary
    public static void ResetInteractions()
    {
        atmInteractions.Clear();
        Debug.Log("ATM interactions have been reset.");
    }
}
