using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;

    private Material backgroundMaterial;
    private float xOffset = 0f;

    public bool isScrolling = true;

    void Start()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (isScrolling)
        {
            // Increase offset only while we're moving
            xOffset += scrollSpeed * Time.deltaTime;

            backgroundMaterial.mainTextureOffset =
                new Vector2(xOffset, 0);
        }
    }

    public void StartScrolling()
    {
        isScrolling = true;
    }

    public void StopScrolling()
    {
        isScrolling = false;
    }
}