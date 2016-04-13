using System;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Runtime.Versioning;

namespace NuGet
{
    internal class ZipPackageFile : PackageFileBase
    {
        private PackagePart _part;

        public ZipPackageFile(PackagePart part) 
            : base(UriUtility.GetPath(part.Uri))
        {
            Debug.Assert(part != null, "part should not be null");

            _part = part;
        }

        public override Stream GetStream()
        {
            var stream2 = new MemoryStream();
            using (Stream partStream = _part.GetStream())
            {
                partStream.CopyTo(stream2);
                partStream.Flush();
            }

            return stream2;
        }

        public override string ToString()
        {
            return Path;
        }
    }
}