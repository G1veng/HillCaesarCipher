using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  class WorkWithMatrix
  {
    public static int[,] GetTransparentMatrix(int[,] matrix)
    {
      int count = 0;
      for (int i = 1; i < matrix.GetLength(0); i++)
      {
        count++;
        for (int j = 0; j < count; j++)
        {
          int temp = matrix[i, j];
          matrix[i, j] = matrix[j, i];
          matrix[j, i] = temp;
        }
      }
      return matrix;
    }
    public static int[,] GetMatrixOfAlgebraicComplement(int[,] matrix)
    {
      int[,] result = new int[matrix.GetLength(0), matrix.GetLength(0)];
      int sign = 1;
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
          sign = ((i + 1) % 2 == (j + 1) % 2) ? 1 : -1;
          int det = GetDeterminant(GetMinorMatrix(matrix, i, j));
          result[i, j] = sign * det;
        }
      }
      return result;
    }
    public static int GetDeterminant(int[,] matrix)
    {
      if (matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0)
        return 1;
      if (matrix.GetLength(0) != matrix.GetLength(1))
        throw new Exception("Матрица должна быть квадратной!");
      if (matrix.GetLength(0) == 2)
        return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
      int sign = 1;
      int result = 0;
      int j = 0;
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        sign = ((i + 1) % 2 == (j + 1) % 2) ? 1 : -1;
        result += sign * matrix[i, j] * GetDeterminant(GetMinorMatrix(matrix, i, j));
      }
      return result;
    }
    static public int[,] GetMinorMatrix(int[,] matrix, int row, int col)
    {
      int[,] result = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
      int m = 0, k;
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        if (i == row) continue;
        k = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          if (j == col) continue;
          result[m, k++] = matrix[i, j];
        }
        m++;
      }
      return result;
    }
    static public int[,] Multiplication(int[,] a, int[,] b)
    {
      if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
      int[,] r = new int[a.GetLength(0), b.GetLength(1)];
      for (int i = 0; i < a.GetLength(0); i++)
      {
        for (int j = 0; j < b.GetLength(1); j++)
        {
          for (int k = 0; k < b.GetLength(0); k++)
          {
            r[i, j] += a[i, k] * b[k, j];
          }
        }
      }
      return r;
    }
    public static int[,] MultiplyOnNumber(int[,] array, double number)
    {
      int[,] result = new int[array.GetLength(0), array.GetLength(1)];
      for (int i = 0; i < array.GetLength(0); i++)
      {
        for (int j = 0; j < array.GetLength(1); j++)
        {
          result[i, j] = (int)(array[i, j] * number);
        }
      }
      return result;
    }
  }
}
