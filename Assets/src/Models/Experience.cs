using System;
using System.Collections.Generic;
using UnityEngine;

public class Experience
{
	private System.Type b = null;
	private GameObject target;
	private List<GameObject> models;
	protected Slide owner;

	public Experience (Experience e) {
		this.b = e.GetBehavior ();
		this.target = e.GetTarget ();
		this.models = e.GetGameObjects ();
		this.owner = e.GetOwner ();
	}

	public Experience (System.Type behaviour, Slide owner)
	{
		this.models = new List<GameObject>();
		this.b = behaviour;
		this.owner = owner;
	}

	public void SetOwner(Slide owner) {
		this.owner = owner;
	}

	public Slide GetOwner() {
		return owner;
	}

	public void SetTarget(GameObject target)
	{
		this.target = target;
	}
	
	public GameObject GetTarget()
	{
		return this.target;
	}
	
	public void AddGameObject(GameObject m)
	{
		this.models.Add(m);
	}

	public void SetGameObjects(List<GameObject> gameObjects) {
		this.models = gameObjects;
	}

	public List<GameObject> GetGameObjects()
	{
		return this.models;
	}
	
	public System.Type GetBehavior()
	{
		return this.b;
	}
	
	public virtual void OnGUI(GameObject gameObject) {

	}
}

