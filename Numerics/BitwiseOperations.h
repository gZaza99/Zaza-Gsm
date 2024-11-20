#pragma once
namespace ZazaGsm
{
	namespace Numerics
	{
		static __declspec(dllexport) class BitwiseOperations
		{
		public:
			static unsigned long RotateLeft(unsigned long target, BYTE offset);
			static unsigned long RotateRight(unsigned long target, BYTE offset);
			static unsigned long ShiftLeft(unsigned long target, BYTE offset);
			static unsigned long ShiftRight(unsigned long target, BYTE offset);
		};
	}
}
