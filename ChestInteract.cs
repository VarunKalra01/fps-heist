using UnityEngine;

public class ChestInteract : Interactable
{
    private PlayerHealth playerHealth;
    private bool hasInteracted = false;

    // Start is called before the first frame update
    void Start()
    {
        // Assuming the player has a tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        if (hasInteracted) return;  // If already interacted, do nothing

        if (playerHealth != null)
        {
            playerHealth.HealToMax();
            Debug.Log("Player healed to max health!");
        }

        hasInteracted = true;
        Destroy(gameObject);  // Destroy the chest after interaction
    }
}


