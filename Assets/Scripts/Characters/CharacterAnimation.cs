using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour
{
    //Particle system to spawn when the character moves
    public GameObject moveParticles;
    //How long until the spawned particle system is destroyed
    public float particleLife = 3.0f;

    //Spawns particles when the character moves (called from the move script)
    public void Step()
    {
        GameObject obj = Instantiate(moveParticles, transform.position, Quaternion.identity) as GameObject;

        Destroy(obj, particleLife);
    }
}
