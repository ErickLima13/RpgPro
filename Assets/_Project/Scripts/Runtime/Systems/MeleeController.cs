using UnityEngine;

public class MeleeController : MonoBehaviour
{
    private GameManager gameManager;
    private Customization customization;

    private Ray ray;
    private RaycastHit hitInfo;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public Transform hitPivot;

    public float radius;
    [Range(0, 360)] public float hitAngle;

    public bool isIgnoreObstacle;

    private void Start()
    {
        gameManager = GameManager.Instance;
        customization = Customization.Instance;
    }

    public void CheckTargets()
    {
        Collider[] targetInRadius = Physics.OverlapSphere(hitPivot.position,
            radius, targetMask);
        foreach (Collider c in targetInRadius)
        {
            DamageController dc = c.GetComponent<DamageController>();
            Transform target = dc.hitPoint;
            Vector3 dirToTarget = (target.position - hitPivot.position).normalized;
            float distToTarget = Vector3.Distance(hitPivot.position,
                target.position);
            ray.origin = hitPivot.position;
            ray.direction = dirToTarget;

            if (Vector3.Angle(transform.forward, dirToTarget)
                < hitAngle / 2)
            {
                Debug.DrawRay(ray.origin, ray.direction * distToTarget,
                    Color.green, 0.3f);

                if (isIgnoreObstacle)
                {
                    dc.TakeDamage(gameManager.SetDamage(
                      gameManager.dmgMelee));
                }
                else
                {
                    if (!Physics.Raycast(ray, distToTarget, obstacleMask))
                    {
                        dc.TakeDamage(gameManager.SetDamage(
                             gameManager.dmgMelee));
                    }
                }
            }
        }
    }

    public Vector3 DirForAngle(float angleInDegress)
    {
        angleInDegress += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegress * Mathf.Deg2Rad),
           0, Mathf.Cos(angleInDegress * Mathf.Deg2Rad));
    }
}
