namespace ExchangeRatesClientEcb.ServiceResponseClasses
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref", IsNullable = false)]
    public partial class Cube
    {

        private CubeCube cube1Field;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cube")]
        public CubeCube Cube1
        {
            get
            {
                return this.cube1Field;
            }
            set
            {
                this.cube1Field = value;
            }
        }
    }
}
