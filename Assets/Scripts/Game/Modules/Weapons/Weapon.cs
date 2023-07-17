using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Reference for the Bullet
    public GameObject bullet;

    // Bullet Force
    public float shootForce, upwardForce;

    // Gun Stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    // Booleans
    bool shooting, readyToShoot, reloading;

    // Other References
    public Camera fpsCam;
    public Transform attackPoint;

    // bug fixing 
    public bool allowInvoke = true;

    // Graphics
    public GameObject muzzleFlash;
    /*public TextMeshProUGUI ammunitionDisplay;*/





    private void Awake()
    {
        // make sure magazine is full 
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        myInput();

        // Set ammo display
    }

    private void myInput()
    {
        // Check if allowed to hold down button and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Reloading automatically when trying to shoot without ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();


        //Shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            // Set bullets shot to 0
            bulletsShot = 0;

            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        

        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Ray thought the middle of your screen
        RaycastHit hit;

        // Check if raycast hits something

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //Calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0); //Just add spread to last direction

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add Forces to bullet 
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);


        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShot()
    {
        // Allow shooting and invoking again
        readyToShoot = true;
        allowInvoke = true;
    }

    void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
