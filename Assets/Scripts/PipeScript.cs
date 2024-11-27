using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private float speed = 1.0f;   // 1 cell / sec
    void Start()
    {

    }
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector2.left);
    }
}
