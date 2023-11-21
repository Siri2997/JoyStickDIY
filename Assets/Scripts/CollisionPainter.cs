using UnityEngine;

public class CollisionPainter : MonoBehaviour{
    public Color paintColor;
    
    public float radius = 0.2f;
    public float strength = 0.2f;
    public float hardness = 0.2f;

    private void OnCollisionStay(Collision other) {
        Paintable p = other.collider.GetComponent<Paintable>();
        if(p != null){
            Vector3 pos = other.contacts[0].point;
            PaintManager.instance.paint(p, pos, radius, hardness, strength, paintColor);
        }
    }
}
