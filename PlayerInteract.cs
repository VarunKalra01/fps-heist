using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI promptText;
    [SerializeField]
    public GameObject pressE;
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera from PlayerCameraController
        cam = GetComponentInChildren<PlayerCameraController>().GetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        pressE.SetActive(false);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                promptText.text = interactable.promptMessage;
                pressE.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
