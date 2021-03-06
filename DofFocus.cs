using UnityEngine;
using UnityEngine.PostProcessing;

public class DofFocus : MonoBehaviour {
    private PostProcessingProfile post;
    private float defaultDistance;
    [SerializeField] private bool mouseMode; // will shoot the ray from where the mouse cursor lies, handy for testing
    [SerializeField] private float focusSpeed = 2f; // change in inspector to adjust rate of focus

    private void Start()
    {
        post = GetComponent<PostProcessingBehaviour>().profile;
        defaultDistance = post.depthOfField.settings.focusDistance;
    }

    private void Update()
    {
        var target = FindTarget();
        var distance = Vector3.Distance(transform.position, target);
        var dof = post.depthOfField.settings;
        dof.focusDistance = Mathf.Lerp(dof.focusDistance, distance, Time.deltaTime * focusSpeed);
        post.depthOfField.settings = dof;
    }

    private Vector3 FindTarget()
    {
        // normally shoot ray from the center of the screen
        var ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
        if (mouseMode) {
            // will shoot the ray from where the mouse cursor lies, handy for testing
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        RaycastHit hit;
        var mask = ~(1 << 9);
        if (Physics.Raycast(ray, out hit, 100f, mask)) {
            return hit.point;
        }
        return transform.position;
    }

    private void OnDestroy() 
    {
        // return your focus value to what it was before the scene started
        var dof = post.depthOfField.settings;
        dof.focusDistance = defaultDistance;
        post.depthOfField.settings = dof;
    }
}
