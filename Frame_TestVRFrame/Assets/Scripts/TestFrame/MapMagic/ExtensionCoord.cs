using MapMagic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapMagic
{
    public static class ExtensionCoord
    {
        public static Coord ToCoord(this Vector3 pos, float cellSize, bool ceil = false) //to use in object grid
        {
            if (!ceil) return new Coord(
                Mathf.FloorToInt((pos.x) / cellSize),
                Mathf.FloorToInt((pos.z) / cellSize));
            else return new Coord(
                Mathf.CeilToInt((pos.x) / cellSize),
                Mathf.CeilToInt((pos.z) / cellSize));
        }

        public static Coord RoundToCoord(this Vector2 pos) //to use in spatial hash (when sphash and matrix sizes are equal)
        {
            int posX = (int)(pos.x + 0.5f); if (pos.x < 0) posX--; //snippet for RoundToInt
            int posZ = (int)(pos.y + 0.5f); if (pos.y < 0) posZ--;
            return new Coord(posX, posZ);
        }

        public static Coord FloorToCoord(this Vector3 pos, float cellSize) { return new Coord(Mathf.FloorToInt(pos.x / cellSize), Mathf.FloorToInt(pos.z / cellSize)); }
        public static Coord CeilToCoord(this Vector3 pos, float cellSize) { return new Coord(Mathf.CeilToInt(pos.x / cellSize), Mathf.CeilToInt(pos.z / cellSize)); }
        public static Coord RoundToCoord(this Vector3 pos, float cellSize) { return new Coord(Mathf.RoundToInt(pos.x / cellSize), Mathf.RoundToInt(pos.z / cellSize)); }
        public static CoordRect ToCoordRect(this Vector3 pos, float range, float cellSize) //this one works with Terrain Sculptor
        {
            Coord min = new Coord(Mathf.FloorToInt((pos.x - range) / cellSize), Mathf.FloorToInt((pos.z - range) / cellSize));
            Coord max = new Coord(Mathf.FloorToInt((pos.x + range) / cellSize), Mathf.FloorToInt((pos.z + range) / cellSize)) + 1;
            return new CoordRect(min, max - min);
        }

        public static CoordRect ToFixedSizeCoordRect(this Vector3 pos, float range, float cellSize)
        {
            Coord size = (Vector3.one * range * 2).CeilToCoord(cellSize) + 1;
            Coord offset = pos.RoundToCoord(cellSize) - size / 2;
            return new CoordRect(offset, size);
        }

        public static CoordRect GetHeightRect(this Terrain terrain)
        {
            float pixelSize = terrain.terrainData.size.x / terrain.terrainData.heightmapResolution;

            int posX = (int)(terrain.transform.localPosition.x / pixelSize + 0.5f); if (terrain.transform.localPosition.x < 0) posX--;
            int posZ = (int)(terrain.transform.localPosition.z / pixelSize + 0.5f); if (terrain.transform.localPosition.z < 0) posZ--;

            return new CoordRect(posX, posZ, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);
        }

        public static CoordRect GetSplatRect(this Terrain terrain)
        {
            float pixelSize = terrain.terrainData.size.x / terrain.terrainData.alphamapResolution;

            int posX = (int)(terrain.transform.localPosition.x / pixelSize + 0.5f); if (terrain.transform.localPosition.x < 0) posX--;
            int posZ = (int)(terrain.transform.localPosition.z / pixelSize + 0.5f); if (terrain.transform.localPosition.z < 0) posZ--;

            return new CoordRect(posX, posZ, terrain.terrainData.alphamapResolution, terrain.terrainData.alphamapResolution);
        }

        public static float[,] SafeGetHeights(this TerrainData data, int offsetX, int offsetZ, int sizeX, int sizeZ)
        {
            if (offsetX < 0) { sizeX += offsetX; offsetX = 0; }
            if (offsetZ < 0) { sizeZ += offsetZ; offsetZ = 0; } //Not Tested!
            int res = data.heightmapResolution;
            if (sizeX + offsetX > res) sizeX = res - offsetX; if (sizeZ + offsetZ > res) sizeZ = res - offsetZ;
            return data.GetHeights(offsetX, offsetZ, sizeX, sizeZ);
        }

        public static float[,,] SafeGetAlphamaps(this TerrainData data, int offsetX, int offsetZ, int sizeX, int sizeZ)
        {
            if (offsetX < 0) { sizeX += offsetX; offsetX = 0; }
            if (offsetZ < 0) { sizeZ += offsetZ; offsetZ = 0; } //Not Tested!
            int res = data.alphamapResolution;
            if (sizeX + offsetX > res) sizeX = res - offsetX; if (sizeZ + offsetZ > res) sizeZ = res - offsetZ;
            return data.GetAlphamaps(offsetX, offsetZ, sizeX, sizeZ);
        }

        public static Texture2D ColorTexture(int width, int height, Color color)
        {
            Texture2D result = new Texture2D(width, height);
            Color[] pixels = result.GetPixels(0, 0, width, height);
            for (int i = 0; i < pixels.Length; i++) pixels[i] = color;
            result.SetPixels(0, 0, width, height, pixels);
            result.Apply();
            return result;
        }

        public static bool Equal(Vector3 v1, Vector3 v2)
        {
            return Mathf.Approximately(v1.x, v2.x) &&
                    Mathf.Approximately(v1.y, v2.y) &&
                    Mathf.Approximately(v1.z, v2.z);
        }

        public static bool Equal(Ray r1, Ray r2)
        {
            return Equal(r1.origin, r2.origin) && Equal(r1.direction, r2.direction);
        }

        public static void RemoveChildren(this Transform tfm)
        {
            for (int i = tfm.childCount - 1; i >= 0; i--)
            {
                Transform child = tfm.GetChild(i);
                GameObject.DestroyImmediate(child.gameObject);
            }
        }

        public static Transform FindChildRecursive(this Transform tfm, string name)
        {
            int numChildren = tfm.childCount;

            for (int i = 0; i < numChildren; i++)
                if (tfm.GetChild(i).name == name) return tfm.GetChild(i);

            for (int i = 0; i < numChildren; i++)
            {
                Transform result = tfm.GetChild(i).FindChildRecursive(name);
                if (result != null) return result;
            }

            return null;
        }

        public static Vector3[] InverseTransformPoint(this Transform tfm, Vector3[] points)
        {
            for (int c = 0; c < points.Length; c++) points[c] = tfm.InverseTransformPoint(points[c]);
            return points;
        }

        public static Vector3 GetCenter(this Vector3[] poses)
        {
            if (poses.Length == 0) return new Vector3();
            if (poses.Length == 1) return poses[0];

            float x = 0; float y = 0; float z = 0;
            for (int i = 0; i < poses.Length; i++)
            {
                x += poses[i].x;
                y += poses[i].y;
                z += poses[i].z;
            }
            return new Vector3(x / poses.Length, y / poses.Length, z / poses.Length);
        }

        public static void ToggleDisplayWireframe(this Transform tfm, bool show)
        {
#if UNITY_EDITOR
#if !UNITY_5_5_OR_NEWER
				UnityEditor.EditorUtility.SetSelectedWireframeHidden(tfm.GetComponent<Renderer>(), !show);
				int childCount = tfm.childCount;
				for (int c=0; c<childCount; c++) tfm.GetChild(c).ToggleDisplayWireframe(show);
#else
            UnityEditor.EditorUtility.SetSelectedRenderState(tfm.GetComponent<Renderer>(), show ? UnityEditor.EditorSelectedRenderState.Highlight : UnityEditor.EditorSelectedRenderState.Hidden);
            int childCount = tfm.childCount;
            for (int c = 0; c < childCount; c++) tfm.GetChild(c).ToggleDisplayWireframe(show);
#endif
#endif
        }

        public static int ToInt(this Coord coord)
        {
            int absX = coord.x < 0 ? -coord.x : coord.x;
            int absZ = coord.z < 0 ? -coord.z : coord.z;

            return ((coord.z < 0 ? 1000000000 : 0) + absX * 30000 + absZ) * (coord.x < 0 ? -1 : 1);
        }

        public static Coord ToCoord(this int hash)
        {
            int absHash = hash < 0 ? -hash : hash;
            int sign = (absHash / 1000000000) * 1000000000;

            int absX = (absHash - sign) / 30000;
            int absZ = absHash - sign - absX * 30000;

            return new Coord(hash < 0 ? -absX : absX, sign == 0 ? absZ : -absZ);
        }
    }
}