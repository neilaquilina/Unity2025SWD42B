using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.02f;

    Material backgroundMaterial;

    Vector2 offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the material attached to the renderer from the Inspector
        backgroundMaterial = GetComponent<MeshRenderer>().material;
        //scroll the background material in the y direction
        offset = new Vector2(0f, scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        //update the texture offset to create a scrolling effect
        backgroundMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
