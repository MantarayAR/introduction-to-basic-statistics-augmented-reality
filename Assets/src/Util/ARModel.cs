	using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]
public class ARModel : MonoBehaviour {
	public static GameObject selected = null;
	private bool processed = false;
	private bool isTouchDevice = false;
	private CharacterController controller;
	private Experience experience;
	public bool guiOn = false;
	
	public bool Processed {
		get { return processed; }
	}
	
	public void Process() {
		processed = true;
	}
	
	// Use this for initialization
	void Start () {
		isTouchDevice = Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer;
    	controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.enabled && !guiOn) {
			if(Touched()) {
				if (selected == null) 
					selected = this.gameObject;
			}
		}	
	}
	
	bool Touched () {
		bool clickDetected;
	    Vector3 touchPosition = Vector3.zero;
	 
	    // Detect click and calculate touch position
	    if (isTouchDevice) {
	        clickDetected = (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended);
	        if (clickDetected)
				touchPosition = Input.GetTouch(0).position;
	    } else {
	        clickDetected = (Input.GetMouseButtonDown(0));
	        touchPosition = Input.mousePosition;
	    }
	 
	    // Detect clicks
	    if (clickDetected) {    
			
	        // Check if the GameObject is clicked by casting a
	        // Ray from the main camera to the touched position.
	        Ray ray = Camera.main.ScreenPointToRay 
	                            (touchPosition);
	        RaycastHit hit;
	        // Cast a ray of distance 100, and check if this
	        // collider is hit.
	        if (GetComponent<Collider>().Raycast (ray, out hit, 100.0f)) {
				SoundUtil.getInstance().buttonPlay(gameObject);
	            return true;
	        }
	    }
	    
	    return false;
	}

	public void SetExperience (Experience experience)
	{
		this.experience = experience;
	}

	public Experience GetExperience ()
	{
		return this.experience;
	}
}
