using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", horiz);
        anim.SetFloat("MoveY", vert);

        Vector2 movement = new Vector2(horiz, vert);
        Vector2 position = (Vector2)transform.position + movement * speed * Time.deltaTime;
        anim.SetFloat("Speed", movement.magnitude);
        transform.position = position;
    }
}
