using UnityEngine;
using System.Collections;

/**
 * Singleton instance for a Sound Utility class.  This class handles playing simple
 * sounds that are global to all Mantaray AR projects.
 * 
 * @author Ivan Montiel
 */
public class SoundUtil {
	
	// Private Variables
	private static SoundUtil Instance;
	
	// Public Variables
	public AudioClip buttonClick;
	
	/**
	 * Constructor
	 */
	public SoundUtil() {
		// Load resource from file
		buttonClick = Resources.Load ("button-16") as AudioClip;
	}
	
	/**
	 * Get an instance of SoundUtil
	 */
	public static SoundUtil getInstance() {
		if(Instance == null)
			Instance = new SoundUtil();
		return Instance;
	}
	
	/**
	 * Play a butotn click sound
	 */
	public void buttonPlay(GameObject gameObject) {
		var a = gameObject.gameObject.AddComponent<AudioSource>();
		a.clip = buttonClick;
		a.Play();
	}
	
}