using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineImpulseSource impulseSource;

    [SerializeField] private float defaultForce = 1f;

    void Awake()
    {
        Instance = this;
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void Shake(float force = -1f)
    {
        if (force < 0f) force = defaultForce;
        impulseSource.GenerateImpulse(force);
    }
}
