using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Normal : MonoBehaviour {
    Rigidbody2D Rgdbody;
    SpriteRenderer SptRander;
    //Vector2 Transform2D;
    //public Vector2 Dir;
    float Speed = 10f;
    float Time_Spawn;
    bool Hited = false;
    void Start () {
        Rgdbody = GetComponent<Rigidbody2D>();
        SptRander = GetComponent<SpriteRenderer>();
        //Transform2D.Set(transform.position.x, transform.position.y);
        Time_Spawn = Time.time;

    }

	void Update () {
        float angle = Mathf.Atan2(Rgdbody.velocity.y, Rgdbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
        if (Time.time - Time_Spawn >= 5.5f && !Hited)
        {
            Destroy(gameObject);
        }

	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Normal>().health -= 1;
        }
        if (collision.gameObject.tag != "BounceWall")
        {
            /*
            Hited = true;
            Rgdbody.mass = 0.0001f;
            StartCoroutine(Destroing(Time.time));
            */
            Destroy(gameObject);
        }
    }

    IEnumerator Destroing(float _Start_Time)
    {
        yield return new WaitForSeconds(0.1f);
        if (SptRander.color.a <= 0)
        {
            Destroy(gameObject);
            StopCoroutine(Destroing(_Start_Time));
        }
        else
        {
            SptRander.color -= new Color(0, 0, 0, 0.1f);
            StartCoroutine(Destroing(_Start_Time));
        }
    }
}
