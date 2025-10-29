using UnityEngine;

public class Parallax : MonoBehaviour
{
   private MeshRenderer meshRenderer;

    public float ANIMATION_SPEED = 0.05f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(this.ANIMATION_SPEED * Time.deltaTime, 0);
    }
}
