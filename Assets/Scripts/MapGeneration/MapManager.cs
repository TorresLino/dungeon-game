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
	private int loadRange = 5; // radius of chunks from player
	[SerializeField]
	private uint seed = 0;

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

	private void UpdateLoadedChunks()
	{
		List<Chunk> newChunks = new List<Chunk>();

		for (int x = 0 - this.loadRange; x < this.loadRange; x++)
		{
			for (int y = 0 - this.loadRange; y < this.loadRange; y++)
			{
				Chunk chunk = 
					this.chunksInRange.Find(c => c.Location == new Vector2Int(x, y)) ??
					this.mapStore.GetChunkAt(new Vector2Int(x, y)) ??
					new Chunk(x, y, roomsPerChunk, chunkWidth, seed);

				newChunks.Add(chunk);
			}
		}

		//ChunkGenerator.GenerateChunks(newChunks, this.currentPlayerChunkCoordinate);

		this.mapStore.PushCompleteChunks(newChunks);

		this.chunksInRange = newChunks;
	}

	public List<Chunk> Chunks { get { return this.chunksInRange; } }

	public Vector2Int PlayerChunkCoorinate { get { return this.currentPlayerChunkCoordinate;  } }

	public int LoadDistance { get { return this.loadRange; } }
}
