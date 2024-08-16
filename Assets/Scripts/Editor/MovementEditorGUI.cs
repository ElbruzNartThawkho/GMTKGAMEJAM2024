using System.Reflection.Emit;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Movement))]
public class MovementEditorGUI : Editor
{
    Movement movement;
    GUILayoutOption third, half;
    GUIStyle style;
    [SerializeField] GUISkin movementSkin;
    int size;

    private void OnEnable()
    {
        movement = (Movement)target;
        style = new GUIStyle(movementSkin.GetStyle("label"));
        size = movementSkin.font.fontSize + 3;
    }
    public override void OnInspectorGUI()
    {
        GUI.skin = movementSkin;
        third = GUILayout.Width(EditorGUIUtility.currentViewWidth / 3 - 20);
        half = GUILayout.Width(EditorGUIUtility.currentViewWidth / 2 - 20);
        style.normal.textColor = Color.yellow;
        style.fontSize = size;
        GUILayout.BeginVertical(); 
        SpeedAndJump();
        DashAndSlide();
        SmoothAndGravity();
        Ground();
        GUILayout.EndVertical();
    }
    void SpeedAndJump()
    {
        GUILayout.Label("Speed and Jump", style);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Walk Speed", third);
        movement.walkSpeed = EditorGUILayout.FloatField(movement.walkSpeed, third);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.Label("Run Speed", third);
        movement.runSpeed = EditorGUILayout.FloatField(movement.runSpeed, third);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.Label("Jump Power", third);
        movement.jumpPower = EditorGUILayout.FloatField(movement.jumpPower, third);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
    void DashAndSlide()
    {
        GUILayout.Label("Dash and Slide", style);
        GUILayout.Label("Dash");
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Dash Speed", half);
        movement.dashSpeed = EditorGUILayout.FloatField(movement.dashSpeed, half);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.Label("Dash Time", half);
        movement.dashTime = EditorGUILayout.FloatField(movement.dashTime, half);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
        GUILayout.Label("Slide");
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Slide Speed", half);
        movement.slideSpeed = EditorGUILayout.FloatField(movement.slideSpeed, half);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.Label("Slide Time", half);
        movement.slideTime = EditorGUILayout.FloatField(movement.slideTime, half);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
    void SmoothAndGravity()
    {
        GUILayout.Label("Smooth and Gravity", style);
        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        GUILayout.Label("Smooth Factor",half);
        movement.smoothFactor = EditorGUILayout.FloatField(movement.smoothFactor, half);
        GUILayout.EndVertical();
        GUILayout.BeginVertical();
        GUILayout.Label("Gravity", half);
        movement.gravity = EditorGUILayout.FloatField(movement.gravity, half);
        GUILayout.EndVertical();
        GUILayout.EndHorizontal();
    }
    void Ground()
    {
        GUILayout.Label("Ground Check", style);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Ground LayerMask", half);
        movement.groundCheck = EditorGUILayout.LayerField(movement.groundCheck, half);
        GUILayout.EndHorizontal();
    }
}
