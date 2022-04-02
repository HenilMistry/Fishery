using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    Vector3 mouserPosition;
    Rigidbody2D rb;
    Vector2 playerPosition;
    public float speed = 0.1f;
     float minX;
     float maxX;
     float minY;
    float maxY;
    public float paddingY = 0.8f;
    public float paddingX = 1f;
    public SpriteRenderer PlayerSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        
    }

    void FindBoundaries() {
        Camera gameCamera = Camera.main;
        minX = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).x+paddingX;
        maxX = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x-paddingX;
        minY = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y+paddingY;
        maxY = gameCamera.ViewportToWorldPoint(new Vector3(0,1,0)).y-paddingY;
    }

    // Update is called once per frame
    void Update()
    {
        FindBoundaries();
        this.mouserPosition = Input.mousePosition;
        this.mouserPosition = Camera.main.ScreenToWorldPoint(this.mouserPosition);
        this.playerPosition = Vector2.Lerp(this.transform.position, this.mouserPosition, this.speed);
        
        float newXPos = Mathf.Clamp(transform.position.x,minX,maxX);
        float newYPos = Mathf.Clamp(transform.position.y,minY,maxY);

        transform.position = new Vector2(newXPos,newYPos);
    }

    private void FixedUpdate() {
        rb.MovePosition(this.playerPosition);
        if (mouserPosition.x > transform.position.x) {
			PlayerSpriteRenderer.flipX = true;
		} else {
			PlayerSpriteRenderer.flipX = false;
		}
    }
}
