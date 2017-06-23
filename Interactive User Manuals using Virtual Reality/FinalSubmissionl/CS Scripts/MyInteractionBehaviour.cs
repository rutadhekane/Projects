
using System;
using UnityEngine;
using UnityEngine.Assertions;
using Leap.Unity.Interaction.CApi;
using Leap.Unity.Interaction;

namespace Leap.Unity.Interaction {
public class MyInteractionBehaviour : InteractionBehaviour {

	public bool bIsGraspBegin = false;
	public bool bIsGraspEnd = false;

			
	protected override void OnGraspBegin() {
		base.OnGraspBegin();
			
		bIsGraspBegin = true;
		bIsGraspEnd = false;
	}

	protected override void OnGraspEnd(Hand lastHand) {
		base.OnGraspEnd(lastHand);

		bIsGraspBegin = false;
		bIsGraspEnd = true;
	}
     

}
}