using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent EventReloaded;
    public UnityEvent EventOutOfAmmo;
    public UnityEvent EventShoot;
    public UnityEvent EventHitTaken;
    public UnityEvent EventGameOver;

    public GameObject bulletPrefab;
    public int maxAmmo = 10;
    public int currentAmmo;
    public int CurrentAmmo { get { return currentAmmo; } }

    public int startLife = 3;
    public int currentLife;
    public int CurrentLife { get { return currentLife; } }


    Transform coverPosition;
    Transform uncoverPosition;
    bool onCover = false;

    void Update()
    {
        if (currentLife == 0)
        {
            GameOver();
        }
    }
    private void Awake()
    {
        currentAmmo = maxAmmo;
        currentLife = startLife;
    }

    public void GameOver()
    {
        EventGameOver.Invoke();
    }
    public void TakeHit()
    {
        currentLife--;
        EventHitTaken.Invoke();
    }

    public void SetAreaPositions(Transform playerPos, Transform coverPos)
    {
        uncoverPosition = playerPos;
        coverPosition = coverPos;
        transform.position = uncoverPosition.position;
    }

    public void ToggleCover()
    {
        onCover = !onCover;
        if (onCover) transform.position = coverPosition.position;
        else transform.position = uncoverPosition.position;
    }

    public void Shoot()
    {
        if(currentAmmo > 0)
        {
            currentAmmo--;

            var  bullet = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Ray r = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            bullet.GetComponent<Rigidbody>().AddForce(r.direction * 750);

            EventShoot.Invoke();
            if(currentAmmo <= 0)
            {
                EventOutOfAmmo.Invoke();
            }
        }
    }

    public void Reload()
    {
        currentAmmo = maxAmmo;
        EventReloaded.Invoke();
    }
}
