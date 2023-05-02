public static class NoiseRNG
{
	const uint BIT_NOISE1 = 0x68e31da4;
	const uint BIT_NOISE2 = 0xb5297a4d;
	const uint BIT_NOISE3 = 0x1b56c4e9;

	const uint MULTIPLIER_2D = 198491317;
	const uint MULTIPLIER_3D = 312403463;

	public static uint Noise1d(int positionX, uint seed=0)
	{
		uint mangledBits = (uint)positionX;
		mangledBits *= BIT_NOISE1;
		mangledBits += seed;
		mangledBits ^= (mangledBits >> 8);
		mangledBits += BIT_NOISE2;
		mangledBits ^= (mangledBits << 8);
		mangledBits *= BIT_NOISE3;
		mangledBits ^= (mangledBits >> 8);
		return mangledBits;
	}

	public static uint Noise2d(uint positionX, uint positionY, uint seed=0)
	{
		return Noise1d((int)(positionX + (MULTIPLIER_2D * positionY)), seed);
	}

	public static uint Noise3d(uint positionX, uint positionY, uint positionZ, uint seed=0)
	{
		return Noise1d((int)(positionX + (MULTIPLIER_2D * positionY) + (MULTIPLIER_3D * positionZ)), seed);
	}

	public static uint GetUintInRange(uint maxValue, int positionX, uint seed)
	{
		return NoiseRNG.Noise1d(positionX, seed) % maxValue;
	}
}
