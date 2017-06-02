using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HandAnimator : MonoBehaviour {
    VRTK_ControllerEvents controller;
    VRTK_InteractGrab grab;
    Animator animator;

    int holdingHash = Animator.StringToHash("Holding");
    int pointingHash = Animator.StringToHash("Pointing");

    bool triggerPressed = false;
    bool wasTriggerPressed = false;
    bool holding = false;
    bool wasHolding = false;

    bool pointing { get { return triggerPressed && !holding; } }
    bool wasPointing { get { return wasTriggerPressed && !wasHolding; } }

    void Awake() {
        controller = GetComponentInParent<VRTK_ControllerEvents>();
        grab = GetComponentInParent<VRTK_InteractGrab>();
        animator = GetComponentInChildren<Animator>();
	}
	
	void Update () {
        triggerPressed = controller.triggerPressed;
        holding = grab.GetGrabbedObject() != null;
        if (holding == wasHolding && pointing == wasPointing) {
            return;
        }
        if (holding != wasHolding) {
            animator.SetBool(holdingHash, holding);
            wasHolding = holding;
        }
        if (pointing != wasPointing) {
            animator.SetBool(pointingHash, pointing);
        }
        wasTriggerPressed = triggerPressed;
	}

}
