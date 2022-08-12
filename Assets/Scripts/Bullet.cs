using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject bullet;

    void Start()
    {
        bullet = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + (1000 * Time.deltaTime));

        if (this.transform.position.y > Screen.height)
        {
            Destroy(this.bullet.gameObject);
        }
    }
}
