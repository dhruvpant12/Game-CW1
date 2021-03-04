using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletprefab;

    public Transform bulletSpawn;

    public float bulletlife = 2;

    public float bulletspeed = 20;

    public AudioSource gunshot;


    // Start is called before the first frame update
    void Start()
    {
        gunshot = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletprefab);

            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>());

            bullet.transform.position = bulletSpawn.position;

            Vector3 rotation = bullet.transform.rotation.eulerAngles;
            bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //Measure of rotation.

            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletspeed, ForceMode.Impulse);

            gunshot.Play();

            StartCoroutine(destroyBulletAfterFourSecond(bullet, bulletlife));
        }

    }

    private IEnumerator destroyBulletAfterFourSecond(GameObject bullet, float aftertime)
    {
        yield return new WaitForSeconds(aftertime);
        Destroy(bullet);
    }
}
