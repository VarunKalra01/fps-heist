using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanInteract : Interactable
{
    // Start is called before the first frame update
    public GameObject moneyText;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    {
        Time.timeScale = 0f;
        moneyText.SetActive(true);

        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
    Cursor.visible = true;                   // Make the cursor visible
    }
}
