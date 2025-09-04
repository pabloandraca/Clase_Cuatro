using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] ParticleSystem ps;

    public void PlayParticle()
    {
        ps.Play();
    }
}