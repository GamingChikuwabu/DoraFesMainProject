using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private ParticleSystem.ForceOverLifetimeModule forceOverLifetimeModule;

    [SerializeField] private float moveParticle = 18;

    private void Start()
    {
        forceOverLifetimeModule = particleSystem.forceOverLifetime;
        forceOverLifetimeModule.x = moveParticle;
    }

    private void Update()
    {


    }
}