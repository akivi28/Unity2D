using System.Linq;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public static int score;
    private Rigidbody2D rb2d;
    private Collider2D[] colliders;
    public ModalScript modalScript;
    void Start()
    {
        score = 0;
        rb2d = this.GetComponent<Rigidbody2D>();
        colliders = this.GetComponents<Collider2D>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);
        }
        this.transform.eulerAngles = new Vector3(0, 0, 2.5f * rb2d.linearVelocityY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            modalScript.ShowGameOverModal(score);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            if (!colliders.Any(c => c.IsTouching(collision)))
            {
                score += 1;
            }

        }
    }
}
