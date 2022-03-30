using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    [Range(0f, 1f)] public float timeBetweenFrames = 0.02f;
    public Texture2D[] frames;

    private int frameIndex = 0;
    private MeshRenderer rendererMy;



    void Start()
    {
        rendererMy = GetComponent<MeshRenderer>();

        rendererMy.sortingLayerName = "Player";
        //rendererMy.sortingOrder = -5;
        rendererMy.sharedMaterial.SetTexture("_MainTex", frames[frameIndex]);
    }

    private void Update()
    {
        StartCoroutine(NextFrame());

    }

    
    IEnumerator NextFrame()
    {
        yield return new WaitForSeconds(timeBetweenFrames);
        if (frameIndex >= frames.Length - 1)
        {
            Destroy(gameObject);
            gameObject.SetActive(false);
        } else
        {
            frameIndex++;
            rendererMy.sharedMaterial.SetTexture("_MainTex", frames[frameIndex]);
            
        }
    }
}