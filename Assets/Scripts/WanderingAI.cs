using UnityEditor.Tilemaps;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private LayerMask background;
    private bool facingRight = true;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    // https://discussions.unity.com/t/moving-an-enemy-randomly/188323/2 lifted most of this code from here
    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        int dirVal = facingRight ? 1 : -1;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (Vector2.right * dirVal), 0.8f, background.value);

        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime || hit)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        if ((!facingRight && movementDirection.x > 0.01f) || (facingRight && movementDirection.x < -0.01f)) {
            Flip();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

    }

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    
    }

}
