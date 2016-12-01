using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]
public class FloatMesh : MonoBehaviour {
	//public enum Eixo { up, forward, rigth }

	[HideInInspector] public Mesh original;
	//public Eixo eixo;

	private MeshFilter _meshFilter;
	public Mesh sharedMesh {
		get {
			if (_meshFilter == null)
				_meshFilter = GetComponent<MeshFilter>();
			return _meshFilter.sharedMesh;
		}
		set {
			if (_meshFilter == null)
				_meshFilter = GetComponent<MeshFilter>();
			_meshFilter.sharedMesh = value;
		}
	}

	[ContextMenu("Float Mesh")]
	void floatMesh () {
		if (original==null)
			original = sharedMesh;

		Mesh mesh = new Mesh();
		Vector3[] vertices = original.vertices;
		Vector3[] normais = original.normals;
		float z;
		for(int i=0; i<vertices.Length; i++) {
			z = -vertices[i].y;
			vertices[i].y = vertices[i].z;
			vertices[i].z = z;
			z = -normais[i].y;
			normais[i].y = normais[i].z;
			normais[i].z = z;
		}
		mesh.vertices = vertices;
		mesh.normals = normais;
		mesh.subMeshCount = original.subMeshCount;
		for (int i=0; i<original.subMeshCount; i++) {
			mesh.SetTriangles(original.GetTriangles(i), i);
		}
		mesh.uv = original.uv;
		this.sharedMesh = mesh;
	}
}
