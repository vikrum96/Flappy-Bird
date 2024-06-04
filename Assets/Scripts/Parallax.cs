using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer mesh_renderer;
    public float animation_speed = 1f;

    private void Awake()
    {
        mesh_renderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        mesh_renderer.material.mainTextureOffset += new Vector2(animation_speed * Time.deltaTime, 0); // Vector2(x,y)
    }
}
