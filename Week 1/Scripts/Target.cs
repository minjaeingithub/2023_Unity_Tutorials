using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Transform target;
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem particles;
    [SerializeField] float range = 15f;

    void Update() {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget(){
        PlayerController enemy1 = FindObjectOfType<PlayerController>(); // finding an object having PlayerController scripts in the scene
        PlayerController1 enemy2 = FindObjectOfType<PlayerController1>();
        // which enemy is the closest?

        Transform closestTarget = null;

        //1. find the distance between tank vs. enemy(Vehicle)
        float targetDistance1 = Vector3.Distance(transform.position, enemy1.transform.position);
        float targetDistance2 = Vector3.Distance(transform.position, enemy2.transform.position);
        
        //2. compare the distance
        if(targetDistance1 < targetDistance2){
            closestTarget = enemy1.transform;
        } else {
            closestTarget = enemy2.transform;
        }
        target = closestTarget;
    }

    void AimWeapon(){
        float targetDistance = Vector3.Distance(transform.position, target.position);
        //make the weapon look at the target
        weapon.LookAt(target);

        if(targetDistance < range){
            Attack(true);
        } else {
            Attack(false);
        }
    }

    void Attack(bool isActive){
        //switch particle system
        var emissionModule = particles.emission;
        emissionModule.enabled = isActive;
    }
}
