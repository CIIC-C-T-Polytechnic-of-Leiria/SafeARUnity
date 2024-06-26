using System.IO;
using Unity.Sentis;
using UnityEngine;

/// <summary>
/// Contains utility methods for saving images to PNG files.
/// </summary>
public static class ImageWriter
{
    public static void WriteTextureToPNG(Texture2D texture, string path)
    {
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(path, bytes);
    }

    public static void WriteFloatMatrixToPNG(float[,] matrix, string path)
    {
        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);
        var texture = new Texture2D(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = matrix[x, y];
                Color color = new(value, value, value, 1.0f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        WriteTextureToPNG(texture, path);
    }

    public static void WriteTensorMatrixToPNG(float[,,] tensor, string path)
    {
        var width = tensor.GetLength(0);
        var height = tensor.GetLength(1);
        var texture = new Texture2D(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var r = tensor[x, y, 0];
                var g = tensor[x, y, 1];
                var b = tensor[x, y, 2];
                var color = new Color(r, g, b, 1.0f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        WriteTextureToPNG(texture, path);
    }

    public static void WriteBoolMatrixToPNG(bool[,] matrix, string path)
    {
        var width = matrix.GetLength(0);
        var height = matrix.GetLength(1);
        Texture2D texture = new(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = matrix[x, y] ? 1.0f : 0.0f;
                Color color = new(value, value, value, 1.0f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        WriteTextureToPNG(texture, path);
    }

    public static void WriteTensorIntToPNG(TensorInt tensor, string path)
    {
        var width = tensor.shape[1];
        var height = tensor.shape[2];
        var texture = new Texture2D(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = tensor[0, x, y];
                Color color = new(value, value, value, 1.0f);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        WriteTextureToPNG(texture, path);
    }

    public static void WriteTensorFloatToPNG(TensorFloat tensor, string path)
    {
        var width = tensor.shape[0];
        var height = tensor.shape[1];
        var texture = new Texture2D(width, height);
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                var value = tensor[0, x, y];
                var color = new Color(value, value, value, 1.0f);

                // Rotate the image minus 90 degrees (Texture2D axis) !!!
                texture.SetPixel(y, width - 1 - x, color);
            }
        }
        texture.Apply();
        WriteTextureToPNG(texture, path);
    }
}
