using Unity.Netcode.Components;
using UnityEngine;
#if UNITY_EDITOR
using Unity.Netcode.Editor;
using UnityEditor;
/// <summary>
/// The custom editor for the <see cref="PlayerControllerNetworked"/> component.
/// </summary>
[CustomEditor(typeof(PlayerControllerNetworked), true)]
public class PlayerControllerNetworkedEditor : NetworkTransformEditor
{
    private SerializedProperty m_Speed;
    private SerializedProperty m_Camera;

    public override void OnEnable()
    {
        m_Speed = serializedObject.FindProperty(nameof(PlayerControllerNetworked.Speed));
        m_Camera = serializedObject.FindProperty(nameof(PlayerControllerNetworked.FPSCamera));
        base.OnEnable();
    }

    private void DisplayPlayerControllerNetworkedProperties()
    {
        EditorGUILayout.PropertyField(m_Speed);
        EditorGUILayout.PropertyField(m_Camera);
    }

    public override void OnInspectorGUI()
    {
        var playerControllerNetworked = target as PlayerControllerNetworked;
        void SetExpanded(bool expanded) { playerControllerNetworked.PlayerControllerNetworkedPropertiesVisible = expanded; };
        DrawFoldOutGroup<PlayerControllerNetworked>(playerControllerNetworked.GetType(), DisplayPlayerControllerNetworkedProperties, playerControllerNetworked.PlayerControllerNetworkedPropertiesVisible, SetExpanded);
        base.OnInspectorGUI();
    }
}
#endif


public class PlayerControllerNetworked : NetworkTransform
{
#if UNITY_EDITOR
    // These bool properties ensure that any expanded or collapsed property views
    // within the inspector view will be saved and restored the next time the
    // asset/prefab is viewed.
    public bool PlayerControllerNetworkedPropertiesVisible;
#endif
    public float Speed = 10;
    private Vector3 m_Motion;

    //[SerializeField]
    public GameObject FPSCamera;

    public GameObject GetFPSCamera() {  return FPSCamera; }

    private void Update()
    {
        if (!IsSpawned || !HasAuthority)
        {
            return;
        }

        // Handle acquiring and applying player input
        m_Motion = Vector3.zero;

        m_Motion += Vector3.forward * Input.GetAxis("Vertical");
        m_Motion += Vector3.right * Input.GetAxis("Horizontal");


        // If there is any player input magnitude, then apply that amount of
        // motion to the transform
        if (m_Motion.magnitude > 0)
        {
            transform.position += m_Motion * Speed * Time.deltaTime;
        }
    }
}