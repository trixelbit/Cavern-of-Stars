using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGateTrigger : MonoBehaviour
{
    public bool Locked = true;
    public float MovementSpeed = .1f;
    public float ShakeAmount = .1f;
    public float SinkDistance = 10;

    [Header("Light Color")]
    public Color UnlockedColor;
    public Color LockedColor;
    public GameObject GateLight;

    private Vector3 InitialPosition;


    private void Awake()
    {
        GetComponentInParent<ParticleSystem>().Stop();
        InitialPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Locked = GlobalData.EnemyCount <= 0 ? false : true;

        if (!Locked)
        {
            GateLight.GetComponent<Light>().color = UnlockedColor;

            if (Vector3.Distance(transform.position, InitialPosition) < SinkDistance)
            {
                transform.position += Vector3.down * MovementSpeed;
                Vector3 Offset = new Vector3(InitialPosition.x + Random.Range(-ShakeAmount, ShakeAmount), transform.position.y, InitialPosition.z + Random.Range(-ShakeAmount, ShakeAmount));
                transform.position = Vector3.Lerp(transform.position, Offset, .1f);

                if (GetComponentInParent<ParticleSystem>().isStopped)
                {
                    GetComponentInParent<ParticleSystem>().Play();
                }
            }
            else
            {
                GetComponentInParent<ParticleSystem>().Stop();
                gameObject.SetActive(false);
            }
        }
        else
        {
            GateLight.GetComponent<Light>().color = LockedColor;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * SinkDistance));
        Gizmos.DrawWireSphere(transform.position + (Vector3.down * SinkDistance), 1);
    }

}
