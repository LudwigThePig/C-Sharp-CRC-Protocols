# C# Implementations of CRC Protocols

This repo contains a couple of CRC implementations in C#. I could not find any good resources online for C# CRCs. So, I ported over a couple of common C++ implementations.

## Included CRC Protocols

- CRC16-CCITT
- CRC-Autosar (8 bit)

## Usage

```cs
using CRC;

// __Autosar__

// Calculating a value
byte[] myArr = Encoding.ASCII.GetBytes("123456789");
byte[] crc = CrcAutosar.Check(myArr);

// Attach the CRC 
byte[] input = new byte[myArr.Length + crc.Length];
Buffer.BlockCopy(myArr, 0, input, 0, myARr.Length);
Buffer.BlockCopy(crc, 0, input, myArr.Length, crc.Length);

// Check if CRC is valid
bool isValid = CrcAutosar.Check(input);



// __CCITT__

// Calculate a value
byte[] myArr = Encoding.ASCII.GetBytes("123456789");
byte[] crc = CrcCcitt.Calculate(myArr);

// Attach the CRC 
byte[] input = new byte[myArr.Length + crc.Length];
Buffer.BlockCopy(myArr, 0, input, 0, myArr.Length);
Buffer.BlockCopy(crc, 0, input, myArr.Length, crc.Length);

// Check if CRC is valid
bool isValid = CrcCcitt.Check(input);
```

