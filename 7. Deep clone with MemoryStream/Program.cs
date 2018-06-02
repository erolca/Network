//--------------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved. 
// 
//  File: Utilities.cs
//
//--------------------------------------------------------------------------

using System;
using System.Drawing;
//using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ParallelMorph
{
    /// <summary>Helper utilities.</summary>
    public static class Utilities
    {
        /// <summary>Deep clones a serializable object.</summary>
        /// <typeparam name="T">Specifies the type of the object to be cloned.</typeparam>
        /// <param name="source">The source object to be cloned.</param>
        /// <returns>The generated deep clone.</returns>
        public static T DeepClone<T>(T source) where T : class
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, source);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }

    }

    class MyClass
    {
        public static void Main()
        {


        }
    }

}