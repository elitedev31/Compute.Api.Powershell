using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Contracts.Vip
{/// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://oec.api.opsource.net/schemas/vip", IsNullable = false)]
    public partial class NewServerFarm
    {

        private string nameField;

        private string probeIdField;

        private ServerFarmPredictorType predictorField;

        private NewServerFarmRealServer[] realServerField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string probeId
        {
            get
            {
                return this.probeIdField;
            }
            set
            {
                this.probeIdField = value;
            }
        }

        /// <remarks/>
        public ServerFarmPredictorType predictor
        {
            get
            {
                return this.predictorField;
            }
            set
            {
                this.predictorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("realServer")]
        public NewServerFarmRealServer[] realServer
        {
            get
            {
                return this.realServerField;
            }
            set
            {
                this.realServerField = value;
            }
        }
    }
}
