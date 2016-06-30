using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// 
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34283")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = true)]
	public partial class EditServerMetadataType
	{
		private string nameField;
		private string descriptionField;
		private bool drsEligibleField;
		private bool drsEligibleFieldSpecified;
		private string idField;
		/// 
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
		/// 
		[System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
		public string description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}
		/// 
		public bool drsEligible
		{
			get
			{
				return this.drsEligibleField;
			}
			set
			{
				this.drsEligibleField = value;
			}
		}
		/// 
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool drsEligibleSpecified
		{
			get
			{
				return this.drsEligibleFieldSpecified;
			}
			set
			{
				this.drsEligibleFieldSpecified = value;
			}
		}
		/// 
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string id
		{
			get
			{
				return this.idField;
			}
			set
			{
				this.idField = value;
			}
		}
	}
}
