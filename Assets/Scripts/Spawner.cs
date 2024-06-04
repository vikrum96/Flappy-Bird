using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject prefab;
   public float spawn_rate = 1f;
   public float min_height = -1f;
   public float max_height = 1f;

   public void OnEnable()
   {
    InvokeRepeating(nameof(Spawn), spawn_rate, spawn_rate);
   }

   public void OnDisable()
   {
    CancelInvoke(nameof(Spawn));
   }

   public void Spawn()
   {
    GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
    pipes.transform.position += Vector3.up * Random.Range(min_height, max_height);
   }
}
