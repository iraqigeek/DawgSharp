﻿using System.IO;
using NUnit.Framework;

namespace DawgSharp
{
    [TestFixture]
    public class MatrixDawgTests : DawgTests
    {
        protected override Dawg<TPayload> GetDawg <TPayload> (DawgBuilder<TPayload> dawgBuilder)
        {
            var dawg = dawgBuilder.BuildDawg ();

            var memoryStream = new MemoryStream ();

#pragma warning disable 612,618
            dawg.SaveAsMatrixDawg (memoryStream);
#pragma warning restore 612,618

            var buffer = memoryStream.GetBuffer ();

            var rehydrated = Dawg<TPayload>.Load (new MemoryStream (buffer));

            return rehydrated;
        }
    }
}
