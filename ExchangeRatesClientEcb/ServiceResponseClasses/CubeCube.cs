namespace ExchangeRatesClientEcb.ServiceResponseClasses
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.ecb.int/vocabulary/2002-08-01/eurofxref")]
    public partial class CubeCube
    {

        private CubeCubeCube[] rates;

        private System.DateTime date;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Cube")]
        public CubeCubeCube[] Cube
        {
            get
            {
                return this.rates;
            }
            set
            {
                this.rates = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime time
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }
    }
}
