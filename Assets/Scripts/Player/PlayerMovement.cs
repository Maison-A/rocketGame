using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Global
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    
    // Audio
    [SerializeField] AudioClip engineThrust;
    Rigidbody rb = null;
    AudioSource asSource = null;
    // Particles
    [SerializeField] ParticleSystem particleBoosterRight;
    [SerializeField] ParticleSystem particleBoosterLeft;
    [SerializeField] ParticleSystem particleThrust;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>(); // get reference to component rigidbody and set to rb
        asSource = GetComponent<AudioSource>(); // get audio source
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    /*
     * Name: ProcessInput
     * Desc: call methods to handle user input for rocket
     */
    void ProcessInput()
    {
        ProcessThrust();
        ProcessRotation();
    }

    /*
     * Name: ProcessThrust
     * Desc: method to take input and calculate thrust on rocket
     */
    void ProcessThrust()
    {
        // GetKey will return true while input is held
        // don't use string reference overload due to nature of naming
        if (Input.GetKey(KeyCode.Space))
        {
            BeginThrusting();
        }
        else
        {
            StopThrust();
        }
    }

    void StopThrust()
    {
        asSource.Stop();
        particleThrust.Stop();
    }

    /* 
     * Name: BeginThrusting
     * Desc: logic check 
     */
    void BeginThrusting()
    {
        if (MediaPlaying())
        {
            PlayMedia();
        }
        //vector is direction and magnitude
        ThrustCalculation();
    }
    
    /* 
     * Name: ThrustCalculation
     * Desc: Putting this in its own method in order to store the var in case we need it
     */
    void ThrustCalculation()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
    }
    /* 
     * Name: MediaPlaying
     * Desc: logic check on if media is playing
     */
    bool MediaPlaying()
    {
        return !asSource.isPlaying || !particleThrust.isPlaying;
    }

    /* 
     * Name: PlayMedia
     * Desc: play all required sounds, vsx, sfx, etc.
     */
    void PlayMedia()
    {
        asSource.PlayOneShot(engineThrust);
        particleThrust.Play();
    }

    /*
    * Name: ProcessRotation
    * Desc: handle player rotate information
    */
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!particleBoosterRight.isPlaying) // i intuitively solved this, there's gotta be a better way
            {
                particleBoosterRight.Play();
            }
            ApplyRotate(rotateThrust);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!particleBoosterLeft.isPlaying)
            {
                particleBoosterLeft.Play();
            }
            
            ApplyRotate(-rotateThrust); // add a negative
        }
        else
        {
            particleBoosterRight.Stop();
            particleBoosterLeft.Stop();
        }
                
    }
    
    /*
     * Name: ApplyRotate
     * Desc: disallow engine physics to compete with user input and calculate 
     * frame independent rotation
     */
    void ApplyRotate(float rotationThisFrame)
    {
        
        rb.freezeRotation = true; // freeze engine physics rotation while inputing manual rottion
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // continue engine physics
    }
}
