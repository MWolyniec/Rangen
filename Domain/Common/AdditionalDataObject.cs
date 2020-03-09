namespace Rangen.Domain.Common
{
    public class AdditionalDataObject : Item
    {


        public int? Value1 { get; set; }
        public string Value1Name { get; set; }

        public int? Value2 { get; set; }
        public string Value2Name { get; set; }

        public int? Value3 { get; set; }
        public string Value3Name { get; set; }

        public int? Value4 { get; set; }
        public string Value4Name { get; set; }

        public int? Value5 { get; set; }
        public string Value5Name { get; set; }

        public float? Value6Float { get; set; }
        public string Value6Name { get; set; }

        public float? Value7Float { get; set; }
        public string Value7Name { get; set; }

        public float? Value8Float { get; set; }
        public string Value8Name { get; set; }

        public float? Value9Float { get; set; }
        public string Value9Name { get; set; }

        public float? Value10Float { get; set; }
        public string Value10Name { get; set; }

        public AdditionalDataObject(string name) : base(name)
        {
        }


    }
}
