#include "pch.h"
#include "BitwiseOperations.h"
#include <bitset>

namespace ZazaGsm
{
	namespace Numerics
	{
		unsigned long BitwiseOperations::RotateLeft(unsigned long target, BYTE offset)
		{
			return _lrotl(target, offset);
		}
		unsigned long BitwiseOperations::RotateRight(unsigned long target, BYTE offset)
		{
			return _lrotr(target, offset);
		}
		unsigned long BitwiseOperations::ShiftLeft(unsigned long target, BYTE offset)
		{
			return target << offset;
		}
		unsigned long BitwiseOperations::ShiftRight(unsigned long target, BYTE offset)
		{
			return target >> offset;
		}
	}
}