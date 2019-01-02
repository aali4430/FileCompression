//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.IO;
using System.IO.Compression;
using System.ServiceModel.Channels;
using System.Text;

namespace Microsoft.Samples.Mtom
{
    //The service contract is defined in generatedClient.cs, generated from the service by the svcutil tool.

    //Client implementation code.
    class Client
    {
        
        static void Main()
        {
            string pickup = @"C:\NewFile\PickUp\";
            
            string queue = @"C:\NewFile\FileQueue\";
            string delive = @"C:\NewFile\Deliver\";
            string[] files = Directory.GetFiles(pickup, "*.*", SearchOption.AllDirectories);
            foreach (var fil in files) {
                string extention = Path.GetFileName(fil);
                string outp = client.Compression.Compress(fil, queue, extention);
                client.Compression.Decompress(outp, delive, extention);
            }
           
        }
        


    }
}
