using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.up * 180 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player") {
           Messenger<string>.Broadcast(GameEvent.PICKUP, gameObject.name);
            Destroy(gameObject);
        }
    }

}
