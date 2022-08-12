using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float runSpeed = 10.0f;

    public GameObject bullet;
    private const float bulletDelay = 0.25f;
    private float bulletDelayTimer = bulletDelay;

    private GameObject rocket;
    private Image rocketSprite;
    private float rocketSpriteLeft;
    private float rocketSpriteRight;
    private float rocketSpriteTop;
    private float rocketSpriteBottom;

    // Start is called before the first frame update
    void Start()
    {
        rocket = this.gameObject;
        body = GetComponent<Rigidbody2D>();

        rocketSprite = rocket.GetComponent<Image>();
        rocketSpriteLeft = -(rocketSprite.GetComponent<RectTransform>().rect.width / 2);
        rocketSpriteRight = (rocketSprite.GetComponent<RectTransform>().rect.width / 2);
        rocketSpriteTop = (rocketSprite.GetComponent<RectTransform>().rect.height / 2);
        rocketSpriteBottom = -(rocketSprite.GetComponent<RectTransform>().rect.height / 2);

        /*Debug.Log(Screen.width);
        Debug.Log(Screen.width / 2);*/

        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space) && bulletDelayTimer <= 0f)
        {
            Instantiate(bullet, position:this.transform.position, Quaternion.identity, parent:this.transform.parent);
            bulletDelayTimer = bulletDelay;
        }

        if (bulletDelayTimer >= 0f)
        {
            bulletDelayTimer -= Time.deltaTime;
        }

        BounderiesCheck();
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void BounderiesCheck()
    {
        //Debug.Log(rocket.GetComponent<RectTransform>().position.x);

        if (rocket.GetComponent<RectTransform>().position.x + rocketSpriteLeft < 0) rocket.transform.position = new Vector2(-(rocketSpriteLeft), rocket.transform.position.y);
        if (rocket.GetComponent<RectTransform>().position.x + rocketSpriteRight > Screen.width) rocket.transform.position = new Vector2(Screen.width - rocketSpriteRight, rocket.transform.position.y);
        if (rocket.GetComponent<RectTransform>().position.y + rocketSpriteTop > Screen.height) rocket.transform.position = new Vector2(rocket.transform.position.x, Screen.height - rocketSpriteTop);
        if (rocket.GetComponent<RectTransform>().position.y + rocketSpriteLeft < 0) rocket.transform.position = new Vector2(rocket.transform.position.x, -(rocketSpriteBottom));


    }
}
