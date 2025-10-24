using UnityEngine;

public class MagnetScript : MonoBehaviour
{

    public Transform floatPoint;
    public float launchSpeed;

    Camera cam;

    private GameObject target;
    private Rigidbody targetRig;

    public float weaponRange = 12f;

    private bool isAttracting;
    private bool isLaunching;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Attract Input, Attract with LMB
        if (Input.GetButtonDown("Fire1"))
            isAttracting = !isAttracting;

        //Throw With RMB
        if (isAttracting)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                isLaunching = true; isAttracting = false;
            }
        }    
    }

    private void FixedUpdate()
    {
        if (isAttracting)
            Attract();
        else if (!isAttracting)
            Release();

        if (isLaunching)
            Throw ();
    }

    //Attraction Code

    private void Attract()
    {
        RaycastHit hit;

        if (isLaunching) return;

        if (target == null)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weaponRange))
            {
                if (hit.transform.tag == "Magnetised")
                {
                    target = hit.transform.gameObject;
                    targetRig = target.GetComponent<Rigidbody>();
                    target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
                    targetRig.useGravity = false;
                }
                else isAttracting = false;
            }
            else isAttracting = false;
        }
        else
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, floatPoint.position, 0.3f);
        }
    }

    //Release Code
    private void Release()
    {
        if (target != null)
        {
            targetRig.useGravity = true;
            target = null;
        }
    }

    //Throw Code
    private void Throw()
    {
        if (targetRig != null)
        {
            targetRig.useGravity = true;
            targetRig.AddForce(floatPoint.transform.forward * launchSpeed, ForceMode.Impulse);
            target = null;
            isLaunching = false;
        }
    }
}
