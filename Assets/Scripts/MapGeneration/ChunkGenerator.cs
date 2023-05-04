using System.Collections.Generic;
using UnityEngine;

public static class ChunkGenerator
{
	public static void GenerateChunks(List<Chunk> chunks, Vector2Int playerChunkLocation)
	{
		List<Chunk> unfinishedChunks = chunks.FindAll(c => c.Status != ChunkGenerationStatus.Done);

		foreach (Chunk chunk in unfinishedChunks)
		{
			// generate depending on generation status and distance form player
		}
	}
}
