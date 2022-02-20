using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  class HillCipher : ICipher
  {
    public const int LENGHTOFALPHABET = 37;
    private static int[,] GetMatrixFromKey(string key)
    {
      int size = key.Length;
      double result = Math.Sqrt(size);
      bool isSquare = result % 1 == 0;
      if (!isSquare)
      {
        while (!isSquare)
        {
          size++;
          result = Math.Sqrt(size);
          isSquare = result % 1 == 0;
        }
      }
      int n = (int)Math.Sqrt(size);
      int[,] matrixOfKey = new int[n, n];
      int count = 0;
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          if (i * n + j < key.Length)
          {
            int asciCode = (int)key[count];
            if (asciCode >= 'А' && asciCode <= 'Д')
            {
              matrixOfKey[i, j] = asciCode - 'А';
            }
            if (asciCode == 'Ё')
            {
              matrixOfKey[i, j] = 6;
            }
            if (asciCode > 'Д' && asciCode <= 'Я')
            {
              matrixOfKey[i, j] = asciCode - 'А' + 1;
            }
            if (asciCode == '.')
            {
              matrixOfKey[i, j] = 33;
            }
            if (asciCode == ',')
            {
              matrixOfKey[i, j] = 34;
            }
            if (asciCode == ' ')
            {
              matrixOfKey[i, j] = 35;
            }
            if (asciCode == '?')
            {
              matrixOfKey[i, j] = 36;
            }
            count++;
          }
          else
          {
            matrixOfKey[i, j] = 35;
          }
        }
      }
      return matrixOfKey;
    }
    private static int[,] GetVectorFromMessage(string message, int size)
    {
      int lenghtOfMessage = message.Length;
      if (lenghtOfMessage % size != 0)
      {
        lenghtOfMessage += (size - (lenghtOfMessage % size));
      }
      int[,] vectorOfMessage = new int[lenghtOfMessage / size, size];
      for (int j = 0; j < lenghtOfMessage / size; j++)
      {
        for (int i = 0; i < size; i++)
        {
          if (j * size + i < message.Length)
          {
            int asciCode = (int)message[j * size + i];
            if (asciCode >= 'А' && asciCode <= 'Д')
            {
              vectorOfMessage[j, i] = asciCode - 'А';
            }
            if (asciCode == 'Ё')
            {
              vectorOfMessage[j, i] = 6;
            }
            if (asciCode > 'Д' && asciCode <= 'Я')
            {
              vectorOfMessage[j, i] = asciCode - 'А' + 1;
            }
            if (asciCode == '.')
            {
              vectorOfMessage[j, i] = 33;
            }
            if (asciCode == ',')
            {
              vectorOfMessage[j, i] = 34;
            }
            if (asciCode == ' ')
            {
              vectorOfMessage[j, i] = 35;
            }
            if (asciCode == '?')
            {
              vectorOfMessage[j, i] = 36;
            }
          }
          else
          {
            vectorOfMessage[j, i] = 35;
          }
        }
      }
      return vectorOfMessage;
    }
    private static int GetCount(int sizeOfMessage, int sizeOfOneDemention)
    {
      int lenghtOfMessage = sizeOfMessage;
      if (lenghtOfMessage % sizeOfOneDemention != 0)
      {
        lenghtOfMessage += (sizeOfOneDemention - (lenghtOfMessage % sizeOfOneDemention));
      }
      lenghtOfMessage = lenghtOfMessage / sizeOfOneDemention;
      return lenghtOfMessage;
    }
    private static int[,] GetNextPartOfMessage(int[,] matrix, int iteration)
    {
      int[,] result = new int[1, matrix.GetLength(1)];
      for (int i = 0; i < matrix.GetLength(1); i++)
      {
        result[0, i] = matrix[iteration, i];
      }
      return result;
    }
    private static int[,] Mod(int[,] array)
    {
      int[,] result = new int[array.GetLength(0), array.GetLength(1)];
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          result[i, j] = array[i, j] % LENGHTOFALPHABET;
        }
      }
      return result;
    }
    private static int[,] SumWithLenghtOfAlphabet(int[,] matrix)
    {
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          if (matrix[i, j] < 0)
          {
            matrix[i, j] = LENGHTOFALPHABET + matrix[i, j];
          }
        }
      }
      return matrix;
    }
    private static string GetSymbols(int[,] array)
    {
      string result = "";
      for (int i = 0; i < array.GetLength(1); i++)
      {
        if (array[0, i] >= 0 && array[0, i] < 6)
        {
          result += (char)(array[0, i] + 'А');
        }
        if (array[0, i] == 6)
        {
          result += 'Ё';
        }
        if (array[0, i] > 6 && array[0, i] <= 32)
        {
          result += (char)(array[0, i] - 1 + 'А');
        }
        if (array[0, i] == 33)
        {
          result += '.';
        }
        if (array[0, i] == 34)
        {
          result += ',';
        }
        if (array[0, i] == 35)
        {
          result += ' ';
        }
        if (array[0, i] == 36)
        {
          result += '?';
        }
      }
      return result;
    }
    private static int GCD(int a, int b)
    {
      while (b != 0)
      {
        var temp = b;
        b = a % b;
        a = temp;
      }
      return a;
    }
    private static (int x, int y, int a) gcd(int a, int b)
    {
      if (b == 0)
      {
        return (1, 0, a);
      }
      var (y, x, g) = gcd(b, a % b);
      return (x, y - ((int)(a / b) * x), g);
    }
    private static int GetAntiDeterminant(int det, int x)
    {
      int toReturn = 0;
      if (det < 0 && x >= 0)
      {
        toReturn = x;
      }
      if (det >= 0 && x < 0)
      {
        toReturn = LENGHTOFALPHABET + x;
      }
      if (det >= 0 && x >= 0)
      {
        toReturn = x;
      }
      if (det < 0 && x < 0)
      {
        toReturn = -x;
      }
      return toReturn;
    }
    public string Encode(string message, string key)
    {
      string encriptedString = "";
      var intKey = GetMatrixFromKey(key);
      int det = WorkWithMatrix.GetDeterminant(intKey);
      if (WorkWithMatrix.GetDeterminant(intKey) == 0) throw new DivideByZeroException();
      if (GCD(WorkWithMatrix.GetDeterminant(intKey), LENGHTOFALPHABET) != 1) throw new DivideByZeroException();
      var (x, y, z) = gcd(det, LENGHTOFALPHABET);
      x = GetAntiDeterminant(det, x);
      if (x == 0) throw new DivideByZeroException();
      var allIntMessage = GetVectorFromMessage(message, intKey.GetLength(0));
      for (int i = 0; i < GetCount(message.Length, intKey.GetLength(0)); i++)
      {
        var intMessage = GetNextPartOfMessage(allIntMessage, i);
        var result = WorkWithMatrix.Multiplication(intMessage, intKey);
        result = Mod(result);
        encriptedString += GetSymbols(result);
      }
      return encriptedString;
    }
    public string Decode(string message, string key)
    {
      string decryptedString = "";
      var intKey = GetMatrixFromKey(key);
      if (WorkWithMatrix.GetDeterminant(intKey) == 0) throw new DivideByZeroException();
      if (GCD(WorkWithMatrix.GetDeterminant(intKey), LENGHTOFALPHABET) == WorkWithMatrix.GetDeterminant(intKey)) throw new DivideByZeroException();
      var allIntMessage = GetVectorFromMessage(message, intKey.GetLength(0));
      for (int i = 0; i < GetCount(message.Length, intKey.GetLength(0)); i++)
      {
        var intMessage = GetNextPartOfMessage(allIntMessage, i);
        int det = WorkWithMatrix.GetDeterminant(intKey);
        var (x, y, z) = gcd(det, LENGHTOFALPHABET);
        x = GetAntiDeterminant(det, x);
        var decription = WorkWithMatrix.GetMatrixOfAlgebraicComplement(intKey);
        decription = Mod(decription);
        decription = WorkWithMatrix.MultiplyOnNumber(decription, x);
        decription = Mod(decription);
        decription = WorkWithMatrix.GetTransparentMatrix(decription);
        decription = SumWithLenghtOfAlphabet(decription);
        decription = WorkWithMatrix.Multiplication(intMessage, decription);
        decription = Mod(decription);
        decryptedString += GetSymbols(decription);
      }
      return decryptedString;
    }
  }
}
