using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
	// generation params
	[SerializeField]
	private static int chunkWidth = 255;
	[SerializeField]
	private static int roomsPerChunk = 3;
	[SerializeField]
	private int loadRange = 4; // radius of chunks from player

	// player transform reference
	[SerializeField]
	private Transform playerLocation;
	[SerializeField]
	private MapStore mapStore;


	private List<Chunk> chunksInRange;
	private Vector2Int currentPlayerChunkCoordinate;

	private void Start()
	{
		this.chunksInRange = new List<Chunk>();
		this.currentPlayerChunkCoordinate = this.WorldToChunkCoordinate(this.playerLocation.position);
	}

	private void Update()
	{
		if (CheckPlayerChunk())
		{
			this.UpdateLoadedChunks();
		}
	}

	// returns true if the player has changed chunk
	private bool CheckPlayerChunk()
	{
		Vector2Int playerChunkCoord = this.WorldToChunkCoordinate(playerLocation.position);
		if (playerChunkCoord != currentPlayerChunkCoordinate)
		{
			this.currentPlayerChunkCoordinate = playerChunkCoord;
			return true;
		}
		return false;
	}

	private Vector2Int WorldToChunkCoordinate(Vector3 coord)
	{
		return (new Vector2Int((int)coord.x, (int)coord.z)) / chunkWidth;
	}

	private bool IsCoordInRange(Vector2Int coord)
	{
		return (coord - this.currentPlayerChunkCoordinate).magnitude <= this.loadRange;
	}

	private void UpdateLoadedChunks()
	{
		foreach (Chunk chunk in this.chunksInRange)
		{
			if (!IsCoordInRange(chunk.Location))
			{
				// continue
				this.chunksInRange.Remove(chunk);
			}
		}
	}
}
