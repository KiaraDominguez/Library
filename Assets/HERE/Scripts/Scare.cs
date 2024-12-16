using UnityEngine;

public class Scare : MonoBehaviour
{
    public Transform player;

    public GameObject face;
    public GameObject body;

    private Color faceOriginalColor;
    private Color bodyOriginalColor;

    private SkinnedMeshRenderer faceSkinnedMeshRenderer;
    private SkinnedMeshRenderer bodySkinnedMeshRenderer;

    private bool playerSawItOnce;

    void Start()
    {
        faceSkinnedMeshRenderer = face.GetComponent<SkinnedMeshRenderer>();
        faceOriginalColor = faceSkinnedMeshRenderer.material.color;

        bodySkinnedMeshRenderer = body.GetComponent<SkinnedMeshRenderer>();
        bodyOriginalColor = bodySkinnedMeshRenderer.material.color;

        SetObjectVisibility(false);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!playerSawItOnce) 
        {
            SetObjectVisibility(true);
        }
        playerSawItOnce = true;

    }

    public void OnTriggerExit(Collider other)
    {
        SetObjectVisibility(false);
    }

    // Update is called once per frame
    private void SetObjectVisibility(bool isVisible)
    {
        if (isVisible)
        {
            faceSkinnedMeshRenderer.material.color = faceOriginalColor;
            bodySkinnedMeshRenderer.material.color = bodyOriginalColor;
        }
        else
        {
            faceSkinnedMeshRenderer.material.color = new Color(faceOriginalColor.r, faceOriginalColor.g, faceOriginalColor.b, 0f); // Rendre transparent
            bodySkinnedMeshRenderer.material.color = new Color(bodyOriginalColor.r, bodyOriginalColor.g, bodyOriginalColor.b, 0f); // Rendre transparent
        }
    }
}
