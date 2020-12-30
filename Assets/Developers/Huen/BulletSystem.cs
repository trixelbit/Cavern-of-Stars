using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletSystem : MonoBehaviour
{
    #region Info
    public string info = "The Bullet also has a bullet script. The bullet prefab references the speed and life variable from this script.";
    #endregion

    #region Dependencies
    [Header("Dependencies")]
    public GameObject bullet; //references the bullet object
    public GameObject bulletInit; //references the bullet initialization point
    #endregion

    #region Variables

    [Header("Bullet Variables")]
    [Range(0, 500)] public float bulletSpeed = 3f;
    [Range(0.5f,1)] public float bulletLife;
    public Vector3 bulletDir;

    [Header("Gizmos and Raycast Variables")]
    public Color setColor;
    [Range(0,3)] public float gizmoSize;
    #endregion

    #region Private Variables

    #endregion

    #region Start, Update, Gizmos
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { //when the spacebar is pushed

            GameObject clone = Instantiate(bullet, bulletInit.transform.position, Quaternion.Euler(0,0,0)); //Instnatiates the bullet at the init location with no rotation
            clone.GetComponent<Rigidbody>().AddForce(bulletDir * bulletSpeed * Time.deltaTime, ForceMode.Impulse); //Shoots the bullet off in a random direction
            Destroy(clone, bulletLife);
        }

        Debug.DrawRay(bulletInit.transform.position, bulletDir, setColor);
    }

    private void OnDrawGizmos()
    {
        #region Define Text Style
        GUIStyle textStyle = new GUIStyle(); //Initiate GUIStyle
        textStyle.fontSize = 30; //Set the font size to 30
        #endregion

        Gizmos.color = setColor; //Set the gizmo color to the set color defined at the start
        Gizmos.DrawWireSphere(bulletInit.transform.position, gizmoSize); //Draw a wiresphere at the bulletInit location

        Handles.color = setColor;
        Handles.Label(bulletInit.transform.position, "Bullet Init Point", textStyle); //Draw a label that communicates the bulletInit location
    }
    #endregion
}
