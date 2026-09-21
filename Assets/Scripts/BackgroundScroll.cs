using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.5f;
    private Material backgroundMaterial;

    void Start()
    {
        // get the material of the background object
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // offset the texture based on time and scroll speed
        float xOffset = Time.time * scrollSpeed;
        
        // apply the offset to the material's texture
        backgroundMaterial.mainTextureOffset = new Vector2(xOffset, 0);
    }
}
