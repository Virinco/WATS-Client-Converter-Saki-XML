using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Virinco.WATS.Interface;

namespace Saki
{
    [TestClass]
    public class ConverterTests : TDM
    {
        [TestMethod]
        public void SetupClient()
        {
            SetupAPI(null, "location", "purpose", true);
            RegisterClient("your WATS instance URL", "username", "password/token");
            InitializeAPI(true);
        }

        [TestMethod]
        public void TestXMLConverter()
        {
        
            InitializeAPI(true);
            SakiXMLConverter converter = new SakiXMLConverter();
            string fileName = "Data\\SAKI-testdata.xml";
            SetConversionSource(new FileInfo(fileName), converter.ConverterParameters, null);
            using (FileStream file = new FileStream(fileName, FileMode.Open))
            {
        
                Report uut = converter.ImportReport(this, file);
                Submit(uut);
            }
        }
    }
}
