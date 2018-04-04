using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] private float speed = 500.0f;
    [SerializeField] private int stepsPerFrame = 6;
    [SerializeField] private Vector3 bulletVelocity;
    private bool canFire = false;

	// Use this for initialization
	void Start () {
        bulletVelocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

        if (!canFire)
        {
            bulletVelocity = transform.forward * speed;
        }



        float stepSize = 1f / stepsPerFrame;
        Vector3 pointA = transform.position;

        for (float step = 0; step < 1; step += stepSize)
        {
            bulletVelocity += Physics.gravity * stepSize * Time.deltaTime; // this is where you would add all the bullet physics
            Vector3 pointB = pointA + bulletVelocity * stepSize * Time.deltaTime;

            Ray ray = new Ray(pointA, pointB - pointA);
            if (Physics.Raycast(ray, (pointB - pointA).magnitude))
            {
                Debug.Log("Hit");
                StartCoroutine(killBullet());
            }


            pointA = pointB;
        }
        transform.position = pointA;


    }

    private IEnumerator killBullet()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    public void fire(bool t)
    {
        canFire = t;
    }

    public void fire(float s, int accuracy, bool t)
    {
        speed = s;
        stepsPerFrame = accuracy;
        canFire = t;
    }
}
