using UnityEngine;

public class TextureAnimator : MonoBehaviour
{
    public Texture2D[] textures; 
    public float frameRate = 1f; 

    private Material material; 
    private int currentTextureIndex = 0; 
    private float timeSinceLastFrame = 0f; 

    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        
        timeSinceLastFrame += Time.deltaTime;

        
        if (timeSinceLastFrame >= 1f / frameRate)
        {
            currentTextureIndex = (currentTextureIndex + 1) % textures.Length;
            material.mainTexture = textures[currentTextureIndex];
            timeSinceLastFrame = 0f;
        }
    }
}

