using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAimNoNetCode : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    float xRotation = 0f;

    public Transform playerBody;

    public float detectRange = 5f;
    public GameObject indicationText;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        indicationText.SetActive(false);

        //if (IsOwner)
        //{
        //    // Set the camera owner to the local player
        //    Camera.main.GetComponent<NetworkObject>().ChangeOwnership(OwnerClientId);
        //}
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, transform.localRotation.z);
        playerBody.Rotate(Vector3.up * mouseX);

        DetectLookAtSuitcase();
    }

    private void DetectLookAtSuitcase()
    {
        indicationText.SetActive(false);

        Ray ray = new Ray (transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectRange))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Suitcase"))
            {
                indicationText.gameObject.SetActive(true);
            }
        }
    }
}
