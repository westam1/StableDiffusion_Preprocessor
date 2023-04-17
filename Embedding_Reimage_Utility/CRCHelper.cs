using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Embedding_Reimage_Utility {
	internal static class CRCHelper {
		// Code shamelessly copied from https://stackoverflow.com/questions/24082305/how-is-png-crc-calculated-exactly
		static uint[]? crcTable;

		// Call this function with the compressed image bytes, 
		// passing in idatCrc as the last parameter
		public static uint Crc32(byte[] stream, int offset, int length, uint crc)
		{
			uint c;
			if(crcTable==null){
				crcTable=new uint[256];
				for(uint n=0;n<=255;n++){
					c = n;
					for(var k=0;k<=7;k++){
						if((c & 1) == 1)
							c = 0xEDB88320^((c>>1)&0x7FFFFFFF);
						else
							c = ((c>>1)&0x7FFFFFFF);
					}
					crcTable[n] = c;
				}
			}
			c = crc^0xffffffff;
			var endOffset=offset+length;
			for(var i=offset;i<endOffset;i++){
				c = crcTable[(c^stream[i]) & 255]^((c>>8)&0xFFFFFF);
			}
			return c^0xffffffff;
		}
	}
}
