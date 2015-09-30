using UnityEngine;
using System.Collections;

/**
 * This Behavior takes care of fish movement and touching events.
 * 
 * @author Ivan Montiel as of 2/11/14
 * @author Ryan Burgoyne
 */
[RequireComponent (typeof (CharacterController))]
public class FishBehavior : MonoBehaviour {
	public const float speed = 0.02f;
	public const float rotateSpeed = 1.0f;
	public const float timeToRotate = 100.0f;
	public const float zoomFactor = 3.0f;
	public const float distanceFromCamera = 3.0f;
	public const float binMaxDistance = 1.5f;
	public const float initialMaxDistance = 3.0f;
	public const float colliderHeight = 0.0f;
	public const float colliderRadius = 3.0f;
	public Vector3 origin = new Vector3(0.0f,0.5f,0.0f);
	public Vector3 affectedBin = new Vector3(-2.0f,0.5f,1.0f);
	public Vector3 unaffectedBin = new Vector3(2.0f,0.5f,1.0f);
	
	private float timeSinceRotate = 0.0f;
	private Transform parentTransform;
	private CharacterController controller;
	private ARModel model;
	private Camera cam;
	private bool affected;
	private Vector3 centerPoint;
	private float rotateDirection = 0.0f;
	private float maxDistance = initialMaxDistance;
	private bool showFeedback = false;
	private GUIStructure gui;
	private GUIStructure lookCloselyGUI;
	private GUIStructure alreadyExaminedGUI;
	
	/**
	 * Initialization code.
	 * 
	 * Set up distances and origin points.
	 */
	void Start () {
    	controller = GetComponent<CharacterController>();
		
		// Adjust the collider size to fit a fish
		controller.height = colliderHeight;
		controller.radius = colliderRadius;
		
		model = this.GetComponent<ARModel>();		
	    cam = Camera.main;
		
		float componentMaxDistance = maxDistance / 2;
		float x = Random.Range(-componentMaxDistance, componentMaxDistance);
		float y = Random.Range(0, componentMaxDistance * 2);
		float z = Random.Range(-componentMaxDistance, componentMaxDistance);
		Vector3 startPoint = origin + new Vector3(x, y, z);
		
		transform.Translate(startPoint);
		centerPoint = origin;
		
		affected = gameObject.name.Contains("affected");

		//  ------------------------ Set up GUI ----------------------------------- \\
		// Create affected button
		GUIButton isAffected = new GUIButton ();
		isAffected.SetText("Yes");
		isAffected.SetBox (new Box()
			.SetMarginTop("auto")
			.SetMarginRight(0.01f)
			.SetMarginLeft("auto")
			.SetMarginBottom(0.01f)
			.SetWidth(Screen.width * 0.2 + "px")
			.SetHeight (0.4f));

		isAffected.OnClick (this.IThinkItsAffected);

		// Create not affected button
		GUIButton isNotAffected = new GUIButton ();
		isNotAffected.SetText("No");
		isNotAffected.SetBox (new Box()
			.SetMarginTop("auto")
			.SetMarginRight("auto")
			.SetMarginLeft(0.01f)
			.SetMarginBottom(0.01f)
			.SetWidth(Screen.width * 0.2 + "px")
			.SetHeight (0.4f));

		
		isNotAffected.OnClick (this.IThinkItsNotAffected);

		GUIFactory factory = new GUIFactory ();

		factory.CreateLabel ("Has this fish been affected by oil?")
			.SetBox(new Box()
		        .SetMarginBottom(0.1f)
		        .SetMarginTop(0.6f)
		        .SetMarginLeft(0.1f)
		        .SetMarginRight(0.1f))
		                .Append(isAffected)
		                .Append(isNotAffected);
	

		gui = factory.Build ();

		// -------------------- Look closely GUI Set up ----------------------------------- \\
		// Create Confirm button
		GUIButton confirm = new GUIButton ();
		confirm.SetText("Okay");
		confirm.SetBox (new Box()
		                   .SetMarginTop("auto")
		                   .SetMarginRight(0.01f)
		                   .SetMarginLeft("auto")
		                   .SetMarginBottom(0.01f)
		                   .SetWidth(Screen.width * 0.2 + "px")
		                   .SetHeight (0.4f));
		
		confirm.OnClick (this.Confirm);

		GUIFactory lookCloselyGUIFactory = new GUIFactory ();
		
		GUIComponent gc = lookCloselyGUIFactory.CreateLabel ("Look closely! Fish affected by pollution will have splotches of oil across their scales.")
			.SetBox (new Box ()
			        .SetMarginBottom (0.1f)
			        .SetMarginTop (0.6f)
			        .SetMarginLeft (0.1f)
			         .SetMarginRight (0.1f));

		GUILabel gl = (GUILabel)gc;
		GUIStyle gs = GUIStyles.GetInstance ().DEFAULT_WHITE_STYLE;
		gs.wordWrap = true;
		gl.SetStyle (gs);
		gc.Append (confirm);

		
		lookCloselyGUI = lookCloselyGUIFactory.Build ();

		// --------------------- alreadyExaminedGUI -------------------------------------- \\
		// Create Confirm button
		GUIButton confirmAlreadyExamined = new GUIButton ();
		confirmAlreadyExamined.SetText("Okay");
		confirmAlreadyExamined.SetBox (new Box()
		                   .SetMarginTop("auto")
		                   .SetMarginRight(0.01f)
		                   .SetMarginLeft("auto")
		                   .SetMarginBottom(0.01f)
		                   .SetWidth(Screen.width * 0.2 + "px")
		                   .SetHeight (0.4f));
		
		confirmAlreadyExamined.OnClick (this.ConfirmAlreadyExamined);
		
		GUIFactory alreadyExaminedGUIFactory = new GUIFactory ();
		
		alreadyExaminedGUIFactory.CreateLabel ("You have already examined this fish.")
			.SetBox (new Box ()
			         .SetMarginBottom (0.1f)
			         .SetMarginTop (0.6f)
			         .SetMarginLeft (0.1f)
			         .SetMarginRight (0.1f))
				.Append (confirmAlreadyExamined);
		
		
		alreadyExaminedGUI = alreadyExaminedGUIFactory.Build ();
	}

	/**
	 * OnUpdate code.
	 */
	void Update (){
		if (controller.enabled) {	
			if (ARModel.selected == gameObject && !model.Processed) {
				// Move in front of the camera			
				if (!parentTransform) {
					parentTransform = transform.parent;
					transform.parent = cam.transform;
				}
				transform.localPosition = Vector3.Slerp(transform.localPosition, new Vector3(0,0,distanceFromCamera), Time.deltaTime * zoomFactor);
				transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * zoomFactor);
			}
			else {
				if (model.Processed) {
					Transform child = model.transform.GetChild(0);
					if (child.GetComponent<Renderer>().material.color.a > 0.0) {
						Color c = child.GetComponent<Renderer>().material.color;
						c.a = c.a - 0.02f;
						child.GetComponent<Renderer>().material.color = c;
					}
					else {
						// Let the Experience know about this fish
						(this.model.GetExperience() as FishExperience).TallyFish(this.affected);

						if (ARModel.selected == this.model) {
							ARModel.selected = null;
						}

						// Destroy
						Destroy (model);
						Destroy(gameObject);
					}
				} else {
					if (parentTransform) {
						transform.parent = parentTransform;
						parentTransform = null;
					}
					float distance = Vector3.Magnitude(transform.position - centerPoint);
					
					// If leaving set bounds, turn around and go back
					if (distance >= maxDistance) {
						Vector3 lookPos = centerPoint - transform.position;
						Quaternion targetRotation = Quaternion.LookRotation(lookPos);
						targetRotation *= Quaternion.FromToRotation(Vector3.right, Vector3.forward);
						Quaternion newRotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
						transform.rotation = newRotation;
					}
					else {
						// Rotate randomly around y-axis. Change direction at intervals.
						if (timeSinceRotate < timeToRotate) {
							timeSinceRotate ++;
						}
						else {
							rotateDirection = Random.Range(-1.0f,1.0f);
							timeSinceRotate = 0;
						}
						transform.Rotate(0, rotateDirection * rotateSpeed, 0);
					}
					
					Vector3 forward = transform.TransformDirection(Vector3.right);
					
					controller.Move(forward * speed);
				}
			}
		}
	}

	/**
	 * OnGUI code
	 */
	void OnGUI () {
		if (showFeedback) {
			lookCloselyGUI.OnGUI(gameObject);
			model.guiOn = true;
		} else {
			if (ARModel.selected == gameObject) {
				if (model.Processed) {
					//alreadyExaminedGUI.OnGUI(gameObject);
					ARModel.selected = null;
					model.guiOn = false;
				} else {
					gui.OnGUI(gameObject);
					model.guiOn = true;
				}
			} else {
				model.guiOn = false;
			}
		}
	}

	private void IThinkItsNotAffected () {
		if (affected != false) {
			showFeedback = true;
		} else {
			ARModel.selected = null;
			model.Process ();
		}
	}

	private void IThinkItsAffected () {
		if (affected != true) {
			showFeedback = true;
		}
		else {
			ARModel.selected = null;
			model.Process();
		}
	}

	private void Confirm () {
		showFeedback = false;
	}

	private void ConfirmAlreadyExamined() {
		ARModel.selected = null;
	}
}
