using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Animator anim;

    [SerializeField] private Camera mainCam;
    

    // Update is called once per frame
    void Update()
    {

        // Movement
        float horiz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", horiz);
        anim.SetFloat("MoveY", vert);

        Vector2 movement = new Vector2(horiz, vert);
        Vector2 position = (Vector2)transform.position + movement * speed * Time.deltaTime;
        anim.SetFloat("Speed", movement.magnitude);
        transform.position = position;


        // Actions 
        if (Input.GetMouseButtonDown(0)) {
            Mouse mouse = Mouse.current;
            Vector2 mousePos = mouse.position.ReadValue();

            if ((mainCam.pixelHeight / 2.0f) > mousePos.y)
            {
                anim.SetTrigger("PlowToward");
            }
            else {
                anim.SetTrigger("PlowAway");
            }
        }
    }
}
