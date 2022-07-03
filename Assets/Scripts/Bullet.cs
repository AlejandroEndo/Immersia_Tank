using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private ParticleSystem explosionParticlesPrefab;
    [SerializeField] private float gravity;
    [SerializeField] private float speed;
    private float _force;

    private Renderer _renderer;

    private void Awake() {
        _renderer = GetComponent<Renderer>();
    }

    public void Shot(float currentForce) {
        _force = currentForce;
    }

    private void Update() {
        transform.position += transform.forward * speed * _force * Time.deltaTime;
        transform.position += Vector3.down * gravity;
    }

    private void OnTriggerEnter(Collider other) {
        StartCoroutine(ManageCollision());
    }

    private IEnumerator ManageCollision() {
        var particles = Instantiate(explosionParticlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        _renderer.enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(particles.gameObject);
        TanksManager.Instance.EndTurn();
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter(Collision collision) {
        var particles = Instantiate(explosionParticlesPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(particles.gameObject, 5f);
        TanksManager.Instance.EndTurn();
    }*/
}